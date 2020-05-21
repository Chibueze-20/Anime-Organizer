namespace AnimeOrganizer
{
     partial class Form1
     {
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;

          /// <summary>
          /// Clean up any resources being used.
          /// </summary>
          /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }

          #region Windows Form Designer generated code

          /// <summary>
          /// Required method for Designer support - do not modify
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent()
          {
               this.components = new System.ComponentModel.Container();
               this.label1 = new System.Windows.Forms.Label();
               this.Homepanel = new System.Windows.Forms.Panel();
               this.viewlbl = new System.Windows.Forms.Label();
               this.label12 = new System.Windows.Forms.Label();
               this.menutab = new System.Windows.Forms.TabControl();
               this.detailstab = new System.Windows.Forms.TabPage();
               this.detailspanel = new System.Windows.Forms.Panel();
               this.deletebtn = new System.Windows.Forms.Button();
               this.updatebtn = new System.Windows.Forms.Button();
               this.ratingnum = new System.Windows.Forms.NumericUpDown();
               this.descriptionrtxt = new System.Windows.Forms.RichTextBox();
               this.yeartxt = new System.Windows.Forms.TextBox();
               this.seasontxt = new System.Windows.Forms.TextBox();
               this.label14 = new System.Windows.Forms.Label();
               this.label13 = new System.Windows.Forms.Label();
               this.episodelbl = new System.Windows.Forms.Label();
               this.label10 = new System.Windows.Forms.Label();
               this.label9 = new System.Windows.Forms.Label();
               this.label4 = new System.Windows.Forms.Label();
               this.titlelbl = new System.Windows.Forms.Label();
               this.label2 = new System.Windows.Forms.Label();
               this.titleList = new System.Windows.Forms.CheckedListBox();
               this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
               this.linkLabel1 = new System.Windows.Forms.LinkLabel();
               this.Homepanel.SuspendLayout();
               this.menutab.SuspendLayout();
               this.detailstab.SuspendLayout();
               this.detailspanel.SuspendLayout();
               ((System.ComponentModel.ISupportInitialize)(this.ratingnum)).BeginInit();
               this.SuspendLayout();
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 54F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label1.Location = new System.Drawing.Point(157, 16);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(469, 85);
               this.label1.TabIndex = 1;
               this.label1.Text = "Anime Organizer";
               // 
               // Homepanel
               // 
               this.Homepanel.Controls.Add(this.viewlbl);
               this.Homepanel.Controls.Add(this.label12);
               this.Homepanel.Controls.Add(this.menutab);
               this.Homepanel.Controls.Add(this.titleList);
               this.Homepanel.Location = new System.Drawing.Point(12, 108);
               this.Homepanel.Name = "Homepanel";
               this.Homepanel.Size = new System.Drawing.Size(743, 369);
               this.Homepanel.TabIndex = 2;
               // 
               // viewlbl
               // 
               this.viewlbl.AutoSize = true;
               this.viewlbl.Font = new System.Drawing.Font("OCR A Extended", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.viewlbl.Location = new System.Drawing.Point(93, 14);
               this.viewlbl.Name = "viewlbl";
               this.viewlbl.Size = new System.Drawing.Size(71, 13);
               this.viewlbl.TabIndex = 12;
               this.viewlbl.Text = "Database";
               this.viewlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // label12
               // 
               this.label12.AutoSize = true;
               this.label12.Location = new System.Drawing.Point(13, 14);
               this.label12.Name = "label12";
               this.label12.Size = new System.Drawing.Size(70, 13);
               this.label12.TabIndex = 12;
               this.label12.Text = "Current View:";
               // 
               // menutab
               // 
               this.menutab.Controls.Add(this.detailstab);
               this.menutab.Location = new System.Drawing.Point(284, 33);
               this.menutab.Name = "menutab";
               this.menutab.SelectedIndex = 0;
               this.menutab.Size = new System.Drawing.Size(439, 319);
               this.menutab.TabIndex = 11;
               // 
               // detailstab
               // 
               this.detailstab.Controls.Add(this.detailspanel);
               this.detailstab.Location = new System.Drawing.Point(4, 22);
               this.detailstab.Name = "detailstab";
               this.detailstab.Padding = new System.Windows.Forms.Padding(3);
               this.detailstab.Size = new System.Drawing.Size(431, 293);
               this.detailstab.TabIndex = 0;
               this.detailstab.Text = "Details";
               this.detailstab.ToolTipText = "Organize";
               this.detailstab.UseVisualStyleBackColor = true;
               // 
               // detailspanel
               // 
               this.detailspanel.Controls.Add(this.deletebtn);
               this.detailspanel.Controls.Add(this.updatebtn);
               this.detailspanel.Controls.Add(this.ratingnum);
               this.detailspanel.Controls.Add(this.descriptionrtxt);
               this.detailspanel.Controls.Add(this.yeartxt);
               this.detailspanel.Controls.Add(this.seasontxt);
               this.detailspanel.Controls.Add(this.label14);
               this.detailspanel.Controls.Add(this.label13);
               this.detailspanel.Controls.Add(this.episodelbl);
               this.detailspanel.Controls.Add(this.label10);
               this.detailspanel.Controls.Add(this.label9);
               this.detailspanel.Controls.Add(this.label4);
               this.detailspanel.Controls.Add(this.titlelbl);
               this.detailspanel.Controls.Add(this.label2);
               this.detailspanel.Location = new System.Drawing.Point(6, 6);
               this.detailspanel.Name = "detailspanel";
               this.detailspanel.Size = new System.Drawing.Size(419, 281);
               this.detailspanel.TabIndex = 18;
               // 
               // deletebtn
               // 
               this.deletebtn.BackColor = System.Drawing.Color.Red;
               this.deletebtn.FlatAppearance.BorderSize = 0;
               this.deletebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
               this.deletebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.deletebtn.Location = new System.Drawing.Point(322, 238);
               this.deletebtn.Name = "deletebtn";
               this.deletebtn.Size = new System.Drawing.Size(75, 23);
               this.deletebtn.TabIndex = 13;
               this.deletebtn.Text = "Delete";
               this.deletebtn.UseVisualStyleBackColor = false;
               this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
               // 
               // updatebtn
               // 
               this.updatebtn.BackColor = System.Drawing.Color.LawnGreen;
               this.updatebtn.FlatAppearance.BorderSize = 0;
               this.updatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
               this.updatebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.updatebtn.Location = new System.Drawing.Point(322, 190);
               this.updatebtn.Name = "updatebtn";
               this.updatebtn.Size = new System.Drawing.Size(75, 23);
               this.updatebtn.TabIndex = 12;
               this.updatebtn.Text = "Update";
               this.updatebtn.UseVisualStyleBackColor = false;
               this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
               // 
               // ratingnum
               // 
               this.ratingnum.Location = new System.Drawing.Point(87, 144);
               this.ratingnum.Name = "ratingnum";
               this.ratingnum.Size = new System.Drawing.Size(120, 20);
               this.ratingnum.TabIndex = 11;
               // 
               // descriptionrtxt
               // 
               this.descriptionrtxt.Location = new System.Drawing.Point(87, 184);
               this.descriptionrtxt.Name = "descriptionrtxt";
               this.descriptionrtxt.Size = new System.Drawing.Size(196, 83);
               this.descriptionrtxt.TabIndex = 10;
               this.descriptionrtxt.Text = "";
               // 
               // yeartxt
               // 
               this.yeartxt.Location = new System.Drawing.Point(311, 141);
               this.yeartxt.Name = "yeartxt";
               this.yeartxt.Size = new System.Drawing.Size(100, 20);
               this.yeartxt.TabIndex = 9;
               // 
               // seasontxt
               // 
               this.seasontxt.Location = new System.Drawing.Point(311, 103);
               this.seasontxt.Name = "seasontxt";
               this.seasontxt.Size = new System.Drawing.Size(100, 20);
               this.seasontxt.TabIndex = 8;
               // 
               // label14
               // 
               this.label14.AutoSize = true;
               this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label14.Location = new System.Drawing.Point(267, 145);
               this.label14.Name = "label14";
               this.label14.Size = new System.Drawing.Size(33, 13);
               this.label14.TabIndex = 7;
               this.label14.Text = "Year";
               // 
               // label13
               // 
               this.label13.AutoSize = true;
               this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label13.Location = new System.Drawing.Point(260, 107);
               this.label13.Name = "label13";
               this.label13.Size = new System.Drawing.Size(49, 13);
               this.label13.TabIndex = 6;
               this.label13.Text = "Season";
               // 
               // episodelbl
               // 
               this.episodelbl.AutoSize = true;
               this.episodelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.episodelbl.Location = new System.Drawing.Point(148, 98);
               this.episodelbl.Name = "episodelbl";
               this.episodelbl.Size = new System.Drawing.Size(14, 13);
               this.episodelbl.TabIndex = 5;
               this.episodelbl.Text = "0";
               // 
               // label10
               // 
               this.label10.AutoSize = true;
               this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label10.Location = new System.Drawing.Point(17, 184);
               this.label10.Name = "label10";
               this.label10.Size = new System.Drawing.Size(71, 13);
               this.label10.TabIndex = 4;
               this.label10.Text = "Description";
               // 
               // label9
               // 
               this.label9.AutoSize = true;
               this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label9.Location = new System.Drawing.Point(17, 144);
               this.label9.Name = "label9";
               this.label9.Size = new System.Drawing.Size(44, 13);
               this.label9.TabIndex = 3;
               this.label9.Text = "Rating";
               // 
               // label4
               // 
               this.label4.AutoSize = true;
               this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label4.Location = new System.Drawing.Point(17, 98);
               this.label4.Name = "label4";
               this.label4.Size = new System.Drawing.Size(119, 13);
               this.label4.TabIndex = 2;
               this.label4.Text = "Number of episodes";
               // 
               // titlelbl
               // 
               this.titlelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.titlelbl.Location = new System.Drawing.Point(53, 46);
               this.titlelbl.Name = "titlelbl";
               this.titlelbl.Size = new System.Drawing.Size(195, 23);
               this.titlelbl.TabIndex = 1;
               this.titlelbl.Text = "xxiitthd";
               this.titlelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // label2
               // 
               this.label2.AutoSize = true;
               this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label2.Location = new System.Drawing.Point(15, 51);
               this.label2.Name = "label2";
               this.label2.Size = new System.Drawing.Size(32, 13);
               this.label2.TabIndex = 0;
               this.label2.Text = "Title";
               // 
               // titleList
               // 
               this.titleList.FormattingEnabled = true;
               this.titleList.Location = new System.Drawing.Point(13, 33);
               this.titleList.Name = "titleList";
               this.titleList.Size = new System.Drawing.Size(244, 319);
               this.titleList.TabIndex = 10;
               this.titleList.SelectedIndexChanged += new System.EventHandler(this.titleList_SelectedIndexChanged);
               // 
               // toolTip1
               // 
               this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
               this.toolTip1.ToolTipTitle = "Information";
               // 
               // linkLabel1
               // 
               this.linkLabel1.AutoSize = true;
               this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
               this.linkLabel1.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.linkLabel1.LinkColor = System.Drawing.Color.Black;
               this.linkLabel1.Location = new System.Drawing.Point(3, 3);
               this.linkLabel1.Name = "linkLabel1";
               this.linkLabel1.Size = new System.Drawing.Size(173, 17);
               this.linkLabel1.TabIndex = 30;
               this.linkLabel1.TabStop = true;
               this.linkLabel1.Text = "Go to Organizer";
               this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Black;
               this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
               // 
               // Form1
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(779, 489);
               this.Controls.Add(this.linkLabel1);
               this.Controls.Add(this.Homepanel);
               this.Controls.Add(this.label1);
               this.Name = "Form1";
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "Form1";
               this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
               this.Homepanel.ResumeLayout(false);
               this.Homepanel.PerformLayout();
               this.menutab.ResumeLayout(false);
               this.detailstab.ResumeLayout(false);
               this.detailspanel.ResumeLayout(false);
               this.detailspanel.PerformLayout();
               ((System.ComponentModel.ISupportInitialize)(this.ratingnum)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.Panel Homepanel;
          private System.Windows.Forms.CheckedListBox titleList;
          private System.Windows.Forms.TabControl menutab;
          private System.Windows.Forms.TabPage detailstab;
          private System.Windows.Forms.Panel detailspanel;
          private System.Windows.Forms.Label viewlbl;
          private System.Windows.Forms.Label label12;
          private System.Windows.Forms.ToolTip toolTip1;
          private System.Windows.Forms.Label titlelbl;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.Label episodelbl;
          private System.Windows.Forms.Label label10;
          private System.Windows.Forms.Label label9;
          private System.Windows.Forms.Label label4;
          private System.Windows.Forms.Button deletebtn;
          private System.Windows.Forms.Button updatebtn;
          private System.Windows.Forms.NumericUpDown ratingnum;
          private System.Windows.Forms.RichTextBox descriptionrtxt;
          private System.Windows.Forms.TextBox yeartxt;
          private System.Windows.Forms.TextBox seasontxt;
          private System.Windows.Forms.Label label14;
          private System.Windows.Forms.Label label13;
          private System.Windows.Forms.LinkLabel linkLabel1;
     }
}

