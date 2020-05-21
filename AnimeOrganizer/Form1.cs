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

          private void linkLabel1_Click(object sender, EventArgs e)
          {
               db.Serialize();
               new Form2().Show();
               this.Hide();
          }
     }
    
     }
