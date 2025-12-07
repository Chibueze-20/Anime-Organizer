namespace AnimeOrganizer
{
     partial class Organizer
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
            this.foldertree = new System.Windows.Forms.TreeView();
            this.viewlbl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.seasontxt = new System.Windows.Forms.TextBox();
            this.updatebtn = new System.Windows.Forms.Button();
            this.descriptionRtx = new System.Windows.Forms.RichTextBox();
            this.ratingNud = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.epdownloadedlbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.titlelbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Renamepanel = new System.Windows.Forms.Panel();
            this.foldernamecbx = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.episoderbtn = new System.Windows.Forms.RadioButton();
            this.dashrbtn = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.folderlbl = new System.Windows.Forms.Label();
            this.startbtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.filenametxt = new System.Windows.Forms.TextBox();
            this.epsodeselectorgbx = new System.Windows.Forms.GroupBox();
            this.nextbtn = new System.Windows.Forms.Button();
            this.stopbtn = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clearbtn = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.episodelbl = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.currentlbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menu1 = new AnimeOrganizer.menu();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratingNud)).BeginInit();
            this.Renamepanel.SuspendLayout();
            this.epsodeselectorgbx.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // foldertree
            // 
            this.foldertree.Location = new System.Drawing.Point(24, 119);
            this.foldertree.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.foldertree.Name = "foldertree";
            this.foldertree.Size = new System.Drawing.Size(612, 808);
            this.foldertree.TabIndex = 0;
            this.foldertree.TabStop = false;
            this.foldertree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.foldertree_AfterSelect);
            // 
            // viewlbl
            // 
            this.viewlbl.AutoSize = true;
            this.viewlbl.Font = new System.Drawing.Font("OCR A Extended", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewlbl.Location = new System.Drawing.Point(190, 87);
            this.viewlbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.viewlbl.Name = "viewlbl";
            this.viewlbl.Size = new System.Drawing.Size(222, 25);
            this.viewlbl.TabIndex = 13;
            this.viewlbl.Text = "Bulk Organizer";
            this.viewlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 87);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(141, 25);
            this.label12.TabIndex = 14;
            this.label12.Text = "Current View:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.seasontxt);
            this.groupBox1.Controls.Add(this.updatebtn);
            this.groupBox1.Controls.Add(this.descriptionRtx);
            this.groupBox1.Controls.Add(this.ratingNud);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.epdownloadedlbl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.titlelbl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1338, 119);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(752, 523);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(516, 254);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "input format (season,year)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 254);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Season details";
            // 
            // seasontxt
            // 
            this.seasontxt.Location = new System.Drawing.Point(274, 242);
            this.seasontxt.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.seasontxt.Name = "seasontxt";
            this.seasontxt.Size = new System.Drawing.Size(224, 31);
            this.seasontxt.TabIndex = 9;
            this.seasontxt.TabStop = false;
            this.toolTip1.SetToolTip(this.seasontxt, "Season,Year");
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(282, 465);
            this.updatebtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(232, 48);
            this.updatebtn.TabIndex = 8;
            this.updatebtn.TabStop = false;
            this.updatebtn.Text = "Update Database";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // descriptionRtx
            // 
            this.descriptionRtx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descriptionRtx.Location = new System.Drawing.Point(32, 337);
            this.descriptionRtx.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.descriptionRtx.Name = "descriptionRtx";
            this.descriptionRtx.Size = new System.Drawing.Size(708, 119);
            this.descriptionRtx.TabIndex = 7;
            this.descriptionRtx.TabStop = false;
            this.descriptionRtx.Text = "";
            this.toolTip1.SetToolTip(this.descriptionRtx, "Description of anime");
            // 
            // ratingNud
            // 
            this.ratingNud.Location = new System.Drawing.Point(274, 171);
            this.ratingNud.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ratingNud.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ratingNud.Name = "ratingNud";
            this.ratingNud.Size = new System.Drawing.Size(228, 31);
            this.ratingNud.TabIndex = 6;
            this.ratingNud.TabStop = false;
            this.ratingNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.ratingNud, "1-10");
            this.ratingNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 304);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(208, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Personal description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 187);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Personal Rating";
            // 
            // epdownloadedlbl
            // 
            this.epdownloadedlbl.AutoSize = true;
            this.epdownloadedlbl.Location = new System.Drawing.Point(268, 108);
            this.epdownloadedlbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.epdownloadedlbl.Name = "epdownloadedlbl";
            this.epdownloadedlbl.Size = new System.Drawing.Size(101, 25);
            this.epdownloadedlbl.TabIndex = 3;
            this.epdownloadedlbl.Text = "Episodes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Episodes downloaded";
            // 
            // titlelbl
            // 
            this.titlelbl.AutoSize = true;
            this.titlelbl.Location = new System.Drawing.Point(268, 42);
            this.titlelbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.titlelbl.Name = "titlelbl";
            this.titlelbl.Size = new System.Drawing.Size(112, 25);
            this.titlelbl.TabIndex = 1;
            this.titlelbl.Text = "Anime title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // Renamepanel
            // 
            this.Renamepanel.Controls.Add(this.foldernamecbx);
            this.Renamepanel.Controls.Add(this.label9);
            this.Renamepanel.Controls.Add(this.episoderbtn);
            this.Renamepanel.Controls.Add(this.dashrbtn);
            this.Renamepanel.Controls.Add(this.label7);
            this.Renamepanel.Controls.Add(this.folderlbl);
            this.Renamepanel.Controls.Add(this.startbtn);
            this.Renamepanel.Controls.Add(this.label10);
            this.Renamepanel.Controls.Add(this.filenametxt);
            this.Renamepanel.Location = new System.Drawing.Point(702, 119);
            this.Renamepanel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Renamepanel.Name = "Renamepanel";
            this.Renamepanel.Size = new System.Drawing.Size(598, 523);
            this.Renamepanel.TabIndex = 19;
            // 
            // foldernamecbx
            // 
            this.foldernamecbx.AutoSize = true;
            this.foldernamecbx.Location = new System.Drawing.Point(372, 85);
            this.foldernamecbx.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.foldernamecbx.Name = "foldernamecbx";
            this.foldernamecbx.Size = new System.Drawing.Size(211, 29);
            this.foldernamecbx.TabIndex = 27;
            this.foldernamecbx.TabStop = false;
            this.foldernamecbx.Text = "Use Folder Name";
            this.foldernamecbx.UseVisualStyleBackColor = true;
            this.foldernamecbx.CheckedChanged += new System.EventHandler(this.checkbox_select);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(252, 225);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 25);
            this.label9.TabIndex = 26;
            this.label9.Text = "Episode style";
            // 
            // episoderbtn
            // 
            this.episoderbtn.AutoSize = true;
            this.episoderbtn.Location = new System.Drawing.Point(134, 298);
            this.episoderbtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.episoderbtn.Name = "episoderbtn";
            this.episoderbtn.Size = new System.Drawing.Size(119, 29);
            this.episoderbtn.TabIndex = 25;
            this.episoderbtn.Text = "episode";
            this.episoderbtn.UseVisualStyleBackColor = true;
            this.episoderbtn.CheckedChanged += new System.EventHandler(this.episoderbtn_CheckedChanged);
            // 
            // dashrbtn
            // 
            this.dashrbtn.AutoSize = true;
            this.dashrbtn.Location = new System.Drawing.Point(406, 298);
            this.dashrbtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dashrbtn.Name = "dashrbtn";
            this.dashrbtn.Size = new System.Drawing.Size(90, 29);
            this.dashrbtn.TabIndex = 25;
            this.dashrbtn.Text = "dash";
            this.dashrbtn.UseVisualStyleBackColor = true;
            this.dashrbtn.CheckedChanged += new System.EventHandler(this.dashrbtn_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 94);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 25);
            this.label7.TabIndex = 24;
            this.label7.Text = "Title";
            // 
            // folderlbl
            // 
            this.folderlbl.AutoSize = true;
            this.folderlbl.Location = new System.Drawing.Point(210, 15);
            this.folderlbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.folderlbl.Name = "folderlbl";
            this.folderlbl.Size = new System.Drawing.Size(196, 25);
            this.folderlbl.TabIndex = 11;
            this.folderlbl.Text = "No Folder Selected";
            // 
            // startbtn
            // 
            this.startbtn.Location = new System.Drawing.Point(236, 440);
            this.startbtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.startbtn.Name = "startbtn";
            this.startbtn.Size = new System.Drawing.Size(172, 44);
            this.startbtn.TabIndex = 20;
            this.startbtn.TabStop = false;
            this.startbtn.Text = "Start";
            this.toolTip1.SetToolTip(this.startbtn, "start organization process");
            this.startbtn.UseVisualStyleBackColor = true;
            this.startbtn.Click += new System.EventHandler(this.startbtn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 15);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 25);
            this.label10.TabIndex = 9;
            this.label10.Text = "Selected folder:";
            // 
            // filenametxt
            // 
            this.filenametxt.Location = new System.Drawing.Point(42, 133);
            this.filenametxt.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.filenametxt.Multiline = true;
            this.filenametxt.Name = "filenametxt";
            this.filenametxt.Size = new System.Drawing.Size(360, 41);
            this.filenametxt.TabIndex = 18;
            this.filenametxt.TabStop = false;
            this.filenametxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.filenametxt.TextChanged += new System.EventHandler(this.filenametxt_TextChanged);
            // 
            // epsodeselectorgbx
            // 
            this.epsodeselectorgbx.Controls.Add(this.nextbtn);
            this.epsodeselectorgbx.Controls.Add(this.stopbtn);
            this.epsodeselectorgbx.Controls.Add(this.label15);
            this.epsodeselectorgbx.Controls.Add(this.panel1);
            this.epsodeselectorgbx.Controls.Add(this.episodelbl);
            this.epsodeselectorgbx.Controls.Add(this.label14);
            this.epsodeselectorgbx.Controls.Add(this.currentlbl);
            this.epsodeselectorgbx.Controls.Add(this.label8);
            this.epsodeselectorgbx.Location = new System.Drawing.Point(702, 654);
            this.epsodeselectorgbx.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.epsodeselectorgbx.Name = "epsodeselectorgbx";
            this.epsodeselectorgbx.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.epsodeselectorgbx.Size = new System.Drawing.Size(1388, 279);
            this.epsodeselectorgbx.TabIndex = 20;
            this.epsodeselectorgbx.TabStop = false;
            this.epsodeselectorgbx.Text = "Episode Selector";
            // 
            // nextbtn
            // 
            this.nextbtn.Location = new System.Drawing.Point(882, 225);
            this.nextbtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nextbtn.Name = "nextbtn";
            this.nextbtn.Size = new System.Drawing.Size(150, 44);
            this.nextbtn.TabIndex = 6;
            this.nextbtn.TabStop = false;
            this.nextbtn.Text = "Next";
            this.nextbtn.UseVisualStyleBackColor = true;
            this.nextbtn.Click += new System.EventHandler(this.nextbtn_Click);
            // 
            // stopbtn
            // 
            this.stopbtn.Location = new System.Drawing.Point(38, 221);
            this.stopbtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.stopbtn.Name = "stopbtn";
            this.stopbtn.Size = new System.Drawing.Size(150, 44);
            this.stopbtn.TabIndex = 6;
            this.stopbtn.TabStop = false;
            this.stopbtn.Text = "Stop";
            this.stopbtn.UseVisualStyleBackColor = true;
            this.stopbtn.Click += new System.EventHandler(this.stopbtn_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(672, 23);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(225, 25);
            this.label15.TabIndex = 5;
            this.label15.Text = "Enter Episode number";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.clearbtn);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.button11);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(636, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(742, 160);
            this.panel1.TabIndex = 4;
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(656, 88);
            this.clearbtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(80, 54);
            this.clearbtn.TabIndex = 11;
            this.clearbtn.TabStop = false;
            this.clearbtn.Text = "cls";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(394, 96);
            this.button9.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(80, 54);
            this.button9.TabIndex = 10;
            this.button9.TabStop = false;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.numpad_click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(316, 96);
            this.button10.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(80, 54);
            this.button10.TabIndex = 9;
            this.button10.TabStop = false;
            this.button10.Text = "8";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.numpad_click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(236, 96);
            this.button11.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(82, 54);
            this.button11.TabIndex = 8;
            this.button11.TabStop = false;
            this.button11.Text = "7";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.numpad_click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(552, 13);
            this.button6.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(80, 54);
            this.button6.TabIndex = 7;
            this.button6.TabStop = false;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.numpad_click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(472, 13);
            this.button7.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(82, 54);
            this.button7.TabIndex = 6;
            this.button7.TabStop = false;
            this.button7.Text = "5";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.numpad_click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(394, 13);
            this.button8.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(80, 54);
            this.button8.TabIndex = 5;
            this.button8.TabStop = false;
            this.button8.Text = "4";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.numpad_click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(316, 13);
            this.button4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 54);
            this.button4.TabIndex = 3;
            this.button4.TabStop = false;
            this.button4.Text = "3";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.numpad_click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(236, 13);
            this.button5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 54);
            this.button5.TabIndex = 2;
            this.button5.TabStop = false;
            this.button5.Text = "2";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.numpad_click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(158, 13);
            this.button3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 54);
            this.button3.TabIndex = 1;
            this.button3.TabStop = false;
            this.button3.Text = "1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.numpad_click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(78, 13);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 54);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Text = "0";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.numpad_click);
            // 
            // episodelbl
            // 
            this.episodelbl.AutoSize = true;
            this.episodelbl.Location = new System.Drawing.Point(210, 171);
            this.episodelbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.episodelbl.Name = "episodelbl";
            this.episodelbl.Size = new System.Drawing.Size(193, 25);
            this.episodelbl.TabIndex = 3;
            this.episodelbl.Text = "select from keypad";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(30, 171);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(168, 25);
            this.label14.TabIndex = 2;
            this.label14.Text = "Episode number";
            // 
            // currentlbl
            // 
            this.currentlbl.Location = new System.Drawing.Point(162, 54);
            this.currentlbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.currentlbl.Name = "currentlbl";
            this.currentlbl.Size = new System.Drawing.Size(462, 102);
            this.currentlbl.TabIndex = 1;
            this.currentlbl.Text = "episode current name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 54);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Current File";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(676, 10);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(483, 91);
            this.label16.TabIndex = 28;
            this.label16.Text = "Anime Organizer";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.Color.Transparent;
            this.menu1.Location = new System.Drawing.Point(24, 10);
            this.menu1.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(616, 50);
            this.menu1.TabIndex = 29;
            // 
            // Organizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2114, 950);
            this.Controls.Add(this.menu1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.epsodeselectorgbx);
            this.Controls.Add(this.Renamepanel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.viewlbl);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.foldertree);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Organizer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anime Organizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratingNud)).EndInit();
            this.Renamepanel.ResumeLayout(false);
            this.Renamepanel.PerformLayout();
            this.epsodeselectorgbx.ResumeLayout(false);
            this.epsodeselectorgbx.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.TreeView foldertree;
          private System.Windows.Forms.Label viewlbl;
          private System.Windows.Forms.Label label12;
          private System.Windows.Forms.GroupBox groupBox1;
          private System.Windows.Forms.Button updatebtn;
          private System.Windows.Forms.RichTextBox descriptionRtx;
          private System.Windows.Forms.NumericUpDown ratingNud;
          private System.Windows.Forms.Label label6;
          private System.Windows.Forms.Label label5;
          private System.Windows.Forms.Label epdownloadedlbl;
          private System.Windows.Forms.Label label3;
          private System.Windows.Forms.Label titlelbl;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.Panel Renamepanel;
          private System.Windows.Forms.Label label9;
          private System.Windows.Forms.RadioButton episoderbtn;
          private System.Windows.Forms.RadioButton dashrbtn;
          private System.Windows.Forms.Label label7;
          private System.Windows.Forms.Label folderlbl;
          private System.Windows.Forms.Button startbtn;
          private System.Windows.Forms.Label label10;
          private System.Windows.Forms.TextBox filenametxt;
          private System.Windows.Forms.GroupBox epsodeselectorgbx;
          private System.Windows.Forms.Label label15;
          private System.Windows.Forms.Panel panel1;
          private System.Windows.Forms.Button button9;
          private System.Windows.Forms.Button button10;
          private System.Windows.Forms.Button button11;
          private System.Windows.Forms.Button button6;
          private System.Windows.Forms.Button button7;
          private System.Windows.Forms.Button button8;
          private System.Windows.Forms.Button button4;
          private System.Windows.Forms.Button button5;
          private System.Windows.Forms.Button button3;
          private System.Windows.Forms.Button button2;
          private System.Windows.Forms.Label episodelbl;
          private System.Windows.Forms.Label label14;
          private System.Windows.Forms.Label currentlbl;
          private System.Windows.Forms.Label label8;
          private System.Windows.Forms.Label label16;
          private System.Windows.Forms.CheckBox foldernamecbx;
          private System.Windows.Forms.Button clearbtn;
          private System.Windows.Forms.Button nextbtn;
          private System.Windows.Forms.Button stopbtn;
          private System.Windows.Forms.Label label4;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.TextBox seasontxt;
          private System.Windows.Forms.ToolTip toolTip1;
          private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private menu menu1;
    }
}