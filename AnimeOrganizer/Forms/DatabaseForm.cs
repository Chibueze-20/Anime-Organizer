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
using AnimeOrganizerCommon;
using AnimeOrganizerDataObjects;
using AnimeOrganizer.Forms;

namespace AnimeOrganizer
{
     public partial class DatabaseForm : Form
     {
          private IFormatter serializerFormatter = new BinaryFormatter();
          private IAnimeDB db;
          private AnimeRecord currentRecord;
          private IEnumerable<DirectoryInfo> bulkOperationTitles;
        private int currentBulkIndex =  0;
          public DatabaseForm()
          {
               InitializeComponent();
            menu1.AddOpenMenuOption("Auto Organizer", OpenAutoOrganizerEvent);
            menu1.AddOpenMenuOption("Auto Organizer V2", OpenAutoOrganizerV2Event);
            menu1.AddOpenMenuOption("Organizer", OpenOrganizerEvent);
            menu1.AddMenuOption("Export Database to CSV", ExportToCsv);
            menu1.AddMenuOption("Import from CSV", csv_importbtn_Click);
            db = Program.database;
               Fill();
          }
          public void Fill()
          {
               foreach (string title in db)
               {
                    titleList.Items.Add(title, false);
               }
          }
         public void RefreshList()
        {
            titleList.Items.Clear();
            Fill();
        }
          
          private void showRecord(AnimeRecord record)
          {
               titlelbl.Text = record.title;
               episodelbl.Text = record.numberOfEpisodes.ToString();
               ratingnum.Value = record.rating.GetValueOrDefault(0);
               descriptionrtxt.Text = record.description;
               yeartxt.Text = record.year.ToString();
               seasontxt.Text = record.season;

          }
          private void clearRecord()
          {
               titlelbl.Text = "";
               episodelbl.Text = "0";
               ratingnum.Value = 0;
               descriptionrtxt.Text = "";
               yeartxt.Text = "";
               seasontxt.Text = "";

          }
          private void Form1_FormClosing(object sender, FormClosingEventArgs e)
          {    
                db.Save();
               Application.Exit();
               //MessageBox.Show("Database index saved, close to exit");
          }

          private void titleList_SelectedIndexChanged(object sender, EventArgs e)
          {
               string selected = titleList.SelectedItem.ToString();
               currentRecord = db[selected];
               showRecord(currentRecord);

          }

          private void updatebtn_Click(object sender, EventArgs e)
          {
               currentRecord.description = descriptionrtxt.Text;
               currentRecord.rating = (int)ratingnum.Value;
               currentRecord.SafeSetSeason(seasontxt.Text);
               try
               {
                    currentRecord.SafeSetYear(int.Parse(yeartxt.Text == "" ? "0" : yeartxt.Text));
               }
               catch (Exception)
               {

                    currentRecord.SafeSetYear(0);
               }
               db.Update(currentRecord);
            db.Save();
               //currentRecord = db[currentRecord.Title];
               //showRecord(currentRecord);
               MessageBox.Show("Record sucessfully updated");
          }

          private void deletebtn_Click(object sender, EventArgs e)
          {
               db.Delete(currentRecord);
            db.Save();
               clearRecord();
               RefreshList();
               MessageBox.Show("Record deleted sucesssfully");
          }

