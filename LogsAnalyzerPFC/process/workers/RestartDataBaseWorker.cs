using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Generic;
using LogsAnalyzerPFC.process.exceptions;

namespace LogsAnalyzerPFC.process
{
    class RestartDataBaseWorker : AbstractWorker
    {
        InitialCharge initialCharge;

        public RestartDataBaseWorker(String fileName) : base(true)
        {
            this.initialCharge = new InitialCharge(fileName);            
        }

        protected override WorkerType getType()
        {
            return WorkerType.RestartDataBase;
        }

        protected override void doSpecificWork(BackgroundWorker worker, DoWorkEventArgs args)
        {            
            Boolean result = false;
            String error = "";

            try
            {
                this.modLog.Info("Borramos todos los comandos y categorias almacenados en la base de datos, antes de cargar el fichero de comandos iniciales");

                worker.ReportProgress(0, Constantes.getMessage("ReportProgress_BD"));
                if (!this.chargeData.restartDataBase(worker))
                {                    
                    throw new AppProcessException("TODO: Error reseteando las tablas de comandos y categorias de la BBDD");
                }

                worker.ReportProgress(15, Constantes.getMessage("ReportProgress_LFCI"));

                this.modLog.Info("Cargamos las categorías y comandos iniciales en la Base de Datos");

                worker.ReportProgress(20);
                this.initialCharge.chargeTables(worker);                

                this.modLog.Info("Fichero de Comandos Iniciales cargado correctamente en la Base de Datos");

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
                error = "WorkerErrorRestartDB";
            }
            finally
            {
                if (result)
                {
                    worker.ReportProgress(100, Constantes.getMessage("ReportProgress_C2"));
                }
                else
                {
                    throw new Exception(error);
                }
            }
        }
   
    }
}