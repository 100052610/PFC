using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using Arquitectura.Log;
using System.Reflection;
using System.ComponentModel;
using LogsAnalyzerPFC.datos;
using System.Collections.Generic;
using LogsAnalyzerPFC.entidades;
using Microsoft.Office.Interop.Excel;
using Arquitectura.Comunicaciones.Email;
using LogsAnalyzerPFC.forms;


namespace LogsAnalyzerPFC.process
{
    class Report
    {

        #region "Atributos"

        private static ModuloLog _moduloLog = ModuloLog.GetInstance(Constantes.MODULO_LOG);

        #endregion

        #region "Constructores"

        private Report()
        {}

        #endregion

        #region "Métodos públicos"

        public static void createReport()
        {
            Application app = null;
            Workbook bookReports = null;

            try
            {
                // Crea un excel desde 0
                app = new Application();
                app.Visible = false;
                app.SheetsInNewWorkbook = 1;                
                bookReports = app.Workbooks.Add(Missing.Value);
                bookReports.SaveCopyAs(Constantes.fileReportsPath);
            }
            catch (Exception ex)
            {
                Report._moduloLog.Error("Error en la copia/creación de los libros de Excel");
                Report._moduloLog.Error(ex);
            }
            finally
            {
                try
                {
                    if (bookReports != null)
                    {
                        bookReports.Saved = true;
                    }
                    if (app != null)
                    {
                        app.Quit();
                    }
                }
                catch (Exception ex)
                {
                    Report._moduloLog.Error(ex);
                }
            }
        }
        
        public static void fillReports(List<QueryReport> queryReportList, BackgroundWorker worker)
        {
            Object misval = System.Reflection.Missing.Value;
            Workbook bookTemplates = null; 
            Workbook bookReports = null;
            Application app = null;

            try
            {
                app = new Application();
                app.Visible = false;

                worker.ReportProgress(5, Constantes.getMessage("ReportProgress_CI"));

                // Se abre el libro de plantillas (origen)
                bookTemplates = app.Workbooks.Open(Constantes.fileTemplatePath, misval, misval, misval, misval, misval, misval, misval,
                                                                                misval, misval, misval, misval, misval, misval, misval);

                // Se abre el libro de informes (destino)
                bookReports = app.Workbooks.Open(Constantes.fileReportsPath, misval, misval, misval, misval, misval, misval, misval,
                                                                             misval, misval, misval, misval, misval, misval, misval);                

                worker.ReportProgress(10, Constantes.getMessage("ReportProgress_RIS"));

                // Nos creamos un mapa con los nombres de las plantillas, para evitar buscar cada vez.
                Dictionary<string, Worksheet> sheetsMap = new Dictionary<string, Worksheet>();
                foreach (Worksheet sheet in bookTemplates.Sheets)
                {
                    sheetsMap.Add(sheet.Name, sheet);
                }

                int start = 10;
                int advance = (int)(80 / queryReportList.Count);

                Worksheet last = (Worksheet) bookReports.Sheets[bookReports.Sheets.Count];

                // Bucle de generación de cada tipo de informe solicitado.
                foreach (QueryReport qr in queryReportList)
                {
                    // Primero se copia la plantilla a la excel de informes, como última hoja del libro.
                    sheetsMap[qr.Sheet_Name].Copy(misval, last);

                    // Volvemos a calcular la última hoja (será la recién insertada).
                    last = (Worksheet)bookReports.Sheets[bookReports.Sheets.Count];

                    // Recalculamos el progreso.
                    string nameAux = Constantes.getMessage(qr.Name);
                    start += advance;
                    worker.ReportProgress(start, Constantes.getMessage("ReportProgress_RI") + nameAux + ".");

                    // Rellenamos los datos y el gráfico de la plantilla con los datos del informe actual.
                    Report.fillSheet(qr, last);

                    // Cambiamos el nombre del informe.
                    last.Name = "Informe " + (bookReports.Sheets.Count - 1);
                }

                // Se borra la primera plantilla de la excel, ya que es una pestaña vacía que se generó al crear el excel desde 0.
                ((Worksheet)bookReports.Sheets[1]).Delete();
            }
            catch (Exception ex)
            {
                Report._moduloLog.Error(ex);
                throw ex;
            }
            finally
            {
                // Cerramos todos los objetos abiertos para evitar que se queden bloqueados en memoria, aunque haya dado error la generación
                try
                {
                    if (bookTemplates != null)
                    {
                        bookTemplates.Save();
                        bookTemplates.Saved = true;
                    }
                    if (bookReports != null)
                    {
                        bookReports.Save();
                        bookReports.Saved = true;
                    }
                    if (app != null)
                    {
                        app.Quit();
                    }
                }
                catch (Exception ex)
                {
                    Report._moduloLog.Error(ex);
                }
            }            
        }

