using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using LogsAnalyzerPFC.entidades;
using System.IO;
using LogsAnalyzerPFC.process;
using LogsAnalyzerPFC.datos;
using LogsAnalyzerPFC.process.workers;
using Arquitectura.Log;
using System.Diagnostics;

namespace LogsAnalyzerPFC.forms
{
    public partial class Form2 : Form, IForm
    {
        #region "Atributos"
                
        /// <summary>
        /// Listado con todos los usuarios, comandos y categorias que se utilizan en commands_used.
        /// </summary>
        private FilterDataResult allData;

        /// <summary>
        /// Listado con los usuarios, comandos y categorias que se muestran en los combos, de acuerdo a los filtrados que se hayan realizado 
        /// sobre otros campos.
        /// </summary>
        private FilterDataResult filteredData;

        /// <summary>
        /// Filtro aplicado actualmente.
        /// </summary>
        private ActiveFilter currentFilter;

        /// <summary>
        /// Listado de informes general.
        /// </summary>
        private List<QueryReport> queryReportList;

        /// <summary>
        /// Listado de informes despues del primer filtro (tendran filtrado el usuario, comando o categoria)
        /// </summary>
        private List<QueryReport> filteredReports;

        /// <summary>
        /// Listado de informes a generar, cada uno con sus filtros.
        /// </summary>
        private List<QueryReport> selectedReports;

        /// <summary>
        /// Indica si se están ejecutando tareas internas que deban 'anular' el lanzamiento de más eventos por cambiar
        /// selecciones en combos del formulario.
        /// </summary>
        private bool noise;

        /// <summary>
        /// Referencia al módulo de logs.
        /// </summary>
        private ModuloLog moduloLog;        
        
        #endregion

        #region "Constructores"

        public Form2()
        {
            this.moduloLog = ModuloLog.GetInstance(Constantes.MODULO_LOG);
            this.noise = false;
            
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Constantes.language);
            InitializeComponent();           

            this.queryReportList = new List<QueryReport>();
            this.filteredReports = new List<QueryReport>();
            this.selectedReports = new List<QueryReport>();            

            // Rellenamos el listBox con el nombre de todos los Reports que hay disponibles en el idioma que corresponda
            this.queryReportList = new QueryReportDatos().GetAllQueryReports();            

            this.allData = new FilterDataResult();
            this.filteredData = new FilterDataResult();
            this.currentFilter = new ActiveFilter();
        }        

        public void initialize()
        {
            // Si no hay informes que realizar, volvemos a la pantalla principal
            if (this.queryReportList.Count == 0)
            {
                FormUtils.ShowMessageBox(Constantes.getMessage("ErrorReports"),
                Constantes.getMessage("Error"));
                FormReferences.getF1Instance(this, false);
                return;
            }

            this.runUpdateFiltersTask();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            // Para evitar que aparezca uno seleccionado por error al mostrar el formulario por primera vez.
            this.rbInitUserFilter.Checked = false;
            this.rbInitCommandFilter.Checked = false;
            this.rbInitCategoryFilter.Checked = false;
            this.rbInitNoneFilter.Checked = false;
            this.rbInitGeneralFilter.Checked = false;
        }

        #endregion

        #region "Métodos Botones"

        private void btnHome_Click(object sender, EventArgs e)
        {
            FormReferences.getF1Instance(this, false);
        }

