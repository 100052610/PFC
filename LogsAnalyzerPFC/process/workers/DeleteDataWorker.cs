using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Generic;

namespace LogsAnalyzerPFC.process
{
    class DeleteDataWorker : AbstractWorker
    {

        public DeleteDataWorker() : base(true)
        { }

        protected override WorkerType getType()
        {
            return WorkerType.DeleteData;
        }

        protected override void doSpecificWork(BackgroundWorker worker, DoWorkEventArgs args)
        {
            String msg;
            Boolean result = false;

            try
            {
                worker.ReportProgress(0, Constantes.getMessage("ReportProgress_BD"));
                result = this.chargeData.clearAllDataBase(worker);                
            }
            catch (Exception ex)
            {
                msg = "Error: Problemas Borrando los datos almacenados.";
                this.modLog.Error(msg + ex.Message);                
            }
            finally
            {
                if (result)
                {
                    worker.ReportProgress(100, Constantes.getMessage("ReportProgress_B"));
                }
                else
                {                    
                    throw new Exception("WorkerErrorDeletingData");
                }
            }
        }
    }
}