        public static Boolean exportWorkbookToPdf()
        {
            Object misval = System.Reflection.Missing.Value;
            Application app;
            Workbook bookReports;
            Boolean exportSuccessful;

            app = new Application();
            app.Visible = false;
            exportSuccessful = true;
            bookReports = app.Workbooks.Open(Constantes.fileReportsPath, misval, misval, misval, misval, misval, misval, misval,
                                                                         misval, misval, misval, misval, misval, misval, misval);

            // If the workbook failed to open, stop, clean up, and bail out
            if (bookReports == null)
            {
                app.Quit();
                app = null;
                return false;
            }

            try
            {
                // Call Excel's native export function (valid in Office 2007 and Office 2010, AFAIK)
                bookReports.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, Constantes.fileReportsPDFPath, misval, misval, misval, misval, misval, misval, misval);
            }
            catch (System.Exception ex)
            {
                // Mark the export as failed for the return value...
                exportSuccessful = false;
                Report._moduloLog.Error("Error exportando el fichero Excel a PDF.");
                Report._moduloLog.Error(ex);
                throw ex;
            }
            finally
            {
                try
                {
                    if (bookReports != null)
                    {
                        bookReports.Save();
                        bookReports.Saved = true;
                    }
                    if (app != null)
                    {
                        app.Quit();
                    }

                    app = null;
                    bookReports = null;
                }
                catch (Exception ex)
                {
                    Report._moduloLog.Error("Error cerrando ficheros Excel al exportar a PDF.");
                    Report._moduloLog.Error(ex);
                }
            }

            return exportSuccessful;
        }

        public static Boolean sendMail(string address, bool excel, bool pdf)
        {
            // IMPORTANTE: Para poder enviar correos a través de la cuenta de GMAIL se ha tenido que modificar un par de cosillas de la cuenta en estas 2 URLs, sino
            // daba este error al enviar el correo: "El servidor SMTP requiere una conexión segura o el cliente no se autenticó. La respuesta del servidor fue: 5.5.1 Authentication Required. Learn more at | MustIssueStartTlsFirst"
            // Y este error da con y sin arquitectura. Es por temas de Seguridad de Gmail.
            // https://www.google.com/settings/security/lesssecureapps
            // https://accounts.google.com/DisplayUnlockCaptcha

            ModuloEmail moduloEmail = ModuloEmail.GetInstance("email");
            String assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            List<String> attachments = new List<String>();

            if(excel)
            {
                attachments.Add(Constantes.fileReportsPath);
            }

            if(pdf)
            {
                attachments.Add(Constantes.fileReportsPDFPath);
            }            

            int result = moduloEmail.EnviarEmail(
                address,                                // To
                Constantes.getMessage("SubjectMail"),   // Subject
                Constantes.getMessage("BodyMail"),      // Plain body
                "<html><body><h1>" + Constantes.getMessage("BodyMail") + "</h1></body></html>",  // HTML Body
                null,                                   // ImagesColllection
                null,                                   // Cc
                null,                                   // Cco
                ModuloEmail.TipoEmail.HtmlTexto,        // Format
                attachments.ToArray(),                  // Attachments
                ModuloEmail.EmailPrioridad.Normal);     // Priority

            attachments.Clear();
            return (result == 0);
        }

        #endregion

        #region "Métodos privados"

