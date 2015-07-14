using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;
using LogsAnalyzerPFC.entidades;
using System.Collections.Generic;
using System.Resources;
using System.Net.Mail;
using LogsAnalyzerPFC.process;
using LogsAnalyzerPFC.process.workers;

namespace LogsAnalyzerPFC.forms
{
    public partial class Form3 : Form, IForm
    {        

        #region "Constructor"

        public Form3()
        {            
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Constantes.language);
            InitializeComponent();
        }

        public void initialize(List<QueryReport> qR)
        {
            FormUtils.loadReports(this.lbxGeneratedReports, qR);
        }

        #endregion

        #region "Métodos Botones"

        private void btnHome_Click(object sender, EventArgs e)
        {
            FormReferences.getF1Instance(this, false);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormReferences.getF2Instance(this, false);
        }

        private void btnEXCEL_Click(object sender, EventArgs e)
        {
            Process.Start(Constantes.fileReportsPath);
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            Process.Start(Constantes.fileReportsPDFPath);
        }

        private void btnMAIL_Click(object sender, EventArgs e)
        {
            this.gBMail.Visible = true;
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            Boolean excel = this.checkExcel.Checked;
            Boolean pdf = this.checkPdf.Checked;

            if (!this.comprobarEmail(this.textBoxEmail.Text))
            {
                FormUtils.ShowMessageBox(Constantes.getMessage("WarnMsgMailAddress"),
                                Constantes.getMessage("Warn"));
                return;
            }

            if (!excel && !pdf)
            {
                FormUtils.ShowMessageBox(Constantes.getMessage("InfoNoFormat"),
                                Constantes.getMessage("Info"));
                return;
            }


            IWorker worker = new SendEmailWorker(textBoxEmail.Text, excel, pdf);            
            this.toolStripProgressBar1.Visible = true;
            FormUtils.startNewWorkAsync(worker, this);          
        }

        #endregion

        #region "Métodos Auxiliares"

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            this.textBoxEmail.Text = "";
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                this.textBoxEmail.Text = new ResourceManager(typeof(Form3)).GetString("textBoxEmail.Text");
            }
        }

        private Boolean comprobarEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void listViewSelectedReports_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                e.Item.Selected = false;
            }
        }

        private void lbxGeneratedReports_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (lbxGeneratedReports.Items.Count > 0)
            {
                // Cambiamos el color para que parezca que no se selecciona nada.
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e = new DrawItemEventArgs(e.Graphics,
                                              e.Font,
                                              e.Bounds,
                                              e.Index,
                                              e.State ^ DrawItemState.Selected,
                                              Color.Black,
                                              Color.White);//Choose the color
                }

                e.DrawBackground();                
                e.Graphics.DrawString(lbxGeneratedReports.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        private void lbxGeneratedReports_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (lbxGeneratedReports.Items.Count > 0)
            {
                e.ItemHeight = e.ItemHeight * (lbxGeneratedReports.Items[e.Index].ToString().Split(new char[] { '\n' }).Length + 1);
            }
        }                

        public void updateTaskProgress(ProgressChangedEventArgs args)
        {
            this.toolStripProgressBar1.Value = args.ProgressPercentage;
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
            }            

            if (ex != null)
            {
                this.toolStripStatusLabel1.Text = ex.Message;
                             
                FormUtils.ShowMessageBox(Constantes.getMessage(ex.Message),
                                Constantes.getMessage("Error"));
            }
            else
            {
                this.toolStripStatusLabel1.Text = Constantes.getMessage("InfoMsgMailSent");                               

                FormUtils.ShowMessageBox(Constantes.getMessage("InfoMsgMailSent"),
                                Constantes.getMessage("Info"));               
            }  
        }

        public List<Control> getWorkingControls()
        {
            Control[] workingControls = new Control[]{
                this.btnHome,
                this.btnBack,
                this.btnEXCEL,
                this.btnPDF,
                this.btnMAIL,
                this.checkExcel,
                this.checkPdf,
                this.textBoxEmail,
                this.btnSendMail
            };            
            return workingControls.ToList<Control>();
        }

        #endregion               
    }
}