          private void OpenOrganizerEvent(object sender, EventArgs e)
          {
               new Organizer().Show();
               this.Hide();
          }
        private void OpenAutoOrganizerEvent(object sender, EventArgs e)
        {
            new QuickOrganizer().Show();
            this.Hide();
        }
        private void OpenAutoOrganizerV2Event(object sender, EventArgs e)
        {
            new QuickOrganizerV2().Show();
            this.Hide();
        }
        private void ExportToCsv(object sender, EventArgs e)
        {
            List<string> lines = new List<string>();
            lines.Add("Title,Description,Rating,Episode Count,Season,Year,Last Updated");
            foreach (var anime in db)
            {
                string line = string.Format("{0},{1},{2:D},{3:D},{4},{5:D},{6:MM-dd-yyyy HH:mm:ss}", 
                    UtillExtensions.RemoveCommas(db[anime].title), UtillExtensions.RemoveCommas(db[anime].description), 
                    db[anime].rating, db[anime].numberOfEpisodes, db[anime].season, db[anime].year, 
                    db[anime].lastUpdate.DateTime);
                lines.Add(line);
            }
            string rootpath = Properties.Settings.Default.zeddPath;
            Console.WriteLine(rootpath);
            string date = string.Format("{0:dd_MM_yyyy-HH_mm_ss}", DateTime.Now);
            string path = rootpath + @"\" + "AnimeDatabase_" + date+".csv";
            Console.WriteLine(path);
            try
            {
                File.WriteAllLines(path, lines.ToArray());
                MessageBox.Show("Database Exported to: " + path);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error Exporting file: " + ex.Message, "Error Exporting to csv", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void csv_importbtn_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = UtillExtensions.GetZeddDirectory();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
               string[] lines = File.ReadAllLines(openFileDialog.FileName);
                for (int i = 1; i < lines.Length; i++)
                {
                    Console.WriteLine("Csv line: " + lines[i]);
                    AnimeRecord animeRecord = AnimeRecord.FromCsv(lines[i]);
                    if (db.Contains(animeRecord.title))
                    {
                        db.Update(animeRecord);
                    } else
                    {
                        db.Create(animeRecord);
                    }
                    Console.WriteLine("Finished Importing record "+ animeRecord.ToString());
                    db.Save();
                }
                Console.WriteLine("Import complete");
                RefreshList();
            } else
            {
                Console.WriteLine("Import Aborted");
            }
        }

        private void import_fdr_btn_Click(object sender, EventArgs e)
        {
            titleList.Enabled = false;
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string rootPath =  folderBrowserDialog.SelectedPath;
                bulkOperationTitles = getTitles(rootPath);
                NextBulkItem();
            }
        }
        private void Skip(object sender, EventArgs e)
        {
            NextBulkItem();
        }
        private void Cancel(object sender, EventArgs e)
        {
            Cancel();
        }
        private void AddToDB(object sender, EventArgs e)
        {
            if (bulk_cbx.SelectedItem == null || string.IsNullOrEmpty(bulk_yeartxt.Text) || !UtillExtensions.IsNumeric(bulk_yeartxt.Text))
            {
                MessageBox.Show("Some Input values are missing for this record", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string season = bulk_cbx.SelectedItem.ToString();
            int year = int.Parse(bulk_yeartxt.Text);
            int rating = (int)bulk_rating_nud.Value;
            string title = bulk_titletxt.Text;
            int episodeCount = int.Parse(bulk_episode_count_lbl.Text);
            if (!db.Contains(title))
            {
                AnimeRecord record = new AnimeRecord(title, episodeCount);
                record.description = title;
                record.lastUpdate = DateTime.Now;
                record.SafeSetSeason(season);
                record.SafeSetYear(year); 
                record.rating = rating;
                db.Create(record);
            }
            NextBulkItem();
        }
        private IEnumerable<DirectoryInfo> getTitles (string rootPath)
        {
            DirectoryInfo dir = new DirectoryInfo(rootPath);
            return dir.EnumerateDirectories();
        }
        private void Cancel()
        {
            currentBulkIndex = 0;
            bulkOperationTitles = Array.Empty<DirectoryInfo>();
            titleList.Enabled = true;
            bulk_titletxt.Text = string.Empty;
            bulk_rating_nud.Value = 1;
            bulk_episode_count_lbl.Text = string.Empty;
            bulk_yeartxt.Text = string.Empty;
            bulk_cbx.Text = string.Empty;
            bulkop_lbl.Text = string.Empty;
            SyncDB();
        }
        private void SyncDB()
        {
            db.Save();
        }
        private void NextBulkItem()
        {
            int total = bulkOperationTitles.Count();
            bulkop_lbl.Text = string.Format("{0} of {1} items left to process", total-currentBulkIndex, total);
            if (bulkOperationTitles != null && currentBulkIndex < total)
            {
                DirectoryInfo title = bulkOperationTitles.ElementAt(currentBulkIndex);
                bulk_titletxt.Text = title.Name;
                bulk_episode_count_lbl.Text = title.EnumerateFiles().Count().ToString();
                currentBulkIndex++;
            } else
            {
                MessageBox.Show("All Items Processed", "Operation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cancel();
            }
            
        }
    }
    
     }
