using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogsAnalyzerPFC.entidades
{
    public class QueryReport
    {

        #region "Atributos"

        private int id;
        private string name;
        private string store_procedure;
        private string description;
        private string char_type;
        private string range_x;
        private string range_y;
        private string sheet_name;
        private bool hasAxis;        
        private bool hasUserFilter;
        private bool hasCommandFilter;
        private bool hasCategoryFilter;

        private bool selected;
        private User queryFilterByUser;
        private Command queryFilterByCommand;
        private Category queryFilterByCategory;

        #endregion

        #region "Propiedades"

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        } 
       
        public string Store_procedure
        {
            get { return store_procedure; }
            set { store_procedure = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Char_Type
        {
            get { return char_type; }
            set { char_type = value; }
        }

        public string Range_X
        {
            get { return range_x; }
            set { range_x = value; }
        }

        public string Range_Y
        {
            get { return range_y; }
            set { range_y = value; }
        }

        public string Sheet_Name
        {
            get { return sheet_name; }
            set { sheet_name = value; }
        }

        public bool HasAxis
        {
            get { return hasAxis; }
            set { hasAxis = value; }
        }

        public bool HasUserFilter
        {
            get { return hasUserFilter; }
            set { hasUserFilter = value; }
        }

        public bool HasCommandFilter
        {
            get { return hasCommandFilter; }
            set { hasCommandFilter = value; }
        }

        public bool HasCategoryFilter
        {
            get { return hasCategoryFilter; }
            set { hasCategoryFilter = value; }
        }

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        public User QueryFilterByUser
        {
          get { return queryFilterByUser; }
          set { queryFilterByUser = value; }
        }

        public Command QueryFilterByCommand
        {
          get { return queryFilterByCommand; }
          set { queryFilterByCommand = value; }
        }

        public Category QueryFilterByCategory
        {
          get { return queryFilterByCategory; }
          set { queryFilterByCategory = value; }
        }

        #endregion

        #region "Constructores"

        public QueryReport() 
        { }

        public QueryReport(QueryReport qr)
        {
            this.Id = qr.Id;
            this.Name = qr.Name;
            this.Store_procedure = qr.Store_procedure;
            this.Description = qr.Description;
            this.Char_Type = qr.Char_Type;
            this.Range_X = qr.Range_X;
            this.Range_Y = qr.Range_Y;
            this.Sheet_Name = qr.Sheet_Name;
            this.HasAxis = qr.HasAxis;
            this.HasUserFilter = qr.HasUserFilter;
            this.HasCommandFilter = qr.HasCommandFilter;
            this.HasCategoryFilter = qr.HasCategoryFilter;
            this.QueryFilterByUser = qr.QueryFilterByUser;
            this.QueryFilterByCommand = qr.QueryFilterByCommand;
            this.QueryFilterByCategory = qr.QueryFilterByCategory;
            this.Selected = true;
        }

        #endregion

        #region "Metodos publicos"

        public void fillFilterFlags(int filterType)
        {
            char[] flags = Convert.ToString(filterType, 2).PadLeft(3, '0').ToCharArray();
            this.HasUserFilter = flags[0] == '1';
            this.HasCommandFilter = flags[1] == '1';
            this.HasCategoryFilter = flags[2] == '1';
        }

        public Boolean isGeneralReport()
        {
            return !this.HasUserFilter && !this.hasCommandFilter && !this.hasCategoryFilter;
        }

        #endregion

    }
}
