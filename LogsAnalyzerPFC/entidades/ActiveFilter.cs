using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogsAnalyzerPFC.entidades
{
    class ActiveFilter : IEquatable<ActiveFilter>
    {
        #region "Atributos"

        private User user;        
        private Command command;        
        private Category category;

        #endregion

        #region "Propiedades"

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public Command Command
        {
            get { return command; }
            set { command = value; }
        }

        public Category Category
        {
            get { return category; }
            set { category = value; }
        }

        #endregion

        #region "Constructores"

        public ActiveFilter() { }

        public ActiveFilter(User userParam, Command commandParam, Category categoryParam)
        {
            this.User = userParam;
            this.Command = commandParam;
            this.Category = categoryParam;
        }

        public ActiveFilter(ActiveFilter otherFilter)
            : this(otherFilter.User, otherFilter.Command, otherFilter.Category)
        { }

        #endregion

        #region "Métodos públicos"

        public override string ToString()
        {
            return this.User + "|" + this.Command + "|" + this.Category;
        }

        #endregion

        #region IEquatable<ActiveFilter> Members

        public bool Equals(ActiveFilter other)
        {
            return ((this.User != null && other.User != null && this.User.Equals(other.User)) || 
                        (this.User == null && other.User == null)) &&
                   ((this.Command != null && other.Command != null && this.Command.Equals(other.Command)) || 
                        (this.Command == null && other.Command == null)) &&
                   ((this.Category != null && other.Category != null && this.Category.Equals(other.Category)) || 
                        (this.Category == null && other.Category == null));
        }

        #endregion
    }
}