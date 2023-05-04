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
     public partial class Form3 : Form
     {
          private DirectoryInfo directoryInfo;
          private List<AnimeFile> animeFiles;
          private List<AnimeFolder> animeFolders;
          private List<string> globalFolders = new List<string>
          {
               "movies and ova"
          };
          private List<string> excludeFolders = new List<string>
          {
              "temp",
              "Done"
          };
          private AnimeFile currentFile;
          private AnimeDB db;
          public Form3(AnimeDB db, string rootPath)
          {
               this.db = db;
               animeFiles = new List<AnimeFile>();
               animeFolders = new List<AnimeFolder>();
               InitializeComponent();
               try
               {
                    GetFiles(rootPath);
               }
               catch (Exception e)
               {

                    MessageBox.Show(e.Message, "Info");
                    Close();
               }
               Next();
          }
          private void GetFiles(string rootPath)
          {
               directoryInfo = new DirectoryInfo(rootPath);
               foreach (FileInfo file in directoryInfo.EnumerateFiles()) 
               {
                    AnimeFile animeFile = new AnimeFile();
                    animeFile.Name = file.Name;
                    animeFile.Path = file.FullName;
                    animeFiles.Add(animeFile);
               }
               if (animeFiles.Count<1)
               {
                    throw new Exception("No files to be arranged");
               }
               RefreshDirectories();
               
          }
          private void RefreshDirectories()
          {
               animeFolders.Clear();
               foreach (DirectoryInfo folder in directoryInfo.EnumerateDirectories())
               {
                    AnimeFolder animeFolder = new AnimeFolder();
                    animeFolder.Name = folder.Name;
                    animeFolder.Path = folder.FullName;
                    animeFolders.Add(animeFolder);
               }
          }
          private new void Close()
          {
              db.Serialize();
              new Form2().Show();
              this.Hide();
          }
          private void ShowFile()
          {
               mainDisplay.Text = currentFile.Name;
               DisplayOptions();
          }
          private void Next()
          {
               if (animeFiles.Count>0)
               {
                    currentFile = animeFiles[0];
                    ShowFile();
               } else
               {
                    MessageBox.Show("No more files to auto organize", "Info");
                   Close();
               }

          }
          private void Option_click(object sender, EventArgs e) {
               if (!((sender as Control).Tag is object[] tags)) return; //if Tag is list of object continue else return
               string name = (string) tags[0];
               string path = (string) tags[1];
               AnimeRecord animeRecord = GetAnimeRecord(name);
               Next();
               MoveFile(path, animeRecord);
               RefreshFiles();

          }
          private AnimeRecord GetAnimeRecord(string name)
          {
               AnimeRecord animeRecord;
               if (db.Contains(name))
               {
                    animeRecord = db[name];
               }
               else
               {
                    animeRecord = new AnimeRecord(name, 0);

               }
               return animeRecord;
          }
          private void MoveFile(string toPath, AnimeRecord animeRecord)
          {
               string fileName = UtillExtensions.GenerateFileName(animeRecord.Title, animeRecord.EpisodeCount + 1, Seperator.dash);
               FileInfo CurrentFileInfo = new FileInfo(currentFile.Path);
               string newPath = toPath + @"\" + fileName + CurrentFileInfo.Extension;
               if (CurrentFileInfo.Exists && MessageBox.Show("Move to " + newPath + " ?", "Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
               {
                    CurrentFileInfo.MoveTo(newPath);
                    animeRecord.EpisodeCount = animeRecord.EpisodeCount + 1;
                    db.Update(animeRecord);
               }
               else
               {
                    MessageBox.Show("Something went wrong, confirm is file still exists", "Error");
               }
               
          }
          private void DisplayOptions()
          {
               List<AnimeFolder> matches = new List<AnimeFolder>();
               foreach (AnimeFolder item in animeFolders)
               {
                    if (globalFolders.Contains(item.Name))
                    {
                         matches.Add(item);
                    } else if (!excludeFolders.Contains(item.Name))
                    {
                        IEnumerable<string> intersect =  currentFile.SearchSet.Intersect(item.SearchSet);
                        if (intersect.Any()) {
                              item.Weight = intersect.Count();
                              matches.Add(item);
                         }
                    }
               }
               matches.Sort();
               Console.WriteLine(string.Join(",", matches));
               optionsBox.Controls.Clear();
               foreach (AnimeFolder match in matches)
               {
                    optionsBox.Controls.Add(GetButton(match.Name, match.Path));
               }
          }

          private Button GetButton(string name, string path)
          {
               Button button = new Button();
               button.Text = "Move to " + name;
               button.Size = new Size(187, 52);
               button.Font = new Font("Segoe UI", 10f, FontStyle.Regular, GraphicsUnit.Pixel);
               button.AutoEllipsis = true;
               button.Tag = new object[] {name, path};
               button.Click += Option_click;
               button.Visible = true;
               this.toolTip1.SetToolTip(button, name);
               return button;
          }
          private void RefreshFiles()
          {
               if (animeFiles.Count>0)
               {
                    animeFiles.RemoveAt(0);
               }
          }
          private void skipBtn_Click(object sender, EventArgs e)
          {
               RefreshFiles();
               Next();
          }

          private void selectFolderBtn_Click(object sender, EventArgs e)
          {
              DialogResult result =  folderBrowserDialog.ShowDialog();
               if (result == DialogResult.OK)
               {
                    string path =  folderBrowserDialog.SelectedPath;
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    if (directoryInfo.Exists)
                    {
                         AnimeRecord animeRecord = GetAnimeRecord(directoryInfo.Name);
                         MoveFile(directoryInfo.FullName, animeRecord);
                         RefreshFiles();
                         RefreshDirectories();
                         Next();
                    }
               }
               
          }

          private void Form3_FormClosing(object sender, FormClosingEventArgs e)
          {
               if (e.CloseReason == CloseReason.UserClosing)
               {
                    db.Serialize();
                    Application.Exit();
               }
          }
     }
}
