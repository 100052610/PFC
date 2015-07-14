using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogsAnalyzerPFC.process.exceptions
{
    class AppProcessException : Exception
    {
        #region "Atributos"

        private String exCode;

        #endregion
        
        #region "Propiedades"

        public String ExCode
        {
            get { return exCode; }
            set { exCode = value; }
        }

        #endregion

        #region "Constructores"

        public AppProcessException(String exCode)
        {
            this.exCode = exCode;
        }

        #endregion
    }
}