        private static void fillSheet(QueryReport queryReport, Worksheet sheetReport)
        {
            object misval = System.Reflection.Missing.Value;

            string reportName = Constantes.getMessage(queryReport.Name);

            // DataSet que contiene el resultado de la query del report

            QueryReportDatos qd = new QueryReportDatos();

            DataSet ds = qd.ExecuteQueryReport(queryReport);

            // Rellenamos la hoja del Excel con los datos del Report
            
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                // Rellenamos el nombre de las columnas

                int columna = 0;
                int[] tamMax = new int[ds.Tables[0].Rows[0].ItemArray.Length];
                int[] tamActual = new int[ds.Tables[0].Rows[0].ItemArray.Length];

                foreach (DataColumn column in ds.Tables[0].Columns)
                {
                    sheetReport.Cells[2, (1 + columna)] = Constantes.getMessage(column.ColumnName);
                    tamActual[columna] = Constantes.getMessage(column.ColumnName).Length;
                    if (tamMax[columna] < tamActual[columna])
                    {
                        tamMax[columna] = tamActual[columna];
                    }
                    columna++;
                }

                // Rellenamos la tabla de datos

                for (int f = 0; f < ds.Tables[0].Rows.Count; f++)
                {
                    for (int c = 0; c < ds.Tables[0].Rows[0].ItemArray.Length; c++)
                    {
                        sheetReport.Cells[(3 + f), (1 + c)] = ds.Tables[0].Rows[f].ItemArray[c];
                        tamActual[c] = ds.Tables[0].Rows[f].ItemArray[c].ToString().Length;
                        if (tamMax[c] < tamActual[c])
                        {
                            tamMax[c] = tamActual[c];
                        }
                    }
                }
                for (int i = 0; i < tamMax.Length; i++)
                {
                    ((Range)sheetReport.Cells[1, 1 + i]).EntireColumn.ColumnWidth = tamMax[i] + 5;
                }
                
                // Rellenamos el gráfico del informe
                ChartObjects chartObjects = (ChartObjects)(sheetReport.ChartObjects(Type.Missing));
                ChartObject myChart = (ChartObject)chartObjects.Item(1);
                Chart chartPage = myChart.Chart;
                Range chartRange = Report.getRangeFrom(queryReport, sheetReport, ds);
                chartPage.SetSourceData(chartRange, misval);

                object categoryTitle = misval, valueTitle = misval;
                
                // Comprobamos si hay que rellenar los textos de los ejes y/o series de datos, para el tipo de grafico a generar en el informe
                if (queryReport.HasAxis)
                {
                    int categoryCol = Report.convertLetterToIndex(queryReport.Range_X.Substring(0, 1));
                    categoryTitle = (String)(sheetReport.Cells[2, categoryCol] as Range).Value2;

                    int valueCol = Report.convertLetterToIndex(queryReport.Range_Y);
                    if (valueCol == categoryCol + 1)
                    {
                        // 1 serie de datos, pintamos el otro eje directamente.
                        valueTitle = (String)(sheetReport.Cells[2, valueCol] as Range).Value2;
                    }                    
                }                

                chartPage.ChartWizard(chartRange, (XlChartType)Enum.Parse(typeof(XlChartType), queryReport.Char_Type, true),
                                          misval, misval, misval, misval, misval, reportName, categoryTitle, valueTitle, misval);
            }
            else
            {
                queryReport.Description = "EMPTY";                
            }

            // Rellenamos la descripción del informe
            fillDescription(queryReport, sheetReport);
        }

        private static int convertLetterToIndex(string letter)
        {
            return Char.Parse(letter) - 'A' + 1;
        }

        private static Range getRangeFrom(QueryReport queryReport, Worksheet sheetReport, DataSet procResultSet)
        {
            // A3
            string rX = queryReport.Range_X;
            // B
            string rY = queryReport.Range_Y;
            // A2 (para coger la fila de titulos y que rellene la leyenda correctamente).
            string rXmodif = rX.Substring(0,1) + (Int32.Parse(rX.Substring(1,1)) - 1);
            // BN (en función del número de datos insertados)
            string rYmodif = rY + (procResultSet.Tables[0].Rows.Count + 2);

            // Devuelve el rango de datos para pasárselo al gráfico.
            return sheetReport.get_Range(rXmodif, rYmodif);
        }

        private static void fillDescription(QueryReport queryReport, Worksheet sheetReport)
        {
            // Rellenamos la descripción del informe (filas 3 - 4 y 5)            
            int colum1 = Report.convertLetterToIndex(queryReport.Range_Y) + 4;
            string reportDescription = Constantes.getMessage(queryReport.Description);
            string[] tokens = reportDescription.Split(new char[] { ';' });

            if(queryReport.Description.Equals("EMPTY"))
            {
                sheetReport.Cells[3, colum1] = tokens[0] + " --> " + Constantes.getMessage(queryReport.Name);
            }
            else
            {
                sheetReport.Cells[3, colum1] = tokens[0];
            }
            
            if (queryReport.HasUserFilter && queryReport.QueryFilterByUser != null)
            {
                sheetReport.Cells[4, colum1] = Constantes.getMessage("ReportGenerateFilteredByMsg");
                sheetReport.Cells[4, colum1 + 1] = Constantes.getMessage("ReportGenerateUserFilterMsg");
                sheetReport.Cells[4, (colum1 + 2)] = queryReport.QueryFilterByUser.Name;
            }

            if (queryReport.HasCommandFilter && queryReport.QueryFilterByCommand != null)
            {
                sheetReport.Cells[4, colum1] = Constantes.getMessage("ReportGenerateFilteredByMsg");
                sheetReport.Cells[4, colum1 + 4] = Constantes.getMessage("ReportGenerateCommandFilterMsg");
                sheetReport.Cells[4, (colum1 + 5)] = queryReport.QueryFilterByCommand.Name;
            }

            if (queryReport.HasCategoryFilter && queryReport.QueryFilterByCategory != null)
            {
                sheetReport.Cells[4, colum1] = Constantes.getMessage("ReportGenerateFilteredByMsg");
                sheetReport.Cells[4, colum1 + 7] = Constantes.getMessage("ReportGenerateCategoryFilterMsg");
                sheetReport.Cells[4, (colum1 + 8)] = queryReport.QueryFilterByCategory.Name;
            }

            if (tokens.Length > 1){
                sheetReport.Cells[5, colum1] = tokens[1];
            }
        }

        #endregion
    
    }

}