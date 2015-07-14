using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using LogsAnalyzerPFC.entidades;
using System.Globalization;
using System.Threading;
using LogsAnalyzerPFC.process.exceptions;

namespace LogsAnalyzerPFC.process
{
    class GenerateReportWorker : AbstractWorker
    {
        private List<QueryReport> reportsToGenerate;

        public GenerateReportWorker(List<QueryReport> queryReportList) 
            : base(false)
        {            
            this.reportsToGenerate = queryReportList;
        }

        protected override WorkerType getType()
        {
            return WorkerType.GenerateReport;
        }

        protected override void doSpecificWork(BackgroundWorker worker, DoWorkEventArgs args)
        {            
            Boolean result = false;
            String error = "";

            try
            {
                worker.ReportProgress(0, Constantes.getMessage("ReportProgress_GIS"));

                // Crea una nueva excel donde se insertarán las hojas de cada informe.
                Report.createReport();

                // Inserta las hojas con los datos y gráficos de cada tipo de informe seleccionado.
                Report.fillReports(reportsToGenerate, worker);

                result = true;
            }
            catch (AppProcessException ex)
            {
                result = false;
                this.modLog.Error(ex);
                error = ex.ExCode;
            }
            catch (Exception ex)
            {
                result = false;
                this.modLog.Error(ex);
                error = "WorkerErrorGeneratingReport";
            }
            finally
            {
                if (result)
                {
                    worker.ReportProgress(100, Constantes.getMessage("InfoPDFCreator"));
                }
                else
                {
                    throw new Exception(error);
                }
            }
        }
    }
}