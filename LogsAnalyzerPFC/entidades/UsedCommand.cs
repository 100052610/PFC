using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogsAnalyzerPFC.entidades
{
    class UsedCommand
    {

        #region "Atributos"

        private int id_commandUsed;
        private int command_id;
        private int user_id;
        private DateTime usedDate;
        private int idSnoopy;
        private int num_params;
        private String parameters = null;

        #endregion

        #region "Propiedades"

        public int Id_commandUsed
        {
            get { return id_commandUsed; }
            set { id_commandUsed = value; }
        }

        public int Command_id
        {
            get { return command_id; }
            set { command_id = value; }
        }

        public int User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public DateTime UsedDate
        {
            get { return usedDate; }
            set { usedDate = value; }
        }

        public int IdSnoopy
        {
            get { return idSnoopy; }
            set { idSnoopy = value; }
        }

        public int Num_params
        {
            get { return num_params; }
            set { num_params = value; }
        }

        public string Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        #endregion

        #region "Constructores"

        public UsedCommand() { }

        // No se usa nunca

        public UsedCommand(int command, int user, DateTime date, int id_snoopy, int num_params, string parameters)
        {
            this.Command_id = command;
            this.User_id = user;
            this.UsedDate = date;
            this.IdSnoopy = id_snoopy;
            this.Num_params = num_params;
            this.Parameters = parameters;
        }

        #endregion

    }
}
