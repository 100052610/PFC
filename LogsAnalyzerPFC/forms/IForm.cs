using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace LogsAnalyzerPFC.forms
{
    interface IForm
    {
        void updateTaskProgress(ProgressChangedEventArgs args);
        void updateTaskCompleted(RunWorkerCompletedEventArgs args);
        List<Control> getWorkingControls();
    }
}
