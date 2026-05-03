using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnimeOrganizerCommon;

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
            refreshZeddPath();
            setUpMode = false;
            redundant_str_update_btn.Enabled = false;
            //folder components tagging for event handling
            global_folders_btn.Tag = global_folders_cbx;
            excluded_folders_btn.Tag = excluded_folders_cbx;
            global_folders_cbx.Tag = global_folders_btn;
            excluded_folders_cbx.Tag = excluded_folders_btn;
            global_folders_btn.Enabled = false;
            excluded_folders_btn.Enabled = false;
            // populate redundant_str_cbx
            redundant_str_cbx.Items.AddRange(UtillExtensions.RedundantStringItems.ToArray());
            excluded_folders_cbx.Items.AddRange(UtillExtensions.excludeFolders.ToArray());
            global_folders_cbx.Items.AddRange(UtillExtensions.globalFolders.ToArray());

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
                label3.Text =  episodeSepcbx.Items[current].ToString();
            }
            catch (Exception)
            {

                episodeSepcbx.SelectedIndex = -1;
                label3.Text = string.Empty;
            }

        }
        private void refreshZeddPath()
        {
            string current = UtillExtensions.ZeddPath;
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
            UtillExtensions.ZeddPath = path;
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
            if (episodeSepcbx.SelectedIndex >= 0 && !setUpMode)
            {
                KeyValuePair<string, object> selected = (KeyValuePair<string, object>)episodeSepcbx.SelectedItem;
                updateEpisodeSeparator((int)selected.Value);
                Console.WriteLine(Properties.Settings.Default.PropertyValues["episodeSep"].PropertyValue);
                refreshEpisodeSeparator();
            }

        }

        private void redundant_str_update_btn_Click(object sender, EventArgs e)
        {
            // verify an item is selected in the redundant_str_cbx and remove it from UtillExtensions.badStrings and if item is manually entered add it to the list
            if (redundant_str_cbx.SelectedItem != null)
            {
                string selected = redundant_str_cbx.SelectedItem.ToString();
                UtillExtensions.RemoveRedundantString(selected.ToLower());
                redundant_str_cbx.Items.Remove(selected);
                MessageBox.Show("Redundant string removed: " + selected);
            }
            else
            {
                string entered = redundant_str_cbx.Text;
                if (!string.IsNullOrWhiteSpace(entered))
                {
                    UtillExtensions.AddRedundantString(entered.ToLower());
                    redundant_str_cbx.Items.Add(entered);
                    MessageBox.Show("Redundant string added: " + entered);
                }
                else
                {
                    MessageBox.Show("Please select or enter a valid string.");
                }
            }

            ((Button)sender).Enabled = false;
            ((Button)sender).Text = "Update";


        }

        private void folder_update_btn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var cbx = btn?.Tag as ComboBox;

            if (btn != null && cbx != null)
            {
                if (cbx.SelectedItem != null)
                {
                    string selected = cbx.SelectedItem.ToString();
                    if (object.ReferenceEquals(btn, global_folders_btn))
                    {
                        UtillExtensions.RemoveGlobalFolder(selected);
                    }
                    else if (object.ReferenceEquals(btn, excluded_folders_btn))
                    {
                        UtillExtensions.RemoveExcludeFolder(selected);
                    }
                    cbx.Items.Remove(selected);
                    MessageBox.Show("Folder removed: " + selected);
                }
                else
                {
                    string entered = cbx.Text;
                    if (!string.IsNullOrWhiteSpace(entered))
                    {
                        if (object.ReferenceEquals(btn, global_folders_btn))
                        {
                            UtillExtensions.AddGlobalFolder(entered);
                        }
                        else if (object.ReferenceEquals(btn, excluded_folders_btn))
                        {
                            UtillExtensions.AddExcludeFolder(entered);
                        }
                        cbx.Items.Add(entered);
                        MessageBox.Show("Folder added: " + entered);
                    }
                    else
                    {
                        MessageBox.Show("Please select or enter a valid folder.");
                    }
                }
            }

            btn.Enabled = false;
            btn.Text = "Update";


        }

        private void redundant_str_cbx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // when an item is selected in the redundant_str_cbx update the redundant_str_button text to "Remove"
            Update_redundant_str_btn_on_cbx_event();
        }

        private void redundant_str_cbx_TextChanged(object sender, EventArgs e)
        {
            // when text is changed in the redundant_str_cbx update the redundant_str_button text to "Add"
            Update_redundant_str_btn_on_cbx_event();

        }

        private void folder_cbx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var cbx = sender as ComboBox;
            var btn = cbx?.Tag as Button;

            var inputComparisonFunc = object.ReferenceEquals(btn, global_folders_btn) ?
                new Func<string, string, bool>(UtillExtensions.IsNotMatchingDefaultGlobalFoler) :
                new Func<string, string, bool>(UtillExtensions.IsNotMatchingDefaultExcludedFoler);

            var defaultCheckerPredicate = object.ReferenceEquals(btn, global_folders_btn) ?
                new Func<string, bool>(UtillExtensions.IsDefaultGlobalFolder) :
                new Func<string, bool>(UtillExtensions.IsDefaultExcludedFolder);

            if (cbx != null && btn != null)
            {
                Update_folder_buttons_on_cbx_event(cbx, btn, inputComparisonFunc, defaultCheckerPredicate);
            }
        }

        private void folder_cbx_TextChanged(object sender, EventArgs e)
        {
            var cbx = sender as ComboBox;
            var btn = cbx?.Tag as Button;

            var inputComparisonFunc = object.ReferenceEquals(btn, global_folders_btn) ?
                new Func<string, string, bool>(UtillExtensions.IsNotMatchingDefaultGlobalFoler) :
                new Func<string, string, bool>(UtillExtensions.IsNotMatchingDefaultExcludedFoler);

            var defaultCheckerPredicate = object.ReferenceEquals(btn, global_folders_btn) ?
                new Func<string, bool>(UtillExtensions.IsDefaultGlobalFolder) :
                new Func<string, bool>(UtillExtensions.IsDefaultExcludedFolder);

            if (cbx != null && btn != null)
            {
                Update_folder_buttons_on_cbx_event(cbx, btn, inputComparisonFunc, defaultCheckerPredicate);
            }
        }

        // Central logic used to update the redundant_str_update_btn based on the selection/input state of the redundant_str_cbx
        private void Update_redundant_str_btn_on_cbx_event()
        {
            string input_Text = (redundant_str_cbx.Text ?? string.Empty).Trim();
            bool input_exists_in_items = false;
            if (!string.IsNullOrEmpty(input_Text))
            {
                foreach (var item in redundant_str_cbx.Items)
                {
                    if (string.Equals(item.ToString(), input_Text, StringComparison.OrdinalIgnoreCase))
                    {
                        input_exists_in_items = true;
                        break;
                    }
                }
            }
            // Update button text to "Remove" if input matches an existing item otherwise "Add"
            redundant_str_update_btn.Text = input_exists_in_items ? "Remove" : "Add";

            // Enable the button only if there is valid input
            redundant_str_update_btn.Enabled = input_exists_in_items || !string.IsNullOrWhiteSpace(input_Text) || redundant_str_cbx.SelectedItem != null;

        }

        //Central logic used to update the global_folders_btn and excluded_folders_btn based on the selection/input state of the respective cbx
        private void Update_folder_buttons_on_cbx_event(ComboBox cbx, Button btn, Func<string,string,bool> inputComparisonFunc, Func<string, bool> defaultCheckerPredicate)
        {
            string input_Text = (cbx.Text ?? string.Empty).Trim();
            bool is_default_item = defaultCheckerPredicate(input_Text);
            if (is_default_item) return; // do not allow adding/removing default items
            bool input_is_user_added_item = false;
            if (!string.IsNullOrEmpty(input_Text))
            {
                foreach (var item in cbx.Items)
                {
                    if (inputComparisonFunc(item.ToString(), input_Text))
                    {
                        input_is_user_added_item = true;
                        break;
                    }
                }
            }
            // Update button text to "Remove" if input matches an existing item otherwise "Add"
            btn.Text = input_is_user_added_item ? "Remove" : "Add";
            // Enable the button only if there is valid input
            btn.Enabled = input_is_user_added_item || !string.IsNullOrWhiteSpace(input_Text) || cbx.SelectedItem != null;
        }

        
    }
}
