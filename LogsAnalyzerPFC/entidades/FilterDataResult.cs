using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogsAnalyzerPFC.entidades
{
    class FilterDataResult
    {
        #region "Atributos"

        private List<User> usersList;        
        private List<Command> commandsList;       
        private List<Category> categoriesList;

        #endregion

        #region "Propiedades"

        public List<User> UsersList
        {
            get { return usersList; }
            set { usersList = value; }
        }

        public List<Command> CommandsList
        {
            get { return commandsList; }
            set { commandsList = value; }
        }

        public List<Category> CategoriesList
        {
            get { return categoriesList; }
            set { categoriesList = value; }
        }

        #endregion

        #region "Constructores"

        public FilterDataResult()
        {
        }

        public FilterDataResult(List<User> usersList, List<Command> commandsList, List<Category> categoriesList)
        {
            this.usersList = usersList;
            this.commandsList = commandsList;
            this.categoriesList = categoriesList;
        }

        public FilterDataResult(FilterDataResult otherFilter)
        {
            this.usersList = new List<User>();
            this.commandsList = new List<Command>();
            this.categoriesList = new List<Category>();

            this.usersList.AddRange(otherFilter.UsersList);
            this.commandsList.AddRange(otherFilter.CommandsList);
            this.categoriesList.AddRange(otherFilter.CategoriesList);
        }

        public bool isEmpty()
        {
            return (this.UsersList == null || !this.UsersList.Any()) &&
                (this.CommandsList == null || !this.CommandsList.Any()) &&
                (this.CategoriesList == null || !this.CategoriesList.Any());
        }

        #endregion
    }
}