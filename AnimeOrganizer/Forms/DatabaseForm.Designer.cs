namespace AnimeOrganizer
{
     partial class DatabaseForm
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
            this.bulktab = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bulk_rating_nud = new System.Windows.Forms.NumericUpDown();
            this.bulk_cbx = new System.Windows.Forms.ComboBox();
            this.bulkop_lbl = new System.Windows.Forms.Label();
            this.bulk_titletxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.addToDb_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.bulk_skipbtn = new System.Windows.Forms.Button();
            this.bulk_yeartxt = new System.Windows.Forms.TextBox();
            this.bulk_episode_count_lbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.import_fdr_btn = new System.Windows.Forms.Button();
            this.csv_importbtn = new System.Windows.Forms.Button();
            this.titleList = new System.Windows.Forms.CheckedListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menu1 = new AnimeOrganizer.menu();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.Homepanel.SuspendLayout();
            this.menutab.SuspendLayout();
            this.detailstab.SuspendLayout();
            this.detailspanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratingnum)).BeginInit();
            this.bulktab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bulk_rating_nud)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.menutab.Controls.Add(this.bulktab);
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
            this.titlelbl.Text = "Anime title";
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
            // bulktab
            // 
            this.bulktab.Controls.Add(this.groupBox2);
            this.bulktab.Controls.Add(this.groupBox1);
            this.bulktab.Location = new System.Drawing.Point(4, 22);
            this.bulktab.Name = "bulktab";
            this.bulktab.Padding = new System.Windows.Forms.Padding(3);
            this.bulktab.Size = new System.Drawing.Size(431, 293);
            this.bulktab.TabIndex = 1;
            this.bulktab.Text = "Bulk";
            this.bulktab.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bulk_rating_nud);
            this.groupBox2.Controls.Add(this.bulk_cbx);
            this.groupBox2.Controls.Add(this.bulkop_lbl);
            this.groupBox2.Controls.Add(this.bulk_titletxt);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.addToDb_btn);
            this.groupBox2.Controls.Add(this.cancel_btn);
            this.groupBox2.Controls.Add(this.bulk_skipbtn);
            this.groupBox2.Controls.Add(this.bulk_yeartxt);
            this.groupBox2.Controls.Add(this.bulk_episode_count_lbl);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(3, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 225);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bulk operation";
            // 
            // bulk_rating_nud
            // 
            this.bulk_rating_nud.Location = new System.Drawing.Point(72, 128);
            this.bulk_rating_nud.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.bulk_rating_nud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bulk_rating_nud.Name = "bulk_rating_nud";
            this.bulk_rating_nud.Size = new System.Drawing.Size(120, 20);
            this.bulk_rating_nud.TabIndex = 40;
            this.toolTip1.SetToolTip(this.bulk_rating_nud, "Rating from 1 to 10");
            this.bulk_rating_nud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bulk_cbx
            // 
            this.bulk_cbx.FormattingEnabled = true;
            this.bulk_cbx.Items.AddRange(new object[] {
            "Winter",
            "Spring",
            "Summer",
            "Fall"});
            this.bulk_cbx.Location = new System.Drawing.Point(72, 79);
            this.bulk_cbx.Name = "bulk_cbx";
            this.bulk_cbx.Size = new System.Drawing.Size(121, 21);
            this.bulk_cbx.TabIndex = 39;
            // 
            // bulkop_lbl
            // 
            this.bulkop_lbl.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bulkop_lbl.Location = new System.Drawing.Point(179, 170);
            this.bulkop_lbl.Name = "bulkop_lbl";
            this.bulkop_lbl.Size = new System.Drawing.Size(142, 49);
            this.bulkop_lbl.TabIndex = 38;
            this.bulkop_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bulk_titletxt
            // 
            this.bulk_titletxt.Location = new System.Drawing.Point(12, 30);
            this.bulk_titletxt.Multiline = true;
            this.bulk_titletxt.Name = "bulk_titletxt";
            this.bulk_titletxt.Size = new System.Drawing.Size(399, 28);
            this.bulk_titletxt.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(195, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Title";
            // 
            // addToDb_btn
            // 
            this.addToDb_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToDb_btn.Location = new System.Drawing.Point(327, 180);
            this.addToDb_btn.Name = "addToDb_btn";
            this.addToDb_btn.Size = new System.Drawing.Size(84, 31);
            this.addToDb_btn.TabIndex = 34;
            this.addToDb_btn.Text = "&AddToDB";
            this.addToDb_btn.UseVisualStyleBackColor = true;
            this.addToDb_btn.Click += new System.EventHandler(this.AddToDB);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.Location = new System.Drawing.Point(98, 179);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 31);
            this.cancel_btn.TabIndex = 34;
            this.cancel_btn.Text = "&Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.Cancel);
            // 
            // bulk_skipbtn
            // 
            this.bulk_skipbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bulk_skipbtn.Location = new System.Drawing.Point(15, 179);
            this.bulk_skipbtn.Name = "bulk_skipbtn";
            this.bulk_skipbtn.Size = new System.Drawing.Size(75, 31);
            this.bulk_skipbtn.TabIndex = 34;
            this.bulk_skipbtn.Text = "&Skip";
            this.bulk_skipbtn.UseVisualStyleBackColor = true;
            this.bulk_skipbtn.Click += new System.EventHandler(this.Skip);
            // 
            // bulk_yeartxt
            // 
            this.bulk_yeartxt.Location = new System.Drawing.Point(306, 83);
            this.bulk_yeartxt.Name = "bulk_yeartxt";
            this.bulk_yeartxt.Size = new System.Drawing.Size(100, 20);
            this.bulk_yeartxt.TabIndex = 29;
            // 
            // bulk_episode_count_lbl
            // 
            this.bulk_episode_count_lbl.AutoSize = true;
            this.bulk_episode_count_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bulk_episode_count_lbl.Location = new System.Drawing.Point(356, 135);
            this.bulk_episode_count_lbl.Name = "bulk_episode_count_lbl";
            this.bulk_episode_count_lbl.Size = new System.Drawing.Size(14, 13);
            this.bulk_episode_count_lbl.TabIndex = 27;
            this.bulk_episode_count_lbl.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(262, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Episode count:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(262, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Year";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Season";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Rating";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.import_fdr_btn);
            this.groupBox1.Controls.Add(this.csv_importbtn);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 50);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import";
            // 
            // import_fdr_btn
            // 
            this.import_fdr_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.import_fdr_btn.Location = new System.Drawing.Point(17, 19);
            this.import_fdr_btn.Name = "import_fdr_btn";
            this.import_fdr_btn.Size = new System.Drawing.Size(129, 25);
            this.import_fdr_btn.TabIndex = 2;
            this.import_fdr_btn.Text = "Import from folder";
            this.import_fdr_btn.UseVisualStyleBackColor = true;
            this.import_fdr_btn.Click += new System.EventHandler(this.import_fdr_btn_Click);
            // 
            // csv_importbtn
            // 
            this.csv_importbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csv_importbtn.Location = new System.Drawing.Point(288, 19);
            this.csv_importbtn.Name = "csv_importbtn";
            this.csv_importbtn.Size = new System.Drawing.Size(123, 25);
            this.csv_importbtn.TabIndex = 2;
            this.csv_importbtn.Text = "Import from csv";
            this.csv_importbtn.UseVisualStyleBackColor = true;
            this.csv_importbtn.Click += new System.EventHandler(this.csv_importbtn_Click);
            // 
            // titleList
            // 
            this.titleList.FormattingEnabled = true;
            this.titleList.Location = new System.Drawing.Point(13, 33);
            this.titleList.Name = "titleList";
            this.titleList.Size = new System.Drawing.Size(244, 319);
            this.titleList.Sorted = true;
            this.titleList.TabIndex = 10;
            this.titleList.SelectedIndexChanged += new System.EventHandler(this.titleList_SelectedIndexChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Information";
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.Color.Transparent;
            this.menu1.Location = new System.Drawing.Point(12, 3);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(682, 26);
            this.menu1.TabIndex = 32;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "csv files|*.csv";
            this.openFileDialog.Title = "Open csv file";
            // 
            // DatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 489);
            this.Controls.Add(this.menu1);
            this.Controls.Add(this.Homepanel);
            this.Controls.Add(this.label1);
            this.Name = "DatabaseForm";
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
            this.bulktab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bulk_rating_nud)).EndInit();
            this.groupBox1.ResumeLayout(false);
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
          private System.Windows.Forms.TabPage bulktab;
          private System.Windows.Forms.GroupBox groupBox2;
          private System.Windows.Forms.TextBox bulk_titletxt;
          private System.Windows.Forms.Label label6;
          private System.Windows.Forms.Button bulk_skipbtn;
          private System.Windows.Forms.TextBox bulk_yeartxt;
          private System.Windows.Forms.Label label3;
          private System.Windows.Forms.Label label5;
          private System.Windows.Forms.Label label7;
          private System.Windows.Forms.GroupBox groupBox1;
          private System.Windows.Forms.Button csv_importbtn;
        private menu menu1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button import_fdr_btn;
        private System.Windows.Forms.Label bulkop_lbl;
        private System.Windows.Forms.ComboBox bulk_cbx;
        private System.Windows.Forms.Button addToDb_btn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.NumericUpDown bulk_rating_nud;
        private System.Windows.Forms.Label bulk_episode_count_lbl;
        private System.Windows.Forms.Label label8;
    }
}

