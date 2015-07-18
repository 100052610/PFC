using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;
using LogsAnalyzerPFC.forms;
using LogsAnalyzerPFC.entidades;
using System.IO;
using System.Reflection;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using LogsAnalyzerPFC.process;
using System.Collections.Generic;

namespace LogsAnalyzerPFC
{
    public partial class Form1 : Form, IForm
    {

        #region "Atributos"

        private Boolean logsFileCharged;
        private Boolean commandsFileCharged;        
        private Statistics dbStatistics;       

        #endregion

        #region "Constructores"

        public Form1()
        {            
            this.commandsFileCharged = false;
            this.logsFileCharged = false;            
            this.dbStatistics = ChargeData.getInstance().getDbStatistics();
            this.InitializeComponentCustom();    
        }

        private void InitializeComponentCustom()
        {            
            InitializeComponent();
            this.lblVennLeft.Parent = this.picVenn;
            this.lblVennRight.Parent = this.picVenn;
            this.lblVennCommon.Parent = this.picVenn;
            this.refreshDbInfo(null);
        }

        #endregion

        #region "Métodos Botones"

        private void btnClearDataBase_Click(object sender, EventArgs e)
        {
            DialogResult result = FormUtils.ShowMessageBox(Constantes.getMessage("InfoMsgClearDB"),
                                                  Constantes.getMessage("Info"),
                                                  MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {                
                IWorker worker = new DeleteDataWorker();
                this.toolStripProgressBar1.Visible = true;
                FormUtils.startNewWorkAsync(worker, this);
            }
        }

        private void btnRestarDataBase_Click(object sender, EventArgs e)
        {
            DialogResult result = FormUtils.ShowMessageBox(Constantes.getMessage("InfoMsgCommandsFile"),
                                                  Constantes.getMessage("Info"),
                                                  MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                OpenFileDialog openFileDialog2 = new OpenFileDialog();

                string assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                openFileDialog2.InitialDirectory = System.IO.Path.Combine(assemblyPath, Properties.Settings.Default.FilesPath);
                openFileDialog2.Filter = "xlsx files (*.xlsx)|*.xlsx";
                openFileDialog2.FilterIndex = 1;
                openFileDialog2.RestoreDirectory = true;

                if (FormUtils.ShowOpenDialog(openFileDialog2) == DialogResult.OK)
                {
                    IWorker w = new RestartDataBaseWorker(openFileDialog2.FileName);
                    this.toolStripProgressBar1.Visible = true;                    
                    FormUtils.startNewWorkAsync(w, this);
                    commandsFileCharged = true;
                }
            }

            if(!commandsFileCharged)
            {
                if (this.dbStatistics.BaseCommands > 0)
                {
                    FormUtils.ShowMessageBox(Constantes.getMessage("WarnMsgCommandsFile"),
                                    Constantes.getMessage("Warn"));
                }
                else
                {
                    FormUtils.ShowMessageBox(Constantes.getMessage("ErrorMsgCommandsFile"),
                                    Constantes.getMessage("Warn"));
                }
            }
        }

        private void btnChargeLogFile_Click(object sender, EventArgs e)
        {
            if (this.dbStatistics.BaseCommands > 0)
            {
                DialogResult result = FormUtils.ShowMessageBox(Constantes.getMessage("InfoMsgLogFile"),
                                                      Constantes.getMessage("Info"),
                                                      MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();

                    string assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                    openFileDialog1.InitialDirectory = System.IO.Path.Combine(assemblyPath, Properties.Settings.Default.FilesPath);
                    openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog1.FilterIndex = 1;
                    openFileDialog1.RestoreDirectory = true;

                    if (FormUtils.ShowOpenDialog(openFileDialog1) == DialogResult.OK)
                    {                        
                        IWorker worker = new FileTreatmentWorker(openFileDialog1.FileName);
                        this.toolStripProgressBar1.Visible = true;
                        FormUtils.startNewWorkAsync(worker, this);
                        logsFileCharged = true;
                    }
                }
                if (!logsFileCharged)
                {
                    if (this.dbStatistics.UsedCommands > 0)
                    {
                        FormUtils.ShowMessageBox(Constantes.getMessage("WarnMsgLogFile"),
                                        Constantes.getMessage("Warn"));
                    }
                    else
                    {
                        FormUtils.ShowMessageBox(Constantes.getMessage("ErrorMsgLogFile"),
                                        Constantes.getMessage("Warn"));
                    }
                }
            }
            else
            {
                FormUtils.ShowMessageBox(Constantes.getMessage("ErrorMsgNoOldCommands"), 
                                Constantes.getMessage("Warn"));
            }
        }

        private void changeFocusToForm2()
        {
            FormReferences.getF2Instance(this, true).initialize();
        }

        private void btnAnalizeLogFile_Click(object sender, EventArgs e)
        {

            if (logsFileCharged && commandsFileCharged && this.dbStatistics.BaseCommands > 0 && this.dbStatistics.UsedCommands > 0)
            {
                DialogResult result = FormUtils.ShowMessageBox(Constantes.getMessage("InfoMsgMakeReport"),
                                                         Constantes.getMessage("Info"),
                                                         MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.changeFocusToForm2();
                }
            }
            else
            {
                if(logsFileCharged)
                {
                    if (this.dbStatistics.BaseCommands > 0)
                    {
                        DialogResult result = FormUtils.ShowMessageBox(Constantes.getMessage("InfoMsgOldCommands"),
                                                              Constantes.getMessage("Info"),
                                                              MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            this.changeFocusToForm2();
                        }
                    }
                    else
                    {
                        FormUtils.ShowMessageBox(Constantes.getMessage("ErrorMsgNoCommands"),
                                        Constantes.getMessage("Error"));
                    }
                }
                else if(commandsFileCharged)
                {
                    if (this.dbStatistics.UsedCommands > 0)
                    {
                        DialogResult result = FormUtils.ShowMessageBox(Constantes.getMessage("InfoMsgOldLogs"),
                                                             Constantes.getMessage("Info"),
                                                             MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            this.changeFocusToForm2();
                        }
                    }
                    else
                    {
                        FormUtils.ShowMessageBox(Constantes.getMessage("ErrorMsgNoLogFile"),
                                        Constantes.getMessage("Error"));
                    }
                }
                else if (this.dbStatistics.BaseCommands > 0 && this.dbStatistics.UsedCommands > 0)
                {
                    DialogResult result = FormUtils.ShowMessageBox(Constantes.getMessage("InfoMsgOldReport"),
                                                             Constantes.getMessage("Info"),
                                                             MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        this.changeFocusToForm2();
                    }
                }
                else
                {
                    if (this.dbStatistics.BaseCommands > 0)
                    {
                        FormUtils.ShowMessageBox(Constantes.getMessage("ErrorMsgNoOldFile"),
                                        Constantes.getMessage("Error"));
                    }
                    else if (this.dbStatistics.UsedCommands > 0)
                    {
                        FormUtils.ShowMessageBox(Constantes.getMessage("ErrorMsgNoOldCommands"),
                                        Constantes.getMessage("Error"));
                    }
                    else
                    {
                        FormUtils.ShowMessageBox(Constantes.getMessage("ErrorMsgNoReport"),
                                        Constantes.getMessage("Error"));
                    }
                }
            }
        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            Constantes.language = "en";
            this.refreshFormLanguage();
        }

        private void btnSpanish_Click(object sender, EventArgs e)
        {
            Constantes.language = "";
            this.refreshFormLanguage();          
        }

        private void refreshFormLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Constantes.language);
            this.Controls.Clear();
            this.InitializeComponentCustom();            
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUtils.ShowMessageBox(Constantes.getMessage("About"),
                            Constantes.getMessage("Info"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Question);
        }