        private void btnAddReport_Click(object sender, EventArgs e)
        {
            // Informes seleccionados
            List<QueryReport> selectedQrs = new List<QueryReport>();
            QueryReport newReport;

            if (this.lbxReports.SelectedIndices.Count > 0)
            {

                foreach (int index in this.lbxReports.SelectedIndices)
                {
                    newReport = new QueryReport(this.filteredReports[index]);

                    if (this.checkUserFilter.Visible && this.checkUserFilter.Checked && this.cBUser.SelectedIndex >= 0)
                    {
                        // Si el check es visible, esta marcado y hay algo marcado en el combo, entonces aplicamos el filtro
                        newReport.QueryFilterByUser = this.filteredData.UsersList[this.cBUser.SelectedIndex];
                    }
                    if (this.checkCommandFilter.Visible && this.checkCommandFilter.Checked && this.cBCommand.SelectedIndex >= 0)
                    {
                        // Si el check es visible, esta marcado y hay algo marcado en el combo, entonces aplicamos el filtro
                        newReport.QueryFilterByCommand = this.filteredData.CommandsList[this.cBCommand.SelectedIndex];
                    }
                    if (this.checkCategoryFilter.Visible && this.checkCategoryFilter.Checked && this.cBCategory.SelectedIndex >= 0)
                    {
                        // Si el check es visible, esta marcado y hay algo marcado en el combo, entonces aplicamos el filtro
                        newReport.QueryFilterByCategory = this.filteredData.CategoriesList[this.cBCategory.SelectedIndex];
                    }

                    this.selectedReports.Add(newReport);
                    FormUtils.loadReport(this.lbxSelectedReports, newReport);
                    this.updateDeleteButtonsWithReportsToGenerateCombo();
                }

                // Hacemos scroll al final de la lista para que se vean los nuevos informes añadidos
                this.lbxSelectedReports.TopIndex = this.lbxSelectedReports.Items.Count - 1;
            }
        }

        private void btnMakeReports_Click(object sender, EventArgs e)
        {
            if (!(this.selectedReports.Count > 0))
            {
                FormUtils.ShowMessageBox(Constantes.getMessage("WarnMsgChooseReport"),
                                Constantes.getMessage("Warn"));
            }
            else
            {
                bool doWork = this.tryToDeleteFile(Constantes.fileReportsPath) && this.tryToDeleteFile(Constantes.fileReportsPDFPath);

                if (!doWork){

                    FormUtils.ShowMessageBox(Constantes.getMessage("WarnFileOpened"),
                                    Constantes.getMessage("Warn"));
                }
                else
                {
                    IWorker worker = new GenerateReportWorker(this.selectedReports);
                    this.toolStripProgressBar1.Visible = true;
                    FormUtils.startNewWorkAsync(worker, this);
                }
            }
        }

        private void btnResetSelReports_Click(object sender, EventArgs e)
        {
            this.selectedReports.Clear();
            this.lbxSelectedReports.Items.Clear();
            this.updateDeleteButtonsWithReportsToGenerateCombo();
        }

        private void btnClearSelReport_Click(object sender, EventArgs e)
        {
            if (this.lbxSelectedReports.SelectedIndices.Count > 0)
            {
                int previousIndex = this.lbxSelectedReports.TopIndex;

                for (int x = this.lbxSelectedReports.SelectedIndices.Count - 1; x >= 0; x--)
                { 
                    this.selectedReports.RemoveAt(this.lbxSelectedReports.SelectedIndices[x]);
                }

                FormUtils.loadReports(this.lbxSelectedReports, this.selectedReports);
                this.updateDeleteButtonsWithReportsToGenerateCombo();

                if (previousIndex >= 0)
                {
                    this.lbxSelectedReports.TopIndex = previousIndex;
                }
            }
        }        

