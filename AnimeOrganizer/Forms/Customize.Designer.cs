
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
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.episodeSepcbx);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 158);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.zeddPathlbl);
            this.flowLayoutPanel1.Controls.Add(this.updateZeddllbl);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(121, 29);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(370, 24);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // zeddPathlbl
            // 
            this.zeddPathlbl.AutoSize = true;
            this.zeddPathlbl.Location = new System.Drawing.Point(3, 0);
            this.zeddPathlbl.Name = "zeddPathlbl";
            this.zeddPathlbl.Size = new System.Drawing.Size(35, 13);
            this.zeddPathlbl.TabIndex = 1;
            this.zeddPathlbl.Text = "label3";
            // 
            // updateZeddllbl
            // 
            this.updateZeddllbl.AutoSize = true;
            this.updateZeddllbl.LinkColor = System.Drawing.Color.Black;
            this.updateZeddllbl.Location = new System.Drawing.Point(44, 0);
            this.updateZeddllbl.Name = "updateZeddllbl";
            this.updateZeddllbl.Size = new System.Drawing.Size(40, 13);
            this.updateZeddllbl.TabIndex = 3;
            this.updateZeddllbl.TabStop = true;
            this.updateZeddllbl.Text = "update";
            this.updateZeddllbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.updateZeddllbl_LinkClicked);
            // 
            // episodeSepcbx
            // 
            this.episodeSepcbx.FormattingEnabled = true;
            this.episodeSepcbx.Location = new System.Drawing.Point(121, 76);
            this.episodeSepcbx.Name = "episodeSepcbx";
            this.episodeSepcbx.Size = new System.Drawing.Size(121, 21);
            this.episodeSepcbx.TabIndex = 2;
            this.episodeSepcbx.SelectedIndexChanged += new System.EventHandler(this.episodeSepcbx_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Episode Separator:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zedd Path:";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // Customize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 179);
            this.Controls.Add(this.panel1);
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
    }
}