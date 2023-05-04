using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace AnimeOrganizer
{
     public partial class Form2 : Form
     {
          Dictionary<string,List<FileInfo>> Folder = new Dictionary<string,List<FileInfo>>();
          List<FileInfo> activeBulk = new List<FileInfo>();
          static string rootPath = Properties.Settings.Default.zeddPath; //@"C:\Users\USER\Downloads\Video\zedd";
          DirectoryInfo root;
          Seperator seperator;
          FileInfo activeFile;
          int index = 0;
          AnimeDB db;
          AnimeRecord? currentRecord;
          private bool isRenaming = false;
          public Form2()
          {
               InitializeComponent();
               if (rootPath == "empty" || rootPath == "" || rootPath == null || !rootPath.Contains(":\\"))
               {
                    SelectZeddPath(true);
                    Properties.Settings.Default["zeddPath"]= rootPath;
                    Properties.Settings.Default.Save();
                    Console.WriteLine(Properties.Settings.Default.zeddPath);
               }
               else
               {
                    try
                    {
                         root = new DirectoryInfo(rootPath);
                    }
                    catch(Exception e)
                    {
                         SelectZeddPath(true);
                    }
               }
               db = AnimeDB.Deserialize();
               buildTree();
               epsodeselectorgbx.Enabled = false;
               
          }
          
          private void buildTree()
          {

               TreeNode rootNode = new TreeNode(root.Name);
               foreach (DirectoryInfo folder in root.EnumerateDirectories())
               {
                    TreeNode node = new TreeNode(folder.Name);
                    List<FileInfo> files = new List<FileInfo>();
                    foreach (FileInfo file in folder.EnumerateFiles())
                    {
                         files.Add(file);
                         node.Nodes.Add(file.Name);
                    }
                    Folder.Add(folder.Name, files);
                    rootNode.Nodes.Add(node);   
               }
               foldertree.Nodes.Add(rootNode);
          }
          private void updateTree()
          {
               Folder.Clear();
               foldertree.Nodes.Clear();
               buildTree();
               foldertree.TopNode.Expand();
          }
          private void showFile()
          {
               activeFile = activeBulk[index];
               currentlbl.Text = activeFile.Name;
          }
          
          private void showRecord(AnimeRecord record)
          {
               titlelbl.Text = record.Title;
               epdownloadedlbl.Text = record.EpisodeCount.ToString();
               ratingNud.Value = record.Rating;
               descriptionRtx.Text = record.Description;
               seasontxt.Text = record.Season + "," + record.Year;
          }
          private void clearRecord()
          {
               titlelbl.Text = "";
               epdownloadedlbl.Text = "";
               ratingNud.Value = 1;
               descriptionRtx.Text = "";
          }
          private void foldertree_AfterSelect(object sender, TreeViewEventArgs e)
          {
               if ((e.Node.Text != root.Name) && Folder.Keys.Contains(e.Node.Text))
               {
                    folderlbl.Text = e.Node.Text;
                    if (db.Contains(folderlbl.Text))
                    {
                         currentRecord = db[folderlbl.Text];
                         showRecord(currentRecord.Value);
                    }
                    else
                    {
                         currentRecord = null;
                         clearRecord();
                    }
                    titlelbl.Text = e.Node.Text;
                    epdownloadedlbl.Text = Folder[titlelbl.Text].Count.ToString();
               }
          }

          private void checkbox_select(object sender, EventArgs e)
          {
               if (((CheckBox)sender).Checked)
               {
                    if (folderlbl.Text != "No Folder Selected")
                    {
                         filenametxt.Text = folderlbl.Text;
                         
                    }
               }
               else
               {
                    if (filenametxt.Text == folderlbl.Text)
                    {
                         filenametxt.Text = "";
                    }
               }
          }

          private void filenametxt_TextChanged(object sender, EventArgs e)
          {
               if (filenametxt.Text!=folderlbl.Text && foldernamecbx.Checked)
               {
                    foldernamecbx.Checked = false;
               }
          }

          private void episoderbtn_CheckedChanged(object sender, EventArgs e)
          {
               if (((RadioButton)sender).Checked)
               {
                    seperator = Seperator.episode;
               }
          }

          private void dashrbtn_CheckedChanged(object sender, EventArgs e)
          {
               if (((RadioButton)sender).Checked)
               {
                    seperator = Seperator.dash;
               }
          }

          private void startbtn_Click(object sender, EventArgs e)
          {
               if (filenametxt.Text!="" && (seperator== Seperator.dash || seperator == Seperator.episode))
               {
                    rootlink.Hide();dblink.Hide();
                    activeBulk = Folder[folderlbl.Text];
                    index = 0;
                    epsodeselectorgbx.Enabled = true;
                    showFile();
                    epsodeselectorgbx.Enabled = true;
                    Renamepanel.Enabled = false;
                    isRenaming = true;
               }
          }

          private void clearbtn_Click(object sender, EventArgs e)
          {
               episodelbl.Text = "select from keypad";
          }

          private void numpad_click(object sender, EventArgs e)
          {
               if (episodelbl.Text == "select from keypad")
               {
                    episodelbl.Text = ((Button)sender).Text;
               }
               else
               {
                    episodelbl.Text += ((Button)sender).Text;
               }
          }

          private void nextbtn_Click(object sender, EventArgs e)
          {
               if (episodelbl.Text != "select from keypad")
               {
                    string filename = UtillExtensions.GenerateFileName(filenametxt.Text, int.Parse(episodelbl.Text), seperator);
                    activeFile.MoveTo(activeFile.Directory.FullName + @"\" + filename + activeFile.Extension);
                    episodelbl.Text = "select from keypad";
               }
               if (index<(activeBulk.Count-1))
               {
                    index += 1;
                    showFile();
               }
               else
               {
                    MessageBox.Show("Completed Bulk action for "+folderlbl.Text);
                    updateTree();
                    reset();
                    Renamepanel.Enabled = true;
                    epsodeselectorgbx.Enabled = false;
                    rootlink.Show(); dblink.Show();
                    isRenaming = false;
               }
          }
          private void reset()
          {
               filenametxt.Text = "";
               folderlbl.Text = "No Folder Selected";
               foldernamecbx.Checked = false;
               episoderbtn.Checked = false;
               dashrbtn.Checked = false;
               seperator = Seperator.none;
               currentlbl.Text = "episode current name";
               episodelbl.Text = "select from keypad";
               isRenaming = false;

          }

          private void updatebtn_Click(object sender, EventArgs e)
          {
               if (currentRecord.HasValue)
               {
                    AnimeRecord rec = currentRecord.GetValueOrDefault();
                    rec.Description = descriptionRtx.Text;
                    rec.EpisodeCount = int.Parse(epdownloadedlbl.Text);
                    rec.Rating = (int)ratingNud.Value;
                    rec.Season = seasontxt.Text.Split(',')[0];
                    try
                    {
                         rec.Year = int.Parse(seasontxt.Text.Split(',')[1].Substring(0, 4));
                    }
                    catch (Exception)
                    {

                         rec.Year = null;
                    }
                    db.Update(rec);
                    currentRecord = db[rec.Title];
                    showRecord(currentRecord.Value);
                    clearRecord();
               }
               else
               {
                    AnimeRecord newRecord = new AnimeRecord(titlelbl.Text,int.Parse(epdownloadedlbl.Text));
                    newRecord.Description = descriptionRtx.Text;
                    newRecord.Rating = (int)ratingNud.Value;
                    newRecord.Season = seasontxt.Text.Split(',')[0];
                    try
                    {
                         newRecord.Year = int.Parse(seasontxt.Text.Split(',')[1].Substring(0, 4));
                    }
                    catch (Exception)
                    {

                         newRecord.Year = null;
                    }
                    db.Update(newRecord);
                    currentRecord = db[newRecord.Title];
                    showRecord(currentRecord.Value);
                    clearRecord();
               }
               MessageBox.Show("updated successfully!");
          }

          private void Form2_FormClosing(object sender, FormClosingEventArgs e)
          {
               db.Serialize();
               Application.Exit();
               //MessageBox.Show("Database index saved, clode to exit");
          }

          private void linkLabel2_LinkClicked(object sender, EventArgs e)
          {
               SelectZeddPath(false);
          }
          private void SelectZeddPath(bool buildOnly)
          {
               if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
               {
                    string newroot = folderBrowserDialog.SelectedPath;
                    rootPath = newroot;
                    root = new DirectoryInfo(rootPath);
                    reset();
                    clearRecord();
                    if (!buildOnly)
                    {
                        
                         updateTree();
                    }
               }
          }
          private void linkLabel1_Click(object sender, EventArgs e)
          {
               db.Serialize();
               new Form1().Show();
               this.Hide();
          }

          private void stopbtn_Click(object sender, EventArgs e)
          {
               updateTree();
               reset();
               Renamepanel.Enabled = true;
               epsodeselectorgbx.Enabled = false;
               rootlink.Show(); dblink.Show();
               isRenaming = false;
          }
          private void Enter_Press(object sender, KeyEventArgs e)
          {

          }
          private void Form2_KeyPress(object sender, KeyPressEventArgs e)
          {

          }

          private void autoOrganizeLnkLbl_Click(object sender, EventArgs e)
          {
               db.Serialize();
               new Form3(db, rootPath).Show();
               this.Hide();
          }
     }
}
