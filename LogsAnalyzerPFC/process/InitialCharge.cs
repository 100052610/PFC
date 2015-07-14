using System;
using System.Linq;
using System.Text;
using Arquitectura.Log;
using System.ComponentModel;
using System.Collections.Generic;
using LogsAnalyzerPFC.process;
using LogsAnalyzerPFC.entidades;
using Microsoft.Office.Interop.Excel;
using LogsAnalyzerPFC.process.exceptions;


namespace LogsAnalyzerPFC
{
    class InitialCharge
    {

        #region "Atributos"
 
        private string file;
        private ChargeData newData;
        private List<Command> commandsList;
        private List<Category> categoriesList;
        private ModuloLog modLog;
        
        #endregion

        #region "Constructores"

        public InitialCharge(string f1)
        {
            this.file = f1;
            this.newData = ChargeData.getInstance();
            this.commandsList = new List<Command>();
            this.categoriesList = new List<Category>();
            this.modLog = ModuloLog.GetInstance(Constantes.MODULO_LOG);
        }

        #endregion

        #region "Métodos Públicos"

        /// <summary>
        /// Método para cargar el Fichero de Comandos Iniciales con sus parámetros
        /// Cargamos las tablas de la base de datos con los comandos y categorias que vamos a tener en cuenta
        /// </summary>

        public void chargeTables(BackgroundWorker worker)
        {
            Category cat;            

            modLog.Info("Leemos la información contenida en el fichero de Comandos Iniciales.");

            if (!this.readCommandsFile(worker))
            {
                throw new AppProcessException("TODO: Se ha producido un error recuperando la informacion del excel de comandos y categorias");
            }
            
            modLog.Info("Fichero de Comandos Iniciales leído.");

            modLog.Info("Cargamos las CATEGORIAS en la tabla CATEGORIES");

            worker.ReportProgress(80, Constantes.getMessage("ReportProgress_CC"));

            if (!this.newData.chargeCategories(this.categoriesList))
            {
                throw new AppProcessException("TODO: No se han guardado correctamente las categorías en BBDD");
            }

            modLog.Info("Categorias Iniciales Cargadas en la Base de Datos");

            // Rellenamos la categoría de los Comandos

            worker.ReportProgress(82);

            this.categoriesList = this.newData.getAllCategories();

            // Buscamos la categoria en la lista para coger el Identificador que tiene en nuestra base de datos para cada comando de nuestra lista
            for (int i = 0; i < commandsList.Count; i++)
            {
                cat = this.categoriesList.Find(category => (category.Name == commandsList[i].Cat.Name));
                commandsList[i].Cat.Id_category = cat.Id_category;
            }

            worker.ReportProgress(84, Constantes.getMessage("ReportProgress_CCI"));

            // Insertamos los Comandos Iniciales en la Base de Datos

            modLog.Info("Cargamos los COMANDOS en la tabla COMMANDS");

            if (!this.newData.chargeInitialCommands(this.commandsList, worker))
            {
                throw new AppProcessException("TODO: No se han guardado correctamente los comandos en BBDD");
            }
            
            modLog.Info("Comandos Iniciales Cargados en la Base de Datos");
        }

        #endregion

        #region Métodos Privados

        private Boolean readCommandsFile(BackgroundWorker worker)
        {
            Boolean result = false;
            Command cmd;
            Category cat;            

            object misval = System.Reflection.Missing.Value;
            Application app = null;
            Workbook book = null;
            Worksheet sheet;
            Range range;

            int rCnt = 1;
            int cCnt = 1;

            int wTimer = 20;

            try
            {
                app = new Application();
                book = app.Workbooks.Open(this.file, misval, misval, misval, misval, misval, misval, misval, misval, misval, misval, misval, misval, misval, misval);
                sheet = (Worksheet)book.Worksheets.get_Item(1);

                range = sheet.UsedRange;

                int add = 0;
                int addWTimer = range.Rows.Count / 60;

                Object[,] data = (object[,])range.get_Value(misval);

                for (rCnt = 2; rCnt <= data.GetLength(0); rCnt++)
                {
                    add++;
                    if (add > addWTimer)
                    {
                        add = 1;
                        wTimer++;
                        worker.ReportProgress(wTimer);
                    }

                    cmd = new Command();
                    cat = new Category();

                    for (cCnt = 1; cCnt <= data.GetLength(1); cCnt++)
                    {
                        switch (cCnt)
                        {
                            case (1):

                                cmd.Name = (string)(data[rCnt, cCnt]);
                                break;

                            case (2):
                                cat.Name = (string)(data[rCnt, cCnt]);
                                cmd.Cat = cat;
                                break;

                            case (3):
                                cmd.NumParams = Int32.Parse(data[rCnt, cCnt].ToString());
                                break;

                            case (4):
                                cmd.Difficulty = Int32.Parse(data[rCnt, cCnt].ToString());
                                break;

                            case (5):
                                cmd.Impact = Int32.Parse(data[rCnt, cCnt].ToString());
                                break;

                            case (6):
                                cmd.Description = (string)(data[rCnt, cCnt]);
                                break;

                            default:
                                modLog.Warning("No hay más información almacenada en el Excel de Comandos Iniciales y Lógica de Análisis.");
                                break;
                        }
                    }
                    if (!cmd.Name.Equals("") && !commandsList.Contains(cmd))
                    {
                        this.commandsList.Add(cmd);
                    }
                    if (!cat.Name.Equals("") && !categoriesList.Exists(x => x.Name.Equals(cat.Name)))
                    {
                        this.categoriesList.Add(cat);
                    }
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                this.modLog.Error(ex);
            }
            finally
            {
                try
                {
                    if (book != null)
                    {
                        book.Close(true, null, null);
                    }
                    if (app != null)
                    {
                        app.Quit();
                    }
                }
                catch (Exception){ }
            }

            return result;
        }

        #endregion
    
    }
}
