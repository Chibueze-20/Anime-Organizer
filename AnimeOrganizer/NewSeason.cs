using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeOrganizer
{
    public partial class NewSeason : Form
    {
        private List<string> animes;
        private string rootPath;
        public NewSeason()
        {
            InitializeComponent();
            animes = new List<string>();
            this.rootPath = Properties.Settings.Default.zeddPath;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }

        private void animelist_btn_Click(object sender, EventArgs e)
        {
            clearList();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
               string[] lines =  File.ReadAllLines(openFileDialog.FileName);
               animes.AddRange(lines);
               updateList();
            }
        }

        private void clearList()
        {
            animes.Clear();
            updateList();
        }
        private void updateList() { 
            
           anime_lbx.Items.Clear();
            foreach (string line in animes)
            {
                anime_lbx.Items.Add(line);
            }
        }
        private void saveList()
        {
            DirectoryInfo rootDir = new DirectoryInfo(this.rootPath);
            foreach (string anime in animes)
            {
                DirectoryInfo subdir = new DirectoryInfo(this.rootPath+"/"+anime);
                if (!subdir.Exists)
                {
                    rootDir.CreateSubdirectory("./" + anime);
                }
                
            }
            MessageBox.Show("Directories Created Successfully.");
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            saveList();
            this.Close();
        }
    }
}
