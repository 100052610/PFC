using System.Drawing;
namespace LogsAnalyzerPFC
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
            System.Windows.Forms.ToolStripMenuItem toolStripHelp;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guíaDeUsoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.labelTitle = new System.Windows.Forms.Label();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSpanish = new System.Windows.Forms.Button();
            this.btnEnglish = new System.Windows.Forms.Button();
            this.helpBox2 = new System.Windows.Forms.PictureBox();
            this.helpBox3 = new System.Windows.Forms.PictureBox();
            this.helpBox4 = new System.Windows.Forms.PictureBox();
            this.helpBox1 = new System.Windows.Forms.PictureBox();
            this.lblCommandsState = new System.Windows.Forms.Label();
            this.lblLogsState = new System.Windows.Forms.Label();
            this.lblDbState = new System.Windows.Forms.Label();
            this.picBBDD = new System.Windows.Forms.PictureBox();
            this.picLogs = new System.Windows.Forms.PictureBox();
            this.picCommands = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnChargeLogFile = new System.Windows.Forms.Button();
            this.btnRestarDataBase = new System.Windows.Forms.Button();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btnAnalizeLogFile = new System.Windows.Forms.Button();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.btnClearDataBase = new System.Windows.Forms.Button();
            this.gb3 = new System.Windows.Forms.GroupBox();
            this.picVenn = new System.Windows.Forms.PictureBox();
            this.lblVennLeft = new System.Windows.Forms.Label();
            this.lblVennRight = new System.Windows.Forms.Label();
            this.lblVennLeftDesc = new System.Windows.Forms.Label();
            this.lblVennCommon = new System.Windows.Forms.Label();
            this.lblVennRightDesc = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            toolStripHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBBDD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCommands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gb1.SuspendLayout();
            this.gb2.SuspendLayout();
            this.gb3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVenn)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripHelp
            // 
            toolStripHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(146)))));
            toolStripHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem,
            this.guíaDeUsoToolStripMenuItem});
            resources.ApplyResources(toolStripHelp, "toolStripHelp");
            toolStripHelp.ForeColor = System.Drawing.SystemColors.Window;
            toolStripHelp.Name = "toolStripHelp";
            toolStripHelp.DropDownOpened += new System.EventHandler(this.toolStripHelp_DropDownOpened);
            toolStripHelp.DropDownClosed += new System.EventHandler(this.toolStripHelp_DropDownClosed);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(146)))));
            this.acercaDeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            resources.ApplyResources(this.acercaDeToolStripMenuItem, "acercaDeToolStripMenuItem");
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // guíaDeUsoToolStripMenuItem
            // 
            this.guíaDeUsoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(146)))));
            this.guíaDeUsoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.guíaDeUsoToolStripMenuItem.Name = "guíaDeUsoToolStripMenuItem";
            resources.ApplyResources(this.guíaDeUsoToolStripMenuItem, "guíaDeUsoToolStripMenuItem");
            this.guíaDeUsoToolStripMenuItem.Click += new System.EventHandler(this.guíaDeUsoToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Window;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
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
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(146)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripHelp});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // btnSpanish
            // 
            resources.ApplyResources(this.btnSpanish, "btnSpanish");
            this.btnSpanish.Image = global::LogsAnalyzerPFC.Properties.Resources.bandera;
            this.btnSpanish.Name = "btnSpanish";
            this.toolTip1.SetToolTip(this.btnSpanish, resources.GetString("btnSpanish.ToolTip"));
            this.btnSpanish.UseVisualStyleBackColor = true;
            this.btnSpanish.Click += new System.EventHandler(this.btnSpanish_Click);
            // 
            // btnEnglish
            // 
            resources.ApplyResources(this.btnEnglish, "btnEnglish");
            this.btnEnglish.Image = global::LogsAnalyzerPFC.Properties.Resources.BanderaUK;
            this.btnEnglish.Name = "btnEnglish";
            this.toolTip1.SetToolTip(this.btnEnglish, resources.GetString("btnEnglish.ToolTip"));
            this.btnEnglish.UseVisualStyleBackColor = true;
            this.btnEnglish.Click += new System.EventHandler(this.btnEnglish_Click);
            // 
            // helpBox2
            // 
            this.helpBox2.Image = global::LogsAnalyzerPFC.Properties.Resources.MB__help;
            resources.ApplyResources(this.helpBox2, "helpBox2");
            this.helpBox2.Name = "helpBox2";
            this.helpBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.helpBox2, resources.GetString("helpBox2.ToolTip"));
            // 
            // helpBox3
            // 
            this.helpBox3.Image = global::LogsAnalyzerPFC.Properties.Resources.MB__help;
            resources.ApplyResources(this.helpBox3, "helpBox3");
            this.helpBox3.Name = "helpBox3";
            this.helpBox3.TabStop = false;
            this.toolTip1.SetToolTip(this.helpBox3, resources.GetString("helpBox3.ToolTip"));
            // 
            // helpBox4
            // 
            this.helpBox4.Image = global::LogsAnalyzerPFC.Properties.Resources.MB__help;
            resources.ApplyResources(this.helpBox4, "helpBox4");
            this.helpBox4.Name = "helpBox4";
            this.helpBox4.TabStop = false;
            this.toolTip1.SetToolTip(this.helpBox4, resources.GetString("helpBox4.ToolTip"));
            // 
            // helpBox1
            // 
            this.helpBox1.Image = global::LogsAnalyzerPFC.Properties.Resources.MB__help;
            resources.ApplyResources(this.helpBox1, "helpBox1");
            this.helpBox1.Name = "helpBox1";
            this.helpBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.helpBox1, resources.GetString("helpBox1.ToolTip"));
            // 
            // lblCommandsState
            // 
            resources.ApplyResources(this.lblCommandsState, "lblCommandsState");
            this.lblCommandsState.Name = "lblCommandsState";
            // 
            // lblLogsState
            // 
            resources.ApplyResources(this.lblLogsState, "lblLogsState");
            this.lblLogsState.Name = "lblLogsState";
            // 
            // lblDbState
            // 
            resources.ApplyResources(this.lblDbState, "lblDbState");
            this.lblDbState.Name = "lblDbState";
            // 
            // picBBDD
            // 
            this.picBBDD.Image = global::LogsAnalyzerPFC.Properties.Resources.database_fail;
            resources.ApplyResources(this.picBBDD, "picBBDD");
            this.picBBDD.Name = "picBBDD";
            this.picBBDD.TabStop = false;
            // 
            // picLogs
            // 
            this.picLogs.Image = global::LogsAnalyzerPFC.Properties.Resources.bat_roja;
            resources.ApplyResources(this.picLogs, "picLogs");
            this.picLogs.Name = "picLogs";
            this.picLogs.TabStop = false;
            // 
            // picCommands
            // 
            this.picCommands.Image = global::LogsAnalyzerPFC.Properties.Resources.bat_roja;
            resources.ApplyResources(this.picCommands, "picCommands");
            this.picCommands.Name = "picCommands";
            this.picCommands.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LogsAnalyzerPFC.Properties.Resources.logo_uc3m;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LogsAnalyzerPFC.Properties.Resources.image_pen1;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // btnChargeLogFile
            // 
            resources.ApplyResources(this.btnChargeLogFile, "btnChargeLogFile");
            this.btnChargeLogFile.Name = "btnChargeLogFile";
            this.btnChargeLogFile.UseVisualStyleBackColor = true;
            this.btnChargeLogFile.Click += new System.EventHandler(this.btnChargeLogFile_Click);
            // 
            // btnRestarDataBase
            // 
            this.btnRestarDataBase.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnRestarDataBase.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnRestarDataBase, "btnRestarDataBase");
            this.btnRestarDataBase.Name = "btnRestarDataBase";
            this.btnRestarDataBase.UseVisualStyleBackColor = true;
            this.btnRestarDataBase.Click += new System.EventHandler(this.btnRestarDataBase_Click);
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.helpBox3);
            this.gb1.Controls.Add(this.helpBox2);
            this.gb1.Controls.Add(this.btnRestarDataBase);
            this.gb1.Controls.Add(this.btnChargeLogFile);
            resources.ApplyResources(this.gb1, "gb1");
            this.gb1.Name = "gb1";
            this.gb1.TabStop = false;
            // 
            // btnAnalizeLogFile
            // 
            resources.ApplyResources(this.btnAnalizeLogFile, "btnAnalizeLogFile");
            this.btnAnalizeLogFile.Name = "btnAnalizeLogFile";
            this.btnAnalizeLogFile.UseVisualStyleBackColor = true;
            this.btnAnalizeLogFile.Click += new System.EventHandler(this.btnAnalizeLogFile_Click);
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.helpBox4);
            this.gb2.Controls.Add(this.btnAnalizeLogFile);
            resources.ApplyResources(this.gb2, "gb2");
            this.gb2.Name = "gb2";
            this.gb2.TabStop = false;
            // 
            // btnClearDataBase
            // 
            this.btnClearDataBase.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnClearDataBase.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnClearDataBase, "btnClearDataBase");
            this.btnClearDataBase.Name = "btnClearDataBase";
            this.btnClearDataBase.UseVisualStyleBackColor = true;
            this.btnClearDataBase.Click += new System.EventHandler(this.btnClearDataBase_Click);
            // 
            // gb3
            // 
            this.gb3.Controls.Add(this.helpBox1);
            this.gb3.Controls.Add(this.btnClearDataBase);
            resources.ApplyResources(this.gb3, "gb3");
            this.gb3.Name = "gb3";
            this.gb3.TabStop = false;
            // 
            // picVenn
            // 
            this.picVenn.Image = global::LogsAnalyzerPFC.Properties.Resources.venn;
            resources.ApplyResources(this.picVenn, "picVenn");
            this.picVenn.Name = "picVenn";
            this.picVenn.TabStop = false;
            // 
            // lblVennLeft
            // 
            resources.ApplyResources(this.lblVennLeft, "lblVennLeft");
            this.lblVennLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblVennLeft.ForeColor = System.Drawing.Color.White;
            this.lblVennLeft.MinimumSize = new System.Drawing.Size(35, 13);
            this.lblVennLeft.Name = "lblVennLeft";
            // 
            // lblVennRight
            // 
            resources.ApplyResources(this.lblVennRight, "lblVennRight");
            this.lblVennRight.BackColor = System.Drawing.Color.Transparent;
            this.lblVennRight.ForeColor = System.Drawing.Color.White;
            this.lblVennRight.MinimumSize = new System.Drawing.Size(35, 13);
            this.lblVennRight.Name = "lblVennRight";
            // 
            // lblVennLeftDesc
            // 
            resources.ApplyResources(this.lblVennLeftDesc, "lblVennLeftDesc");
            this.lblVennLeftDesc.Name = "lblVennLeftDesc";
            // 
            // lblVennCommon
            // 
            resources.ApplyResources(this.lblVennCommon, "lblVennCommon");
            this.lblVennCommon.BackColor = System.Drawing.Color.Transparent;
            this.lblVennCommon.ForeColor = System.Drawing.Color.White;
            this.lblVennCommon.MinimumSize = new System.Drawing.Size(35, 13);
            this.lblVennCommon.Name = "lblVennCommon";
            // 
            // lblVennRightDesc
            // 
            resources.ApplyResources(this.lblVennRightDesc, "lblVennRightDesc");
            this.lblVennRightDesc.Name = "lblVennRightDesc";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.lblVennRightDesc);
            this.panel1.Controls.Add(this.lblVennCommon);
            this.panel1.Controls.Add(this.lblVennLeftDesc);
            this.panel1.Controls.Add(this.lblVennRight);
            this.panel1.Controls.Add(this.lblVennLeft);
            this.panel1.Controls.Add(this.picVenn);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gb3);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.lblDbState);
            this.Controls.Add(this.picBBDD);
            this.Controls.Add(this.lblLogsState);
            this.Controls.Add(this.lblCommandsState);
            this.Controls.Add(this.picLogs);
            this.Controls.Add(this.picCommands);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSpanish);
            this.Controls.Add(this.btnEnglish);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox2);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBBDD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCommands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gb1.ResumeLayout(false);
            this.gb2.ResumeLayout(false);
            this.gb3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picVenn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnEnglish;
        private System.Windows.Forms.Button btnSpanish;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guíaDeUsoToolStripMenuItem;
        private System.Windows.Forms.PictureBox picCommands;
        private System.Windows.Forms.PictureBox picLogs;
        private System.Windows.Forms.Label lblCommandsState;
        private System.Windows.Forms.Label lblLogsState;
        private System.Windows.Forms.PictureBox picBBDD;
        private System.Windows.Forms.Label lblDbState;
        private System.Windows.Forms.Button btnChargeLogFile;
        private System.Windows.Forms.Button btnRestarDataBase;
        private System.Windows.Forms.PictureBox helpBox2;
        private System.Windows.Forms.PictureBox helpBox3;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Button btnAnalizeLogFile;
        private System.Windows.Forms.PictureBox helpBox4;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.Button btnClearDataBase;
        private System.Windows.Forms.PictureBox helpBox1;
        private System.Windows.Forms.GroupBox gb3;
        private System.Windows.Forms.PictureBox picVenn;
        private System.Windows.Forms.Label lblVennLeft;
        private System.Windows.Forms.Label lblVennRight;
        private System.Windows.Forms.Label lblVennLeftDesc;
        private System.Windows.Forms.Label lblVennCommon;
        private System.Windows.Forms.Label lblVennRightDesc;
        private System.Windows.Forms.Panel panel1;
    }
}