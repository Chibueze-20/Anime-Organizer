using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AnimeOrganizer.Controls.Drag
{
    /// <summary>
    /// A visual adorner control that displays a ghost outline during drag operations.
    /// Provides visual feedback to the user by drawing a dashed rectangle representing the dragged control's bounds.
    /// </summary>
    public class GhostDragAdorner : Control
    {
        /// <summary>
        /// Gets or sets the bounds of the ghost rectangle to be drawn during dragging.
        /// </summary>
        public Rectangle GhostBounds { get; set; }


        /// <summary>
        /// Initializes a new instance of the GhostDragAdorner class.
        /// </summary>
        /// <param name="parent">The parent control that will contain this adorner.</param>
        public GhostDragAdorner(Form form)
        {
            Parent = form;
            BackColor = form.BackColor;
            Visible = false;

            // Configure control styles for custom painting and performance optimization
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint, true);

            Enabled = false;
        }

        /// <summary>
        /// Paints the ghost outline (dashed rectangle) on the control surface.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Create a dashed pen for drawing the ghost outline
            var pen = new Pen(Color.Red, 1)
            {
                DashStyle = DashStyle.Dash
            };

            // Draw the ghost rectangle at the specified bounds
            e.Graphics.DrawRectangle(pen, GhostBounds);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Skip background painting → appears transparent
        }


        public void updateParent(Control newParent)
        {
            Parent = newParent;
        }
        
    }


    public class DragGhostRenderer : IMessageFilter
    {
        public Rectangle GhostBounds { get; set; }
        public bool Visible { get; set; }
        private readonly Form _form;

        public DragGhostRenderer(Form form)
        {
            _form = form;
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (!Visible)
                return false;

            if (m.Msg == 0x0F) // WM_PAINT
            {
                 var g = _form.CreateGraphics();
                var pen = new Pen(Color.Black) { DashStyle = DashStyle.Dash, Width = 2f };
                g.DrawRectangle(pen, GhostBounds);
            }

            return false;
        }
    }
}
