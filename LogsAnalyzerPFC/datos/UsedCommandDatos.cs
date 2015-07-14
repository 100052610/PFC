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
    class UsedCommandDatos : DatosBase
    {
        #region "Constantes"

        private const String SP_INSERT_USED_COMMANDS =
            "INSERT INTO COMMANDS_USED (ID, COMMAND_ID, USER_ID, USE_DATE, ID_SNOOPY, NUM_PARAMS, PARAMS) VALUES (SEQ_COMMANDS_USED.NEXTVAL, {0}, {1}, TO_DATE({2},'dd/MM/yyyy HH24:mi:ss'), {3}, {4}, {5})";

        private const String SP_UPDATE_USED_COMMANDS =
            "UPDATE COMMANDS_USED SET (COMMAND_ID={0}, USER_ID={1}, USE_DATE={2}, ID_SNOOPY={3}, NUM_PARAMS={4}, PARAMS={5}) WHERE (COMMAND_ID={6} and USER_ID={7} and USE_DATE={8} and ID_SNOOPY={9} and NUM_PARAMS={10}) and PARAMS={11}";

        private const String SP_DELETE_USED_COMMANDS =
            "DELETE FROM COMMANDS_USED WHERE (COMMAND_ID={0} and USER_ID={1} and USE_DATE={2} and ID_SNOOPY={3} and NUM_PARAMS={4} and PARAMS={5})";

        private const String SP_DELETE_ALL =
            "DELETE FROM COMMANDS_USED";

        private const String SP_SELECT_ALL_USED_COMMANDS =
            "SELECT * FROM COMMANDS_USED";

        private const String SP_SELECT_USED_COMMANDS_BY_COMMAND =
            "SELECT * FROM COMMANDS_USED WHERE COMMAND_ID={0}";

        private const String SP_SELECT_USED_COMMANDS_BY_USER =
            "SELECT * FROM COMMANDS_USED WHERE USER_ID={0}";

        private const String SP_SELECT_USED_COMMANDS_BY_DATE =
            "SELECT * FROM COMMANDS_USED WHERE USE_DATE={0}";

        private const String SP_SELECT_USED_COMMANDS_BY_ID_SNOOPY =
            "SELECT * FROM COMMANDS_USED WHERE ID_SNOOPY={0}";

        private const String SP_SELECT_USED_COMMANDS_BY_NUMPARAMS =
            "SELECT * FROM COMMANDS_USED WHERE NUM_PARAMS={0}";

        private const String SP_SELECT_USED_COMMANDS_BY_PARAMS =
            "SELECT * FROM COMMANDS_USED WHERE PARAMS={0}";

        private const String SP_SELECT_ONE_COMMANDS_USED =
            "SELECT * FROM COMMANDS_USED WHERE COMMAND_ID={0} and USER_ID={1} and USE_DATE=TO_DATE({2},'dd/MM/yyyy HH24:mi:ss') and ID_SNOOPY={3} and NUM_PARAMS={4} and PARAMS={5}";

        private const String SP_SELECT_COUNT_ALL_USED_COMMANDS =
            "SELECT COUNT(*) FROM COMMANDS_USED";

        private const String SP_COUNT_USED_COMMANDS = 
            "SELECT COUNT(DISTINCT U.COMMAND_ID) FROM COMMANDS_USED U";

        private const String SP_COUNT_COMMON_COMMANDS = 
            "SELECT COUNT(DISTINCT U.COMMAND_ID) " +
            "FROM COMMANDS_USED U, COMMANDS C, CATEGORIES G " +
            "WHERE C.ID = U.COMMAND_ID AND U.COMMAND_ID = C.ID AND G.ID = C.CATEGORY_ID AND G.NAME <> {0}";

        private const String SP_SELECT_ALL_COMMANDS_USED_NAME =
            " SELECT C.NAME as CMD " +
            " FROM COMMANDS_USED cU, COMMANDS C " +
            " WHERE C.ID = cU.COMMAND_ID " +
            " GROUP BY C.NAME ";

        // Filtros previos a la generación de informes
        private const String SP_FILTER_COMMANDS_BY_USER = 
            "SELECT DISTINCT U.COMMAND_ID AS ID FROM COMMANDS_USED U WHERE U.USER_ID = {0}";

        private const String SP_FILTER_CATEGORIES_BY_USER = 
            "SELECT DISTINCT C.CATEGORY_ID AS ID FROM COMMANDS_USED U, COMMANDS C WHERE U.COMMAND_ID = C.ID AND U.USER_ID = {0}";

        private const String SP_FILTER_USERS_BY_COMMAND =
            "SELECT DISTINCT U.USER_ID AS ID FROM COMMANDS_USED U WHERE U.COMMAND_ID = {0}";

        private const String SP_FILTER_USERS_BY_CATEGORY =
            "SELECT DISTINCT U.USER_ID AS ID FROM COMMANDS_USED U, COMMANDS C WHERE U.COMMAND_ID = C.ID AND C.CATEGORY_ID = {0}";

        #endregion

        #region "Constructores"

        public UsedCommandDatos()
        { }

        #endregion

        #region "Métodos públicos"

        // Se usan desde fuera

        public Boolean InsertUsedCommands(List<UsedCommand> commandsList)
        {
            Boolean result = false;
            int r;

            try
            {
                ArrayList parameters = new ArrayList();

                List<Int32> l1 = new List<Int32>();
                List<Int32> l2 = new List<Int32>();
                List<Int32> l3 = new List<Int32>();
                List<DateTime> l4 = new List<DateTime>();
                List<Int32> l5 = new List<Int32>();
                List<String> l6 = new List<String>();

                for (int i = 0; i < commandsList.Count; i++)
                {
                    l1.Add(commandsList[i].Command_id);
                    l2.Add(commandsList[i].User_id);
                    l3.Add(commandsList[i].IdSnoopy);
                    l4.Add(commandsList[i].UsedDate);
                    l5.Add(commandsList[i].Num_params);
                    l6.Add(commandsList[i].Parameters);
                }

                OracleParameter p1 = new OracleParameter();
                p1.OracleDbType = OracleDbType.Int32;
                p1.Value = l1.ToArray<Int32>();
                parameters.Add(p1);

                OracleParameter p2 = new OracleParameter();
                p2.OracleDbType = OracleDbType.Int32;
                p2.Value = l2.ToArray<Int32>();
                parameters.Add(p2);

                OracleParameter p3 = new OracleParameter();
                p3.OracleDbType = OracleDbType.Int32;
                p3.Value = l3.ToArray<Int32>();
                parameters.Add(p3);

                OracleParameter p4 = new OracleParameter();
                p4.OracleDbType = OracleDbType.Date;
                p4.Value = l4.ToArray<DateTime>();
                parameters.Add(p4);

                OracleParameter p5 = new OracleParameter();
                p5.OracleDbType = OracleDbType.Int32;
                p5.Value = l5.ToArray<Int32>();
                parameters.Add(p5);

                OracleParameter p6 = new OracleParameter();
                p6.OracleDbType = OracleDbType.Varchar2;
                p6.Value = l6.ToArray<String>();
                parameters.Add(p6);

                r = base.ModuloDatosInformes.ExecuteNonReader("PL_INSERT_USED_COMMANDS", parameters, commandsList.Count);

                result = (r == -1);
            }
            catch (Exception ex)
            {
                result = false;
                base.ModuloLog.Error(ex);
            }

            return result;
        }

        public List<UsedCommand> GetAllUsedCommands()
        {
            List<UsedCommand> listaComandosUsados = new List<UsedCommand>();
            UsedCommand cmd = new UsedCommand();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consultan todos lo comandos usados almacenados.");

                base.Query = SP_SELECT_ALL_USED_COMMANDS;
                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cmd = new UsedCommand();
                        this.FillUsedCommandsData(dRow, cmd);
                        listaComandosUsados.Add(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                listaComandosUsados.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaComandosUsados;
        }

        public Boolean hayUsedCommands()
        {
            Boolean result = false;
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta el número comandos usados almacenados.");

                base.Query = SP_SELECT_COUNT_ALL_USED_COMMANDS;

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                result = (int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString())) > 0;

            }
            catch (Exception ex)
            {
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

        public int GetUsedCommandsNumber()
        {
            int number = 0;
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta el numero de comandos distintos usados en los ficheros de log importados");

                base.Query = SP_COUNT_USED_COMMANDS;
                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                number = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                number = 0;
                base.ModuloLog.Error(ex);
            }
            return number;
        }

        public int GetCommonCommandsNumber()
        {
            int number = 0;
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta el numero de comandos distintos usados en los ficheros de log importados, que ya existían en la base de comandos previa");

                base.Query = SP_COUNT_COMMON_COMMANDS;
                base.InsertParameter(0, Constantes.OTHERS_CATEGORY_NAME);
                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                number = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                number = 0;
                base.ModuloLog.Error(ex);
            }
            return number;
        }

        public List<int> GetDistinctCommandsUsedBy(User user)
        {
            return this.GenericFilterModelByField(SP_FILTER_COMMANDS_BY_USER, user.Id_user);
        }

        public List<int> GetDistinctCategoriesUsedBy(User user)
        {
            return this.GenericFilterModelByField(SP_FILTER_CATEGORIES_BY_USER, user.Id_user);
        }

        public List<int> GetDistinctUsersUsingCmd(Command command)
        {
            return this.GenericFilterModelByField(SP_FILTER_USERS_BY_COMMAND, command.Id_command);
        }

        public List<int> GetDistinctUsersUsingCat(Category category)
        {
            return this.GenericFilterModelByField(SP_FILTER_USERS_BY_CATEGORY, category.Id_category);
        }

        // No se usan nunca

        public Boolean InsertUsedCommand(UsedCommand cmd)
        {
            Boolean result = false;
            int r;

            try
            {
                base.Query = SP_INSERT_USED_COMMANDS;
                base.InsertParameter(0, cmd.Command_id);
                base.InsertParameter(1, cmd.User_id);
                base.InsertParameter(2, cmd.UsedDate.ToString("dd/MM/yyyy HH:mm:ss"));
                base.InsertParameter(3, cmd.IdSnoopy);
                base.InsertParameter(4, cmd.Num_params);
                base.InsertParameter(5, cmd.Parameters);

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

        public Boolean DeleteUsedCommand(UsedCommand cmd)
        {
            Boolean result = false;
            int r;

            try
            {
                base.Query = SP_DELETE_USED_COMMANDS;
                base.InsertParameter(0, cmd.Command_id);
                base.InsertParameter(1, cmd.User_id);
                base.InsertParameter(2, cmd.UsedDate);
                base.InsertParameter(3, cmd.IdSnoopy);
                base.InsertParameter(4, cmd.Num_params);
                base.InsertParameter(5, cmd.Parameters);

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

        public Boolean UpdateUsedCommand(UsedCommand cmd, int id_cmd_original, int id_user_original, DateTime original_date, int id_snoopy_original, int num_params, String parameters)
        {
            Boolean result = false;
            int r;

            try
            {
                base.Query = SP_UPDATE_USED_COMMANDS;
                base.InsertParameter(0, cmd.Command_id);
                base.InsertParameter(1, cmd.User_id);
                base.InsertParameter(2, cmd.UsedDate);
                base.InsertParameter(3, cmd.IdSnoopy);
                base.InsertParameter(4, cmd.Num_params);
                base.InsertParameter(5, cmd.Parameters);
                base.InsertParameter(6, id_cmd_original);
                base.InsertParameter(7, id_user_original);
                base.InsertParameter(8, original_date);
                base.InsertParameter(9, id_snoopy_original);
                base.InsertParameter(10, num_params);
                base.InsertParameter(11, parameters);

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

        public List<UsedCommand> GetUsedCommandsByCommandId(int id_command)
        {
            List<UsedCommand> listaComandosUsados = new List<UsedCommand>();
            UsedCommand cmd = new UsedCommand();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consultan las relaciones de comandos usados por identificador de comando: " + id_command);

                base.Query = SP_SELECT_USED_COMMANDS_BY_COMMAND;
                base.InsertParameter(0, id_command);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cmd = new UsedCommand();
                        this.FillUsedCommandsData(dRow, cmd);
                        listaComandosUsados.Add(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                listaComandosUsados.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaComandosUsados;
        }

        public List<UsedCommand> GetUsedCommandsByUserId(int id_user)
        {
            List<UsedCommand> listaComandosUsados = new List<UsedCommand>();
            UsedCommand cmd = new UsedCommand();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consultan las relaciones de comandos usados por id de usuario: " + id_user);

                base.Query = SP_SELECT_USED_COMMANDS_BY_USER;
                base.InsertParameter(0, id_user);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cmd = new UsedCommand();
                        this.FillUsedCommandsData(dRow, cmd);
                        listaComandosUsados.Add(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                listaComandosUsados.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaComandosUsados;
        }

        public List<UsedCommand> GetUsedCommandsByDate(DateTime date)
        {
            List<UsedCommand> listaComandosUsados = new List<UsedCommand>();
            UsedCommand cmd = new UsedCommand();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consultan las relaciones de comandos usados por fecha de uso: " + date.ToLongDateString());

                base.Query = SP_SELECT_USED_COMMANDS_BY_DATE;
                base.InsertParameter(0, date);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cmd = new UsedCommand();
                        this.FillUsedCommandsData(dRow, cmd);
                        listaComandosUsados.Add(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                listaComandosUsados.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaComandosUsados;
        }

        public List<UsedCommand> GetUsedCommandsByIdSnoopy(int id_snoopy)
        {
            List<UsedCommand> listaComandosUsados = new List<UsedCommand>();
            UsedCommand cmd = new UsedCommand();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta los comandos utilizados por ID_SNOOPY" + id_snoopy);

                base.Query = SP_SELECT_USED_COMMANDS_BY_ID_SNOOPY;
                base.InsertParameter(0, id_snoopy);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cmd = new UsedCommand();
                        this.FillUsedCommandsData(dRow, cmd);
                        listaComandosUsados.Add(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                listaComandosUsados.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaComandosUsados;
        }

        public Boolean GetOneUsedCommand(UsedCommand cmd_original)
        {
            Boolean find = false;
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta si el registro con: COMMAND_ID = " + cmd_original.Command_id +
                                                                    " USER_ID = " + cmd_original.User_id +
                                                                    " USE_DATE = " + cmd_original.UsedDate.ToString("dd/MM/yyyy HH:mm:ss") +
                                                                    " ID_SNOOPY = " + cmd_original.IdSnoopy +
                                                                    " NUM_PARAMS = " + cmd_original.Num_params +
                                                                    " PARAMS = " + cmd_original.Parameters +
                                     " existe ya en la tabla COMMANDS_USED, o no.");

                base.Query = SP_SELECT_ONE_COMMANDS_USED;
                base.InsertParameter(0, cmd_original.Command_id);
                base.InsertParameter(1, cmd_original.User_id);
                base.InsertParameter(2, cmd_original.UsedDate.ToString("dd/MM/yyyy HH:mm:ss"));
                base.InsertParameter(3, cmd_original.IdSnoopy);
                base.InsertParameter(4, cmd_original.Num_params);
                base.InsertParameter(5, cmd_original.Parameters);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        find = true;
                    }
                }
            }
            catch (Exception ex)
            {
                base.ModuloLog.Error(ex);
                find = false;
            }
            return find;
        }

        public List<String> GetAllCommandsUsedName()
        {
            List<String> result = new List<String>();
            String cmd = "";
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta el nombre de todos los comandos usados.");

                base.Query = SP_SELECT_ALL_COMMANDS_USED_NAME;
                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        object obj = dRow["CMD"];
                        if (obj != DBNull.Value)
                        {
                            cmd = obj.ToString();
                        }
                        result.Add(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                result.Clear();
                base.ModuloLog.Error(ex);
            }
            return result;
        }

        #endregion

        #region "Métodos privados"

        private void FillUsedCommandsData(DataRow dRow, UsedCommand cmd)
        {
            object obj;

            obj = dRow["ID"];
            if (obj != DBNull.Value)
            {
                cmd.Id_commandUsed = Int32.Parse(obj.ToString());
            }
            obj = dRow["COMMAND_ID"];
            if (obj != DBNull.Value)
            {
                cmd.Command_id = Int32.Parse(obj.ToString());
            }
            obj = dRow["USER_ID"];
            if (obj != DBNull.Value)
            {
                cmd.User_id = Int32.Parse(obj.ToString());
            }

            //Jan 20 06:35:03
            obj = dRow["USE_DATE"];
            if (obj != DBNull.Value)
            {
                cmd.UsedDate = DateTime.Parse(obj.ToString());
            }
            obj = dRow["ID_SNOOPY"];
            if (obj != DBNull.Value)
            {
                cmd.IdSnoopy = Int32.Parse(obj.ToString());
            }
            obj = dRow["NUM_PARAMS"];
            if (obj != DBNull.Value)
            {
                cmd.Num_params = Int32.Parse(obj.ToString());
            }

            obj = dRow["PARAMS"];
            if (obj != DBNull.Value)
            {
                cmd.Parameters = obj.ToString();
            }
        }

        private List<int> GenericFilterModelByField(String procedure, int filteringParam)
        {

            List<int> lista = new List<int>();
            DataSet ds = null;

            try
            {
                base.Query = procedure;
                base.InsertParameter(0, filteringParam);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        lista.Add(Int32.Parse(dRow["ID"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                lista.Clear();
                base.ModuloLog.Error(ex);
            }
            return lista;
        }


        #endregion        
    }
}
