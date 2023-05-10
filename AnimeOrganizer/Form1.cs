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
          private AnimeDB db;
          private AnimeRecord currentRecord;
          public Form1()
          {
               InitializeComponent();
            menu1.AddOpenMenuOption("Auto Organizer", OpenAutoOrganizerEvent);
            menu1.AddOpenMenuOption("Organizer", OpenOrganizerEvent);
            menu1.AddMenuOption("Export Database to CSV", ExportToCsv);
               db = AnimeDB.Deserialize();
               fill();
          }
          public void fill()
          {
               foreach (string title in db)
               {
                    titleList.Items.Add(title, false);
               }
          }
          
          private void showRecord(AnimeRecord record)
          {
               titlelbl.Text = record.Title;
               episodelbl.Text = record.EpisodeCount.ToString();
               ratingnum.Value = record.Rating;
               descriptionrtxt.Text = record.Description;
               yeartxt.Text = record.Year.HasValue? record.Year.Value.ToString():"";
               seasontxt.Text = record.Season;

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
               db.Serialize();
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
               currentRecord.Description = descriptionrtxt.Text;
               currentRecord.Rating = (int)ratingnum.Value;
               currentRecord.Season = seasontxt.Text;
               try
               {
                    currentRecord.Year = int.Parse(yeartxt.Text == "" ? "0" : yeartxt.Text);
               }
               catch (Exception)
               {

                    currentRecord.Year = null;
               }
               db.Update(currentRecord);
               //currentRecord = db[currentRecord.Title];
               //showRecord(currentRecord);
               MessageBox.Show("Record sucessfully updated");
          }

          private void deletebtn_Click(object sender, EventArgs e)
          {
               db.Delete(currentRecord);
               clearRecord();
               titleList.Items.Clear();
               fill();
               MessageBox.Show("Record deleted sucesssfully");
          }

          private void OpenOrganizerEvent(object sender, EventArgs e)
          {
               db.Serialize();
               new Form2().Show();
               this.Hide();
          }
        private void OpenAutoOrganizerEvent(object sender, EventArgs e)
        {
            db.Serialize();
            new Form3(db).Show();
            this.Hide();
        }
        private void ExportToCsv(object sender, EventArgs e)
        {
            List<string> lines = new List<string>();
            lines.Add("Title,Description,Rating,Episode Count,Season,Year,Last Updated");
            foreach (var anime in db)
            {
                string line = string.Format("{0},{1},{2:D},{3:D},{4},{5:D},{6:MM-dd-yyyy HH:mm:ss}", 
                    UtillExtensions.RemoveCommas(db[anime].Title), UtillExtensions.RemoveCommas(db[anime].Description), 
                    db[anime].Rating, db[anime].EpisodeCount, db[anime].Season, db[anime].Year, 
                    db[anime].LastUpdated);
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
    }
    
     }
