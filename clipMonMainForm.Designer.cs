namespace clipmon
{
    partial class clipMonMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(clipMonMainForm));
            this.nfIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.listAlerters = new System.Windows.Forms.ListBox();
            this.ofdAlertImage = new System.Windows.Forms.OpenFileDialog();
            this.cpAlertBG = new System.Windows.Forms.ColorDialog();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRegex = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.lblRegex = new System.Windows.Forms.Label();
            this.lblBG = new System.Windows.Forms.Label();
            this.txtBG = new System.Windows.Forms.TextBox();
            this.timbgCol = new System.Windows.Forms.Timer(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getSHAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblSan = new System.Windows.Forms.Label();
            this.txtSan = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // nfIcon
            // 
            this.nfIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nfIcon.BalloonTipText = "D";
            this.nfIcon.BalloonTipTitle = "D";
            this.nfIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nfIcon.Icon")));
            this.nfIcon.Text = "ClipMon";
            this.nfIcon.Visible = true;
            this.nfIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nfIcon_MouseDoubleClick);
            // 
            // listAlerters
            // 
            this.listAlerters.FormattingEnabled = true;
            this.listAlerters.Location = new System.Drawing.Point(12, 12);
            this.listAlerters.Name = "listAlerters";
            this.listAlerters.Size = new System.Drawing.Size(205, 173);
            this.listAlerters.Sorted = true;
            this.listAlerters.TabIndex = 0;
            this.listAlerters.DoubleClick += new System.EventHandler(this.listAlerters_DoubleClick);
            // 
            // ofdAlertImage
            // 
            this.ofdAlertImage.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdAlertImage_FileOk);
            // 
            // cpAlertBG
            // 
            this.cpAlertBG.AnyColor = true;
            this.cpAlertBG.FullOpen = true;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(351, 33);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(210, 20);
            this.txtTitle.TabIndex = 2;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(351, 76);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(210, 20);
            this.txtUrl.TabIndex = 3;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(351, 114);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(210, 20);
            this.txtText.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(351, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(36, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Navn:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Url:";
            // 
            // txtRegex
            // 
            this.txtRegex.Location = new System.Drawing.Point(351, 151);
            this.txtRegex.Name = "txtRegex";
            this.txtRegex.Size = new System.Drawing.Size(210, 20);
            this.txtRegex.TabIndex = 7;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(351, 99);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(31, 13);
            this.lblText.TabIndex = 8;
            this.lblText.Text = "Text:";
            // 
            // lblRegex
            // 
            this.lblRegex.AutoSize = true;
            this.lblRegex.Location = new System.Drawing.Point(351, 137);
            this.lblRegex.Name = "lblRegex";
            this.lblRegex.Size = new System.Drawing.Size(41, 13);
            this.lblRegex.TabIndex = 9;
            this.lblRegex.Text = "Regex:";
            // 
            // lblBG
            // 
            this.lblBG.AutoSize = true;
            this.lblBG.Location = new System.Drawing.Point(280, 81);
            this.lblBG.Name = "lblBG";
            this.lblBG.Size = new System.Drawing.Size(52, 13);
            this.lblBG.TabIndex = 10;
            this.lblBG.Text = "BG farve:";
            // 
            // txtBG
            // 
            this.txtBG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBG.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtBG.Location = new System.Drawing.Point(283, 97);
            this.txtBG.Name = "txtBG";
            this.txtBG.ReadOnly = true;
            this.txtBG.Size = new System.Drawing.Size(51, 13);
            this.txtBG.TabIndex = 11;
            this.txtBG.Click += new System.EventHandler(this.txtBG_Click);
            // 
            // timbgCol
            // 
            this.timbgCol.Interval = 1000;
            this.timbgCol.Tick += new System.EventHandler(this.timbgCol_Tick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(575, 186);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(44, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Gem";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(218, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(36, 23);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "Ny";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(218, 41);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Slet";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkToolStripMenuItem,
            this.getSHAToolStripMenuItem});
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // checkToolStripMenuItem
            // 
            this.checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            this.checkToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.checkToolStripMenuItem.Text = "Check";
            this.checkToolStripMenuItem.Click += new System.EventHandler(this.checkToolStripMenuItem_Click);
            // 
            // getSHAToolStripMenuItem
            // 
            this.getSHAToolStripMenuItem.Name = "getSHAToolStripMenuItem";
            this.getSHAToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.getSHAToolStripMenuItem.Text = "Get SHA";
            this.getSHAToolStripMenuItem.Click += new System.EventHandler(this.getSHAToolStripMenuItem_Click);
            // 
            // pbImage
            // 
            this.pbImage.Image = global::clipmon.Properties.Resources.clickup;
            this.pbImage.Location = new System.Drawing.Point(279, 12);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(67, 62);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 1;
            this.pbImage.TabStop = false;
            this.pbImage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseDoubleClick);
            // 
            // lblSan
            // 
            this.lblSan.AutoSize = true;
            this.lblSan.Location = new System.Drawing.Point(350, 175);
            this.lblSan.Name = "lblSan";
            this.lblSan.Size = new System.Drawing.Size(47, 13);
            this.lblSan.TabIndex = 16;
            this.lblSan.Text = "Sanitize:";
            // 
            // txtSan
            // 
            this.txtSan.Location = new System.Drawing.Point(350, 189);
            this.txtSan.Name = "txtSan";
            this.txtSan.Size = new System.Drawing.Size(210, 20);
            this.txtSan.TabIndex = 15;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(218, 70);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(44, 23);
            this.btnCopy.TabIndex = 17;
            this.btnCopy.Text = "Kopi";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // clipMonMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(625, 216);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lblSan);
            this.Controls.Add(this.txtSan);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBG);
            this.Controls.Add(this.lblBG);
            this.Controls.Add(this.lblRegex);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.txtRegex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.listAlerters);
            this.MaximizeBox = false;
            this.Name = "clipMonMainForm";
            this.ShowIcon = false;
            this.Text = "ClipMon 1.3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.clipMonMainForm_FormClosing);
            this.Load += new System.EventHandler(this.clipMonMain_Load);
            this.Resize += new System.EventHandler(this.clipMonMainForm_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon nfIcon;
        private System.Windows.Forms.ListBox listAlerters;
        private System.Windows.Forms.OpenFileDialog ofdAlertImage;
        private System.Windows.Forms.ColorDialog cpAlertBG;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRegex;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblRegex;
        private System.Windows.Forms.Label lblBG;
        private System.Windows.Forms.TextBox txtBG;
        private System.Windows.Forms.Timer timbgCol;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getSHAToolStripMenuItem;
        private System.Windows.Forms.Label lblSan;
        private System.Windows.Forms.TextBox txtSan;
        private System.Windows.Forms.Button btnCopy;
    }
}

