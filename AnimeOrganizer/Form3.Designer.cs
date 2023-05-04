namespace AnimeOrganizer
{
     partial class Form3
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
               this.optionsBox = new System.Windows.Forms.GroupBox();
               this.mainDisplay = new System.Windows.Forms.Label();
               this.linkLabel1 = new System.Windows.Forms.LinkLabel();
               this.skipBtn = new System.Windows.Forms.Button();
               this.selectFolderBtn = new System.Windows.Forms.Button();
               this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
               this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
               this.SuspendLayout();
               // 
               // optionsBox
               // 
               this.optionsBox.Location = new System.Drawing.Point(6, 185);
               this.optionsBox.Name = "optionsBox";
               this.optionsBox.Size = new System.Drawing.Size(782, 249);
               this.optionsBox.TabIndex = 0;
               this.optionsBox.TabStop = false;
               this.optionsBox.Text = "Options";
               // 
               // mainDisplay
               // 
               this.mainDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.mainDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
               this.mainDisplay.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.mainDisplay.Location = new System.Drawing.Point(165, 38);
               this.mainDisplay.Name = "mainDisplay";
               this.mainDisplay.Size = new System.Drawing.Size(456, 120);
               this.mainDisplay.TabIndex = 1;
               this.mainDisplay.Text = "Anime Video file";
               this.mainDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // linkLabel1
               // 
               this.linkLabel1.AutoSize = true;
               this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
               this.linkLabel1.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.linkLabel1.LinkColor = System.Drawing.Color.Black;
               this.linkLabel1.Location = new System.Drawing.Point(12, 9);
               this.linkLabel1.Name = "linkLabel1";
               this.linkLabel1.Size = new System.Drawing.Size(173, 17);
               this.linkLabel1.TabIndex = 31;
               this.linkLabel1.TabStop = true;
               this.linkLabel1.Text = "Go to Organizer";
               this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Black;
               // 
               // skipBtn
               // 
               this.skipBtn.BackColor = System.Drawing.Color.Yellow;
               this.skipBtn.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
               this.skipBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
               this.skipBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
               this.skipBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.skipBtn.Location = new System.Drawing.Point(640, 79);
               this.skipBtn.Name = "skipBtn";
               this.skipBtn.Size = new System.Drawing.Size(111, 46);
               this.skipBtn.TabIndex = 32;
               this.skipBtn.Text = "Skip this file";
               this.skipBtn.UseVisualStyleBackColor = false;
               this.skipBtn.Click += new System.EventHandler(this.skipBtn_Click);
               // 
               // selectFolderBtn
               // 
               this.selectFolderBtn.BackColor = System.Drawing.Color.SteelBlue;
               this.selectFolderBtn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
               this.selectFolderBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumAquamarine;
               this.selectFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
               this.selectFolderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.selectFolderBtn.Location = new System.Drawing.Point(15, 74);
               this.selectFolderBtn.Name = "selectFolderBtn";
               this.selectFolderBtn.Size = new System.Drawing.Size(119, 46);
               this.selectFolderBtn.TabIndex = 32;
               this.selectFolderBtn.Text = "Select Folder";
               this.selectFolderBtn.UseVisualStyleBackColor = false;
               this.selectFolderBtn.Click += new System.EventHandler(this.selectFolderBtn_Click);
               // 
               // folderBrowserDialog
               // 
               this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
               // 
               // Form3
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(800, 450);
               this.Controls.Add(this.selectFolderBtn);
               this.Controls.Add(this.skipBtn);
               this.Controls.Add(this.linkLabel1);
               this.Controls.Add(this.mainDisplay);
               this.Controls.Add(this.optionsBox);
               this.MaximizeBox = false;
               this.Name = "Form3";
               this.Text = "Quick Organizer";
               this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.GroupBox optionsBox;
          private System.Windows.Forms.Label mainDisplay;
          private System.Windows.Forms.LinkLabel linkLabel1;
          private System.Windows.Forms.Button skipBtn;
          private System.Windows.Forms.Button selectFolderBtn;
          private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
          private System.Windows.Forms.ToolTip toolTip1;
     }
}