using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogsAnalyzerPFC.entidades
{
    public class User : IEquatable<User>
    {

        #region "Atributos"

        private int id_user;
        private string name;
        private int u_id;
        private int s_id;

        #endregion

        #region "Propiedades"

        public int Id_user
        {
            get { return id_user; }
            set { id_user = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public int U_id
        {
          get { return u_id; }
          set { u_id = value; }
        }

        public int S_id
        {
          get { return s_id; }
          set { s_id = value; }
        }
        
        #endregion

        #region "Constructores"

        public User() { }

        #endregion

        #region "Métodos Públicos"

        public bool Equals(User other)
        {
            return(other.U_id == this.U_id);
        }

        #endregion

        #region "Métodos públicos"

        public override String ToString()
        {
            return this.Name;
        }

        #endregion
    }
}
