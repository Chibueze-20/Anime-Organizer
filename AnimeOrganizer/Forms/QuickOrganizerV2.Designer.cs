namespace AnimeOrganizer.Forms
{
    partial class QuickOrganizerV2
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
            this.excessFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.animelv = new System.Windows.Forms.ListView();
            this.nextBtn = new System.Windows.Forms.Button();
            this.actionBtnFlp = new System.Windows.Forms.FlowLayoutPanel();
            this.plusBtn = new System.Windows.Forms.Button();
            this.minusBtn = new System.Windows.Forms.Button();
            this.episodeLbl = new System.Windows.Forms.Label();
            this.folderLbl = new System.Windows.Forms.Label();
            this.point5btn = new System.Windows.Forms.Button();
            this.menu1 = new AnimeOrganizer.menu();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // excessFLP
            // 
            this.excessFLP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.excessFLP.Location = new System.Drawing.Point(18, 918);
            this.excessFLP.Name = "excessFLP";
            this.excessFLP.Size = new System.Drawing.Size(1608, 252);
            this.excessFLP.TabIndex = 0;
            // 
            // animelv
            // 
            this.animelv.FullRowSelect = true;
            this.animelv.HideSelection = false;
            this.animelv.Location = new System.Drawing.Point(18, 243);
            this.animelv.Name = "animelv";
            this.animelv.Size = new System.Drawing.Size(1380, 604);
            this.animelv.TabIndex = 3;
            this.animelv.UseCompatibleStateImageBehavior = false;
            this.animelv.View = System.Windows.Forms.View.Details;
            this.animelv.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.animelv_ItemSelectionChanged);
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(1188, 157);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(210, 75);
            this.nextBtn.TabIndex = 2;
            this.nextBtn.Text = "Next";
            this.toolTip1.SetToolTip(this.nextBtn, "Save current organization");
            this.nextBtn.UseVisualStyleBackColor = true;
            // 
            // actionBtnFlp
            // 
            this.actionBtnFlp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.actionBtnFlp.Location = new System.Drawing.Point(1422, 165);
            this.actionBtnFlp.Name = "actionBtnFlp";
            this.actionBtnFlp.Size = new System.Drawing.Size(220, 460);
            this.actionBtnFlp.TabIndex = 4;
            // 
            // plusBtn
            // 
            this.plusBtn.Location = new System.Drawing.Point(864, 168);
            this.plusBtn.Name = "plusBtn";
            this.plusBtn.Size = new System.Drawing.Size(56, 58);
            this.plusBtn.TabIndex = 5;
            this.plusBtn.Text = "+";
            this.plusBtn.UseVisualStyleBackColor = true;
            // 
            // minusBtn
            // 
            this.minusBtn.Location = new System.Drawing.Point(926, 168);
            this.minusBtn.Name = "minusBtn";
            this.minusBtn.Size = new System.Drawing.Size(56, 58);
            this.minusBtn.TabIndex = 5;
            this.minusBtn.Text = "-";
            this.minusBtn.UseVisualStyleBackColor = true;
            // 
            // episodeLbl
            // 
            this.episodeLbl.AutoSize = true;
            this.episodeLbl.Location = new System.Drawing.Point(850, 134);
            this.episodeLbl.Name = "episodeLbl";
            this.episodeLbl.Size = new System.Drawing.Size(191, 25);
            this.episodeLbl.TabIndex = 6;
            this.episodeLbl.Text = "Episode Adjustmet";
            // 
            // folderLbl
            // 
            this.folderLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderLbl.Location = new System.Drawing.Point(12, 66);
            this.folderLbl.Name = "folderLbl";
            this.folderLbl.Size = new System.Drawing.Size(1660, 59);
            this.folderLbl.TabIndex = 7;
            this.folderLbl.Text = "Folder c Name That Is Very Long (new)Long Long Long Long Long Nogd";
            // 
            // point5btn
            // 
            this.point5btn.Location = new System.Drawing.Point(988, 168);
            this.point5btn.Name = "point5btn";
            this.point5btn.Size = new System.Drawing.Size(56, 58);
            this.point5btn.TabIndex = 5;
            this.point5btn.Text = ".5";
            this.point5btn.UseVisualStyleBackColor = true;
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.Color.Transparent;
            this.menu1.Location = new System.Drawing.Point(3, 5);
            this.menu1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(1364, 50);
            this.menu1.TabIndex = 8;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 858);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 51);
            this.label1.TabIndex = 9;
            this.label1.Text = "File Hold";
            // 
            // QuickOrganizerV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1670, 1187);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu1);
            this.Controls.Add(this.folderLbl);
            this.Controls.Add(this.episodeLbl);
            this.Controls.Add(this.point5btn);
            this.Controls.Add(this.minusBtn);
            this.Controls.Add(this.plusBtn);
            this.Controls.Add(this.actionBtnFlp);
            this.Controls.Add(this.animelv);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.excessFLP);
            this.MaximizeBox = false;
            this.Name = "QuickOrganizerV2";
            this.Text = "QuickOrganizerV2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuickOrganizerV2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel excessFLP;
        private System.Windows.Forms.ListView animelv;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.FlowLayoutPanel actionBtnFlp;
        private System.Windows.Forms.Button plusBtn;
        private System.Windows.Forms.Button minusBtn;
        private System.Windows.Forms.Label episodeLbl;
        private System.Windows.Forms.Label folderLbl;
        private System.Windows.Forms.Button point5btn;
        private menu menu1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
    }
}