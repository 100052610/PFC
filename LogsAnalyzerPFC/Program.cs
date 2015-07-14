using System;
using System.IO;
using Arquitectura.Log;
using System.Reflection;
using System.Windows.Forms;
using Arquitectura.Contexto;
using Arquitectura.Criptografia;
using LogsAnalyzerPFC.forms;
using LogsAnalyzerPFC.Properties;

namespace LogsAnalyzerPFC
{
    static class Program
    {
        #region "Métodos Privados"

        /// <summary>
        /// Inicializa la arquitectura de tratamiento de datos
        /// </summary>
        /// 
        private static void borrarArchivosAntiguos()
        {
            ModuloLog modLog = ModuloLog.GetInstance(Constantes.MODULO_LOG);

            try
            {
                if (File.Exists(Constantes.fileReportsPath))
                {
                    File.Delete(Constantes.fileReportsPath);
                }

                if (File.Exists(Constantes.fileReportsPDFPath))
                {
                    File.Delete(Constantes.fileReportsPDFPath);
                }
            }
            catch (Exception ex)
            {
                modLog.Error("Error Borrando los ficheros antiguos");
                modLog.Error(ex);
            }
        }

        private static void inicializarArquitectura()
        {
            String assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            Constantes.fileConfigPath = Path.Combine(assemblyPath, Settings.Default.FicheroConfigPath);            
            ContextoApp.InicializarContexto(Constantes.fileConfigPath);
            ModuloLog modLog = ModuloLog.GetInstance(Constantes.MODULO_LOG);

            Constantes.fileTemplatePath = Path.Combine(assemblyPath, Settings.Default.PlantillaInformesPath);
            Constantes.fileReportsPath = Path.Combine(assemblyPath, Settings.Default.InformesPath);
            Constantes.fileReportsPDFPath = Path.Combine(assemblyPath, Settings.Default.InformesPDFPath);
            Constantes.fileManualPath = Path.Combine(assemblyPath, Settings.Default.ManualPath);
            Constantes.externalResourcesPath = Path.Combine(assemblyPath, Settings.Default.ExternalResources);
            Constantes.maxInitialCommands = Settings.Default.MaxInitialCommands;
            Constantes.maxCommandsUsed = Settings.Default.MaxCommandsUsed;
            Constantes.maxParams = Settings.Default.MaxParams;

            modLog.Info("Arquitectura Iniciada");
        }

        #endregion
        
        #region "Método MAIN"

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            inicializarArquitectura();

            borrarArchivosAntiguos();

            Application.Run(FormReferences.getF1Instance(null, true));
        }
        
        #endregion

    }
}