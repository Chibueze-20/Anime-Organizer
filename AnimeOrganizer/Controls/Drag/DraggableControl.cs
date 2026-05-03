using AnimeOrganizer.Controls.Drag;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

/// <summary>
/// Provides drag functionality for a Windows Forms control with optional ghost visual feedback.
/// Supports dragging controls across different parent containers of type <typeparamref name="TContainer"/> with screen-based coordinate tracking.
/// When ghost mode is enabled, displays a dashed outline preview of the control's destination before releasing.
/// </summary>
/// <typeparam name="TContainer">The type of control that serves as valid drop target containers. Must inherit from Control.</typeparam>
public class DraggableControl<TContainer> where TContainer : Control
{
    private readonly Control _target;
    private readonly bool _useGhost;

    private DragGhostRenderer _adorner;

    private bool _dragging;
    private Point _startMouseScreen;
    private Form _form;
    private Rectangle _startBoundsScreen;
    private Rectangle _currentGhostBoundsScreen;
    private Control _originalParent;
    private Rectangle _originalLocalBounds;
    private List<Control> _dropTargets = new List<Control>();

    /// <summary>
    /// Gets or sets a value indicating whether the control's movement should be restricted to its parent's bounds.
    /// </summary>
    public bool RestrictToParentBounds { get; set; } = false;

    public Action<TContainer, bool> HighlightStrategy { get; set; }

    /// <summary>
    /// Initializes a new instance of the DraggableControl&lt;TContainer&gt; class.
    /// </summary>
    /// <param name="target">The control to make draggable. Cannot be null.</param>
    /// <param name="useGhost">If true, displays a ghost outline during dragging. If false, the control moves directly. Defaults to false.</param>
    /// <exception cref="ArgumentNullException">Thrown when target is null.</exception>
    public DraggableControl(Control target, bool useGhost = false)
    {
        _target = target ?? throw new ArgumentNullException(nameof(target));
        _useGhost = useGhost;
        _form = target.FindForm();

        if (_useGhost)
        {
            _adorner = new DragGhostRenderer(_form);
            Application.AddMessageFilter(_adorner);
        }

        // Subscribe to mouse events on the target control
        _target.MouseDown += OnMouseDown;
        _target.MouseMove += OnMouseMove;
        _target.MouseUp += OnMouseUp;
    }

    /// <summary>
    /// Handles the MouseDown event to initiate dragging.
    /// Captures the initial mouse position and control bounds in screen coordinates.
    /// If ghost mode is enabled, displays the adorner at the starting position.
    /// </summary>
    private void OnMouseDown(object sender, MouseEventArgs e)
    {
        _dragging = true;
        _originalParent = _target.Parent;
        _originalLocalBounds = _target.Bounds;
        // Track everything in SCREEN coordinates to support cross-container dragging
        _startMouseScreen = Control.MousePosition;
        _startBoundsScreen = new Rectangle(
            _target.PointToScreen(Point.Empty),
            _target.Size
        );

        _currentGhostBoundsScreen = _startBoundsScreen;

        // Display ghost adorner if enabled
        if (_useGhost)
        {
            //_adorner.Bounds = _form.ClientRectangle;
            _adorner.GhostBounds = _form.RectangleToClient(_startBoundsScreen);
            _adorner.Visible = true;
            //_adorner.BringToFront();
            _form.Invalidate();
        }
        applyHighlighting(true);
    }

    /// <summary>
    /// Handles the MouseMove event to update the control's position or ghost bounds during dragging.
    /// Tracks movement using screen coordinates and converts to parent-relative coordinates for display/movement.
    /// In ghost mode, updates only the adorner outline. In direct mode, moves the control immediately.
    /// </summary>
    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        if (!_dragging)
            return;

        var currentMouseScreen = Control.MousePosition;

        // Calculate displacement in screen coordinates
        int dx = currentMouseScreen.X - _startMouseScreen.X;
        int dy = currentMouseScreen.Y - _startMouseScreen.Y;

        var newBoundsScreen = new Rectangle(
            _startBoundsScreen.Left + dx,
            _startBoundsScreen.Top + dy,
            _startBoundsScreen.Width,
            _startBoundsScreen.Height
        );

        _currentGhostBoundsScreen = newBoundsScreen;

        if (_useGhost)
        {
            // Ghost mode: convert screen coordinates to parent coordinates and update adorner
            //var parent = _target.Parent;
            //_adorner.updateParent(parent);
            _adorner.GhostBounds = _form.RectangleToClient(newBoundsScreen);
            _form.Invalidate();
        }
        else
        {
            // Direct mode: move the control immediately by converting screen to parent coordinates
            var parent = _target.Parent;
            var local = parent.RectangleToClient(newBoundsScreen);
            _target.Bounds = local;
        }
    }

    /// <summary>
    /// Handles the MouseUp event to stop dragging and finalize the control's position.
    /// Determines the drop target container of type <typeparamref name="TContainer"/> and reparents the control if appropriate.
    /// In ghost mode, hides the adorner before moving the control to its final position.
    /// </summary>
    private void OnMouseUp(object sender, MouseEventArgs e)
    {
        if (!_dragging)
            return;

        _dragging = false;

        if (_useGhost)
        {
            _adorner.Visible = false;
            _form.Invalidate();
        }


        applyHighlighting(false);

        // Determine which TContainer control the mouse is over for potential reparenting
        Control dropTarget = FindDropContainer();

        if (dropTarget != null)
        {
            // Convert screen coordinates to drop container coordinates and reparent
            var local = dropTarget.RectangleToClient(_currentGhostBoundsScreen);
            
            local = ClampToContainer(dropTarget, local);

            _target.Parent = dropTarget;
            //_adorner.updateParent(dropTarget.FindForm());
            _target.Bounds = local;
        }
        else
        {
            // Default: drop back into original parent if no valid drop container found
            var parent = _originalParent;
            _target.Bounds = _originalLocalBounds;
        }
    }

    /// <summary>
    /// Finds the drop target container of type <typeparamref name="TContainer"/> at the current mouse position.
    /// Searches for visible TContainer controls on the form that contain the mouse cursor.
    /// </summary>
    /// <returns>A <typeparamref name="TContainer"/> control at the current mouse position, or null if no suitable container is found.</returns>
    private Control FindDropContainer()
    {
        var screenPos = Control.MousePosition;
        var root = _target.FindForm();

        // Search through all top-level controls for a visible TContainer at the mouse position
        foreach (Control c in root.Controls)
        {
            if (c is TContainer && c.Visible)
            {
                var rect = c.RectangleToScreen(c.ClientRectangle);
                if (rect.Contains(screenPos))
                    return c;
            }
        }

        return null;
    }

    private void applyHighlighting(bool highlight)
    {
        if (HighlightStrategy != null)
        {
            foreach (Control c in _form.Controls)
            {
                if (c is TContainer container)
                {
                    HighlightStrategy(container, highlight);
                }
            }
        }
    }

    private Rectangle ClampToContainer(Control container, Rectangle bounds)
    {
        var maxY = container.Height - bounds.Height;

        if (bounds.Y < 66)
            bounds.Y = 66;

        if (bounds.Y > (maxY - 66))
            bounds.Y = maxY - 66;

        bounds.X = 20; // fixed X offset

        return bounds;
    }

}