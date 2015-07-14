using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using LogsAnalyzerPFC.entidades;
using System.Threading;

namespace LogsAnalyzerPFC.datos
{
    class UserDatos : DatosBase
    {

        #region "Constantes"

        private const String SP_INSERT_USER =
            "INSERT INTO USERS (ID, NAME, U_ID, S_ID) VALUES (SEQ_USERS.NEXTVAL, {0}, {1}, {2})";

        private const String SP_UPDATE_USER =
            "UPDATE USERS SET (NAME={0}, U_ID={1}, S_ID={2}) WHERE (NAME={3} and U_ID={4} and S_ID={5})";

        private const String SP_DELETE_USER =
            "DELETE FROM USERS WHERE (NAME={0} and U_ID={1} and S_ID={2})";

        private const String SP_DELETE_ALL =
            "DELETE FROM USERS";

        private const String SP_SELECT_ALL_USERS =
            "SELECT * FROM USERS U ORDER BY U.NAME";

        private const String SP_SELECT_USERS_BY_ID =
            "SELECT * FROM USERS WHERE ID={0}"; 

        private const String SP_SELECT_USERS_BY_NAME =
            "SELECT * FROM USERS WHERE NAME={0}";

        private const String SP_SELECT_USERS_BY_U_ID =
            "SELECT * FROM USERS WHERE U_ID={0}";

        private const String SP_SELECT_USERS_BY_S_ID =
            "SELECT * FROM USERS WHERE S_ID={0}";

        private const String SP_SELECT_ONE_USER =
            "SELECT * FROM USERS WHERE (NAME={0} and U_ID={1} and S_ID={2})";

        #endregion

        #region "Constructores"

        public UserDatos()
        { }

        #endregion

        #region "Métodos públicos"

        // Se usan desde fuera

