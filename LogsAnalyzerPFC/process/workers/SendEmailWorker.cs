using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace LogsAnalyzerPFC.process.workers
{
    class SendEmailWorker : AbstractWorker
    {
        private String emailAddress;
        private bool excel;
        private bool pdf;

        public SendEmailWorker(String emailAddress, bool excel, bool pdf)
            : base(false)
        {
            this.emailAddress = emailAddress;
            this.excel = excel;
            this.pdf = pdf;
        }

        protected override WorkerType getType()
        {
            return WorkerType.SendEmail;
        }

        protected override void doSpecificWork(BackgroundWorker worker, DoWorkEventArgs args)
        {
            String msg;
            Boolean result = false;

            try
            {
                worker.ReportProgress(10, Constantes.getMessage("MsgMailSendingStatus"));
                Report.sendMail(emailAddress, excel, pdf);
                result = true;
            }
            catch (Exception ex)
            {
                msg = "Error: Problemas enviando los informes por correo electrónico";
                this.modLog.Error(msg + ex.Message);
            }
            finally
            {
                if (result)
                {
                    worker.ReportProgress(100, Constantes.getMessage("InfoMsgMailSent"));
                }
                else
                {
                    throw new Exception("ErrorMsgMailSent");
                }
            }
        }        
    }
}