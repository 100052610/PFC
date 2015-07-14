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
            this.gbSelectReports.AccessibleDescription = null;
            this.gbSelectReports.AccessibleName = null;
            resources.ApplyResources(this.gbSelectReports, "gbSelectReports");
            this.gbSelectReports.BackgroundImage = null;
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
            this.gbSelectReports.Name = "gbSelectReports";
            this.gbSelectReports.TabStop = false;
            // 
            // checkMultiselect
            // 
            this.checkMultiselect.AccessibleDescription = null;
            this.checkMultiselect.AccessibleName = null;
            resources.ApplyResources(this.checkMultiselect, "checkMultiselect");
            this.checkMultiselect.BackgroundImage = null;
            this.checkMultiselect.Name = "checkMultiselect";
            this.checkMultiselect.UseVisualStyleBackColor = true;
            this.checkMultiselect.CheckedChanged += new System.EventHandler(this.checkMultiselect_CheckedChanged);
            // 
            // btnSelectAllInitialReports
            // 
            this.btnSelectAllInitialReports.AccessibleDescription = null;
            this.btnSelectAllInitialReports.AccessibleName = null;
            resources.ApplyResources(this.btnSelectAllInitialReports, "btnSelectAllInitialReports");
            this.btnSelectAllInitialReports.BackgroundImage = null;
            this.btnSelectAllInitialReports.Name = "btnSelectAllInitialReports";
            this.btnSelectAllInitialReports.UseVisualStyleBackColor = true;
            this.btnSelectAllInitialReports.Click += new System.EventHandler(this.btnSelectAllInitialReports_Click);
            // 
            // btnClearInitialReport
            // 
            this.btnClearInitialReport.AccessibleDescription = null;
            this.btnClearInitialReport.AccessibleName = null;
            resources.ApplyResources(this.btnClearInitialReport, "btnClearInitialReport");
            this.btnClearInitialReport.BackgroundImage = null;
            this.btnClearInitialReport.Name = "btnClearInitialReport";
            this.btnClearInitialReport.UseVisualStyleBackColor = true;
            this.btnClearInitialReport.Click += new System.EventHandler(this.btnClearInitialReport_Click);
            // 
            // btnClearSelReport
            // 
            this.btnClearSelReport.AccessibleDescription = null;
            this.btnClearSelReport.AccessibleName = null;
            resources.ApplyResources(this.btnClearSelReport, "btnClearSelReport");
            this.btnClearSelReport.BackgroundImage = null;
            this.btnClearSelReport.Name = "btnClearSelReport";
            this.btnClearSelReport.UseVisualStyleBackColor = true;
            this.btnClearSelReport.Click += new System.EventHandler(this.btnClearSelReport_Click);
            // 
            // btnResetSelReports
            // 
            this.btnResetSelReports.AccessibleDescription = null;
            this.btnResetSelReports.AccessibleName = null;
            resources.ApplyResources(this.btnResetSelReports, "btnResetSelReports");
            this.btnResetSelReports.BackgroundImage = null;
            this.btnResetSelReports.Name = "btnResetSelReports";
            this.btnResetSelReports.UseVisualStyleBackColor = true;
            this.btnResetSelReports.Click += new System.EventHandler(this.btnResetSelReports_Click);
            // 
            // lbxSelectedReports
            // 
            this.lbxSelectedReports.AccessibleDescription = null;
            this.lbxSelectedReports.AccessibleName = null;
            resources.ApplyResources(this.lbxSelectedReports, "lbxSelectedReports");
            this.lbxSelectedReports.BackgroundImage = null;
            this.lbxSelectedReports.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbxSelectedReports.FormattingEnabled = true;
            this.lbxSelectedReports.Name = "lbxSelectedReports";
            this.lbxSelectedReports.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbxSelectedReports_DrawItem);
            this.lbxSelectedReports.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lbxSelectedReports_MeasureItem);
            this.lbxSelectedReports.SelectedIndexChanged += new System.EventHandler(this.lbxSelectedReports_SelectedIndexChanged);
            // 
            // lblRightReportsTitle
            // 
            this.lblRightReportsTitle.AccessibleDescription = null;
            this.lblRightReportsTitle.AccessibleName = null;
            resources.ApplyResources(this.lblRightReportsTitle, "lblRightReportsTitle");
            this.lblRightReportsTitle.Name = "lblRightReportsTitle";
            // 
            // gBFilters
            // 
            this.gBFilters.AccessibleDescription = null;
            this.gBFilters.AccessibleName = null;
            resources.ApplyResources(this.gBFilters, "gBFilters");
            this.gBFilters.BackgroundImage = null;
            this.gBFilters.Controls.Add(this.btnAddReport);
            this.gBFilters.Controls.Add(this.cBCategory);
            this.gBFilters.Controls.Add(this.cBCommand);
            this.gBFilters.Controls.Add(this.cBUser);
            this.gBFilters.Controls.Add(this.checkCategoryFilter);
            this.gBFilters.Controls.Add(this.checkCommandFilter);
            this.gBFilters.Controls.Add(this.checkUserFilter);
            this.gBFilters.Name = "gBFilters";
            this.gBFilters.TabStop = false;
            // 
            // btnAddReport
            // 
            this.btnAddReport.AccessibleDescription = null;
            this.btnAddReport.AccessibleName = null;
            resources.ApplyResources(this.btnAddReport, "btnAddReport");
            this.btnAddReport.BackgroundImage = null;
            this.btnAddReport.Name = "btnAddReport";
            this.btnAddReport.UseVisualStyleBackColor = true;
            this.btnAddReport.Click += new System.EventHandler(this.btnAddReport_Click);
            // 
            // cBCategory
            // 
            this.cBCategory.AccessibleDescription = null;
            this.cBCategory.AccessibleName = null;
            resources.ApplyResources(this.cBCategory, "cBCategory");
            this.cBCategory.BackgroundImage = null;
            this.cBCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBCategory.DropDownWidth = 200;
            this.cBCategory.FormattingEnabled = true;
            this.cBCategory.Name = "cBCategory";
            this.cBCategory.VisibleChanged += new System.EventHandler(this.cBCategory_VisibleChanged);
            this.cBCategory.SelectedIndexChanged += new System.EventHandler(this.cBCategory_SelectedIndexChanged);
            // 
            // cBCommand
            // 
            this.cBCommand.AccessibleDescription = null;
            this.cBCommand.AccessibleName = null;
            resources.ApplyResources(this.cBCommand, "cBCommand");
            this.cBCommand.BackgroundImage = null;
            this.cBCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBCommand.DropDownWidth = 150;
            this.cBCommand.FormattingEnabled = true;
            this.cBCommand.Name = "cBCommand";
            this.cBCommand.VisibleChanged += new System.EventHandler(this.cBCommand_VisibleChanged);
            this.cBCommand.SelectedIndexChanged += new System.EventHandler(this.cBCommand_SelectedIndexChanged);
            // 
            // cBUser
            // 
            this.cBUser.AccessibleDescription = null;
            this.cBUser.AccessibleName = null;
            resources.ApplyResources(this.cBUser, "cBUser");
            this.cBUser.BackgroundImage = null;
            this.cBUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBUser.DropDownWidth = 100;
            this.cBUser.Name = "cBUser";
            this.cBUser.VisibleChanged += new System.EventHandler(this.cBUser_VisibleChanged);
            this.cBUser.SelectedIndexChanged += new System.EventHandler(this.cBUser_SelectedIndexChanged);
            // 
            // checkCategoryFilter
            // 
            this.checkCategoryFilter.AccessibleDescription = null;
            this.checkCategoryFilter.AccessibleName = null;
            resources.ApplyResources(this.checkCategoryFilter, "checkCategoryFilter");
            this.checkCategoryFilter.BackgroundImage = null;
            this.checkCategoryFilter.Name = "checkCategoryFilter";
            this.checkCategoryFilter.UseVisualStyleBackColor = true;
            this.checkCategoryFilter.VisibleChanged += new System.EventHandler(this.checkCategoryFilter_VisibleChanged);
            this.checkCategoryFilter.CheckedChanged += new System.EventHandler(this.checkCategoryFilter_CheckedChanged);
            // 
            // checkCommandFilter
            // 
            this.checkCommandFilter.AccessibleDescription = null;
            this.checkCommandFilter.AccessibleName = null;
            resources.ApplyResources(this.checkCommandFilter, "checkCommandFilter");
            this.checkCommandFilter.BackgroundImage = null;
            this.checkCommandFilter.Name = "checkCommandFilter";
            this.checkCommandFilter.UseVisualStyleBackColor = true;
            this.checkCommandFilter.VisibleChanged += new System.EventHandler(this.checkCommandFilter_VisibleChanged);
            this.checkCommandFilter.CheckedChanged += new System.EventHandler(this.checkCommandFilter_CheckedChanged);
            // 
            // checkUserFilter
            // 
            this.checkUserFilter.AccessibleDescription = null;
            this.checkUserFilter.AccessibleName = null;
            resources.ApplyResources(this.checkUserFilter, "checkUserFilter");
            this.checkUserFilter.BackgroundImage = null;
            this.checkUserFilter.Name = "checkUserFilter";
            this.checkUserFilter.UseVisualStyleBackColor = true;
            this.checkUserFilter.VisibleChanged += new System.EventHandler(this.checkUserFilter_VisibleChanged);
            this.checkUserFilter.CheckedChanged += new System.EventHandler(this.checkUserFilter_CheckedChanged);
            // 
            // btnHome
            // 
            this.btnHome.AccessibleDescription = null;
            this.btnHome.AccessibleName = null;
            resources.ApplyResources(this.btnHome, "btnHome");
            this.btnHome.BackgroundImage = null;
            this.btnHome.Name = "btnHome";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.AccessibleDescription = null;
            this.pictureBox2.AccessibleName = null;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.BackgroundImage = null;
            this.pictureBox2.Font = null;
            this.pictureBox2.Image = global::LogsAnalyzerPFC.Properties.Resources.lupa;
            this.pictureBox2.ImageLocation = null;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // btnMakeReports
            // 
            this.btnMakeReports.AccessibleDescription = null;
            this.btnMakeReports.AccessibleName = null;
            resources.ApplyResources(this.btnMakeReports, "btnMakeReports");
            this.btnMakeReports.BackgroundImage = null;
            this.btnMakeReports.Name = "btnMakeReports";
            this.btnMakeReports.UseVisualStyleBackColor = true;
            this.btnMakeReports.Click += new System.EventHandler(this.btnMakeReports_Click);
            // 
            // lblLeftReportsTitle
            // 
            this.lblLeftReportsTitle.AccessibleDescription = null;
            this.lblLeftReportsTitle.AccessibleName = null;
            resources.ApplyResources(this.lblLeftReportsTitle, "lblLeftReportsTitle");
            this.lblLeftReportsTitle.Name = "lblLeftReportsTitle";
            // 
            // lbxReports
            // 
            this.lbxReports.AccessibleDescription = null;
            this.lbxReports.AccessibleName = null;
            resources.ApplyResources(this.lbxReports, "lbxReports");
            this.lbxReports.BackgroundImage = null;
            this.lbxReports.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbxReports.FormattingEnabled = true;
            this.lbxReports.Name = "lbxReports";
            this.lbxReports.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbxReports_DrawItem);
            this.lbxReports.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lbxReports_MeasureItem);
            this.lbxReports.SelectedIndexChanged += new System.EventHandler(this.lbxReports_SelectedIndexChanged);
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.AccessibleDescription = null;
            this.btnResetFilters.AccessibleName = null;
            resources.ApplyResources(this.btnResetFilters, "btnResetFilters");
            this.btnResetFilters.BackgroundImage = null;
            this.btnResetFilters.Font = null;
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.UseVisualStyleBackColor = true;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.AccessibleDescription = null;
            this.menuStrip2.AccessibleName = null;
            resources.ApplyResources(this.menuStrip2, "menuStrip2");
            this.menuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(146)))));
            this.menuStrip2.BackgroundImage = null;
            this.menuStrip2.Font = null;
            this.menuStrip2.Name = "menuStrip2";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AccessibleDescription = null;
            this.toolStripTextBox1.AccessibleName = null;
            resources.ApplyResources(this.toolStripTextBox1, "toolStripTextBox1");
            this.toolStripTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(146)))));
            this.toolStripTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            // 
            // labelTitle
            // 
            this.labelTitle.AccessibleDescription = null;
            this.labelTitle.AccessibleName = null;
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // statusStrip2
            // 
            this.statusStrip2.AccessibleDescription = null;
            this.statusStrip2.AccessibleName = null;
            resources.ApplyResources(this.statusStrip2, "statusStrip2");
            this.statusStrip2.BackgroundImage = null;
            this.statusStrip2.Font = null;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip2.Name = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AccessibleDescription = null;
            this.toolStripStatusLabel1.AccessibleName = null;
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.BackgroundImage = null;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AccessibleDescription = null;
            this.toolStripProgressBar1.AccessibleName = null;
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleDescription = null;
            this.pictureBox1.AccessibleName = null;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackgroundImage = null;
            this.pictureBox1.Font = null;
            this.pictureBox1.Image = global::LogsAnalyzerPFC.Properties.Resources.logo_uc3m;
            this.pictureBox1.ImageLocation = null;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // rbInitUserFilter
            // 
            this.rbInitUserFilter.AccessibleDescription = null;
            this.rbInitUserFilter.AccessibleName = null;
            resources.ApplyResources(this.rbInitUserFilter, "rbInitUserFilter");
            this.rbInitUserFilter.BackgroundImage = null;
            this.rbInitUserFilter.Name = "rbInitUserFilter";
            this.rbInitUserFilter.UseVisualStyleBackColor = true;
            this.rbInitUserFilter.CheckedChanged += new System.EventHandler(this.rbInitFilter_CheckedChanged);
            // 
            // rbInitCommandFilter
            // 
            this.rbInitCommandFilter.AccessibleDescription = null;
            this.rbInitCommandFilter.AccessibleName = null;
            resources.ApplyResources(this.rbInitCommandFilter, "rbInitCommandFilter");
            this.rbInitCommandFilter.BackgroundImage = null;
            this.rbInitCommandFilter.Name = "rbInitCommandFilter";
            this.rbInitCommandFilter.UseVisualStyleBackColor = true;
            this.rbInitCommandFilter.CheckedChanged += new System.EventHandler(this.rbInitFilter_CheckedChanged);
            // 
            // rbInitNoneFilter
            // 
            this.rbInitNoneFilter.AccessibleDescription = null;
            this.rbInitNoneFilter.AccessibleName = null;
            resources.ApplyResources(this.rbInitNoneFilter, "rbInitNoneFilter");
            this.rbInitNoneFilter.BackgroundImage = null;
            this.rbInitNoneFilter.Name = "rbInitNoneFilter";
            this.rbInitNoneFilter.UseVisualStyleBackColor = true;
            this.rbInitNoneFilter.CheckedChanged += new System.EventHandler(this.rbInitFilter_CheckedChanged);
            // 
            // gbInitialFiltersGroup
            // 
            this.gbInitialFiltersGroup.AccessibleDescription = null;
            this.gbInitialFiltersGroup.AccessibleName = null;
            resources.ApplyResources(this.gbInitialFiltersGroup, "gbInitialFiltersGroup");
            this.gbInitialFiltersGroup.BackgroundImage = null;
            this.gbInitialFiltersGroup.Controls.Add(this.rbInitGeneralFilter);
            this.gbInitialFiltersGroup.Controls.Add(this.rbInitCategoryFilter);
            this.gbInitialFiltersGroup.Controls.Add(this.rbInitNoneFilter);
            this.gbInitialFiltersGroup.Controls.Add(this.rbInitUserFilter);
            this.gbInitialFiltersGroup.Controls.Add(this.rbInitCommandFilter);
            this.gbInitialFiltersGroup.Name = "gbInitialFiltersGroup";
            this.gbInitialFiltersGroup.TabStop = false;
            // 
            // rbInitGeneralFilter
            // 
            this.rbInitGeneralFilter.AccessibleDescription = null;
            this.rbInitGeneralFilter.AccessibleName = null;
            resources.ApplyResources(this.rbInitGeneralFilter, "rbInitGeneralFilter");
            this.rbInitGeneralFilter.BackgroundImage = null;
            this.rbInitGeneralFilter.Name = "rbInitGeneralFilter";
            this.rbInitGeneralFilter.UseVisualStyleBackColor = true;
            this.rbInitGeneralFilter.CheckedChanged += new System.EventHandler(this.rbInitFilter_CheckedChanged);
            // 
            // rbInitCategoryFilter
            // 
            this.rbInitCategoryFilter.AccessibleDescription = null;
            this.rbInitCategoryFilter.AccessibleName = null;
            resources.ApplyResources(this.rbInitCategoryFilter, "rbInitCategoryFilter");
            this.rbInitCategoryFilter.BackgroundImage = null;
            this.rbInitCategoryFilter.Name = "rbInitCategoryFilter";
            this.rbInitCategoryFilter.UseVisualStyleBackColor = true;
            this.rbInitCategoryFilter.CheckedChanged += new System.EventHandler(this.rbInitFilter_CheckedChanged);
            // 
            // Form2
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = null;
            this.ControlBox = false;
            this.Controls.Add(this.gbInitialFiltersGroup);
            this.Controls.Add(this.btnResetFilters);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.gbSelectReports);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = null;
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