        public Boolean InsertUser(User usr)
        {
            Boolean result = false;
            int r;

            try
            {
                base.Query = SP_INSERT_USER;
                base.InsertParameter(0, usr.Name);
                base.InsertParameter(1, usr.U_id);
                base.InsertParameter(2, usr.S_id);

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

        public Boolean InsertUsers(List<User> list)
        {
            Boolean result = false;
            int r;

            try
            {
                ArrayList parameters = new ArrayList();

                List<String> l1 = new List<String>();
                List<Int32> l2 = new List<Int32>();
                List<Int32> l3 = new List<Int32>();

                for (int i = 0; i < list.Count; i++)
                {
                    l1.Add(list[i].Name);
                    l2.Add(list[i].U_id);
                    l3.Add(list[i].S_id);
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

                r = base.ModuloDatosInformes.ExecuteNonReader("PL_INSERT_USERS", parameters, list.Count);

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

        public List<User> GetAllUsers()
        {
            List<User> listaUsuarios = new List<User>();
            User usr = new User();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consultan todos lo usuarios almacenados.");

                base.Query = SP_SELECT_ALL_USERS;
                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                // ExecuteDataSet -> Selects
                // ExecuteScalar  -> Devuelve un campo (ej: select count(*) from commands)
                // ExecuteNonReader -> Insert/Update/Delete: el valor que devuelve es el numero de filas que se han insertado/actualizado o borrado....

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        usr = new User();
                        this.FillUserData(dRow, usr);
                        listaUsuarios.Add(usr);
                    }
                }                
            }
            catch (Exception ex)
            {
                listaUsuarios.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaUsuarios;
        }

        public List<User> GetOneUser(String name, int uid, int sid)
        {
            List<User> listaUsuarios = new List<User>();
            User usr = new User();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta una relación concreta NOMBRE: " + name + " U_ID: " + uid + " S_ID: " + sid);

                base.Query = SP_SELECT_ONE_USER;
                base.InsertParameter(0, name);
                base.InsertParameter(1, uid);
                base.InsertParameter(2, sid);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        usr = new User();
                        this.FillUserData(dRow, usr);
                        listaUsuarios.Add(usr);
                    }
                }
            }
            catch (Exception ex)
            {
                listaUsuarios.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaUsuarios;
        }

        public int GetIdUser(String name, int u_id, int s_id)
        {
            User usr = new User();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta el ID de un usuario concreto con NOMBRE: " + name + " U_ID: " + u_id + " y S_ID: " + s_id);

                base.Query = SP_SELECT_ONE_USER;
                base.InsertParameter(0, name);
                base.InsertParameter(1, u_id);
                base.InsertParameter(2, s_id);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        usr = new User();
                        this.FillUserData(dRow, usr);
                    }
                }
            }
            catch (Exception ex)
            {
                base.ModuloLog.Error(ex);
            }
            return usr.Id_user;
        }

        // No se usan nunca

        public Boolean DeleteUser(User usr)
        {
            Boolean result = false;
            int r;

            try
            {
                base.Query = SP_DELETE_USER;
                base.InsertParameter(0, usr.Name);
                base.InsertParameter(1, usr.U_id);
                base.InsertParameter(2, usr.S_id);

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

        public Boolean UpdateUser(User usr, String nameOriginal, int u_idOriginal, int s_idOriginal)
        {
            Boolean result = false;
            int r;

            try
            {
                base.Query = SP_UPDATE_USER;
                base.InsertParameter(0, usr.Name);
                base.InsertParameter(1, usr.U_id);
                base.InsertParameter(2, usr.S_id);
                base.InsertParameter(3, nameOriginal);
                base.InsertParameter(4, u_idOriginal);
                base.InsertParameter(5, s_idOriginal);

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

        public List<User> GetUsersById(int id_original)
        {
            List<User> listaUsuarios = new List<User>();
            User usr = new User();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consultan las relaciones de Usuarios con ID: " + id_original);

                base.Query = SP_SELECT_USERS_BY_ID;
                base.InsertParameter(0, id_original);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        usr = new User();
                        this.FillUserData(dRow, usr);
                        listaUsuarios.Add(usr);
                    }
                }
            }
            catch (Exception ex)
            {
                listaUsuarios.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaUsuarios;
        }
        
        public List<User> GetUsersByName(String name)
        {
            List<User> listaUsuarios = new List<User>();
            User usr = new User();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consultan las relaciones de Usuarios por nombre: " + name);

                base.Query = SP_SELECT_USERS_BY_NAME;
                base.InsertParameter(0, name);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        usr = new User();
                        this.FillUserData(dRow, usr);
                        listaUsuarios.Add(usr);
                    }
                }
            }
            catch (Exception ex)
            {
                listaUsuarios.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaUsuarios;
        }

        public List<User> GetUsersByUID(int uid)
        {
            List<User> listaUsuarios = new List<User>();
            User usr = new User();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta el usuario con UID " + uid);

                base.Query = SP_SELECT_USERS_BY_U_ID;
                base.InsertParameter(0, uid);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        usr = new User();
                        this.FillUserData(dRow, usr);
                        listaUsuarios.Add(usr);
                    }
                }
            }
            catch (Exception ex)
            {
                listaUsuarios.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaUsuarios;
        }

        public List<User> GetUsersBySID(int sid)
        {
            List<User> listaUsuarios = new List<User>();
            User usr = new User();
            DataSet ds = null;

            try
            {
                base.ModuloLog.Debug("Se consulta el usuario con S_ID " + sid);

                base.Query = SP_SELECT_USERS_BY_S_ID;
                base.InsertParameter(0, sid);

                ds = base.ModuloDatos.ExecuteDataSet(base.Query);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        usr = new User();
                        this.FillUserData(dRow, usr);
                        listaUsuarios.Add(usr);
                    }
                }
            }
            catch (Exception ex)
            {
                listaUsuarios.Clear();
                base.ModuloLog.Error(ex);
            }
            return listaUsuarios;
        }

        public Boolean FindUser(String name, int uid, int sid)
        {
            List<User> listaUsuarios = new List<User>();

            listaUsuarios = this.GetOneUser(name, uid, sid);
            
            return (listaUsuarios.Count>0);
        }

        #endregion

        #region "Métodos privados"

        private void FillUserData(DataRow dRow, User usr)
        {
            object obj;

            obj = dRow["ID"];
            if (obj != DBNull.Value)
            {
                usr.Id_user = Int32.Parse(obj.ToString());
            }
            obj = dRow["NAME"];
            if (obj != DBNull.Value)
            {
                usr.Name = obj.ToString();
            }
            obj = dRow["U_ID"];
            if (obj != DBNull.Value)
            {
                usr.U_id = Int32.Parse(obj.ToString());
            }
            obj = dRow["S_ID"];
            if (obj != DBNull.Value)
            {
                usr.S_id = Int32.Parse(obj.ToString());
            }
        }

        #endregion

    }
}
