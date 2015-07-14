using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LogsAnalyzerPFC.entidades;
using LogsAnalyzerPFC.datos;
using System.Threading;

namespace LogsAnalyzerPFC.process.workers
{
    class UpdateReportFiltersWorker : AbstractWorker
    {
        private ActiveFilter filterToApply;
        private FilterDataResult allData;

        public UpdateReportFiltersWorker(ActiveFilter filterToApply, FilterDataResult allData) 
            : base(false)
        {
            this.filterToApply = filterToApply;            
            this.allData = allData;
        }

        protected override WorkerType getType()
        {
            return WorkerType.UpdateReportFilters;
        }

        protected override void doSpecificWork(BackgroundWorker worker, DoWorkEventArgs args)
        {
            String msg;
            Boolean result = false;

            try
            {
                worker.ReportProgress(10, Constantes.getMessage("MsgUpdateReportFiltersInit"));

                FilterDataResult filteredData = null;

                if (this.allData == null || this.allData.isEmpty())
                {
                    // Primera llamada al cargar los filtros
                    filteredData = new FilterDataResult();
                    filteredData.UsersList = new UserDatos().GetAllUsers();                    
                    filteredData.CommandsList = new CommandDatos().GetAllCommandsInCommandsUsed();                    
                    filteredData.CategoriesList = new CategoryDatos().GetAllCategoriesInCommandsUsed();    
                }
                else
                {
                    // Resto de llamadas

                    filteredData = new FilterDataResult(this.allData);

                    if (this.filterToApply.User != null)
                    {
                        // Tenemos que calcular los comandos y categorias que tiene sentido mostrar para el usuario seleccionado.
                        List<Int32> commandIds = new UsedCommandDatos().GetDistinctCommandsUsedBy(this.filterToApply.User);
                        filteredData.CommandsList = filteredData.CommandsList.FindAll(c => commandIds.Contains(c.Id_command));

                        List<Int32> categoryIds = new UsedCommandDatos().GetDistinctCategoriesUsedBy(this.filterToApply.User);
                        filteredData.CategoriesList = filteredData.CategoriesList.FindAll(c => categoryIds.Contains(c.Id_category));
                    }

                    if (this.filterToApply.Command != null)
                    {
                        // Tenemos que calcular los usuarios que tiene sentido mostrar para el comando seleccionado.
                        // La categoría se seleccionará automáticamente la correspondiente al comando, de las que haya en el combo.
                        List<Int32> usersIds = new UsedCommandDatos().GetDistinctUsersUsingCmd(this.filterToApply.Command);
                        filteredData.UsersList = filteredData.UsersList.FindAll(u => usersIds.Contains(u.Id_user));
                        filteredData.CategoriesList = filteredData.CategoriesList.FindAll(u => this.filterToApply.Command.Cat.Equals(u));
                    }

                    if (this.filterToApply.Category != null)
                    {
                        // Tenemos que calcular los usuarios que tiene sentido mostrar para la categoría seleccionada.
                        // Los comandos se seleccionarán automáticamente aquellos que pertenezcan a dicha categoría.
                        List<Int32> usersIds = new UsedCommandDatos().GetDistinctUsersUsingCat(this.filterToApply.Category);
                        filteredData.UsersList = filteredData.UsersList.FindAll(u => usersIds.Contains(u.Id_user));
                        filteredData.CommandsList = filteredData.CommandsList.FindAll(c => this.filterToApply.Category.Equals(c.Cat));
                    }
                }

                args.Result = filteredData;
                result = true;
            }
            catch (Exception ex)
            {
                msg = "Error: Problemas actualizando los filtros que se muestran para generar los informes";
                this.modLog.Error(msg + ex.Message);
            }
            finally
            {
                if (result)
                {
                    worker.ReportProgress(100, Constantes.getMessage("MsgUpdateReportFiltersOk"));
                }
                else
                {
                    throw new Exception("MsgUpdateReportFiltersError");
                }
            }
        }
    }
}