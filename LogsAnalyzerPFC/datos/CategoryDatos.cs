using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using LogsAnalyzerPFC.entidades;

namespace LogsAnalyzerPFC.datos
{
    class CategoryDatos : DatosBase
    {

        #region "Constantes"

        private const String SP_INSERT_CATEGORY =
            "INSERT INTO CATEGORIES (ID, NAME) VALUES (SEQ_CATEGORIES.NEXTVAL, {0})";

        private const String SP_UPDATE_CATEGORY =
            "UPDATE CATEGORIES SET NAME={0} WHERE NAME={1}";

        private const String SP_DELETE_CATEGORY =
            "DELETE FROM CATEGORIES WHERE NAME={0}";

        private const String SP_DELETE_ALL =
            "DELETE FROM CATEGORIES";

        private const String SP_SELECT_ALL_CATEGORIES =
            "SELECT * FROM CATEGORIES";

        private const String SP_SELECT_CATEGORY_BY_ID =
            "SELECT * FROM CATEGORIES WHERE ID={0}";

        private const String SP_SELECT_CATEGORY_BY_NAME =
            "SELECT * FROM CATEGORIES WHERE NAME={0}";

        private const String SP_SELECT_COUNT_ALL_CATEGORIES =
            "SELECT COUNT(*) FROM CATEGORIES";

        private const String SP_SELECT_USED_CATEGORIES =
            "SELECT C.* " +
            "FROM CATEGORIES C, " +
            "(SELECT DISTINCT C.CATEGORY_ID FROM COMMANDS_USED U, COMMANDS C " +
            "WHERE U.COMMAND_ID = C.ID) T " +
            "WHERE C.ID = T.CATEGORY_ID " +
            "ORDER BY C.NAME";

        #endregion

        #region "Constructores"

        public CategoryDatos()
        { }

        #endregion

        #region "Métodos públicos"

        // Se usan desde fuera

        public Boolean InsertCategories(List<Category> list)
        {
            Boolean result = false;
            int r;

            try
            {
                ArrayList parameters = new ArrayList();

                List<String> l1 = new List<String>();

                for (int i = 0; i < list.Count; i++)
                {
                    l1.Add(list[i].Name);
                }

                OracleParameter p1 = new OracleParameter();
                p1.OracleDbType = OracleDbType.Varchar2;
                p1.Value = l1.ToArray<String>();
                parameters.Add(p1);

                r = base.ModuloDatosInformes.ExecuteNonReader("PL_INSERT_CATEGORIES", parameters, list.Count);

                result = (r == -1);
            }
            catch (Exception ex)
            {
                result = false;
                base.ModuloLog.Error(ex);
            }

            return result;
        }
  
        public Boolean DeleteAll()
        {
            Boolean result = false;
            int r;

            try
            {
                base.Query = SP_DELETE_ALL;

                r = base.ModuloDatos.ExecuteNonReader(base.Query);

                result = (r >= 0);
            }
            catch (Exception ex)
            {
                result = false;
                base.ModuloLog.Error(ex);
            }

            return result;
        }

