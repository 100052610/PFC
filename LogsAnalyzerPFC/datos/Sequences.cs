using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LogsAnalyzerPFC.datos
{
    class Sequences : DatosBase
    {

        #region "Constructores"

        public Sequences()
        { }

        #endregion

        #region "Métodos Públicos"

        /// <summary>
        /// Método para reiniciar los valores de las secuencias de las tablas de Comandos y Categorias
        /// </summary>

        public Boolean restartBothSequences()
        {
            ArrayList parameters = null;
            Boolean result = false;
            int r;

            try
            {
                r = this.ModuloDatosInformes.ExecuteNonReader("PL_RESTART_BOTH_SEQUENCES", parameters);

                result = (r == -1);
            }
            catch (Exception ex)
            {
                result = false;
                this.ModuloLog.Error(ex);
            }

            return result;
        }

        /// <summary>
        /// Método para reiniciar los valores de las secuencias de las tablas de Usuarios y Commands Used
        /// </summary>

        public Boolean restartSequences()
        {
            ArrayList parameters = null;
            Boolean result = false;
            int r;

            try
            {
                r = this.ModuloDatosInformes.ExecuteNonReader("PL_RESTART_SEQUENCES", parameters);

                result = (r == -1);
            }
            catch (Exception ex)
            {
                result = false;
                this.ModuloLog.Error(ex);
            }

            return result;
        }

        /// <summary>
        /// Método para reiniciar los valores de las secuencias de todas las tablas
        /// </summary>

        public Boolean restartAllSequences()
        {
            ArrayList parameters = null;
            Boolean result = false;
            int r;

            try
            {
                r = this.ModuloDatosInformes.ExecuteNonReader("PL_RESTART_ALL_SEQUENCES", parameters);

                result = (r == -1);
            }
            catch (Exception ex)
            {
                result = false;
                this.ModuloLog.Error(ex);
            }

            return result;
        }

        #endregion
    
    }
}
