using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogsAnalyzerPFC.forms
{
    class FormReferences
    {
        #region "Atributos"

        /// <summary>
        /// Referencia estática al Form1.
        /// </summary>
        private static Form1 f1;

        /// <summary>
        /// Referencia estática al Form2.
        /// </summary>
        private static Form2 f2;

        /// <summary>
        /// Referencia estática al Form3.
        /// </summary>
        private static Form3 f3;

        #endregion

        #region "Propiedades"

        #endregion

        #region "Métodos públicos"       

        /// <summary>
        /// Devuelve o crea una instancia del Form1 (principal)
        /// </summary>
        /// <param name="currentForm">Formulario desde el que se solicita la referencia del Form1.</param>
        /// <param name="forceCreate">Si es true, siempre se creará una instancia nueva, si es false intentará devolver la existente.</param>
        /// <returns>Form1</returns>
        public static Form1 getF1Instance(Form currentForm, Boolean forceCreate)
        {
            return (FormReferences.f1 = (Form1)FormReferences.getGenericFormInstance(currentForm, typeof(Form1), FormReferences.f1, forceCreate));
        }

        /// <summary>
        /// Devuelve o crea una instancia del Form2 (selección de informes)
        /// </summary>
        /// <param name="currentForm">Formulario desde el que se solicita la referencia del Form2.</param>
        /// <param name="forceCreate">Si es true, siempre se creará una instancia nueva, si es false intentará devolver la existente.</param>
        /// <returns>Form2</returns>
        public static Form2 getF2Instance(Form currentForm, Boolean forceCreate)
        {
            return (FormReferences.f2 = (Form2)FormReferences.getGenericFormInstance(currentForm, typeof(Form2), FormReferences.f2, forceCreate));            
        }

        /// <summary>
        /// Devuelve o crea una instancia del Form3 (resultados)
        /// </summary>
        /// <param name="currentForm">Formulario desde el que se solicita la referencia del Form3.</param>
        /// <param name="forceCreate">Si es true, siempre se creará una instancia nueva, si es false intentará devolver la existente.</param>
        /// <returns>Form3</returns>
        public static Form3 getF3Instance(Form currentForm, Boolean forceCreate)
        {
            return (FormReferences.f3 = (Form3)FormReferences.getGenericFormInstance(currentForm, typeof(Form3), FormReferences.f3, forceCreate));
        }

        /// <summary>
        /// Devuelve o crea una instancia de un tipo de Formulario de la aplicación de forma genérica
        /// </summary>
        /// <param name="currentForm">Referencia del formulario origen de la llamada</param>
        /// <param name="newFormType">Tipo del formulario a crear</param>
        /// <param name="newForm">Referencia actual del formulario a crear (puede que ya exista)</param>
        /// <param name="forceCreate">Si es true, siempre se creará una instancia nueva, y si es false intentará devolver la instancia existente.</param>
        /// <returns></returns>
        private static Form getGenericFormInstance(Form currentForm, Type newFormType, Form newForm, Boolean forceCreate)
        {                    
            if (newForm == null || forceCreate)
            {
                // Hay que crear una instancia nueva
                if (newForm != null)
                {
                    // Si ya existía, lo cerramos antes de crear otro, liberando los recursos utilizados por el mismo.
                    newForm.Close();
                    newForm.Dispose();
                }
                // Creamos el nuevo formulario
                newForm = (Form)Activator.CreateInstance(newFormType);                
            }            
            
            // Mostramos el nuevo formulario
            newForm.Show();

            if (currentForm != null)
            {
                // Si nos llegó la referencia al formulario origen de la 'navegación', lo ocultamos (la referencia está guardada para recuperarla después)
                currentForm.Hide();
            }
            return newForm;
        }

        #endregion

    }
}
