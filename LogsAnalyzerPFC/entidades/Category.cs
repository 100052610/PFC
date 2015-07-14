using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogsAnalyzerPFC.entidades
{
    public class Category : IEquatable<Category>
    {

        #region "Atributos"

        private int id_category;
        private string name;

        #endregion

        #region "Propiedades"

        public int Id_category
        {
            get { return id_category; }
            set { id_category = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion

        #region "Constructores"

        public Category() 
        {
            this.Id_category = 0;
            this.Name = "";
        }

        // No se usa nunca

        public Category(String name)
        {
            this.Name = name;
        }

        #endregion

        #region IEquatable<Category> Members

        public bool Equals(Category other)
        {
            return (other.Id_category.Equals(this.Id_category));
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
