using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace AnimeOrganizer
{
     public partial class Form1 : Form
     {
          private IFormatter serializerFormatter = new BinaryFormatter();
          IList<FileInfo> currentDirectory;
          private Database db;
          private FileInfo SelecetedFile = null;
          private DirectoryInfo SelectedDirectory = null;
          private bool IsCleaning =false;
          private AnimeFile CurrentFile;
          public Form1()
          {
               InitializeComponent();
               Deserialize();
               CurrentFile = new AnimeFile();
               OFileDialog.Filter = "Mp4 video file (*.mp4)|*.mp4|MKV file (*.mkv)|*.mkv|3gp video file (*.3gp)|*.3gp";
          }
          public string OpenFolder()
          {
               if (folderBrowserDialog.ShowDialog() != DialogResult.Cancel)
               {
                    return folderBrowserDialog.SelectedPath;
               }
               else
               {
                    return null;
               }
          }
          public IList<string> OpenFiles()
          {
               if (OFileDialog.ShowDialog() != DialogResult.Cancel)
               {
                    return OFileDialog.FileNames;
               }
               else
               {
                    return null;
               }
          }
          public void indexFolder(bool rootprefix)
          {
               string path = OpenFolder();
               if (path != null)
               {
                    db.index(path, rootprefix);
                    filenamecbx.Items.AddRange(db.Ongoing.ToArray());
                    MessageBox.Show("Index done!");
               }
          }
          public void RefreshList()
          {
               SelectedDirectory.Refresh();
               currentDirectory = SelectedDirectory.GetFiles();
               AddtoListView();
          }
          public void CleanForm()
          {
               IsCleaning = true;
               if (foldercb.Enabled)
               {
                    foldercb.Checked = false;
               }
               filenametxt.Text = "";
               filenamecbx.SelectedItem = null;
               filenamecbx.Text = "";
               episodenud.Value = 0;

          }
          public void ListFiles(OpenMode openMode)
          {
               if (openMode == OpenMode.Folder)
               {
                    string folder = OpenFolder();
                    if (folder != null)
                    {
                         DirectoryInfo directoryInfo = new DirectoryInfo(folder);
                         SelectedDirectory = directoryInfo;
                         folderlbl.Text = directoryInfo.Name;
                         currentDirectory = directoryInfo.GetFiles();
                    }
               } else if (openMode == OpenMode.Files)
               {
                    IList<string> files = OpenFiles();
                    currentDirectory = new List<FileInfo>(files.Count);
                    files.ToList().ForEach(x =>currentDirectory.Add(new FileInfo(x)));
               }
               try
               {
                    AddtoListView();
               }
               catch (Exception)
               {

                    MessageBox.Show("No files addec");
               }
               finally
               {
                    if (openMode == OpenMode.Folder)
                    {
                         foldercb.Enabled = true;
                    }
                    else
                    {
                         foldercb.Enabled = false;
                    }
               }
          }
          void AddtoListView()
          {
               fileList.Items.Clear();
               foreach (FileInfo item in currentDirectory)
               {
                    fileList.Items.Add(item.Name);
               }
          }
          public void Deserialize()
          {
               Stream dbFileStream = null;
               try
               {
                    dbFileStream = new FileStream("database.pnk", FileMode.Open, FileAccess.Read, FileShare.Read);
                    db = (Database)serializerFormatter.Deserialize(dbFileStream);
                    filenamecbx.Items.AddRange(db.Ongoing.ToArray()); 
               }
               catch (Exception)
               {

                    db = new Database();
               }
               finally
               {
                    if (dbFileStream != null)
                    {
                         dbFileStream.Close();
                    }
               }
          }
          public void Serialize()
          {
               Stream dbFileStream = new FileStream("database.pnk",FileMode.Create,FileAccess.Write,FileShare.None);
               serializerFormatter.Serialize(dbFileStream, db);
               dbFileStream.Close();
          }

          private void fileList_SelectedValueChanged(object sender, EventArgs e)
          {
               if (!IsCleaning)
               {
                    if (menutab.SelectedIndex==0)
                    {
                         CleanForm();
                         filenametxt.Text = ((CheckedListBox)sender).Text;
                         string file = ((CheckedListBox)sender).Text;
                         SelecetedFile = currentDirectory.ToList().Find(info => new TitleComparer().Equals(info.Name, file));
                    }
                    else
                    {
                         titletxt.Text = ((CheckedListBox)sender).Text;
                    }
               }
          }

          private void filenamecbx_SelectionChangeCommitted(object sender, EventArgs e)
          {
               if (!IsCleaning && SelecetedFile!=null)
               {
                    CurrentFile.Title = (string)((ComboBox)sender).SelectedItem;
                    CurrentFile.Episode = (int)episodenud.Value;
                    filenametxt.Text = CurrentFile.ToString();
               }
          }

          private void episodenud_ValueChanged(object sender, EventArgs e)
          {
               if (!IsCleaning && SelecetedFile != null)
               {
                    CurrentFile.Episode = (int)episodenud.Value;
                    filenametxt.Text = CurrentFile.ToString();
               }
          }

          private void foldercb_CheckedChanged(object sender, EventArgs e)
          {
               if (((CheckBox)sender).Checked && SelecetedFile != null)
               {
                    CurrentFile.Title = folderlbl.Text;
                    CurrentFile.Episode = (int)episodenud.Value;
                    filenametxt.Text = CurrentFile.ToString();
               }
               else
               {
                    CurrentFile.Title = "";
                    CurrentFile.Episode = 0;
                    filenametxt.Text = SelecetedFile.Name;
               }
          }

          private void renamebtn_Click(object sender, EventArgs e)
          {
               try
               {
                    if (SelecetedFile != null)
                    {
                         SelecetedFile.MoveTo(SelecetedFile.Directory.FullName +@"\"+ CurrentFile.ToString() + SelecetedFile.Extension);
                         MessageBox.Show("Change made, confrim froom yout file explorer, file path: " + SelecetedFile.Directory.FullName + @"\" + CurrentFile.ToString() + SelecetedFile.Extension);
                         CleanForm();
                         if (SelectedDirectory !=null)
                         {
                              RefreshList();
                         }
                         IsCleaning = false;
                    }
                    else
                    {
                         MessageBox.Show("No changes made");
                    }
               }
               catch (Exception ex)
               {

                    MessageBox.Show(ex.Message);
               }
          }

          private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
          {
               ListFiles(OpenMode.Folder);
          }

          private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
          {
               ListFiles(OpenMode.Files);
          }

          private void rootPrefixToolStripMenuItem_Click(object sender, EventArgs e)
          {
               indexFolder(true);
          }

          private void noRootPrefixToolStripMenuItem_Click(object sender, EventArgs e)
          {
               indexFolder(false);
          }

          private void Form1_FormClosing(object sender, FormClosingEventArgs e)
          {
               Serialize();
               MessageBox.Show("Database index saved, close to exit");
          }
          
          private void OngoingToolStripMenuItem_Click(object sender, EventArgs e)
          {
               menutab.SelectTab(1);
               viewlbl.Text = "Manager: Ongoing Anime";
               fileList.Items.Clear();
               foreach (string item in db.Ongoing)
               {
                    fileList.Items.Add(item);
               }
          }

          private void planToWatchToolStripMenuItem_Click(object sender, EventArgs e)
          {
               menutab.SelectTab(1);
               viewlbl.Text = "Manager: Plan to watch Anime";
               fileList.Items.Clear();
               foreach (string item in db.Planning)
               {
                    fileList.Items.Add(item);
               }
          }

          private void allToolStripMenuItem_Click(object sender, EventArgs e)
          {
               fileList.Items.Clear();
               viewlbl.Text = "Manager: All Anime";
               foreach (string item in db.Ongoing)
               {
                    fileList.Items.Add(item);
               }
               foreach (string item in db.Planning)
               {
                    fileList.Items.Add(item);
               }
          }

          private void menutab_SelectedIndexChanged(object sender, EventArgs e)
          {
               if (menutab.SelectedIndex == 1)
               {
                    viewlbl.Text = "Manager";
                    fileList.Items.Clear();
                    ongoingcnt.Text = db.Ongoing.Count() + "";
                    planningcnt.Text = db.Planning.Count() + "";
                    allcnt.Text = (db.Ongoing.Count + db.Planning.Count()) + "";
               } else if (menutab.SelectedIndex == 0)
               {
                    viewlbl.Text = "Organizer";
                    fileList.Items.Clear();
               }
          }

          private void modifyplanningbtn_Click(object sender, EventArgs e)
          {
               string title = titletxt.Text;
               if (db.Ongoing.Contains(title))
               {
                    MessageBox.Show("Can not move title from ongoing to plan to watch");
               }else if (db.Planning.Contains(title))
               {
                    db.Planning.Remove(title);
                    MessageBox.Show("Removed " + title + " from Plan to watch");
               }
               else
               {
                    db.Planning.Add(title);
                    MessageBox.Show("Added " + title + " to Plan to watch");
               }
               titletxt.Text = "";
          }

          private void modifyongoingbtn_Click(object sender, EventArgs e)
          {
               string title = titletxt.Text;
               if (db.Ongoing.Contains(title))
               {
                    db.Ongoing.Remove(title);
                    MessageBox.Show("Removed " + title + " from Ongoing");
               }
               else if (db.Planning.Contains(title))
               {
                    db.Planning.Remove(title);
                    db.Ongoing.Add(title);
                    MessageBox.Show("Moved " + title + " from Plan to watch to Ongoing");
               }
               else
               {
                    db.Ongoing.Add(title);
                    MessageBox.Show("Added " + title + " to Ongoing");
               }
          }
     }
     [Serializable]
     public class Database
     {
          private ISet<string> ongoing;
          private ISet<string> plan;
          public Database()
          {
               ongoing = new HashSet<string>(new TitleComparer());
               plan = new HashSet<string>(new TitleComparer());
          }
          public void index(string path, bool rootPrefix)
          {
               DirectoryInfo directory = new DirectoryInfo(path);
               if (directory.Exists)
               {
                    if (directory.GetDirectories().Length == 0)
                    {
                         ongoing.Add(directory.Name);
                    }
                    else
                    {
                         foreach (DirectoryInfo item in directory.GetDirectories())
                         {
                              ongoing.Add(rootPrefix ? directory.Name +" "+item.Name:item.Name);
                         }
                    }
               }
          }
          public IList<string> Ongoing
          {
               get
               {
                    return ongoing.ToList();
               }
          }
          public IList<string> Planning
          {
               get
               {
                    return plan.ToList();
               }
          }

          
     }
     [Serializable]
     class TitleComparer : IEqualityComparer<string>
     {
          public bool Equals(string x, string y)
          {
               if (x.Length == y.Length)
               {
                    for (int i = 0; i < x.Length; i++)
                    {
                         if (x[i] != y[i])
                         {
                              return false;
                         }
                    }
                    return true;
               }
               else
               {
                    return false;
               }
          }

          public int GetHashCode(string obj)
          {
               return obj.GetHashCode();
          }
     }
     public enum OpenMode
     {
          Folder,
          Files
     }
     struct AnimeFile
     {
          private string title;
          private int episode;
          public string Title
          {
               set
               {
                    title = value;
               }
               get
               {
                    return title;
               }
          }
          public int Episode
          {
               set
               {
                    episode = value;
               }
               get
               {
                    return episode;
               }
          }
          public override string ToString()
          {
               return title + " Episode " + episode;
          }
     }
}
