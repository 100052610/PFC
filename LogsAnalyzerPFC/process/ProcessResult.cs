using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogsAnalyzerPFC.entidades;

namespace LogsAnalyzerPFC.process
{
    class ProcessResult
    {
        #region "Atributos"

        private AbstractWorker.WorkerType type;
        private Statistics dbStatistics;                                   
        private Exception processException;
        private Object processOutput;        

        #endregion

        #region "Propiedades"

        public AbstractWorker.WorkerType Type
        {
            get { return type; }
            set { type = value; }
        }

        public Statistics DbStatistics
        {
            get { return dbStatistics; }
            set { dbStatistics = value; }
        }       

        public Exception ProcessException
        {
            get { return processException; }
            set { processException = value; }
        }

        public Object ProcessOutput
        {
            get { return processOutput; }
            set { processOutput = value; }
        }

        #endregion

        #region "Constructores"        

        public ProcessResult(AbstractWorker.WorkerType type)
        {
            this.type = type;
        }

        #endregion
    }
}
