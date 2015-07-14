using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;

namespace LogsAnalyzerPFC.process
{
    public interface IWorker
    {
        void doWork(BackgroundWorker worker, DoWorkEventArgs args);
    }
}