        private void lbxReports_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (lbxReports.Items.Count > 0)
            {
                e.DrawBackground();
                e.Graphics.DrawString(lbxReports.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        private void lbxReports_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (lbxReports.Items.Count > 0)
            {
                e.ItemHeight = e.ItemHeight * (lbxReports.Items[e.Index].ToString().Split(new char[] { '\n' }).Length + 1);
            }
        }

        private void lbxSelectedReports_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (lbxSelectedReports.Items.Count > 0)
            {
                e.DrawBackground();
                e.Graphics.DrawString(lbxSelectedReports.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        private void lbxSelectedReports_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (lbxSelectedReports.Items.Count > 0)
            {
                e.ItemHeight = e.ItemHeight * (lbxSelectedReports.Items[e.Index].ToString().Split(new char[] { '\n' }).Length + 1);
            }
        }

        #endregion

        #region "Eventos de filtrado"

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            // Generamos ruido para que al actualizar los combos de los filtros no se hagan llamadas a BBDD.
            this.noise = true;

            // Simula el click en "Sin filtro"            
            this.rbInitNoneFilter.Checked = true;
            
            // Reseteo total de los filtros, incluidas las posible selecciones del usuario
            this.resetFilterInputs();

            // Recargamos los combos con todos los valores
            this.rechargeFilterCombos(true, true, true, this.allData);

            // El filtro actual vuelve a estar vacío
            this.currentFilter = new ActiveFilter();

            // Quitamos el multiselect.
            this.checkMultiselect.Checked = false;

            // Limpiamos los posibles informes que pudiera haber seleccionados.
            this.btnClearInitialReport_Click(sender, e);

            // Desactivamos el ruido.
            this.noise = false;
        }

        private void checkUserFilter_CheckedChanged(object sender, EventArgs e)
        {
            // Se muestra/oculta el combo en función de si se marca el check
            this.cBUser.Visible = this.checkUserFilter.Checked;
        }

        private void checkCommandFilter_CheckedChanged(object sender, EventArgs e)
        {
            // Se muestra/oculta el combo en función de si se marca el check
            this.cBCommand.Visible = this.checkCommandFilter.Checked;
        }

        private void checkCategoryFilter_CheckedChanged(object sender, EventArgs e)
        {
            // Se muestra/oculta el combo en función de si se marca el check
            this.cBCategory.Visible = this.checkCategoryFilter.Checked;
        }

        private void checkUserFilter_VisibleChanged(object sender, EventArgs e)
        {
            // Solo se muestra el combo si el check es visible y esta marcado
            this.cBUser.Visible = this.checkUserFilter.Visible && this.checkUserFilter.Checked;
        }

        private void checkCommandFilter_VisibleChanged(object sender, EventArgs e)
        {
            // Solo se muestra el combo si el check es visible y esta marcado
            this.cBCommand.Visible = this.checkCommandFilter.Visible && this.checkCommandFilter.Checked;
        }

        private void checkCategoryFilter_VisibleChanged(object sender, EventArgs e)
        {
            // Solo se muestra el combo si el check es visible y esta marcado
            this.cBCategory.Visible = this.checkCategoryFilter.Visible && this.checkCategoryFilter.Checked;
        }

        private void cBUser_VisibleChanged(object sender, EventArgs e)
        {
            this.cBUser_SelectedIndexChanged(sender, e);           
        }

        private void cBCommand_VisibleChanged(object sender, EventArgs e)
        {
            this.cBCommand_SelectedIndexChanged(sender, e);
        }

        private void cBCategory_VisibleChanged(object sender, EventArgs e)
        {
            this.cBCategory_SelectedIndexChanged(sender, e);
        }

        private void cBUser_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if (!noise)
            {
                // Actualizamos el filtro de usuario
                User currentUserFiltering = this.currentFilter.User;
                this.updateUserFiltering();

                if (currentUserFiltering != this.currentFilter.User)
                {
                    this.runUpdateFiltersTask();
                }    
            }            
        }        

