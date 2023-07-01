namespace AnimeOrganizer
{
    partial class NewSeason
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
            this.anime_lbx = new System.Windows.Forms.ListBox();
            this.animelist_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // anime_lbx
            // 
            this.anime_lbx.FormattingEnabled = true;
            this.anime_lbx.Location = new System.Drawing.Point(13, 13);
            this.anime_lbx.Name = "anime_lbx";
            this.anime_lbx.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.anime_lbx.Size = new System.Drawing.Size(281, 368);
            this.anime_lbx.TabIndex = 0;
            // 
            // animelist_btn
            // 
            this.animelist_btn.Location = new System.Drawing.Point(349, 134);
            this.animelist_btn.Name = "animelist_btn";
            this.animelist_btn.Size = new System.Drawing.Size(111, 23);
            this.animelist_btn.TabIndex = 1;
            this.animelist_btn.Text = "Upload Anime List";
            this.animelist_btn.UseVisualStyleBackColor = true;
            this.animelist_btn.Click += new System.EventHandler(this.animelist_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(349, 197);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(111, 23);
            this.save_btn.TabIndex = 1;
            this.save_btn.Text = "Save and exit";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "txt files|*.txt";
            this.openFileDialog.Title = "Open Anime List File";
            // 
            // NewSeason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 389);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.animelist_btn);
            this.Controls.Add(this.anime_lbx);
            this.Name = "NewSeason";
            this.Text = "Setup new season";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox anime_lbx;
        private System.Windows.Forms.Button animelist_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}