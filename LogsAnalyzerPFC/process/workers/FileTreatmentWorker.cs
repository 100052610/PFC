using System;
using System.Linq;
using System.Text;
using System.Threading;
using Arquitectura.Log;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Generic;
using LogsAnalyzerPFC.process;
using LogsAnalyzerPFC.process.exceptions;

namespace LogsAnalyzerPFC.process
{
    class FileTreatmentWorker : AbstractWorker
    {
        private FileTreatment fileTreatment;

        public FileTreatmentWorker(String fileName) : base(true)
        {
            this.fileTreatment = new FileTreatment(fileName);
        }

        protected override WorkerType getType()
        {
            return WorkerType.FileTreatment;
        }

        protected override void doSpecificWork(BackgroundWorker worker, DoWorkEventArgs args)
        {            
            Boolean result = false;
            String error = "";

            try
            {
                this.modLog.Info("Borramos todos los usuarios y comandos usados en la base de datos, antes de cargar el fichero de logs que queremos analizar.");

                worker.ReportProgress(0, Constantes.getMessage("ReportProgress_LBD"));
                if (!this.chargeData.clearDataBase(worker))
                {
                    throw new AppProcessException("FileTreatmentErrorDeletingPreviousData");
                }
                
                worker.ReportProgress(10, Constantes.getMessage("ReportProgress_CD"));

                this.modLog.Info("Cargamos los usuarios y comandos usados en la Base de Datos");

                fileTreatment.treatFile(worker);                

                this.modLog.Info("Fichero de Logs cargado correctamente en la Base de Datos");

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
                error = "WorkerErrorFileTreatment";
            }
            finally
            {
                if (result)
                {
                    worker.ReportProgress(100, Constantes.getMessage("ReportProgress_C1"));
                }
                else
                {
                    throw new Exception(error);
                }
            }
        }    
    }
}