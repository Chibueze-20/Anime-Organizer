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
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
               this.toolStrip1 = new System.Windows.Forms.ToolStrip();
               this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
               this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.indexFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.rootPrefixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.noRootPrefixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.animeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.OngoingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.planToWatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.organizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
               this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
               this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
               this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
               this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
               this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
               this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
               this.label1 = new System.Windows.Forms.Label();
               this.Homepanel = new System.Windows.Forms.Panel();
               this.viewlbl = new System.Windows.Forms.Label();
               this.label12 = new System.Windows.Forms.Label();
               this.menutab = new System.Windows.Forms.TabControl();
               this.organizetab = new System.Windows.Forms.TabPage();
               this.Renamepanel = new System.Windows.Forms.Panel();
               this.label3 = new System.Windows.Forms.Label();
               this.episodenud = new System.Windows.Forms.NumericUpDown();
               this.label4 = new System.Windows.Forms.Label();
               this.filenamecbx = new System.Windows.Forms.ComboBox();
               this.folderlbl = new System.Windows.Forms.Label();
               this.renamebtn = new System.Windows.Forms.Button();
               this.label2 = new System.Windows.Forms.Label();
               this.foldercb = new System.Windows.Forms.CheckBox();
               this.filenametxt = new System.Windows.Forms.TextBox();
               this.managetab = new System.Windows.Forms.TabPage();
               this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
               this.label5 = new System.Windows.Forms.Label();
               this.titletxt = new System.Windows.Forms.TextBox();
               this.modifyongoingbtn = new System.Windows.Forms.Button();
               this.modifyplanningbtn = new System.Windows.Forms.Button();
               this.ongoingcnt = new System.Windows.Forms.Label();
               this.planningcnt = new System.Windows.Forms.Label();
               this.allcnt = new System.Windows.Forms.Label();
               this.label6 = new System.Windows.Forms.Label();
               this.label7 = new System.Windows.Forms.Label();
               this.label8 = new System.Windows.Forms.Label();
               this.fileList = new System.Windows.Forms.CheckedListBox();
               this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
               this.OFileDialog = new System.Windows.Forms.OpenFileDialog();
               this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
               this.dashrbtn = new System.Windows.Forms.RadioButton();
               this.episoderbtn = new System.Windows.Forms.RadioButton();
               this.label9 = new System.Windows.Forms.Label();
               this.toolStrip1.SuspendLayout();
               this.Homepanel.SuspendLayout();
               this.menutab.SuspendLayout();
               this.organizetab.SuspendLayout();
               this.Renamepanel.SuspendLayout();
               ((System.ComponentModel.ISupportInitialize)(this.episodenud)).BeginInit();
               this.managetab.SuspendLayout();
               this.tableLayoutPanel1.SuspendLayout();
               this.SuspendLayout();
               // 
               // toolStrip1
               // 
               this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator2,
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.toolStripSeparator1,
            this.helpToolStripButton});
               this.toolStrip1.Location = new System.Drawing.Point(0, 0);
               this.toolStrip1.Name = "toolStrip1";
               this.toolStrip1.Size = new System.Drawing.Size(779, 25);
               this.toolStrip1.TabIndex = 0;
               this.toolStrip1.Text = "toolStrip1";
               // 
               // toolStripDropDownButton1
               // 
               this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFolderToolStripMenuItem,
            this.indexFolderToolStripMenuItem,
            this.viewToolStripMenuItem});
               this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
               this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
               this.toolStripDropDownButton1.Size = new System.Drawing.Size(69, 22);
               this.toolStripDropDownButton1.Text = "&Home";
               this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
               // 
               // openFileToolStripMenuItem
               // 
               this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
               this.openFileToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
               this.openFileToolStripMenuItem.Text = "Open File";
               this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
               // 
               // openFolderToolStripMenuItem
               // 
               this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
               this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
               this.openFolderToolStripMenuItem.Text = "Open Folder";
               this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
               // 
               // indexFolderToolStripMenuItem
               // 
               this.indexFolderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rootPrefixToolStripMenuItem,
            this.noRootPrefixToolStripMenuItem});
               this.indexFolderToolStripMenuItem.Name = "indexFolderToolStripMenuItem";
               this.indexFolderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
               this.indexFolderToolStripMenuItem.Text = "Index Folder";
               // 
               // rootPrefixToolStripMenuItem
               // 
               this.rootPrefixToolStripMenuItem.Name = "rootPrefixToolStripMenuItem";
               this.rootPrefixToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
               this.rootPrefixToolStripMenuItem.Text = "Root prefix";
               this.rootPrefixToolStripMenuItem.Click += new System.EventHandler(this.rootPrefixToolStripMenuItem_Click);
               // 
               // noRootPrefixToolStripMenuItem
               // 
               this.noRootPrefixToolStripMenuItem.Name = "noRootPrefixToolStripMenuItem";
               this.noRootPrefixToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
               this.noRootPrefixToolStripMenuItem.Text = "No Root prefix";
               this.noRootPrefixToolStripMenuItem.Click += new System.EventHandler(this.noRootPrefixToolStripMenuItem_Click);
               // 
               // viewToolStripMenuItem
               // 
               this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animeListToolStripMenuItem,
            this.organizerToolStripMenuItem});
               this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
               this.viewToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
               this.viewToolStripMenuItem.Text = "View";
               // 
               // animeListToolStripMenuItem
               // 
               this.animeListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OngoingToolStripMenuItem,
            this.planToWatchToolStripMenuItem,
            this.allToolStripMenuItem});
               this.animeListToolStripMenuItem.Name = "animeListToolStripMenuItem";
               this.animeListToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
               this.animeListToolStripMenuItem.Text = "Anime List";
               // 
               // OngoingToolStripMenuItem
               // 
               this.OngoingToolStripMenuItem.Name = "OngoingToolStripMenuItem";
               this.OngoingToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
               this.OngoingToolStripMenuItem.Text = "&Ongoing";
               this.OngoingToolStripMenuItem.Click += new System.EventHandler(this.OngoingToolStripMenuItem_Click);
               // 
               // planToWatchToolStripMenuItem
               // 
               this.planToWatchToolStripMenuItem.Name = "planToWatchToolStripMenuItem";
               this.planToWatchToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
               this.planToWatchToolStripMenuItem.Text = "&Plan to watch";
               this.planToWatchToolStripMenuItem.Click += new System.EventHandler(this.planToWatchToolStripMenuItem_Click);
               // 
               // allToolStripMenuItem
               // 
               this.allToolStripMenuItem.Name = "allToolStripMenuItem";
               this.allToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
               this.allToolStripMenuItem.Text = "&All";
               this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
               // 
               // organizerToolStripMenuItem
               // 
               this.organizerToolStripMenuItem.Name = "organizerToolStripMenuItem";
               this.organizerToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
               this.organizerToolStripMenuItem.Text = "O&rganizer";
               // 
               // toolStripSeparator2
               // 
               this.toolStripSeparator2.Name = "toolStripSeparator2";
               this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
               // 
               // newToolStripButton
               // 
               this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
               this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
               this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.newToolStripButton.Name = "newToolStripButton";
               this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
               this.newToolStripButton.Text = "&File";
               // 
               // openToolStripButton
               // 
               this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
               this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
               this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.openToolStripButton.Name = "openToolStripButton";
               this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
               this.openToolStripButton.Text = "&Folder";
               // 
               // saveToolStripButton
               // 
               this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
               this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
               this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.saveToolStripButton.Name = "saveToolStripButton";
               this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
               this.saveToolStripButton.Text = "&Save";
               // 
               // toolStripSeparator
               // 
               this.toolStripSeparator.Name = "toolStripSeparator";
               this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
               // 
               // toolStripSeparator1
               // 
               this.toolStripSeparator1.Name = "toolStripSeparator1";
               this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
               // 
               // helpToolStripButton
               // 
               this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
               this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
               this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.helpToolStripButton.Name = "helpToolStripButton";
               this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
               this.helpToolStripButton.Text = "He&lp";
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 54F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label1.Location = new System.Drawing.Point(157, 29);
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
               this.Homepanel.Controls.Add(this.fileList);
               this.Homepanel.Location = new System.Drawing.Point(12, 133);
               this.Homepanel.Name = "Homepanel";
               this.Homepanel.Size = new System.Drawing.Size(743, 347);
               this.Homepanel.TabIndex = 2;
               // 
               // viewlbl
               // 
               this.viewlbl.AutoSize = true;
               this.viewlbl.Font = new System.Drawing.Font("OCR A Extended", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.viewlbl.Location = new System.Drawing.Point(93, 14);
               this.viewlbl.Name = "viewlbl";
               this.viewlbl.Size = new System.Drawing.Size(79, 13);
               this.viewlbl.TabIndex = 12;
               this.viewlbl.Text = "Organizer";
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
               this.menutab.Controls.Add(this.organizetab);
               this.menutab.Controls.Add(this.managetab);
               this.menutab.Location = new System.Drawing.Point(284, 33);
               this.menutab.Name = "menutab";
               this.menutab.SelectedIndex = 0;
               this.menutab.Size = new System.Drawing.Size(439, 304);
               this.menutab.TabIndex = 11;
               this.menutab.SelectedIndexChanged += new System.EventHandler(this.menutab_SelectedIndexChanged);
               // 
               // organizetab
               // 
               this.organizetab.Controls.Add(this.Renamepanel);
               this.organizetab.Location = new System.Drawing.Point(4, 22);
               this.organizetab.Name = "organizetab";
               this.organizetab.Padding = new System.Windows.Forms.Padding(3);
               this.organizetab.Size = new System.Drawing.Size(431, 278);
               this.organizetab.TabIndex = 0;
               this.organizetab.Text = "Organize";
               this.organizetab.ToolTipText = "Organize";
               this.organizetab.UseVisualStyleBackColor = true;
               // 
               // Renamepanel
               // 
               this.Renamepanel.Controls.Add(this.label9);
               this.Renamepanel.Controls.Add(this.episoderbtn);
               this.Renamepanel.Controls.Add(this.dashrbtn);
               this.Renamepanel.Controls.Add(this.label3);
               this.Renamepanel.Controls.Add(this.episodenud);
               this.Renamepanel.Controls.Add(this.label4);
               this.Renamepanel.Controls.Add(this.filenamecbx);
               this.Renamepanel.Controls.Add(this.folderlbl);
               this.Renamepanel.Controls.Add(this.renamebtn);
               this.Renamepanel.Controls.Add(this.label2);
               this.Renamepanel.Controls.Add(this.foldercb);
               this.Renamepanel.Controls.Add(this.filenametxt);
               this.Renamepanel.Location = new System.Drawing.Point(23, 21);
               this.Renamepanel.Name = "Renamepanel";
               this.Renamepanel.Size = new System.Drawing.Size(370, 237);
               this.Renamepanel.TabIndex = 18;
               // 
               // label3
               // 
               this.label3.AutoSize = true;
               this.label3.Location = new System.Drawing.Point(18, 49);
               this.label3.Name = "label3";
               this.label3.Size = new System.Drawing.Size(27, 13);
               this.label3.TabIndex = 24;
               this.label3.Text = "Title";
               // 
               // episodenud
               // 
               this.episodenud.Location = new System.Drawing.Point(252, 68);
               this.episodenud.Name = "episodenud";
               this.episodenud.Size = new System.Drawing.Size(105, 20);
               this.episodenud.TabIndex = 23;
               this.episodenud.ValueChanged += new System.EventHandler(this.episodenud_ValueChanged);
               // 
               // label4
               // 
               this.label4.AutoSize = true;
               this.label4.Location = new System.Drawing.Point(249, 49);
               this.label4.Name = "label4";
               this.label4.Size = new System.Drawing.Size(83, 13);
               this.label4.TabIndex = 22;
               this.label4.Text = "Episode number";
               // 
               // filenamecbx
               // 
               this.filenamecbx.FormattingEnabled = true;
               this.filenamecbx.Location = new System.Drawing.Point(15, 68);
               this.filenamecbx.Name = "filenamecbx";
               this.filenamecbx.Size = new System.Drawing.Size(204, 21);
               this.filenamecbx.TabIndex = 21;
               this.filenamecbx.SelectedIndexChanged += new System.EventHandler(this.filenamecbx_SelectionChangeCommitted);
               this.filenamecbx.SelectionChangeCommitted += new System.EventHandler(this.filenamecbx_SelectionChangeCommitted);
               // 
               // folderlbl
               // 
               this.folderlbl.AutoSize = true;
               this.folderlbl.Location = new System.Drawing.Point(200, 8);
               this.folderlbl.Name = "folderlbl";
               this.folderlbl.Size = new System.Drawing.Size(98, 13);
               this.folderlbl.TabIndex = 11;
               this.folderlbl.Text = "No Folder Selected";
               // 
               // renamebtn
               // 
               this.renamebtn.Location = new System.Drawing.Point(282, 202);
               this.renamebtn.Name = "renamebtn";
               this.renamebtn.Size = new System.Drawing.Size(75, 23);
               this.renamebtn.TabIndex = 20;
               this.renamebtn.Text = "Rename";
               this.renamebtn.UseVisualStyleBackColor = true;
               this.renamebtn.Click += new System.EventHandler(this.renamebtn_Click);
               // 
               // label2
               // 
               this.label2.AutoSize = true;
               this.label2.Location = new System.Drawing.Point(113, 8);
               this.label2.Name = "label2";
               this.label2.Size = new System.Drawing.Size(81, 13);
               this.label2.TabIndex = 9;
               this.label2.Text = "Selected folder:";
               // 
               // foldercb
               // 
               this.foldercb.AutoSize = true;
               this.foldercb.Location = new System.Drawing.Point(115, 45);
               this.foldercb.Name = "foldercb";
               this.foldercb.Size = new System.Drawing.Size(103, 17);
               this.foldercb.TabIndex = 19;
               this.foldercb.Text = "Use folder name";
               this.foldercb.UseVisualStyleBackColor = true;
               this.foldercb.CheckedChanged += new System.EventHandler(this.foldercb_CheckedChanged);
               // 
               // filenametxt
               // 
               this.filenametxt.Location = new System.Drawing.Point(5, 189);
               this.filenametxt.Multiline = true;
               this.filenametxt.Name = "filenametxt";
               this.filenametxt.Size = new System.Drawing.Size(273, 36);
               this.filenametxt.TabIndex = 18;
               this.filenametxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
               // 
               // managetab
               // 
               this.managetab.Controls.Add(this.tableLayoutPanel1);
               this.managetab.Location = new System.Drawing.Point(4, 22);
               this.managetab.Name = "managetab";
               this.managetab.Padding = new System.Windows.Forms.Padding(3);
               this.managetab.Size = new System.Drawing.Size(431, 278);
               this.managetab.TabIndex = 1;
               this.managetab.Text = "Manage";
               this.managetab.UseVisualStyleBackColor = true;
               // 
               // tableLayoutPanel1
               // 
               this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.tableLayoutPanel1.ColumnCount = 2;
               this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
               this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
               this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
               this.tableLayoutPanel1.Controls.Add(this.titletxt, 1, 0);
               this.tableLayoutPanel1.Controls.Add(this.modifyongoingbtn, 0, 1);
               this.tableLayoutPanel1.Controls.Add(this.modifyplanningbtn, 1, 1);
               this.tableLayoutPanel1.Controls.Add(this.ongoingcnt, 1, 2);
               this.tableLayoutPanel1.Controls.Add(this.planningcnt, 1, 3);
               this.tableLayoutPanel1.Controls.Add(this.allcnt, 1, 4);
               this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
               this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
               this.tableLayoutPanel1.Controls.Add(this.label8, 0, 4);
               this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 12);
               this.tableLayoutPanel1.Name = "tableLayoutPanel1";
               this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
               this.tableLayoutPanel1.RowCount = 5;
               this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.01563F));
               this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.46875F));
               this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.96875F));
               this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.57813F));
               this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.96875F));
               this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 256);
               this.tableLayoutPanel1.TabIndex = 0;
               // 
               // label5
               // 
               this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.label5.Font = new System.Drawing.Font("Lucida Fax", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label5.Location = new System.Drawing.Point(6, 8);
               this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
               this.label5.Name = "label5";
               this.label5.Size = new System.Drawing.Size(183, 30);
               this.label5.TabIndex = 0;
               this.label5.Text = "Title";
               this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // titletxt
               // 
               this.titletxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.titletxt.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.titletxt.Location = new System.Drawing.Point(195, 6);
               this.titletxt.Multiline = true;
               this.titletxt.Name = "titletxt";
               this.titletxt.Size = new System.Drawing.Size(183, 34);
               this.titletxt.TabIndex = 1;
               // 
               // modifyongoingbtn
               // 
               this.modifyongoingbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.modifyongoingbtn.BackColor = System.Drawing.Color.PaleGoldenrod;
               this.modifyongoingbtn.FlatAppearance.BorderColor = System.Drawing.Color.Green;
               this.modifyongoingbtn.FlatAppearance.BorderSize = 4;
               this.modifyongoingbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LimeGreen;
               this.modifyongoingbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
               this.modifyongoingbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
               this.modifyongoingbtn.Font = new System.Drawing.Font("Lucida Fax", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
               this.modifyongoingbtn.ForeColor = System.Drawing.Color.White;
               this.modifyongoingbtn.Location = new System.Drawing.Point(6, 46);
               this.modifyongoingbtn.Name = "modifyongoingbtn";
               this.modifyongoingbtn.Size = new System.Drawing.Size(183, 54);
               this.modifyongoingbtn.TabIndex = 2;
               this.modifyongoingbtn.Text = "Modify Ongoing";
               this.toolTip1.SetToolTip(this.modifyongoingbtn, "Adds an anime title to the onoing list if it is not there or removes it if it is " +
        "there, it also supports migrating a title from the plan to watch list to the ong" +
        "oing list");
               this.modifyongoingbtn.UseVisualStyleBackColor = false;
               this.modifyongoingbtn.Click += new System.EventHandler(this.modifyongoingbtn_Click);
               // 
               // modifyplanningbtn
               // 
               this.modifyplanningbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.modifyplanningbtn.BackColor = System.Drawing.Color.PaleGoldenrod;
               this.modifyplanningbtn.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
               this.modifyplanningbtn.FlatAppearance.BorderSize = 4;
               this.modifyplanningbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
               this.modifyplanningbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SandyBrown;
               this.modifyplanningbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
               this.modifyplanningbtn.Font = new System.Drawing.Font("Lucida Fax", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
               this.modifyplanningbtn.ForeColor = System.Drawing.Color.White;
               this.modifyplanningbtn.Location = new System.Drawing.Point(195, 46);
               this.modifyplanningbtn.Name = "modifyplanningbtn";
               this.modifyplanningbtn.Size = new System.Drawing.Size(183, 54);
               this.modifyplanningbtn.TabIndex = 2;
               this.modifyplanningbtn.Text = "Modify Plan to Watch";
               this.toolTip1.SetToolTip(this.modifyplanningbtn, "Adds to the plan to watch list if new and removes if it is in the list, does not " +
        "support list migration");
               this.modifyplanningbtn.UseVisualStyleBackColor = false;
               this.modifyplanningbtn.Click += new System.EventHandler(this.modifyplanningbtn_Click);
               // 
               // ongoingcnt
               // 
               this.ongoingcnt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.ongoingcnt.Font = new System.Drawing.Font("Lucida Fax", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.ongoingcnt.Location = new System.Drawing.Point(195, 124);
               this.ongoingcnt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
               this.ongoingcnt.Name = "ongoingcnt";
               this.ongoingcnt.Size = new System.Drawing.Size(183, 34);
               this.ongoingcnt.TabIndex = 0;
               this.ongoingcnt.Text = "0";
               this.ongoingcnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // planningcnt
               // 
               this.planningcnt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.planningcnt.Font = new System.Drawing.Font("Lucida Fax", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.planningcnt.Location = new System.Drawing.Point(195, 168);
               this.planningcnt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
               this.planningcnt.Name = "planningcnt";
               this.planningcnt.Size = new System.Drawing.Size(183, 33);
               this.planningcnt.TabIndex = 0;
               this.planningcnt.Text = "0";
               this.planningcnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // allcnt
               // 
               this.allcnt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.allcnt.Font = new System.Drawing.Font("Lucida Fax", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.allcnt.Location = new System.Drawing.Point(195, 211);
               this.allcnt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
               this.allcnt.Name = "allcnt";
               this.allcnt.Size = new System.Drawing.Size(183, 37);
               this.allcnt.TabIndex = 0;
               this.allcnt.Text = "0";
               this.allcnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // label6
               // 
               this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.label6.Font = new System.Drawing.Font("Lucida Fax", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label6.Location = new System.Drawing.Point(6, 124);
               this.label6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
               this.label6.Name = "label6";
               this.label6.Size = new System.Drawing.Size(183, 34);
               this.label6.TabIndex = 0;
               this.label6.Text = "Ongoing";
               this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // label7
               // 
               this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.label7.Font = new System.Drawing.Font("Lucida Fax", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label7.Location = new System.Drawing.Point(6, 168);
               this.label7.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
               this.label7.Name = "label7";
               this.label7.Size = new System.Drawing.Size(183, 33);
               this.label7.TabIndex = 0;
               this.label7.Text = "Planning";
               this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // label8
               // 
               this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.label8.Font = new System.Drawing.Font("Lucida Fax", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label8.Location = new System.Drawing.Point(6, 211);
               this.label8.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
               this.label8.Name = "label8";
               this.label8.Size = new System.Drawing.Size(183, 37);
               this.label8.TabIndex = 0;
               this.label8.Text = "All";
               this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // fileList
               // 
               this.fileList.FormattingEnabled = true;
               this.fileList.Location = new System.Drawing.Point(13, 33);
               this.fileList.Name = "fileList";
               this.fileList.Size = new System.Drawing.Size(244, 304);
               this.fileList.TabIndex = 10;
               this.fileList.SelectedValueChanged += new System.EventHandler(this.fileList_SelectedValueChanged);
               // 
               // folderBrowserDialog
               // 
               this.folderBrowserDialog.Description = "Select a folder with anime videos";
               // 
               // OFileDialog
               // 
               this.OFileDialog.Multiselect = true;
               this.OFileDialog.Title = "Select a video file";
               // 
               // toolTip1
               // 
               this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
               this.toolTip1.ToolTipTitle = "Information";
               // 
               // dashrbtn
               // 
               this.dashrbtn.AutoSize = true;
               this.dashrbtn.Location = new System.Drawing.Point(252, 140);
               this.dashrbtn.Name = "dashrbtn";
               this.dashrbtn.Size = new System.Drawing.Size(48, 17);
               this.dashrbtn.TabIndex = 25;
               this.dashrbtn.TabStop = true;
               this.dashrbtn.Text = "dash";
               this.toolTip1.SetToolTip(this.dashrbtn, "use \"x - episode num\" style");
               this.dashrbtn.UseVisualStyleBackColor = true;
               this.dashrbtn.CheckedChanged += new System.EventHandler(this.dashrbtn_CheckedChanged);
               // 
               // episoderbtn
               // 
               this.episoderbtn.AutoSize = true;
               this.episoderbtn.Location = new System.Drawing.Point(252, 117);
               this.episoderbtn.Name = "episoderbtn";
               this.episoderbtn.Size = new System.Drawing.Size(62, 17);
               this.episoderbtn.TabIndex = 25;
               this.episoderbtn.TabStop = true;
               this.episoderbtn.Text = "episode";
               this.toolTip1.SetToolTip(this.episoderbtn, "use \"x Episode episode num\" style");
               this.episoderbtn.UseVisualStyleBackColor = true;
               this.episoderbtn.CheckedChanged += new System.EventHandler(this.episoderbtn_CheckedChanged);
               // 
               // label9
               // 
               this.label9.AutoSize = true;
               this.label9.Location = new System.Drawing.Point(249, 95);
               this.label9.Name = "label9";
               this.label9.Size = new System.Drawing.Size(69, 13);
               this.label9.TabIndex = 26;
               this.label9.Text = "Episode style";
               // 
               // Form1
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(779, 489);
               this.Controls.Add(this.Homepanel);
               this.Controls.Add(this.label1);
               this.Controls.Add(this.toolStrip1);
               this.Name = "Form1";
               this.Text = "Form1";
               this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
               this.toolStrip1.ResumeLayout(false);
               this.toolStrip1.PerformLayout();
               this.Homepanel.ResumeLayout(false);
               this.Homepanel.PerformLayout();
               this.menutab.ResumeLayout(false);
               this.organizetab.ResumeLayout(false);
               this.Renamepanel.ResumeLayout(false);
               this.Renamepanel.PerformLayout();
               ((System.ComponentModel.ISupportInitialize)(this.episodenud)).EndInit();
               this.managetab.ResumeLayout(false);
               this.tableLayoutPanel1.ResumeLayout(false);
               this.tableLayoutPanel1.PerformLayout();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.ToolStrip toolStrip1;
          private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
          private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem animeListToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem OngoingToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem planToWatchToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
          private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
          private System.Windows.Forms.ToolStripButton newToolStripButton;
          private System.Windows.Forms.ToolStripButton openToolStripButton;
          private System.Windows.Forms.ToolStripButton saveToolStripButton;
          private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
          private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
          private System.Windows.Forms.ToolStripButton helpToolStripButton;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.Panel Homepanel;
          private System.Windows.Forms.CheckedListBox fileList;
          private System.Windows.Forms.TabControl menutab;
          private System.Windows.Forms.TabPage organizetab;
          private System.Windows.Forms.Panel Renamepanel;
          private System.Windows.Forms.NumericUpDown episodenud;
          private System.Windows.Forms.Label label4;
          private System.Windows.Forms.ComboBox filenamecbx;
          private System.Windows.Forms.Label folderlbl;
          private System.Windows.Forms.Button renamebtn;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.CheckBox foldercb;
          private System.Windows.Forms.TextBox filenametxt;
          private System.Windows.Forms.TabPage managetab;
          private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
          private System.Windows.Forms.Label label5;
          private System.Windows.Forms.TextBox titletxt;
          private System.Windows.Forms.Button modifyongoingbtn;
          private System.Windows.Forms.Button modifyplanningbtn;
          private System.Windows.Forms.Label ongoingcnt;
          private System.Windows.Forms.Label planningcnt;
          private System.Windows.Forms.Label allcnt;
          private System.Windows.Forms.Label label6;
          private System.Windows.Forms.Label label7;
          private System.Windows.Forms.Label label8;
          private System.Windows.Forms.ToolStripMenuItem organizerToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem indexFolderToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem rootPrefixToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem noRootPrefixToolStripMenuItem;
          private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
          private System.Windows.Forms.OpenFileDialog OFileDialog;
          private System.Windows.Forms.Label label3;
          private System.Windows.Forms.Label viewlbl;
          private System.Windows.Forms.Label label12;
          private System.Windows.Forms.ToolTip toolTip1;
          private System.Windows.Forms.Label label9;
          private System.Windows.Forms.RadioButton episoderbtn;
          private System.Windows.Forms.RadioButton dashrbtn;
     }
}

