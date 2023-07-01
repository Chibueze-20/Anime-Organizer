using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeOrganizer
{
    public partial class menu : UserControl
    {
        private Action<bool,bool> onConstomize; //fun(zeddUpdated, EpisodeSepUpdated) => act
        public menu()
        {
            InitializeComponent();
        }

        public Action<bool, bool> OnCustomize
        {
            set
            {
                onConstomize = value;
            }
        }
        private void CustomizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(Customize customizeForm =  new Customize())
            {
                customizeForm.ShowDialog();
                if (onConstomize != null)
                {
                    onConstomize.Invoke(customizeForm.ZeddUpdated, customizeForm.EpisodeSepUpdated);
                }
               
            }
        }

        public void AddOpenMenuOption(string name, EventHandler eventHandler)
        {
            ToolStripButton toolStrip = new ToolStripButton();
            toolStrip.Text = name;
            toolStrip.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStrip.Click += eventHandler;
            toolStrip.Name = name;
            openToolStripMenuItem.DropDownItems.Add(toolStrip);
        }
        public void AddMenuOption(string name, EventHandler eventHandler)
        {
            ToolStripButton toolStrip = new ToolStripButton();
            toolStrip.Text = name;
            toolStrip.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStrip.Click += eventHandler;
            toolStrip.Name = name;
            menuStrip.Items.Add(toolStrip);
        }

        private void newSeasonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NewSeason newSeasonForm =  new NewSeason())
            {
                newSeasonForm.ShowDialog();
            }
        }
    }
}
