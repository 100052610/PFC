using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Oracle.DataAccess.Client;
using System.Collections.Generic;

namespace LogsAnalyzerPFC
{
    class CommandDatos : DatosBase
    {

        #region "Constantes"

        private const String SP_INSERT_COMMAND =
            "INSERT INTO COMMANDS (ID, NAME, CATEGORY_ID, NUM_PARAMS, DIFFICULTY, IMPACT, DESCRIPTION) VALUES (SEQ_COMMANDS.NEXTVAL, {0}, {1}, {2}, {3}, {4}, {5})";

        private const String SP_UPDATE_COMMAND =
            "UPDATE COMMANDS SET (NAME={0}, CATEGORY_ID={1}, NUM_PARAMS={2}, DIFFICULTY={3}, IMPACT={4}, DESCRIPTION={5}) WHERE NAME={6}";

        private const String SP_DELETE_COMMAND =
            "DELETE FROM COMMANDS WHERE NAME={0}";

        private const String SP_DELETE_ALL =
            "DELETE FROM COMMANDS";

        private const String SP_SELECT_ALL_COMMANDS =
            "SELECT * FROM COMMANDS";
        
        private const String SP_SELECT_COMMANDS_BY_ID =
            "SELECT * FROM COMMANDS WHERE ID={0}";

        private const String SP_SELECT_COMMANDS_BY_NAME =
            "SELECT * FROM COMMANDS WHERE NAME={0}";
        
        private const String SP_SELECT_COMMANDS_BY_CATEGORY =
            "SELECT * FROM COMMANDS WHERE CATEGORY_ID={0}";

        private const String SP_SELECT_COMMANDS_BY_NUM_PARAMS =
            "SELECT * FROM COMMANDS WHERE NUM_PARAMS={0}";

        private const String SP_SELECT_COMMANDS_BY_DIFICULTY =
            "SELECT * FROM COMMANDS WHERE DIFFICULTY={0}";

        private const String SP_SELECT_COMMANDS_BY_IMPACT =
            "SELECT * FROM COMMANDS WHERE IMPACT={0}";

        private const String SP_SELECT_COMMANDS_BY_DESCRIPTION =
            "SELECT * FROM COMMANDS WHERE DESCRIPTION={0}";

        private const String SP_COUNT_BASE_COMMANDS =
            "SELECT COUNT(C.ID) FROM COMMANDS C, CATEGORIES G WHERE C.CATEGORY_ID = G.ID AND G.NAME <> {0}";

        private const String SP_SELECT_ALL_COMMANDS_IN_COMMANDS_USED =
            " SELECT C.* " +
            " FROM   COMMANDS C, " +
            "      ( SELECT C.ID " +
            "        FROM COMMANDS_USED cU, COMMANDS C " +
            "        WHERE C.ID = cU.COMMAND_ID " +
            "        GROUP BY C.ID) T " +
            " WHERE C.ID = T.ID " +
            " ORDER BY C.NAME";

        #endregion

        #region "Constructores"

        public CommandDatos()
        { }

        #endregion

        #region "Métodos públicos"

        // Se usan desde fuera

        public Boolean InsertInicialCommands(List<Command> list)
        {
            Boolean result = false;
            int r;

            try
            {
                ArrayList parameters = new ArrayList();

                List<String> l1 = new List<String>();
                List<Int32> l2 = new List<Int32>();
                List<Int32> l3 = new List<Int32>();
                List<Int32> l4 = new List<Int32>();
                List<Int32> l5 = new List<Int32>();
                List<String> l6 = new List<String>();

                for (int i = 0; i < list.Count; i++)
                {
                    l1.Add(list[i].Name);
                    l2.Add(list[i].Cat.Id_category);
                    l3.Add(list[i].NumParams);
                    l4.Add(list[i].Difficulty);
                    l5.Add(list[i].Impact);
                    l6.Add(list[i].Description);
                }

                OracleParameter p1 = new OracleParameter();
                p1.OracleDbType = OracleDbType.Varchar2;
                p1.Value = l1.ToArray<String>();
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
                p4.OracleDbType = OracleDbType.Int32;
                p4.Value = l4.ToArray<Int32>();
                parameters.Add(p4);

                OracleParameter p5 = new OracleParameter();
                p5.OracleDbType = OracleDbType.Int32;
                p5.Value = l5.ToArray<Int32>();
                parameters.Add(p5);

                OracleParameter p6 = new OracleParameter();
                p6.OracleDbType = OracleDbType.Varchar2;
                p6.Value = l6.ToArray<String>();
                parameters.Add(p6);

                r = base.ModuloDatosInformes.ExecuteNonReader("PL_INSERT_COMMANDS_INICIAL", parameters, list.Count);

                result = (r == -1);
            }
            catch (Exception ex)
            {
                result = false;
                base.ModuloLog.Error(ex);
            }

            return result;
        }

