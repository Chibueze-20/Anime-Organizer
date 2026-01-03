
namespace AnimeOrganizer
{
    partial class Customize
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.zeddPathlbl = new System.Windows.Forms.Label();
            this.updateZeddllbl = new System.Windows.Forms.LinkLabel();
            this.episodeSepcbx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.redundant_str_update_btn = new System.Windows.Forms.Button();
            this.redundant_str_cbx = new System.Windows.Forms.ComboBox();
            this.global_folders_lbl = new System.Windows.Forms.Label();
            this.global_folders_btn = new System.Windows.Forms.Button();
            this.excluded_folders_lbl = new System.Windows.Forms.Label();
            this.excluded_folders_btn = new System.Windows.Forms.Button();
            this.global_folders_cbx = new System.Windows.Forms.ComboBox();
            this.excluded_folders_cbx = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.excluded_folders_btn);
            this.panel1.Controls.Add(this.global_folders_btn);
            this.panel1.Controls.Add(this.redundant_str_update_btn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.excluded_folders_lbl);
            this.panel1.Controls.Add(this.excluded_folders_cbx);
            this.panel1.Controls.Add(this.global_folders_cbx);
            this.panel1.Controls.Add(this.redundant_str_cbx);
            this.panel1.Controls.Add(this.global_folders_lbl);
            this.panel1.Controls.Add(this.episodeSepcbx);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(24, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 387);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(532, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.zeddPathlbl);
            this.flowLayoutPanel1.Controls.Add(this.updateZeddllbl);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(242, 56);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(740, 46);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // zeddPathlbl
            // 
            this.zeddPathlbl.AutoSize = true;
            this.zeddPathlbl.Location = new System.Drawing.Point(6, 0);
            this.zeddPathlbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.zeddPathlbl.Name = "zeddPathlbl";
            this.zeddPathlbl.Size = new System.Drawing.Size(70, 25);
            this.zeddPathlbl.TabIndex = 1;
            this.zeddPathlbl.Text = "label3";
            // 
            // updateZeddllbl
            // 
            this.updateZeddllbl.AutoSize = true;
            this.updateZeddllbl.LinkColor = System.Drawing.Color.Black;
            this.updateZeddllbl.Location = new System.Drawing.Point(88, 0);
            this.updateZeddllbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.updateZeddllbl.Name = "updateZeddllbl";
            this.updateZeddllbl.Size = new System.Drawing.Size(78, 25);
            this.updateZeddllbl.TabIndex = 3;
            this.updateZeddllbl.TabStop = true;
            this.updateZeddllbl.Text = "update";
            this.updateZeddllbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.updateZeddllbl_LinkClicked);
            // 
            // episodeSepcbx
            // 
            this.episodeSepcbx.FormattingEnabled = true;
            this.episodeSepcbx.Location = new System.Drawing.Point(242, 146);
            this.episodeSepcbx.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.episodeSepcbx.Name = "episodeSepcbx";
            this.episodeSepcbx.Size = new System.Drawing.Size(238, 33);
            this.episodeSepcbx.TabIndex = 2;
            this.episodeSepcbx.SelectedIndexChanged += new System.EventHandler(this.episodeSepcbx_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Episode Separator:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zedd Path:";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 224);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Redundant strings:";
            // 
            // redundant_str_update_btn
            // 
            this.redundant_str_update_btn.Location = new System.Drawing.Point(537, 216);
            this.redundant_str_update_btn.Name = "redundant_str_update_btn";
            this.redundant_str_update_btn.Size = new System.Drawing.Size(166, 38);
            this.redundant_str_update_btn.TabIndex = 6;
            this.redundant_str_update_btn.Text = "update";
            this.redundant_str_update_btn.UseVisualStyleBackColor = true;
            this.redundant_str_update_btn.Click += new System.EventHandler(this.redundant_str_update_btn_Click);
            // 
            // redundant_str_cbx
            // 
            this.redundant_str_cbx.FormattingEnabled = true;
            this.redundant_str_cbx.Location = new System.Drawing.Point(242, 221);
            this.redundant_str_cbx.Margin = new System.Windows.Forms.Padding(6);
            this.redundant_str_cbx.Name = "redundant_str_cbx";
            this.redundant_str_cbx.Size = new System.Drawing.Size(238, 33);
            this.redundant_str_cbx.TabIndex = 2;
            this.redundant_str_cbx.SelectionChangeCommitted += new System.EventHandler(this.redundant_str_cbx_SelectionChangeCommitted);
            this.redundant_str_cbx.TextChanged += new System.EventHandler(this.redundant_str_cbx_TextChanged);
            // 
            // global_folders_lbl
            // 
            this.global_folders_lbl.AutoSize = true;
            this.global_folders_lbl.Location = new System.Drawing.Point(34, 284);
            this.global_folders_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.global_folders_lbl.Name = "global_folders_lbl";
            this.global_folders_lbl.Size = new System.Drawing.Size(151, 25);
            this.global_folders_lbl.TabIndex = 0;
            this.global_folders_lbl.Text = "Global folders:";
            // 
            // global_folders_btn
            // 
            this.global_folders_btn.Location = new System.Drawing.Point(537, 276);
            this.global_folders_btn.Name = "global_folders_btn";
            this.global_folders_btn.Size = new System.Drawing.Size(166, 38);
            this.global_folders_btn.TabIndex = 6;
            this.global_folders_btn.Text = "update";
            this.global_folders_btn.UseVisualStyleBackColor = true;
            this.global_folders_btn.Click += new System.EventHandler(this.redundant_str_update_btn_Click);
            // 
            // excluded_folders_lbl
            // 
            this.excluded_folders_lbl.AutoSize = true;
            this.excluded_folders_lbl.Location = new System.Drawing.Point(34, 346);
            this.excluded_folders_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.excluded_folders_lbl.Name = "excluded_folders_lbl";
            this.excluded_folders_lbl.Size = new System.Drawing.Size(185, 25);
            this.excluded_folders_lbl.TabIndex = 0;
            this.excluded_folders_lbl.Text = "Excluded Folders:";
            // 
            // excluded_folders_btn
            // 
            this.excluded_folders_btn.Location = new System.Drawing.Point(537, 338);
            this.excluded_folders_btn.Name = "excluded_folders_btn";
            this.excluded_folders_btn.Size = new System.Drawing.Size(166, 38);
            this.excluded_folders_btn.TabIndex = 6;
            this.excluded_folders_btn.Text = "update";
            this.excluded_folders_btn.UseVisualStyleBackColor = true;
            this.excluded_folders_btn.Click += new System.EventHandler(this.redundant_str_update_btn_Click);
            // 
            // global_folders_cbx
            // 
            this.global_folders_cbx.FormattingEnabled = true;
            this.global_folders_cbx.Location = new System.Drawing.Point(242, 280);
            this.global_folders_cbx.Margin = new System.Windows.Forms.Padding(6);
            this.global_folders_cbx.Name = "global_folders_cbx";
            this.global_folders_cbx.Size = new System.Drawing.Size(238, 33);
            this.global_folders_cbx.TabIndex = 2;
            this.global_folders_cbx.SelectionChangeCommitted += new System.EventHandler(this.folder_cbx_SelectionChangeCommitted);
            this.global_folders_cbx.TextChanged += new System.EventHandler(this.folder_cbx_TextChanged);
            // 
            // excluded_folders_cbx
            // 
            this.excluded_folders_cbx.FormattingEnabled = true;
            this.excluded_folders_cbx.Location = new System.Drawing.Point(242, 342);
            this.excluded_folders_cbx.Margin = new System.Windows.Forms.Padding(6);
            this.excluded_folders_cbx.Name = "excluded_folders_cbx";
            this.excluded_folders_cbx.Size = new System.Drawing.Size(238, 33);
            this.excluded_folders_cbx.TabIndex = 2;
            this.excluded_folders_cbx.SelectionChangeCommitted += new System.EventHandler(this.folder_cbx_SelectionChangeCommitted);
            this.excluded_folders_cbx.TextChanged += new System.EventHandler(this.folder_cbx_TextChanged);
            // 
            // Customize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 413);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Customize";
            this.Text = "Customize";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox episodeSepcbx;
        private System.Windows.Forms.Label zeddPathlbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel updateZeddllbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button redundant_str_update_btn;
        private System.Windows.Forms.ComboBox redundant_str_cbx;
        private System.Windows.Forms.Button excluded_folders_btn;
        private System.Windows.Forms.Button global_folders_btn;
        private System.Windows.Forms.Label excluded_folders_lbl;
        private System.Windows.Forms.ComboBox excluded_folders_cbx;
        private System.Windows.Forms.ComboBox global_folders_cbx;
        private System.Windows.Forms.Label global_folders_lbl;
    }
}