        private void cBCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!noise)
            {
                // Actualizamos el filtro de comando
                Command currentCommandFiltering = this.currentFilter.Command;
                this.updateCommandFiltering();

                if (currentCommandFiltering != this.currentFilter.Command)
                {
                    this.runUpdateFiltersTask();
                }
            }
        }        

        private void cBCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!noise)
            {
                // Actualizamos el filtro de categoria
                Category currentCategFiltering = this.currentFilter.Category;
                this.updateCategoryFiltering();

                if (currentCategFiltering != this.currentFilter.Category)
                {
                    this.runUpdateFiltersTask();
                }
            }
        }             

        private void rbInitFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                this.filteredReports.Clear();
                foreach (QueryReport qr in this.queryReportList)
                {
                    if ((this.rbInitNoneFilter.Checked) ||
                        (this.rbInitUserFilter.Checked && qr.HasUserFilter) ||
                        (this.rbInitCommandFilter.Checked && qr.HasCommandFilter) ||
                        (this.rbInitCategoryFilter.Checked && qr.HasCategoryFilter) ||
                        (this.rbInitGeneralFilter.Checked && (qr.isGeneralReport())))
                    {
                        this.filteredReports.Add(new QueryReport(qr));
                    }
                }

                FormUtils.loadReports(this.lbxReports, this.filteredReports);
                
                this.gBFilters.Visible = false;

                // Habilitamos el boton de reset y el group de informes inferior (la primera vez estaran deshabilitados).
                if (!this.gbSelectReports.Visible)
                {
                    this.gbSelectReports.Visible = true;
                    this.btnResetFilters.Visible = true;
                }
            }
        }

        private void lbxReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.noise)
            {
                // Deberia haber un informe seleccionado, sino ocultamos los filtros.
                if (this.lbxReports.SelectedIndices.Count > 0)
                {
                    this.noise = true;

                    ActiveFilter oldFilter = new ActiveFilter(this.currentFilter);

                    this.gBFilters.Visible = true;

                    // Informes seleccionados
                    List<QueryReport> selectedQrs = new List<QueryReport>();
                    foreach (int index in this.lbxReports.SelectedIndices)
                    {
                        selectedQrs.Add(this.filteredReports[index]);
                    }

                    // Comprobamos si alguno de los informes seleccionados tiene cada tipo de filtro.
                    // Con que un informe tenga un tipo de filtro, deberemos preguntar por ese filtro.
                    bool hasUserFilter = false, hasCmndFilter = false, hasCatgFilter = false;
                    selectedQrs.ForEach(q => hasUserFilter = hasUserFilter || q.HasUserFilter);
                    selectedQrs.ForEach(q => hasCmndFilter = hasCmndFilter || q.HasCommandFilter);
                    selectedQrs.ForEach(q => hasCatgFilter = hasCatgFilter || q.HasCategoryFilter);

                    // Se muestran los checks en función de si los tipos de informes seleccionados lo admiten.
                    this.checkUserFilter.Visible = hasUserFilter;
                    this.checkCommandFilter.Visible = hasCmndFilter;
                    this.checkCategoryFilter.Visible = hasCatgFilter;

                    // Actualizamos el filtro actual con los filtros visibles que estén seleccionados.
                    this.updateUserFiltering();
                    this.updateCommandFiltering();
                    this.updateCategoryFiltering();

                    if (!oldFilter.Equals(this.currentFilter))
                    {
                        // Si el filtro ha cambiado respecto al antiguo, se recalculan los valores de los 3 combos.
                        this.runUpdateFiltersTask();
                    }
                    else
                    {
                        this.noise = false;
                    }                    
                }
                else
                {
                    // Si no esta seleccionado ningún informe, ocultamos el panel de filtros (por si acaso).
                    this.gBFilters.Visible = false;
                }
            }
        }

        private void btnClearInitialReport_Click(object sender, EventArgs e)
        {
            this.noise = true;
            this.lbxReports.ClearSelected();
            this.noise = false;
            // Refresh
            this.lbxReports_SelectedIndexChanged(sender, e);
        }

        private void btnSelectAllInitialReports_Click(object sender, EventArgs e)
        {
            this.noise = true;
            for (int i = 0; i < this.lbxReports.Items.Count; i++)
            {
                this.lbxReports.SetSelected(i, true);
            }            
            this.noise = false;            
            // Refresh
            this.lbxReports_SelectedIndexChanged(sender, e);
        }

        private void checkMultiselect_CheckedChanged(object sender, EventArgs e)
        {
            this.lbxReports.SelectionMode = this.checkMultiselect.Checked ? SelectionMode.MultiSimple : SelectionMode.One;
            this.btnSelectAllInitialReports.Enabled = this.checkMultiselect.Checked;
            this.btnClearInitialReport.Enabled = this.checkMultiselect.Checked;
            // Refresh
            this.lbxReports_SelectedIndexChanged(sender, e);
        }

        #endregion

        #region "Métodos Auxiliares"               

        private void resetFilterInputs()
        {               
            this.checkUserFilter.Checked = false;
            this.checkCommandFilter.Checked = false;
            this.checkCategoryFilter.Checked = false;
            this.cBUser.SelectedIndex = -1;
            this.cBCommand.SelectedIndex = -1;
            this.cBCategory.SelectedIndex = -1;            
        }              

        private bool tryToDeleteFile(String file)
        {
            bool deleteOk = true;
            if (File.Exists(file))
            {
                try
                {
                    File.Delete(file);
                    deleteOk = true;
                }
                catch (Exception)
                {
                    deleteOk = false;
                }
            }
            return deleteOk;
        }        

        private void rechargeFilterCombos(
            bool rechargeUser, 
            bool rechargeCommands, 
            bool rechargeCategories, 
            FilterDataResult newDataForCombos)
        {
            // Si hay que recargar el combo de usuarios.
            if (rechargeUser)
            {
                this.rechargeComboWithListAndMaintainStatus<User>(this.cBUser, this.filteredData.UsersList, newDataForCombos.UsersList);
                this.filteredData.UsersList = new List<User>();
                this.filteredData.UsersList.AddRange(newDataForCombos.UsersList);
            }

            // Si hay que recargar el combo de comandos.
            if (rechargeCommands)
            {
                this.rechargeComboWithListAndMaintainStatus<Command>(this.cBCommand, this.filteredData.CommandsList, newDataForCombos.CommandsList);
                this.filteredData.CommandsList = new List<Command>();
                this.filteredData.CommandsList.AddRange(newDataForCombos.CommandsList);
            }

            // Si hay que recargar el combo de categorias.
            if (rechargeCategories)
            {
                this.rechargeComboWithListAndMaintainStatus<Category>(this.cBCategory, this.filteredData.CategoriesList, newDataForCombos.CategoriesList);
                this.filteredData.CategoriesList = new List<Category>();
                this.filteredData.CategoriesList.AddRange(newDataForCombos.CategoriesList);
            }
        }

        private void rechargeComboWithListAndMaintainStatus<T>(ComboBox combo, List<T> oldList, List<T> newList)
        {
            // Nos guardamos el usuario seleccionado si es que hay alguno
            T previousSelection = default(T);
            if (combo.SelectedIndex >= 0 && oldList != null)
            {
                previousSelection = oldList[combo.SelectedIndex];
            }

            // Recargamos la lista
            combo.Items.Clear();
            newList.ForEach(e => combo.Items.Add(e.ToString()));

            // Volvemos a seleccionar el usaurio original, si es que había alguno seleccionado, y si es que existe en la nueva lista.
            if (previousSelection != null)
            {
                int index = newList.IndexOf(previousSelection);
                if (index >= 0)
                {
                    combo.SelectedIndex = index;
                }
            }
        }

        private void runUpdateFiltersTask()
        {
            // Se lanza el worker de actualizacion de filtros (cambiar parámetro para ejecutar en modo 'silencioso' o no).
            this.runUpdateFiltersTask(true, true);
        }

        private void runUpdateFiltersTask(bool silent, bool blockInterface)
        {
            // Se lanza el filtro con la seleccion de usuario/comando/categoria.
            IWorker worker = new UpdateReportFiltersWorker(this.currentFilter, allData);
            if (!silent)
            {
                this.toolStripProgressBar1.Visible = true;
            }
            this.noise = true;
            FormUtils.startNewWorkAsync(worker, this, silent, blockInterface);
        }

        private void lbxSelectedReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se habilita/deshabilita el boton de borrar seleccion cuando haya alguna selección
            this.btnClearSelReport.Enabled = this.lbxSelectedReports.SelectedIndices.Count > 0;
        }

        private void updateDeleteButtonsWithReportsToGenerateCombo()
        {
            // Se habilita/deshabilita el boton de borrar todos los informes seleccionados cuando haya algun informe.
            this.btnResetSelReports.Enabled = this.lbxSelectedReports.Items.Count > 0;
            this.btnClearSelReport.Enabled = this.lbxSelectedReports.SelectedIndices.Count > 0;
        }

        /// <summary>
        /// Actualiza el filtro actual con la selección del combo de usuarios.
        /// </summary>
        private void updateUserFiltering()
        {            
            if (this.cBUser.Visible && this.cBUser.SelectedIndex >= 0)
            {
                this.currentFilter.User = this.filteredData.UsersList[this.cBUser.SelectedIndex];
            }
            else
            {
                this.currentFilter.User = null;
            }
        }

        /// <summary>
        /// Actualiza el filtro actual con la selección del combo de comandos.
        /// </summary>
        private void updateCommandFiltering()
        {
            if (this.cBCommand.Visible && this.cBCommand.SelectedIndex >= 0)
            {
                this.currentFilter.Command = this.filteredData.CommandsList[this.cBCommand.SelectedIndex];
            }
            else
            {
                this.currentFilter.Command = null;
            }
        }

        /// <summary>
        /// Actualiza el filtro actual con la selección del combo de categorías.
        /// </summary>
        private void updateCategoryFiltering()
        {            
            if (this.cBCategory.Visible && this.cBCategory.SelectedIndex >= 0)
            {
                this.currentFilter.Category = this.filteredData.CategoriesList[this.cBCategory.SelectedIndex];
            }
            else
            {
                this.currentFilter.Category = null;
            }            
        }

        #endregion
        
        #region IForm Members

        public void updateTaskProgress(ProgressChangedEventArgs args)
        {
            this.toolStripProgressBar1.Value = args.ProgressPercentage;
            if (args.UserState != null)
            {
                this.toolStripStatusLabel1.Text = args.UserState.ToString();
            }
        }

        public void updateTaskCompleted(RunWorkerCompletedEventArgs args)
        {
            FormUtils.enablingFormWorkingControls(this, true);
            this.toolStripProgressBar1.Visible = false;
            this.toolStripProgressBar1.Value = 0;

            // Debería estar a true, pero por si acaso lo volvemos a poner, para que nada interfiera en la actualización.
            this.noise = true;
            
            ProcessResult pr = null;

            if (args.Result != null && args.Result is ProcessResult)
            {
                pr = (ProcessResult)args.Result;
            }

            if (pr.ProcessException != null)
            {
                FormUtils.ShowMessageBox(Constantes.getMessage(pr.ProcessException.Message),
                                Constantes.getMessage("Error"));
            }
            else
            {
                if (pr.Type == AbstractWorker.WorkerType.GenerateReport)
                {
                    // Respuesta del worker de generación de informes.
                    try
                    {
                        // Conversión a PDF.
                        Report.exportWorkbookToPdf();
                        this.toolStripStatusLabel1.Text = Constantes.getMessage("InfoMsgReportOk");

                        FormUtils.ShowMessageBox(Constantes.getMessage("InfoMsgReportOk"),
                                        Constantes.getMessage("Info"));

                        // Si todo ha ido bien, se muestra el Form3 (resultados).
                        FormReferences.getF3Instance(this, true).initialize(this.selectedReports);
                    }
                    catch (Exception)
                    {
                        // Export failed.
                        FormUtils.ShowMessageBox(Constantes.getMessage("ErrorMsgExportFailed"),
                                        Constantes.getMessage("Error"));

                        throw new Exception(Constantes.getMessage("ErrorMsgExportFailed"));
                    }
                }
                else if (pr.Type == AbstractWorker.WorkerType.UpdateReportFilters)
                {
                    // Respuesta del worker de actualizacion de filtros.

                    if (pr.ProcessOutput != null && pr.ProcessOutput is FilterDataResult)
                    {
                        FilterDataResult newFilters = (FilterDataResult)pr.ProcessOutput;
                        
                        // Si es la primera llamada...
                        if (this.allData.isEmpty())
                        {
                            this.allData = newFilters;
                        }
                        this.rechargeFilterCombos(true, true, true, newFilters);
                        this.moduloLog.Debug("Filtro aplicado: " + this.currentFilter.ToString());
                    }
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            this.noise = false;            
        }

        public List<Control> getWorkingControls()
        {
            Control[] workingControls = new Control[]{
                this.gbSelectReports,                
                this.gbInitialFiltersGroup,
                this.btnResetFilters
            };
            return workingControls.ToList<Control>();
        }       

        #endregion                                      
    }
}