using System;
using Arquitectura.Log;
using Arquitectura.Datos;
using System.Data;

namespace LogsAnalyzerPFC
{
    /// <summary>
    /// Clase base que se utilizará por cada componente que desee acceder a la base de datos
    /// </summary>
     
    public class DatosBase
    {

        #region "Constantes"

        private const String SP_CHECK_CONNECTION_QUERY = "SELECT SYSDATE FROM DUAL";

        #endregion

        #region "Atributos"

        /// <summary>
        /// Módulo de log utilizado
        /// </summary>
       
        private ModuloLog _moduloLog;

        /// <summary>
        /// Modulo de datos configurado para el acceso a datos del servidor
        /// </summary>
        
        private ModuloDatos _moduloDatos;

        /// <summary>
        /// Modulo de datos configurado para el acceso a datos del servidor (Driver nativo de Oracle)
        /// </summary>

        private ModuloDatos _moduloDatosInformes;

        /// <summary>
        /// Query a realizar
        /// </summary>
        
        private String query;


        #endregion

        #region "Propiedades"

        /// <summary>
        /// Obtiene o establece el modulo de log
        /// </summary>
        
        public ModuloLog ModuloLog
        {
            get { return _moduloLog; }
            set { _moduloLog = value; }
        }

        /// <summary>
        /// Obtiene o establece el modulo de datos
        /// </summary>
        
        public ModuloDatos ModuloDatos
        {
            get { return _moduloDatos; }
            set { _moduloDatos = value; }
        }

        /// <summary>
        /// Obtiene o establece el modulo de datos
        /// </summary>

        public ModuloDatos ModuloDatosInformes
        {
            get { return _moduloDatosInformes; }
            set { _moduloDatosInformes = value; }
        }

        /// <summary>
        /// Obtiene o establece el valor de la query que se va a realizar
        /// </summary>
        
        protected String Query
        {
            get { return query; }
            set { query = value; }
        }


        #endregion

        #region "Constructores"

        /// <summary>
        /// Inicializa una nueva instancia de la clase DatosBase y recupera la instancia de modulo de log y datos
        /// </summary>
        
        public DatosBase()
        {
            this._moduloLog = ModuloLog.GetInstance(Constantes.MODULO_LOG);
            this._moduloDatos = ModuloDatos.GetInstance(Constantes.MODULO_DATOS);
            this._moduloDatosInformes = ModuloDatos.GetInstance(Constantes.MODULO_DATOS_INFORMES);
        }


        #endregion

        #region "Métodos public"

        public Boolean checkConnection()
        {
            Boolean result = false;
            DataSet ds = null;

            try
            {
                this.ModuloLog.Debug("Se comprueba si la conexión con la BBDD está levantada");

                this.Query = SP_CHECK_CONNECTION_QUERY;

                ds = this.ModuloDatos.ExecuteDataSet(this.Query);

                result = ds.Tables[0].Rows[0].ItemArray[0].ToString().Length > 0;
            }
            catch (Exception ex)
            {
                this.ModuloLog.Error(ex);
            }

            return result;
        }

        #endregion

        #region "Métodos protected"

        private String GetParameter(object obj)
        {
            String ret = null;

            if (obj == null || (obj is String && ((String)obj).Length == 0) ||
                               (obj is int && ((int)obj) == -1) ||
                               (obj is float && ((float)obj) == -1.0F) ||
                               (obj is double && ((double)obj) == -1.0D))
            {
                ret = "null";
            }
            else
            {
                if (obj is String)
                {
                    ret = String.Format("'{0}'", obj.ToString());
                }
                else if (obj is DateTime)
                {
                    ret = String.Format("'{0}'", ((DateTime)obj).ToShortDateString());

                }
                else if (obj is float || obj is double)
                {
                    ret = obj.ToString().Replace(',', '.');
                }
                else
                {
                    ret = obj.ToString();
                }
            }

            return ret;
        }

        protected void InsertParameter(int nParam, object obj)
        {
            this.query = this.query.Replace("{" + nParam + "}", GetParameter(obj));
        }


        #endregion
    
    }

}
