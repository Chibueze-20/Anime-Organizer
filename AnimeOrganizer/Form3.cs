﻿using System;
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
          
          private AnimeFile currentFile;
          private readonly AnimeDB db;
        private readonly string rootPath;
        private Seperator seperator;
        private bool useDefaultSeason;
          public Form3(AnimeDB db)
          {
               this.db = db;
            this.useDefaultSeason = false;
            this.rootPath = Properties.Settings.Default.zeddPath;
               animeFiles = new List<AnimeFile>();
               animeFolders = new List<AnimeFolder>();
               InitializeComponent();
            menu1.AddOpenMenuOption("Database", OpenDatabaseEvent);
            menu1.AddOpenMenuOption("Organizer", OpenOrganizerEvent);
            menu1.OnCustomize = CustomizeSeparatorEvent;
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
          private void OpenDatabaseEvent(object sender, EventArgs e)
          {
            
            new Form1().Show();
            this.Hide();
          }
        private void OpenOrganizerEvent(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void GetFiles(string rootPath)
          {
               directoryInfo = new DirectoryInfo(rootPath);
               foreach (FileInfo file in directoryInfo.EnumerateFiles()) 
               {
                if (!UtillExtensions.videoExtensions.Contains(file.Extension))
                {
                    continue;
                }
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
            directoryInfo = new DirectoryInfo(rootPath);
            foreach (DirectoryInfo folder in directoryInfo.EnumerateDirectories())
               {
                    AnimeFolder animeFolder = new AnimeFolder();
                    animeFolder.Name = folder.Name;
                    animeFolder.Path = folder.FullName;
                    animeFolders.Add(animeFolder);
               }
          }
          private void RefreshSeparator()
        {
            try
            {
                Seperator current = (Seperator)Enum.Parse(typeof(Seperator), Properties.Settings.Default.episodeSep.ToString());
                seperator = current;
            }
            catch (Exception e)
            {

                Console.WriteLine("Sep convert Exception: " + e.Message);
            }
        }
        private void CustomizeSeparatorEvent(bool zeddPathChanged, bool separatorChanged)
        {
            if (separatorChanged)
            {
                RefreshSeparator();
            }
        }
          private new void Close()
          {
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
               AnimeRecord animeRecord = GetAnimeRecord(name, path);
               if(MoveFile(path, animeRecord))
            {
                RefreshFiles();
                Next();
            }
               

        }
          private AnimeRecord GetAnimeRecord(string name, string path)
          {
               AnimeRecord animeRecord;
               DirectoryInfo directoryInfo = new DirectoryInfo(path);
               int fileCount = directoryInfo.EnumerateFiles().Count();
               if (db.Contains(name))
               {
                    animeRecord = db[name];
               }
               else
               {
                    animeRecord = new AnimeRecord(name, fileCount);

               }
               return animeRecord;
          }
          private bool MoveFile(string toPath, AnimeRecord animeRecord)
          {
               string fileName = UtillExtensions.GenerateFileName(animeRecord.title, animeRecord.numberOfEpisodes + 1, seperator);
               FileInfo CurrentFileInfo = new FileInfo(currentFile.Path);
               DirectoryInfo ToDirectoryInfo = new DirectoryInfo(toPath);
            string newPath = "";
            if (UtillExtensions.globalFolders.Contains(ToDirectoryInfo.Name))
            {
                newPath = toPath + @"\" + CurrentFileInfo.Name;
            }else
            {
                newPath = toPath + @"\" + fileName + CurrentFileInfo.Extension;
            }
               
               if (CurrentFileInfo.Exists && MessageBox.Show("Move to " + newPath + " ?", "Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
               {
                    CurrentFileInfo.MoveTo(newPath);
                    animeRecord.numberOfEpisodes = animeRecord.numberOfEpisodes + 1;
                if (!UtillExtensions.globalFolders.Contains(animeRecord.title)) //no global folders in db
                {
                    //check if season and year are set and use default if default flag is set
                    if (animeRecord.Season == "unknown" && useDefaultSeason)
                    {
                        animeRecord.Season = UtillExtensions.getSeason();
                    }
                    if(animeRecord.Year == 0 && useDefaultSeason)
                    {
                        animeRecord.Year = DateTime.Now.Year;
                    }
                    db.Update(animeRecord);
                }
                return true;
               }
               else
               {
                return false;
               }
               
          }
          private void DisplayOptions()
          {
               List<AnimeFolder> matches = new List<AnimeFolder>();
               foreach (AnimeFolder item in animeFolders)
               {
                    if (UtillExtensions.globalFolders.Contains(item.Name))
                    {
                         item.Weight = int.MaxValue;
                         matches.Add(item);
                    } else if (!UtillExtensions.excludeFolders.Contains(item.Name))
                    {
                        IEnumerable<string> intersect =  currentFile.SearchSet.Intersect(item.SearchSet);
                        if (intersect.Any()) {
                              item.Weight = intersect.Count();
                              matches.Add(item);
                         }
                    }
               }
            matches.Sort((a, b) => a > b ? -1 : 1);
            Console.WriteLine(string.Join(",", matches));
               optionsBox.Controls.Clear();
               foreach (AnimeFolder match in matches)
               {
                    optionsBox.Controls.Add(GetButton(match.Name, match.Path));
               }
            VScrollBar scrollBar = new VScrollBar();
            scrollBar.Dock = DockStyle.Right;
            optionsBox.Controls.Add(scrollBar);
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
            button.Name = name;
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
                         AnimeRecord animeRecord = GetAnimeRecord(directoryInfo.Name, path);
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
                    Application.Exit();
               }
          }

        private void mainDisplay_Click(object sender, EventArgs e)
        {
            string possibleFolderName = string.Join(" ", currentFile.SearchSet);
            Clipboard.SetText(possibleFolderName);
        }

        private void autoSeason_cbx_CheckedChanged(object sender, EventArgs e)
        {
            if (autoSeason_cbx.Checked)
            {
                this.useDefaultSeason = true;
            } else { 
                this.useDefaultSeason = false; 
            }
        }
    }
}
