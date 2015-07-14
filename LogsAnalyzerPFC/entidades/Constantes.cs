using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using LogsAnalyzerPFC.entidades;
using LogsAnalyzerPFC.entidades.messages;
using Arquitectura.Log;
using System.Resources;

namespace LogsAnalyzerPFC
{
    public class Constantes
    {

        #region "Constantes"
        
        // MODULOS DE LA ARQUITECTURA

        /// <summary>
        /// Nombre asociado al modulo de log de la arquitectura
        /// </summary>        
        public const string MODULO_LOG = "log";

        /// <summary>
        /// Nombre asociado al modulo de datos de la arquitectura
        /// </summary>        
        public const string MODULO_DATOS = "datos";

        /// <summary>
        /// Nombre asociado al modulo de datos de la arquitectura (Driver nativo de Oracle)
        /// </summary>
        public const string MODULO_DATOS_INFORMES = "datosInformes";

        /// <summary>
        /// Nombre asociado a la categoria 'Otros' que se insertará por defecto en aquellos comandos que se detecten como nuevos en el fichero de logs.
        /// </summary>
        public const string OTHERS_CATEGORY_NAME = "Others";

        #endregion
        
        #region "Variables estáticas públicas"

        /// <summary>
        /// Ruta del fichero de configuracion de la arquitectura
        /// </summary>        
        public static string fileConfigPath;

        /// <summary>
        /// Ruta del fichero que se utiliza como plantilla para los informes
        /// </summary>        
        public static string fileTemplatePath;

        /// <summary>
        /// Ruta del fichero que se utiliza para rellenar los informes
        /// </summary>        
        public static string fileReportsPath;

        /// <summary>
        /// Ruta del fichero PDF que contiene los informes realizados
        /// </summary>        
        public static string fileReportsPDFPath;

        /// <summary>
        /// Ruta del manual de la aplicación
        /// </summary>
        public static string fileManualPath;

        /// <summary>
        /// Ruta del fichero externo de recursos (para literales que se pueden modificar una vez compilada la aplicación).
        /// </summary>
        public static string externalResourcesPath;

        /// <summary>
        /// Número de registros máximo para la carga de los comandos iniciales
        /// </summary>
        public static int maxInitialCommands;

        /// <summary>
        /// Número de registros máximo para la carga de comandos usados
        /// </summary>
        public static int maxCommandsUsed;

        /// <summary>
        /// Tamaño máximo para la cadena de parámetros a guardar en la tabla de comandos usados o logs: Commands_Used
        /// </summary>
        public static int maxParams;

        /// <summary>
        /// Idioma de la interfaz de usuario
        /// </summary>
        public static string language = "";
        
        #endregion

        #region "Variables estáticas privadas"

        private static ResourceManager internalMgr;

        private static ResourceManager externalMgr;

        #endregion

        #region "Constructores"

        private Constantes() {
            // Es una clase de utilidades, no tiene sentido tener un constructor público.        
        }

        #endregion

        #region "Métodos estáticos"

        public static string getMessage(String messageKey)
        {
            // Primero intentamos con el fichero de recursos interno (ensamblado en la app)
            String msg = Constantes.getInternalResourceMgrInstance().GetString(messageKey); 

            if (msg == null)
            {
                // Si no encontrasemos coincidencias, probamos con el externo.
                msg = Constantes.getExternalResourceMgrInstance().GetString(messageKey);
            }

            if (msg == null)
            {
                ModuloLog _moduloLog = ModuloLog.GetInstance(Constantes.MODULO_LOG);
                _moduloLog.Warning(messageKey + " no existe en el fichero de mensajes de la interfaz.");
                msg = messageKey;                
            }            

            return msg; 
        }

        private static ResourceManager getInternalResourceMgrInstance()
        {
            if (internalMgr == null)
            {
                internalMgr = new ResourceManager(typeof(Messages));
            }
            return Constantes.internalMgr;
        }

        private static ResourceManager getExternalResourceMgrInstance()
        {
            if (externalMgr == null)
            {
                int sepIndex = Constantes.externalResourcesPath.LastIndexOf(Path.DirectorySeparatorChar);                

                externalMgr = ResourceManager.CreateFileBasedResourceManager(
                    Constantes.externalResourcesPath.Substring(sepIndex + 1),
                    Constantes.externalResourcesPath.Substring(0, sepIndex),
                    null);
            }

            return Constantes.externalMgr;
        }

        #endregion        
   
    }
}