        private void guíaDeUsoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Constantes.fileManualPath);
        }

        #endregion

        #region "Métodos Auxiliares"

        private void toolStripHelp_DropDownOpened(object sender, EventArgs e)
        {
            this.menuStrip1.Items[0].ForeColor = System.Drawing.Color.FromArgb(43, 69, 146);
        }

        private void toolStripHelp_DropDownClosed(object sender, EventArgs e)
        {
            this.menuStrip1.Items[0].ForeColor = System.Drawing.SystemColors.Window;
        }

        private void refreshDbInfo(ProcessResult result)
        {
            if (result != null)
            {
                this.dbStatistics = result.DbStatistics;           
            }

            Image redData = global::LogsAnalyzerPFC.Properties.Resources.bat_roja;
            Image greenData = global::LogsAnalyzerPFC.Properties.Resources.bat_verde;

            Image redConnection = global::LogsAnalyzerPFC.Properties.Resources.database_fail;
            Image greenConnection = global::LogsAnalyzerPFC.Properties.Resources.database_ok;

            this.picCommands.Image = this.dbStatistics.BaseCommands > 0 ? greenData : redData;
            this.picLogs.Image = this.dbStatistics.UsedCommands > 0 ? greenData : redData;
            this.picBBDD.Image = this.dbStatistics.Connection ? greenConnection : redConnection;


            this.lblVennLeft.Text = (this.dbStatistics.BaseCommands - this.dbStatistics.CommonCommands).ToString();
            this.lblVennCommon.Text = this.dbStatistics.CommonCommands.ToString();
            this.lblVennRight.Text = (this.dbStatistics.UsedCommands - this.dbStatistics.CommonCommands).ToString();
            this.panel1.Visible = this.dbStatistics.BaseCommands > 0;            
        }       

        #endregion

        #region IForm Members

        public void updateTaskProgress(ProgressChangedEventArgs args)
        {
            this.toolStripProgressBar1.Value = FormUtils.normalizeProgress(args.ProgressPercentage);
            if (args.UserState != null)
            {
                this.toolStripStatusLabel1.Text = args.UserState.ToString();
            }
        }

        public void updateTaskCompleted(RunWorkerCompletedEventArgs args)
        {
            FormUtils.enablingFormWorkingControls(this, true);
            this.toolStripProgressBar1.Visible = false;
            this.toolStripProgressBar1.Value = 0;

            Exception ex = null;
            if (args.Result != null && args.Result is ProcessResult)
            {
                ProcessResult pr = (ProcessResult)args.Result;
                ex = pr.ProcessException;
                this.refreshDbInfo(pr);
            }

            if (ex != null)
            {
                this.toolStripStatusLabel1.Text = "";
                FormUtils.ShowMessageBox(Constantes.getMessage(ex.Message),
                                Constantes.getMessage("Error"));
            }
            else
            {
                FormUtils.ShowMessageBox(Constantes.getMessage("InfoMsgTaskOk"),
                                Constantes.getMessage("Info"));
            }            
        }

        public List<Control> getWorkingControls()
        {
            Control[] workingControls = new Control[]{
                this.btnRestarDataBase,
                this.btnChargeLogFile,
                this.btnAnalizeLogFile,
                this.btnClearDataBase,
                this.btnEnglish,
                this.btnSpanish,
                this.menuStrip1                
            };
            return workingControls.ToList<Control>();
        }

        #endregion
    }
}