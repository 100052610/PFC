namespace LogsAnalyzerPFC.forms
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.gbSelectReports = new System.Windows.Forms.GroupBox();
            this.checkMultiselect = new System.Windows.Forms.CheckBox();
            this.btnSelectAllInitialReports = new System.Windows.Forms.Button();
            this.btnClearInitialReport = new System.Windows.Forms.Button();
            this.btnClearSelReport = new System.Windows.Forms.Button();
            this.btnResetSelReports = new System.Windows.Forms.Button();
            this.lbxSelectedReports = new System.Windows.Forms.ListBox();
            this.lblRightReportsTitle = new System.Windows.Forms.Label();
            this.gBFilters = new System.Windows.Forms.GroupBox();
            this.btnAddReport = new System.Windows.Forms.Button();
            this.cBCategory = new System.Windows.Forms.ComboBox();
            this.cBCommand = new System.Windows.Forms.ComboBox();
            this.cBUser = new System.Windows.Forms.ComboBox();
            this.checkCategoryFilter = new System.Windows.Forms.CheckBox();
            this.checkCommandFilter = new System.Windows.Forms.CheckBox();
            this.checkUserFilter = new System.Windows.Forms.CheckBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnMakeReports = new System.Windows.Forms.Button();
            this.lblLeftReportsTitle = new System.Windows.Forms.Label();
            this.lbxReports = new System.Windows.Forms.ListBox();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbInitUserFilter = new System.Windows.Forms.RadioButton();
            this.rbInitCommandFilter = new System.Windows.Forms.RadioButton();
            this.rbInitNoneFilter = new System.Windows.Forms.RadioButton();
            this.gbInitialFiltersGroup = new System.Windows.Forms.GroupBox();
            this.rbInitGeneralFilter = new System.Windows.Forms.RadioButton();
            this.rbInitCategoryFilter = new System.Windows.Forms.RadioButton();
            this.gbSelectReports.SuspendLayout();
            this.gBFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbInitialFiltersGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSelectReports
            // 
            this.gbSelectReports.Controls.Add(this.checkMultiselect);
            this.gbSelectReports.Controls.Add(this.btnSelectAllInitialReports);
            this.gbSelectReports.Controls.Add(this.btnClearInitialReport);
            this.gbSelectReports.Controls.Add(this.btnClearSelReport);
            this.gbSelectReports.Controls.Add(this.btnResetSelReports);
            this.gbSelectReports.Controls.Add(this.lbxSelectedReports);
            this.gbSelectReports.Controls.Add(this.lblRightReportsTitle);
            this.gbSelectReports.Controls.Add(this.gBFilters);
            this.gbSelectReports.Controls.Add(this.btnHome);
            this.gbSelectReports.Controls.Add(this.pictureBox2);
            this.gbSelectReports.Controls.Add(this.btnMakeReports);
            this.gbSelectReports.Controls.Add(this.lblLeftReportsTitle);
            this.gbSelectReports.Controls.Add(this.lbxReports);
            resources.ApplyResources(this.gbSelectReports, "gbSelectReports");
            this.gbSelectReports.Name = "gbSelectReports";
            this.gbSelectReports.TabStop = false;
            // 
            // checkMultiselect
            // 
            resources.ApplyResources(this.checkMultiselect, "checkMultiselect");
            this.checkMultiselect.Name = "checkMultiselect";
            this.checkMultiselect.UseVisualStyleBackColor = true;
            this.checkMultiselect.CheckedChanged += new System.EventHandler(this.checkMultiselect_CheckedChanged);
            // 
            // btnSelectAllInitialReports
            // 
            resources.ApplyResources(this.btnSelectAllInitialReports, "btnSelectAllInitialReports");
            this.btnSelectAllInitialReports.Name = "btnSelectAllInitialReports";
            this.btnSelectAllInitialReports.UseVisualStyleBackColor = true;
            this.btnSelectAllInitialReports.Click += new System.EventHandler(this.btnSelectAllInitialReports_Click);
            // 
            // btnClearInitialReport
            // 
            resources.ApplyResources(this.btnClearInitialReport, "btnClearInitialReport");
            this.btnClearInitialReport.Name = "btnClearInitialReport";
            this.btnClearInitialReport.UseVisualStyleBackColor = true;
            this.btnClearInitialReport.Click += new System.EventHandler(this.btnClearInitialReport_Click);
            // 
            // btnClearSelReport
            // 
            resources.ApplyResources(this.btnClearSelReport, "btnClearSelReport");
            this.btnClearSelReport.Name = "btnClearSelReport";
            this.btnClearSelReport.UseVisualStyleBackColor = true;
            this.btnClearSelReport.Click += new System.EventHandler(this.btnClearSelReport_Click);
            // 
            // btnResetSelReports
            // 
            resources.ApplyResources(this.btnResetSelReports, "btnResetSelReports");
            this.btnResetSelReports.Name = "btnResetSelReports";
            this.btnResetSelReports.UseVisualStyleBackColor = true;
            this.btnResetSelReports.Click += new System.EventHandler(this.btnResetSelReports_Click);
            // 
            // lbxSelectedReports
            // 
            this.lbxSelectedReports.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            resources.ApplyResources(this.lbxSelectedReports, "lbxSelectedReports");
            this.lbxSelectedReports.FormattingEnabled = true;
            this.lbxSelectedReports.Name = "lbxSelectedReports";
            this.lbxSelectedReports.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbxSelectedReports_DrawItem);
            this.lbxSelectedReports.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lbxSelectedReports_MeasureItem);
            this.lbxSelectedReports.SelectedIndexChanged += new System.EventHandler(this.lbxSelectedReports_SelectedIndexChanged);
            // 
            // lblRightReportsTitle
            // 
            resources.ApplyResources(this.lblRightReportsTitle, "lblRightReportsTitle");
            this.lblRightReportsTitle.Name = "lblRightReportsTitle";
            // 
            // gBFilters
            // 
            this.gBFilters.Controls.Add(this.btnAddReport);
            this.gBFilters.Controls.Add(this.cBCategory);
            this.gBFilters.Controls.Add(this.cBCommand);
            this.gBFilters.Controls.Add(this.cBUser);
            this.gBFilters.Controls.Add(this.checkCategoryFilter);
            this.gBFilters.Controls.Add(this.checkCommandFilter);
            this.gBFilters.Controls.Add(this.checkUserFilter);
            resources.ApplyResources(this.gBFilters, "gBFilters");
            this.gBFilters.Name = "gBFilters";
            this.gBFilters.TabStop = false;
            // 
            // btnAddReport
            // 
            resources.ApplyResources(this.btnAddReport, "btnAddReport");
            this.btnAddReport.Name = "btnAddReport";
            this.btnAddReport.UseVisualStyleBackColor = true;
            this.btnAddReport.Click += new System.EventHandler(this.btnAddReport_Click);
            // 
            // cBCategory
            // 
            this.cBCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBCategory.DropDownWidth = 200;
            resources.ApplyResources(this.cBCategory, "cBCategory");
            this.cBCategory.FormattingEnabled = true;
            this.cBCategory.Name = "cBCategory";
            this.cBCategory.VisibleChanged += new System.EventHandler(this.cBCategory_VisibleChanged);
            this.cBCategory.SelectedIndexChanged += new System.EventHandler(this.cBCategory_SelectedIndexChanged);
            // 
            // cBCommand
            // 
            this.cBCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBCommand.DropDownWidth = 150;
            resources.ApplyResources(this.cBCommand, "cBCommand");
            this.cBCommand.FormattingEnabled = true;
            this.cBCommand.Name = "cBCommand";
            this.cBCommand.VisibleChanged += new System.EventHandler(this.cBCommand_VisibleChanged);
            this.cBCommand.SelectedIndexChanged += new System.EventHandler(this.cBCommand_SelectedIndexChanged);
            // 
            // cBUser
            // 
            this.cBUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBUser.DropDownWidth = 100;
            resources.ApplyResources(this.cBUser, "cBUser");
            this.cBUser.Name = "cBUser";
            this.cBUser.VisibleChanged += new System.EventHandler(this.cBUser_VisibleChanged);
            this.cBUser.SelectedIndexChanged += new System.EventHandler(this.cBUser_SelectedIndexChanged);
            // 
            // checkCategoryFilter
            // 
            resources.ApplyResources(this.checkCategoryFilter, "checkCategoryFilter");
            this.checkCategoryFilter.Name = "checkCategoryFilter";
            this.checkCategoryFilter.UseVisualStyleBackColor = true;
            this.checkCategoryFilter.VisibleChanged += new System.EventHandler(this.checkCategoryFilter_VisibleChanged);
            this.checkCategoryFilter.CheckedChanged += new System.EventHandler(this.checkCategoryFilter_CheckedChanged);
            // 
            // checkCommandFilter
            // 
            resources.ApplyResources(this.checkCommandFilter, "checkCommandFilter");
            this.checkCommandFilter.Name = "checkCommandFilter";
            this.checkCommandFilter.UseVisualStyleBackColor = true;
            this.checkCommandFilter.VisibleChanged += new System.EventHandler(this.checkCommandFilter_VisibleChanged);
            this.checkCommandFilter.CheckedChanged += new System.EventHandler(this.checkCommandFilter_CheckedChanged);
            // 
            // checkUserFilter
            // 
            resources.ApplyResources(this.checkUserFilter, "checkUserFilter");
            this.checkUserFilter.Name = "checkUserFilter";
            this.checkUserFilter.UseVisualStyleBackColor = true;
            this.checkUserFilter.VisibleChanged += new System.EventHandler(this.checkUserFilter_VisibleChanged);
            this.checkUserFilter.CheckedChanged += new System.EventHandler(this.checkUserFilter_CheckedChanged);
            // 
            // btnHome
            // 
            resources.ApplyResources(this.btnHome, "btnHome");
            this.btnHome.Name = "btnHome";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LogsAnalyzerPFC.Properties.Resources.lupa;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // btnMakeReports
            // 
            resources.ApplyResources(this.btnMakeReports, "btnMakeReports");
            this.btnMakeReports.Name = "btnMakeReports";
            this.btnMakeReports.UseVisualStyleBackColor = true;
            this.btnMakeReports.Click += new System.EventHandler(this.btnMakeReports_Click);
            // 
            // lblLeftReportsTitle
            // 
            resources.ApplyResources(this.lblLeftReportsTitle, "lblLeftReportsTitle");
            this.lblLeftReportsTitle.Name = "lblLeftReportsTitle";
            // 
            // lbxReports
            // 
            this.lbxReports.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            resources.ApplyResources(this.lbxReports, "lbxReports");
            this.lbxReports.FormattingEnabled = true;
            this.lbxReports.Name = "lbxReports";
            this.lbxReports.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbxReports_DrawItem);
            this.lbxReports.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lbxReports_MeasureItem);
            this.lbxReports.SelectedIndexChanged += new System.EventHandler(this.lbxReports_SelectedIndexChanged);
            // 
            // btnResetFilters
            // 
            resources.ApplyResources(this.btnResetFilters, "btnResetFilters");
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.UseVisualStyleBackColor = true;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(146)))));
            resources.ApplyResources(this.menuStrip2, "menuStrip2");
            this.menuStrip2.Name = "menuStrip2";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(146)))));
            resources.ApplyResources(this.toolStripTextBox1, "toolStripTextBox1");
            this.toolStripTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // statusStrip2
            // 
            resources.ApplyResources(this.statusStrip2, "statusStrip2");
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip2.Name = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LogsAnalyzerPFC.Properties.Resources.logo_uc3m;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // rbInitUserFilter
            // 
            resources.ApplyResources(this.rbInitUserFilter, "rbInitUserFilter");
            this.rbInitUserFilter.Name = "rbInitUserFilter";
            this.rbInitUserFilter.UseVisualStyleBackColor = true;
            this.rbInitUserFilter.CheckedChanged += new System.EventHandler(this.rbInitFilter_CheckedChanged);
            // 
            // rbInitCommandFilter
            // 
            resources.ApplyResources(this.rbInitCommandFilter, "rbInitCommandFilter");
            this.rbInitCommandFilter.Name = "rbInitCommandFilter";
            this.rbInitCommandFilter.UseVisualStyleBackColor = true;
            this.rbInitCommandFilter.CheckedChanged += new System.EventHandler(this.rbInitFilter_CheckedChanged);
            // 
            // rbInitNoneFilter
            // 
            resources.ApplyResources(this.rbInitNoneFilter, "rbInitNoneFilter");
            this.rbInitNoneFilter.Name = "rbInitNoneFilter";
            this.rbInitNoneFilter.UseVisualStyleBackColor = true;
            this.rbInitNoneFilter.CheckedChanged += new System.EventHandler(this.rbInitFilter_CheckedChanged);
            // 
            // gbInitialFiltersGroup
            // 
            this.gbInitialFiltersGroup.Controls.Add(this.rbInitGeneralFilter);
            this.gbInitialFiltersGroup.Controls.Add(this.rbInitCategoryFilter);
            this.gbInitialFiltersGroup.Controls.Add(this.rbInitNoneFilter);
            this.gbInitialFiltersGroup.Controls.Add(this.rbInitUserFilter);
            this.gbInitialFiltersGroup.Controls.Add(this.rbInitCommandFilter);
            resources.ApplyResources(this.gbInitialFiltersGroup, "gbInitialFiltersGroup");
            this.gbInitialFiltersGroup.Name = "gbInitialFiltersGroup";
            this.gbInitialFiltersGroup.TabStop = false;
            // 
            // rbInitGeneralFilter
            // 
            resources.ApplyResources(this.rbInitGeneralFilter, "rbInitGeneralFilter");
            this.rbInitGeneralFilter.Name = "rbInitGeneralFilter";
            this.rbInitGeneralFilter.UseVisualStyleBackColor = true;
            this.rbInitGeneralFilter.CheckedChanged += new System.EventHandler(this.rbInitFilter_CheckedChanged);
            // 
            // rbInitCategoryFilter
            // 
            resources.ApplyResources(this.rbInitCategoryFilter, "rbInitCategoryFilter");
            this.rbInitCategoryFilter.Name = "rbInitCategoryFilter";
            this.rbInitCategoryFilter.UseVisualStyleBackColor = true;
            this.rbInitCategoryFilter.CheckedChanged += new System.EventHandler(this.rbInitFilter_CheckedChanged);
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ControlBox = false;
            this.Controls.Add(this.gbInitialFiltersGroup);
            this.Controls.Add(this.btnResetFilters);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.gbSelectReports);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.gbSelectReports.ResumeLayout(false);
            this.gbSelectReports.PerformLayout();
            this.gBFilters.ResumeLayout(false);
            this.gBFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbInitialFiltersGroup.ResumeLayout(false);
            this.gbInitialFiltersGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSelectReports;
        private System.Windows.Forms.ListBox lbxReports;
        private System.Windows.Forms.Button btnMakeReports;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.Label lblLeftReportsTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.GroupBox gBFilters;
        private System.Windows.Forms.CheckBox checkCategoryFilter;
        private System.Windows.Forms.CheckBox checkCommandFilter;
        private System.Windows.Forms.CheckBox checkUserFilter;
        private System.Windows.Forms.ComboBox cBUser;
        private System.Windows.Forms.ComboBox cBCategory;
        private System.Windows.Forms.ComboBox cBCommand;
        private System.Windows.Forms.Button btnAddReport;
        private System.Windows.Forms.Label lblRightReportsTitle;
        private System.Windows.Forms.ListBox lbxSelectedReports;
        private System.Windows.Forms.Button btnResetSelReports;
        private System.Windows.Forms.Button btnClearSelReport;
        private System.Windows.Forms.Button btnResetFilters;
        private System.Windows.Forms.Button btnSelectAllInitialReports;
        private System.Windows.Forms.Button btnClearInitialReport;
        private System.Windows.Forms.CheckBox checkMultiselect;
        private System.Windows.Forms.RadioButton rbInitUserFilter;
        private System.Windows.Forms.RadioButton rbInitCommandFilter;
        private System.Windows.Forms.RadioButton rbInitNoneFilter;
        private System.Windows.Forms.GroupBox gbInitialFiltersGroup;
        private System.Windows.Forms.RadioButton rbInitCategoryFilter;
        private System.Windows.Forms.RadioButton rbInitGeneralFilter;
    }
}