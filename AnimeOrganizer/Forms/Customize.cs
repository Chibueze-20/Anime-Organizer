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
    public partial class Customize : Form
    {
        private bool zeddUpdated = false;
        private bool episodeSepUpdated = false;
        private bool setUpMode = true;
        public Customize()
        {
            InitializeComponent();
            episodeSepcbx.DataSource = UtillExtensions.GetCbxDataSourceFromEnum<Seperator>();
            episodeSepcbx.SelectedIndex = -1;
            episodeSepcbx.DisplayMember = "Key";
            episodeSepcbx.ValueMember = "Value";
            episodeSepcbx.DropDownStyle = ComboBoxStyle.DropDownList;
            refreshEpisodeSeparator();
            label3.Text = Properties.Settings.Default.episodeSep.ToString();
            refreshZeddPath();
            setUpMode = false;
        }
        
        public bool ZeddUpdated
        {
            get
            {
                return zeddUpdated;
            }
        }

        public bool EpisodeSepUpdated
        {
            get
            {
                return episodeSepUpdated;
            }
        }

        private void refreshEpisodeSeparator()
        {
            Console.WriteLine("Current selector: " + Properties.Settings.Default.episodeSep);
            try
            {
                int current = int.Parse(Properties.Settings.Default.episodeSep);
                episodeSepcbx.SelectedIndex = current;
            }
            catch (Exception)
            {

                episodeSepcbx.SelectedIndex = -1;
            }
            
        }
        private void refreshZeddPath()
        {
            string current = Properties.Settings.Default.zeddPath;
            zeddPathlbl.Text = current;
        }
        private void updateEpisodeSeparator(int code)
        {
            Properties.Settings.Default["episodeSep"] = code.ToString();
            Properties.Settings.Default.Save();
            episodeSepUpdated = true;
        }
        private void updateZeddPath(string path)
        {
            Properties.Settings.Default["zeddPath"] = path;
            Properties.Settings.Default.Save();
            zeddUpdated = true;
        }

        private void updateZeddllbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string newPath = folderBrowserDialog.SelectedPath;
                updateZeddPath(newPath);
                refreshZeddPath();
                MessageBox.Show("Zedd path updated successfully.");
            }
        }

        private void episodeSepcbx_SelectedValueChanged(object sender, EventArgs e)
        {
            if (episodeSepcbx.SelectedIndex>=0 && !setUpMode)
            {
                KeyValuePair<string, object> selected = (KeyValuePair<string, object>)episodeSepcbx.SelectedItem;
                updateEpisodeSeparator((int)selected.Value);
                Console.WriteLine(Properties.Settings.Default.PropertyValues["episodeSep"].PropertyValue);
            }
           
        }
    }
}
