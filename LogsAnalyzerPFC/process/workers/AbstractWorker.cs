using System;
using System.Linq;
using System.Text;
using Arquitectura.Log;
using System.ComponentModel;
using System.Collections.Generic;
using LogsAnalyzerPFC.process;
using System.Globalization;
using System.Threading;

namespace LogsAnalyzerPFC.process
{
    abstract class AbstractWorker : IWorker
    {       
        protected ChargeData chargeData;
        protected ModuloLog modLog;
        protected bool returnUpdatedDbStats;

        public enum WorkerType
        {
            DeleteData,
            FileTreatment,
            GenerateReport,
            RestartDataBase,
            SendEmail,
            UpdateReportFilters
        };

        public AbstractWorker(bool returnUpdatedDbStats)
        {
            this.chargeData = ChargeData.getInstance();
            this.modLog = ModuloLog.GetInstance(Constantes.MODULO_LOG);
            this.returnUpdatedDbStats = returnUpdatedDbStats;
        }

        public void doWork(BackgroundWorker worker, DoWorkEventArgs args)
        {
            Exception processEx = null;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Constantes.language);
            this.modLog.Info(String.Format("Starting worker thread: [{0}]", this.getType().ToString()));
            
            try
            {
                this.doSpecificWork(worker, args);
            }
            catch (Exception ex) {
                processEx = ex;
            }
            finally
            {
                try
                {                    
                    ProcessResult pr = new ProcessResult(this.getType());                    
                    pr.ProcessException = processEx;
                    pr.ProcessOutput = args.Result;

                    if (returnUpdatedDbStats)
                    {
                        pr.DbStatistics = this.chargeData.getDbStatistics();
                    }
                    
                    // Cambiamos el resultado del objeto 'DoWorkEventArgs' (lo que devolvemos hacia fuera) por nuestro
                    // objeto ProcessResult, que además de tener el resultado como tal (processOutput) tiene incluida 
                    // la posible excepción que el proceso haya podido lanzar, y las estadísticas actualizadas de BBDD.
                    args.Result = pr;
                }
                catch (Exception) { }
            }
            this.modLog.Info(String.Format("Finished worker thread: [{0}]", this.getType().ToString()));            
        }

        protected abstract void doSpecificWork(BackgroundWorker worker, DoWorkEventArgs args);
        protected abstract WorkerType getType();
    }
}