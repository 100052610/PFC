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
    class QueryReportDatos : DatosBase
    {

        #region "Constantes"

        private const String SP_INSERT_QUERY_REPORT =
            "INSERT INTO QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHAR_TYPE, RANGE_X, RANGE_Y, SHEET_NAME) VALUES (SEQ_QUERY_RERPOTS.NEXTVAL, {0}, {1}, {2}, {3}, {4}, {5}, {6})";

        private const String SP_UPDATE_QUERY_REPORT =
            "UPDATE QUERY_REPORTS SET (NAME={0}, STORE_PROCEDURE={1}, DESCRIPTION={2}, CHAR_TYPE={3}, RANGE_X={4}, RANGE_Y={5}, SHEET_NAME={6}) WHERE (NAME={7} and STORE_PROCEDURE={8} and DESCRIPTION={9} and CHAR_TYPE={10} and RANGE_X={11} and RANGE_Y={12} and SHEET_NAME={13})";

        private const String SP_DELETE_QUERY_REPORT =
            "DELETE FROM QUERY_REPORTS WHERE NAME={0} and STORE_PROCEDURE={1} and DESCRIPTION={2} and CHAR_TYPE={3} and RANGE_X={4} and RANGE_Y={5} and SHEET_NAME={6}";

        private const String SP_SELECT_ALL_QUERY_REPORTS =
            "SELECT Q.ID, Q.NAME, Q.STORE_PROCEDURE, Q.DESCRIPTION, C.NAME AS CHART_TYPE, R.RANGE_X, R.RANGE_Y, R.NAME AS P_NAME, C.HAS_AXIS, Q.FILTERS "+
            "FROM QUERY_REPORTS Q, CHART_TYPES C, REPORT_TEMPLATES R "+
            "WHERE Q.CHART_TYPE = C.ID AND Q.TEMPLATE = R.ID "+
            "ORDER BY Q.ID ASC";            

        private const String SP_SELECT_ALL_QUERY_REPORTS_NAME =
            "SELECT NAME FROM QUERY_REPORTS";

        private const String SP_SELECT_QUERY_REPORT_BY_STORE_PROCEDURE =
            "SELECT * FROM QUERY_REPORTS WHERE STORE_PROCEDURE={0}";

        private const String SP_SELECT_QUERY_REPORT_BY_DESCRIPTION =
            "SELECT * FROM QUERY_REPORTS WHERE DESCRIPTION={0}";

        private const String SP_SELECT_QUERY_REPORT_BY_CHAR_TYPE =
            "SELECT * FROM QUERY_REPORTS WHERE CHAR_TYPE={0}";

        private const String SP_SELECT_QUERY_REPORT_BY_RANGE_X =
            "SELECT * FROM QUERY_REPORTS WHERE RANGE_X={0}";

        private const String SP_SELECT_QUERY_REPORT_BY_RANGE_Y =
            "SELECT * FROM QUERY_REPORTS WHERE RANGE_Y={0}";

        private const String SP_SELECT_QUERY_REPORT_BY_SHEET_NAME =
            "SELECT * FROM QUERY_REPORTS WHERE SHEET_NAME={0}";
        
        #endregion

        #region "Constructores"

        public QueryReportDatos()
        { }

        #endregion

        #region "Métodos públicos"

        public List<QueryReport> GetAllQueryReports()
        {
            List<QueryReport> listaQueryReports = new List<QueryReport>();
            QueryReport qR = new QueryReport();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consultan todas las QueryReport que hay en la base de datos.");

                base.Query = SP_SELECT_ALL_QUERY_REPORTS;
                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                // ExecuteDataSet -> Selects
                // ExecuteScalar  -> Devuelve un campo (ej: select count(*) from commands)
                // ExecuteNonReader -> Insert/Update/Delete: el valor que devuelve es el numero de filas que se han insertado/actualizado o borrado....

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        qR = new QueryReport();
                        this.FillQueryReportData(dRow, qR);
                        listaQueryReports.Add(qR);
                    }
                }
            }
            catch (Exception ex)
            {
                listaQueryReports.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaQueryReports;
        }

        private void addConditionalParameter(ArrayList parameters, bool condition, string paramName, object paramValue)
        {
            if (condition)
            {
                OracleParameter filterParam = new OracleParameter(paramName, OracleDbType.Varchar2);
                filterParam.Direction = ParameterDirection.Input;
                filterParam.Value = DBNull.Value;

                if (paramValue != null)
                {
                    filterParam.Value = paramValue;
                }

                parameters.Add(filterParam);
            }
        }

        public DataSet ExecuteQueryReport(QueryReport queryReport)
        {
            DataSet ds = null;

            try
            {
                ArrayList parameters = new ArrayList();

                if (queryReport.HasUserFilter)
                {
                    OracleParameter filterParam = new OracleParameter("filterUser", OracleDbType.Int32);
                    filterParam.Direction = ParameterDirection.Input;
                    filterParam.Value = DBNull.Value;
                    if (queryReport.QueryFilterByUser != null)
                    {
                        filterParam.Value = queryReport.QueryFilterByUser.Id_user;
                    }
                    parameters.Add(filterParam);
                }

                if (queryReport.HasCommandFilter)
                {
                    OracleParameter filterParam = new OracleParameter("filterCommand", OracleDbType.Int32);
                    filterParam.Direction = ParameterDirection.Input;
                    filterParam.Value = DBNull.Value;
                    if (queryReport.QueryFilterByCommand != null)
                    {
                        filterParam.Value = queryReport.QueryFilterByCommand.Id_command;
                    }
                    parameters.Add(filterParam);
                }

                if (queryReport.HasCategoryFilter)
                {
                    OracleParameter filterParam = new OracleParameter("filterCategory", OracleDbType.Int32);
                    filterParam.Direction = ParameterDirection.Input;
                    filterParam.Value = DBNull.Value;
                    if (queryReport.QueryFilterByCategory != null)
                    {
                        filterParam.Value = queryReport.QueryFilterByCategory.Id_category;
                    }
                    parameters.Add(filterParam);
                }
                
                OracleParameter cursorParam = new OracleParameter("pRefCursor", OracleDbType.RefCursor);
                cursorParam.Direction = ParameterDirection.Output;                
                parameters.Add(cursorParam);

                ds = base.ModuloDatosInformes.ExecuteDataSet(queryReport.Store_procedure, parameters);
            }
            catch (Exception ex)
            {
                ds = null;
                base.ModuloLog.Error(ex);
            }

            return ds;
        }

        #endregion

        #region "Métodos privados"

        private void FillQueryReportData(DataRow dRow, QueryReport qR)
        {
            object obj;

            obj = dRow["ID"];
            if (obj != DBNull.Value)
            {
                qR.Id = Int32.Parse(obj.ToString());
            }

            obj = dRow["NAME"];
            if (obj != DBNull.Value)
            {
                qR.Name = obj.ToString();
            }

            obj = dRow["STORE_PROCEDURE"];
            if (obj != DBNull.Value)
            {
                qR.Store_procedure = obj.ToString();
            }

            obj = dRow["DESCRIPTION"];
            if (obj != DBNull.Value)
            {
                qR.Description = obj.ToString();
            }

            obj = dRow["CHART_TYPE"];
            if (obj != DBNull.Value)
            {
                qR.Char_Type = obj.ToString();
            }

            obj = dRow["RANGE_X"];
            if (obj != DBNull.Value)
            {
                qR.Range_X = obj.ToString();
            }

            obj = dRow["RANGE_Y"];
            if (obj != DBNull.Value)
            {
                qR.Range_Y = obj.ToString();
            }

            obj = dRow["P_NAME"];
            if (obj != DBNull.Value)
            {
                qR.Sheet_Name = obj.ToString();
            }

            obj = dRow["HAS_AXIS"];
            if (obj != DBNull.Value)
            {
                qR.HasAxis = obj.ToString().Equals("1");
            }

            obj = dRow["FILTERS"];
            if (obj != DBNull.Value)
            {
                qR.fillFilterFlags(Int32.Parse(obj.ToString()));
            }
        }

        #endregion

    }
}
