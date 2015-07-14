namespace LogsAnalyzerPFC.forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.gbReports = new System.Windows.Forms.GroupBox();
            this.btnMAIL = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnEXCEL = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkShot = new System.Windows.Forms.CheckBox();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.gBSelectedReports = new System.Windows.Forms.GroupBox();
            this.lbxGeneratedReports = new System.Windows.Forms.ListBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.checkPdf = new System.Windows.Forms.CheckBox();
            this.checkExcel = new System.Windows.Forms.CheckBox();
            this.gBMail = new System.Windows.Forms.GroupBox();
            this.statusStrip3.SuspendLayout();
            this.gbReports.SuspendLayout();
            this.gBSelectedReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.gBMail.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip3
            // 
            this.menuStrip3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(146)))));
            resources.ApplyResources(this.menuStrip3, "menuStrip3");
            this.menuStrip3.Name = "menuStrip3";
            // 
            // statusStrip3
            // 
            resources.ApplyResources(this.statusStrip3, "statusStrip3");
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip3.Name = "statusStrip3";
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            // 
            // gbReports
            // 
            this.gbReports.Controls.Add(this.btnMAIL);
            this.gbReports.Controls.Add(this.btnPDF);
            this.gbReports.Controls.Add(this.btnEXCEL);
            this.gbReports.Controls.Add(this.label4);
            this.gbReports.Controls.Add(this.label3);
            this.gbReports.Controls.Add(this.label1);
            this.gbReports.Controls.Add(this.checkShot);
            resources.ApplyResources(this.gbReports, "gbReports");
            this.gbReports.Name = "gbReports";
            this.gbReports.TabStop = false;
            // 
            // btnMAIL
            // 
            this.btnMAIL.Image = global::LogsAnalyzerPFC.Properties.Resources.btnMail;
            resources.ApplyResources(this.btnMAIL, "btnMAIL");
            this.btnMAIL.Name = "btnMAIL";
            this.btnMAIL.UseVisualStyleBackColor = true;
            this.btnMAIL.Click += new System.EventHandler(this.btnMAIL_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.Image = global::LogsAnalyzerPFC.Properties.Resources.btnPdf;
            resources.ApplyResources(this.btnPDF, "btnPDF");
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnEXCEL
            // 
            this.btnEXCEL.Image = global::LogsAnalyzerPFC.Properties.Resources.btnExcel;
            resources.ApplyResources(this.btnEXCEL, "btnEXCEL");
            this.btnEXCEL.Name = "btnEXCEL";
            this.btnEXCEL.UseVisualStyleBackColor = true;
            this.btnEXCEL.Click += new System.EventHandler(this.btnEXCEL_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // checkShot
            // 
            resources.ApplyResources(this.checkShot, "checkShot");
            this.checkShot.Name = "checkShot";
            this.checkShot.UseVisualStyleBackColor = true;
            // 
            // btnSendMail
            // 
            resources.ApplyResources(this.btnSendMail, "btnSendMail");
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // textBoxEmail
            // 
            resources.ApplyResources(this.textBoxEmail, "textBoxEmail");
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Leave += new System.EventHandler(this.textBoxEmail_Leave);
            this.textBoxEmail.Enter += new System.EventHandler(this.textBoxEmail_Enter);
            // 
            // gBSelectedReports
            // 
            this.gBSelectedReports.Controls.Add(this.lbxGeneratedReports);
            this.gBSelectedReports.Controls.Add(this.btnHome);
            this.gBSelectedReports.Controls.Add(this.btnBack);
            resources.ApplyResources(this.gBSelectedReports, "gBSelectedReports");
            this.gBSelectedReports.Name = "gBSelectedReports";
            this.gBSelectedReports.TabStop = false;
            // 
            // lbxGeneratedReports
            // 
            this.lbxGeneratedReports.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            resources.ApplyResources(this.lbxGeneratedReports, "lbxGeneratedReports");
            this.lbxGeneratedReports.FormattingEnabled = true;
            this.lbxGeneratedReports.Name = "lbxGeneratedReports";
            this.lbxGeneratedReports.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbxGeneratedReports_DrawItem);
            this.lbxGeneratedReports.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lbxGeneratedReports_MeasureItem);
            // 
            // btnHome
            // 
            resources.ApplyResources(this.btnHome, "btnHome");
            this.btnHome.Name = "btnHome";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnBack
            // 
            resources.ApplyResources(this.btnBack, "btnBack");
            this.btnBack.Name = "btnBack";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::LogsAnalyzerPFC.Properties.Resources.logo_uc3m;
            resources.ApplyResources(this.pictureBox5, "pictureBox5");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.TabStop = false;
            // 
            // checkPdf
            // 
            resources.ApplyResources(this.checkPdf, "checkPdf");
            this.checkPdf.Name = "checkPdf";
            this.checkPdf.UseVisualStyleBackColor = true;
            // 
            // checkExcel
            // 
            resources.ApplyResources(this.checkExcel, "checkExcel");
            this.checkExcel.Name = "checkExcel";
            this.checkExcel.UseVisualStyleBackColor = true;
            // 
            // gBMail
            // 
            this.gBMail.Controls.Add(this.checkExcel);
            this.gBMail.Controls.Add(this.checkPdf);
            this.gBMail.Controls.Add(this.btnSendMail);
            this.gBMail.Controls.Add(this.textBoxEmail);
            resources.ApplyResources(this.gBMail, "gBMail");
            this.gBMail.Name = "gBMail";
            this.gBMail.TabStop = false;
            // 
            // Form3
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ControlBox = false;
            this.Controls.Add(this.gBMail);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.gBSelectedReports);
            this.Controls.Add(this.gbReports);
            this.Controls.Add(this.statusStrip3);
            this.Controls.Add(this.menuStrip3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            this.gbReports.ResumeLayout(false);
            this.gbReports.PerformLayout();
            this.gBSelectedReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.gBMail.ResumeLayout(false);
            this.gBMail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.GroupBox gbReports;
        private System.Windows.Forms.CheckBox checkShot;
        private System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.GroupBox gBSelectedReports;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEXCEL;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Button btnMAIL;
        private System.Windows.Forms.CheckBox checkPdf;
        private System.Windows.Forms.CheckBox checkExcel;
        private System.Windows.Forms.GroupBox gBMail;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.ListBox lbxGeneratedReports;
    }
}