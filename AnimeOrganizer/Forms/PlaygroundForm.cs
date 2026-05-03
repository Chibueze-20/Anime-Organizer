using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeOrganizer.Forms
{
    public partial class PlaygroundForm : Form
    {
        private DraggableControl<Panel> dragControl;
        public PlaygroundForm()
        {
            //item 263W 66H
            //location 20,66
            InitializeComponent();
            SpawnDraggable();

        }

        private void SpawnDraggable()
        {
            var homePanel = panel1;
            var item = new Button() { 
                Height = 66,
                Width = 263,
                Text = "Drag Me",
                Parent = homePanel,
                Location = new Point(20, 66)
            };
            dragControl = new DraggableControl<Panel>(item, useGhost: true)
            {
                HighlightStrategy = highlightPanel,
            };
        }

        private void highlightPanel(Panel panel, bool highlight)
        {
            if (!highlight)
            {
                panel.BackColor = SystemColors.Control;
                panel.BorderStyle = BorderStyle.None;
                return;
            }

            var mouse = Control.MousePosition;
            var rect = panel.RectangleToScreen(panel.ClientRectangle);

            panel.BackColor = rect.Contains(mouse)
                ? Color.LightGreen   // active drop target
                : Color.LightYellow; // potential drop target

            // Additional visual effects can be added here
            
            // add dashed borders
            panel.BorderStyle = BorderStyle.FixedSingle;


        }
    }
}
