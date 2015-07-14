using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using LogsAnalyzerPFC.entidades;

namespace LogsAnalyzerPFC
{
    public class Command : IEquatable<Command>
    {
        #region "Atributos"

        private int id_command;
        private String name;
        private Category cat;
        private int numParams;
        private int difficulty;        
        private int impact;
        private String description;

        #endregion

        #region "Propiedades"

        public int Id_command
        {
            get { return id_command; }
            set { id_command = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Category Cat
        {
            get { return cat; }
            set { cat = value; }
        }

        public int NumParams
        {
            get { return numParams; }
            set { numParams = value; }
        }

        public int Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }

        public int Impact
        {
            get { return impact; }
            set { impact = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        #endregion

        #region "Constructores"

        public Command() 
        {
            this.id_command = 0;
            this.name = "";
            this.cat = new Category();
            this.numParams = 0;
            this.difficulty = 0;
            this.impact = 0;
            this.description = "Unknown";
        }

        #endregion
         
        #region IEquatable<Command> Members

        public bool Equals(Command other)
        {
            return (other.Name.Equals(this.Name));
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