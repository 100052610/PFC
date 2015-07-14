using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LogsAnalyzerPFC.entidades;
using LogsAnalyzerPFC.process;
using System.ComponentModel;
using System.Drawing;

namespace LogsAnalyzerPFC.forms
{
    class FormUtils
    {
        #region "Constantes"                
        
        /// <summary>
        /// Margen de un listbox con respecto al texto que cabe en su interior y su tamaño total (descontando el scroll, etc.)
        /// </summary>
        private static int ELEMENT_MARGIN = 25;

        #endregion

        #region "Métodos públicos"

        public static ListBox loadReports(ListBox listBox, List<QueryReport> listToLoad)
        {
            listBox.Items.Clear();
            for (int i = 0; i < listToLoad.Count; i++)
            {
                FormUtils.loadReport(listBox, listToLoad[i]);
            }
            return listBox;
        }

        public static void loadReport(ListBox listBox, QueryReport newReport)
        {            
            String formattedText = FormUtils.getFormattedTextFromReport(newReport.Id, newReport, listBox.Width, listBox.Font);
            listBox.Items.Add(formattedText);
        }

        public static void startNewWorkAsync(IWorker worker, IForm originForm)
        {
            FormUtils.startNewWorkAsync(worker, originForm, false, true);
        }            

        public static void startNewWorkAsync(IWorker worker, IForm originForm, bool silent, bool blockInterface)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;

            // Tarea a realizar.
            bw.DoWork += new DoWorkEventHandler((o, args) => worker.doWork(o as BackgroundWorker, args));
            
            if (!silent){
                // Comportamiento a ejecutar cada vez que cambie el progreso.
                bw.ProgressChanged += new ProgressChangedEventHandler((o, args) => originForm.updateTaskProgress(args));
            }

            // Comportamiento a ejecutar cuando finalice por completo la tarea.
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler((o, args) => originForm.updateTaskCompleted(args));

            if (blockInterface)
            {
                FormUtils.enablingFormWorkingControls(originForm, false);
            }

            // Arranca la tarea en un Thread independiente del formulario de la aplicación, para no dejarla colgada.
            bw.RunWorkerAsync();
        }

        public static void enablingFormWorkingControls(IForm originForm, bool enabled)
        {
            foreach (Control ctrl in originForm.getWorkingControls())
            {
                ctrl.Enabled = enabled;
            }
        }

        public static DialogResult ShowMessageBox(string text, string caption)
        {
            return FormUtils.ShowMessageBox(text, caption, MessageBoxButtons.OK);
        }

        public static DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons)
        {
            return FormUtils.ShowMessageBox(text, caption, buttons, MessageBoxIcon.None);
        }

        public static DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            FormUtils.configureMessageBoxManager();

            DialogResult result = MessageBox.Show(text, caption, buttons, icon);

            FormUtils.resetMessageBoxManager();

            return result;
        }

        public static DialogResult ShowOpenDialog(OpenFileDialog fileDialog)
        {
            FormUtils.configureMessageBoxManager();

            DialogResult result = fileDialog.ShowDialog();

            FormUtils.resetMessageBoxManager();

            return result;
        }
        
        #endregion

        #region "Métodos privados"

        private static void configureMessageBoxManager()
        {
            MessageBoxManager.OK = Constantes.getMessage("MessageBoxOk");
            MessageBoxManager.Cancel = Constantes.getMessage("MessageBoxCancel");
            MessageBoxManager.Yes = Constantes.getMessage("MessageBoxYes");
            MessageBoxManager.No = Constantes.getMessage("MessageBoxNo");

            MessageBoxManager.Register();
        }

        private static void resetMessageBoxManager()
        {
            MessageBoxManager.Unregister();
        }

        private static String getFormattedTextFromReport(int elementId, QueryReport newReport, int elementWidth, Font elementFont)
        {            
            List<String> text = new List<String>();
            StringBuilder build = new StringBuilder();
            text.Add(elementId + " -> " + Constantes.getMessage(newReport.Name));

            if (newReport.QueryFilterByUser != null)
            {
                build.Append(" @" + newReport.QueryFilterByUser.Name);
            }
            if (newReport.QueryFilterByCommand != null)
            {
                build.Append(" @" + newReport.QueryFilterByCommand.Name);
            }
            if (newReport.QueryFilterByCategory != null)
            {
                build.Append(" @" + newReport.QueryFilterByCategory.Name);
            }
            text.Add(build.ToString());

            return FormUtils.textToPaint(text.ToArray(), elementWidth, elementFont);            
        }

        private static String textToPaint(String[] initialArrayText, int elementWidth, Font elementFont)
        {
            StringBuilder build = new StringBuilder();

            foreach (String initialText in initialArrayText)
            {
                if (initialText != null && initialText.Length > 0)
                {
                    FormUtils.textToPaintInLine(elementWidth, elementFont, build, initialText);
                }
            }

            return build.ToString();
        }

        private static void textToPaintInLine(int elementWidth, Font elementFont, StringBuilder build, String initialText)
        {            
            String[] splittedText = initialText.Split(new char[] { ' ' });
            StringBuilder currentLine = new StringBuilder();

            int maxSize = elementWidth - ELEMENT_MARGIN;
            String tmp;

            foreach (String token in splittedText)
            {
                tmp = currentLine + token + " ";

                if (TextRenderer.MeasureText(tmp, elementFont).Width < maxSize)
                {
                    currentLine.Append(token);
                    currentLine.Append(" ");
                }
                else
                {
                    if (build.Length > 0)
                    {
                        build.Append("\n");
                    }
                    build.Append(currentLine.ToString());

                    currentLine = new StringBuilder();
                    currentLine.Append(token);
                    currentLine.Append(" ");
                }
            }

            if (currentLine.Length > 0)
            {
                if (build.Length > 0)
                {
                    build.Append("\n");
                }
                build.Append(currentLine.ToString());
            }
        }       

        #endregion
    }
}