        public List<Category> GetAllCategoriesInCommandsUsed()
        {
            List<Category> listaCategorias = new List<Category>();
            Category cat = new Category();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consultan todas las categorias relevantes.");

                base.Query = SP_SELECT_USED_CATEGORIES;
                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                // ExecuteDataSet -> Selects
                // ExecuteScalar  -> Devuelve un campo (ej: select count(*) from commands)
                // ExecuteNonReader -> Insert/Update/Delete: el valor que devuelve es el numero de filas que se han insertado/actualizado o borrado....

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cat = new Category();
                        this.FillCategoryData(dRow, cat);
                        listaCategorias.Add(cat);
                    }
                }
            }
            catch (Exception ex)
            {
                listaCategorias.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaCategorias;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> listaCategorias = new List<Category>();
            Category cat = new Category();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consultan todas las categorias relevantes.");

                base.Query = SP_SELECT_ALL_CATEGORIES;
                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                // ExecuteDataSet -> Selects
                // ExecuteScalar  -> Devuelve un campo (ej: select count(*) from commands)
                // ExecuteNonReader -> Insert/Update/Delete: el valor que devuelve es el numero de filas que se han insertado/actualizado o borrado....

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cat = new Category();
                        this.FillCategoryData(dRow, cat);
                        listaCategorias.Add(cat);
                    }
                }
            }
            catch (Exception ex)
            {
                listaCategorias.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaCategorias;
        }

        public Boolean hayCategories()
        {
            Boolean result = false;
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta el número de categorías almacenadas.");

                base.Query = SP_SELECT_COUNT_ALL_CATEGORIES;

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                result = (int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString()))>0;

            }
            catch (Exception ex)
            {
                base.ModuloLog.Error(ex);
            }

            return result;
        }

        // Se usan sólo aquí 

        public List<Category> GetCategoryById(int id_cat)
        {
            List<Category> listaCategorias = new List<Category>();
            Category cat = new Category();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta la categoria con id " + id_cat);

                base.Query = SP_SELECT_CATEGORY_BY_ID;
                base.InsertParameter(0, id_cat);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cat = new Category();
                        this.FillCategoryData(dRow, cat);
                        listaCategorias.Add(cat);
                    }
                }
            }
            catch (Exception ex)
            {
                listaCategorias.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaCategorias;
        }

        public List<Category> GetCategoryByName(String name)
        {
            List<Category> listaCategorias = new List<Category>();
            Category cat = new Category();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta la categoria con nombre " + name);

                base.Query = SP_SELECT_CATEGORY_BY_NAME;
                base.InsertParameter(0, name);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cat = new Category();
                        this.FillCategoryData(dRow, cat);
                        listaCategorias.Add(cat);
                    }
                }
            }
            catch (Exception ex)
            {
                listaCategorias.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaCategorias;
        }


        // No se usan nunca

        public Boolean InsertCategory(Category cat)
        {
            Boolean result = false;
            int r;

            try
            {
                base.Query = SP_INSERT_CATEGORY;
                base.InsertParameter(0, cat.Name);

                r = base.ModuloDatos.ExecuteNonReader(base.Query);

                result = (r == 1);
            }
            catch (Exception ex)
            {
                result = false;
                base.ModuloLog.Error(ex);
            }

            return result;
        }

        public Boolean UpdateCategory(Category cat, String nameOriginal)
        {
            Boolean result = false;
            int r;

            try
            {
                base.Query = SP_UPDATE_CATEGORY;
                base.InsertParameter(0, cat.Name);
                base.InsertParameter(1, nameOriginal);

                r = base.ModuloDatos.ExecuteNonReader(base.Query);

                result = (r == 1);
            }
            catch (Exception ex)
            {
                result = false;
                base.ModuloLog.Error(ex);
            }

            return result;
        }

        public Boolean DeleteCategory(Category cat)
        {
            Boolean result = false;
            int r;

            try
            {
                base.Query = SP_DELETE_CATEGORY;
                base.InsertParameter(0, cat.Name);

                r = base.ModuloDatos.ExecuteNonReader(base.Query);

                result = (r == 1);
            }
            catch (Exception ex)
            {
                result = false;
                base.ModuloLog.Error(ex);
            }

            return result;
        }

        public Boolean FindCategoryByName(String name)
        {
            List<Category> listaCategorias = new List<Category>();

            listaCategorias = this.GetCategoryByName(name);

            return (listaCategorias.Count > 0);
        }

        public Boolean FindCategoryById(int id)
        {
            List<Category> listaCategorias = new List<Category>();

            listaCategorias = this.GetCategoryById(id);

            return (listaCategorias.Count > 0);
        }

        public int GetIdCategory(String name)
        {
            Category cat = new Category();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta la categoria con nombre " + name);

                base.Query = SP_SELECT_CATEGORY_BY_NAME;
                base.InsertParameter(0, name);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cat = new Category();
                        this.FillCategoryData(dRow, cat);
                    }
                }
            }
            catch (Exception ex)
            {
                base.ModuloLog.Error(ex);
            }
            return cat.Id_category;
        }

        #endregion

        #region "Métodos privados"

        private void FillCategoryData(DataRow dRow, Category cat)
        {
            object obj;

            obj = dRow["ID"];
            if (obj != DBNull.Value)
            {
                cat.Id_category = Int32.Parse(obj.ToString());
            }

            obj = dRow["NAME"];
            if (obj != DBNull.Value)
            {
                cat.Name = obj.ToString();
            }
        }

        #endregion
    
    }
}