        public Boolean InsertCommands(List<Command> commandsList)
        {
            Boolean result = false;
            int r;

            try
            {
                ArrayList parameters = new ArrayList();

                List<String> l1 = new List<String>();
                List<String> l2 = new List<String>();

                for (int i = 0; i < commandsList.Count; i++)
                {
                    l1.Add(commandsList[i].Name);
                    l2.Add(commandsList[i].Description);
                }

                OracleParameter p1 = new OracleParameter();
                p1.OracleDbType = OracleDbType.Varchar2;
                p1.Value = l1.ToArray<String>();
                parameters.Add(p1);

                OracleParameter p2 = new OracleParameter();
                p2.OracleDbType = OracleDbType.Varchar2;
                p2.Value = l2.ToArray<String>();
                parameters.Add(p2);

                r = base.ModuloDatosInformes.ExecuteNonReader("PL_INSERT_COMMANDS", parameters, commandsList.Count);

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

        public List<Command> GetAllCommands()
        {
            List<Command> listaComandos = new List<Command>();
            Command cmd = null;
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consultan todos los comandos almacenados.");

                base.Query = SP_SELECT_ALL_COMMANDS;
                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                // ExecuteDataSet -> Selects
                // ExecuteScalar  -> Devuelve un campo (ej: select count(*) from commands)
                // ExecuteNonReader -> Insert/Update/Delete: el valor que devuelve es el numero de filas que se han insertado/actualizado o borrado....

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cmd = new Command();
                        this.FillCommandData(dRow, cmd);
                        listaComandos.Add(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                listaComandos.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaComandos;
        }

        public int GetBaseCommandsNumber()
        {
            int number = 0;            
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta el numero de comandos cargados de la base de comandos (excel)");

                base.Query = SP_COUNT_BASE_COMMANDS;
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

        public List<Command> GetAllCommandsInCommandsUsed()
        {
            List<Command> listaComandos = new List<Command>();
            Command cmd = new Command();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta el listado de todos los comandos usados.");

                base.Query = SP_SELECT_ALL_COMMANDS_IN_COMMANDS_USED;
                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cmd = new Command();
                        this.FillCommandData(dRow, cmd);
                        listaComandos.Add(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                listaComandos.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaComandos;
        }

        // Se usan sólo aquí

        public List<Command> GetCommandsById(int id)
        {
            List<Command> listaComandos = new List<Command>();
            Command cmd = null;
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consultan los comandos con ID " + id);

                base.Query = SP_SELECT_COMMANDS_BY_ID;
                base.InsertParameter(0, id);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cmd = new Command();
                        this.FillCommandData(dRow, cmd);
                        listaComandos.Add(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                listaComandos.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaComandos;
        }

        public List<Command> GetCommandsByName(String name)
        {
            List<Command> listaComandos = new List<Command>();
            Command cmd = null;
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consultan los comandos con nombre " + name);

                base.Query = SP_SELECT_COMMANDS_BY_NAME;
                base.InsertParameter(0, name);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cmd = new Command();
                        this.FillCommandData(dRow, cmd);
                        listaComandos.Add(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                listaComandos.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaComandos;
        }

        // No se usan nunca

        public Boolean InsertCommand(Command cmd)
        {
            Boolean result = false;
            int r;

            try
            {
                base.Query = SP_INSERT_COMMAND;
                base.InsertParameter(0, cmd.Name);
                base.InsertParameter(1, cmd.Difficulty);
                base.InsertParameter(2, cmd.Impact);
                base.InsertParameter(3, cmd.Cat.Id_category);

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

        public Boolean UpdateCommand(Command cmd, String nameOriginal)
        {
            Boolean result = false;
            int r;

            try
            {
                base.Query = SP_UPDATE_COMMAND;
                base.InsertParameter(0, cmd.Name);
                base.InsertParameter(1, cmd.Difficulty);
                base.InsertParameter(2, cmd.Impact);
                base.InsertParameter(3, cmd.Cat.Id_category);
                base.InsertParameter(4, nameOriginal);

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

        public Boolean DeleteCommand(Command cmd)
        {
            Boolean result = false;
            int r;

            try
            {
                base.Query = SP_DELETE_COMMAND;
                base.InsertParameter(0, cmd.Name);

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

        public List<Command> GetCommandsByDifficulty(int difficulty)
        {
            List<Command> listaComandos = new List<Command>();
            Command cmd = null;
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consultan los comandos con dificultad " + difficulty);

                base.Query = SP_SELECT_COMMANDS_BY_DIFICULTY;
                base.InsertParameter(0, difficulty);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cmd = new Command();
                        this.FillCommandData(dRow, cmd);
                        listaComandos.Add(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                listaComandos.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaComandos;
        }

        public List<Command> GetCommandsByImpact(int impact)
        {
            List<Command> listaComandos = new List<Command>();
            Command cmd = null;
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consultan los comandos con impacto " + impact);

                base.Query = SP_SELECT_COMMANDS_BY_IMPACT;
                base.InsertParameter(0, impact);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cmd = new Command();
                        this.FillCommandData(dRow, cmd);
                        listaComandos.Add(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                listaComandos.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaComandos;
        }

        public List<Command> GetCommandsByCategory(int id_category)
        {
            List<Command> listaComandos = new List<Command>();
            Command cmd = null;
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consultan los comandos de la categoria " + id_category);

                base.Query = SP_SELECT_COMMANDS_BY_CATEGORY;
                base.InsertParameter(0, id_category);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cmd = new Command();
                        this.FillCommandData(dRow, cmd);
                        listaComandos.Add(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                listaComandos.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaComandos;
        }

        public Boolean FindCommandById(int id)
        {
            List<Command> listaComandos = new List<Command>();

            listaComandos = this.GetCommandsById(id);

            return (listaComandos.Count > 0);
        }

        public Boolean FindCommandByName(String name)
        {
            List<Command> listaComandos = new List<Command>();

            listaComandos = this.GetCommandsByName(name);

            return (listaComandos.Count > 0);
        }

        public int GetIdCommand(String name)
        {
            Command cmd = new Command();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta el ID del Comando con nombre " + name);

                base.Query = SP_SELECT_COMMANDS_BY_NAME;
                base.InsertParameter(0, name);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        cmd = new Command();
                        this.FillCommandData(dRow, cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                base.ModuloLog.Error(ex);
            }
            return cmd.Id_command;
        }

        #endregion

        #region "Métodos privados"

        private void FillCommandData(DataRow dRow, Command cmd)
        {
            object obj;

            obj = dRow["ID"];
            if (obj != DBNull.Value)
            {
                cmd.Id_command = Int32.Parse(obj.ToString());
            }

            obj = dRow["NAME"];
            if (obj != DBNull.Value)
            {
                cmd.Name = obj.ToString();
            }

            obj = dRow["CATEGORY_ID"];
            if (obj != DBNull.Value)
            {
                cmd.Cat.Id_category = Int32.Parse(obj.ToString());
            }

            obj = dRow["NUM_PARAMS"];
            if (obj != DBNull.Value)
            {
                cmd.NumParams = Int32.Parse(obj.ToString());
            }

            obj = dRow["DIFFICULTY"];
            if (obj != DBNull.Value)
            {
                cmd.Difficulty = Int32.Parse(obj.ToString());
            }

            obj = dRow["IMPACT"];
            if (obj != DBNull.Value)
            {
                cmd.Impact = Int32.Parse(obj.ToString());
            }

            obj = dRow["DESCRIPTION"];
            if (obj != DBNull.Value)
            {
                cmd.Description = obj.ToString();
            }
        }

        #endregion

    }
}