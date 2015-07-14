using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;
using LogsAnalyzerPFC.datos;
using System.Collections.Generic;
using LogsAnalyzerPFC.entidades;
using Arquitectura.Log;

namespace LogsAnalyzerPFC.process
{
    class ChargeData
    {

        #region "Atributos"

        private ModuloLog modLog = ModuloLog.GetInstance(Constantes.MODULO_LOG);
        private List<UsedCommand> usedCommandsList;
        private static ChargeData instance;

        #endregion

        #region "Constructores"

        private ChargeData()
        {
            this.usedCommandsList = new List<UsedCommand>();
        }

        #endregion
        
        #region "Métodos Públicos"

        /// <summary>
        /// Método para implementar el Singleton que controlará los accesos a la clase actual
        /// </summary>
        /// <param name="usedCommand"></param>         

        public static ChargeData getInstance()
        {
            if (instance == null)
            {
                // Singleton
                instance = new ChargeData();
            }
            return instance;
        }

        /// <summary>
        /// Método para almacenar en la base de datos el uso de comandos registrado en el fichero de logs 
        /// </summary>
        /// <param name="usedCommand"></param>
        
        public Boolean chargeCategories(List<Category> catList)
        {
            Boolean result = false;
            CategoryDatos catDatos = new CategoryDatos();

            try
            {
                result = catDatos.InsertCategories(catList);                
            }
            catch (Exception ex)
            {
                result = false;
                this.modLog.Error(ex);
            }

            return result;
        }

        /// <summary>
        /// Método para almacenar en la base de datos el uso de comandos registrado en el fichero de logs 
        /// </summary>
        /// <param name="usedCommand"></param>

        public Boolean chargeInitialCommands(List<Command> cmdList, BackgroundWorker w)
        {
            int j = 0;
            Boolean end = false;
            Boolean result = true;
            int wTimer = 85;
            CommandDatos cmdDatos = new CommandDatos();
            List<Command> listCommandsAux = new List<Command>();

            try
            {
                do
                {
                    wTimer++;
                    w.ReportProgress(wTimer);
                    
                    for(int i = 1; i<Constantes.maxInitialCommands && !end; i++)
                    {
                        if (j < cmdList.Count)
                        {
                            listCommandsAux.Add(cmdList[j]);
                            j++;
                        }
                        else
                        {
                            end = true;
                        }
                    }
                    if (!end)
                    {
                        result = result && cmdDatos.InsertInicialCommands(listCommandsAux);
                        listCommandsAux.Clear();
                    }

                }while(!end && result);

                result = result && cmdDatos.InsertInicialCommands(listCommandsAux);

            }
            catch (Exception ex)
            {
                this.modLog.Error(ex);
            }

            return result;
        }

        /// <summary>
        /// Método para almacenar en la base de datos el uso de comandos registrado en el fichero de logs 
        /// </summary>
        /// <param name="usedCommand"></param>
        
        public Boolean chargeUsedCommand(UsedCommand usedCommand)
        {
            Boolean result = false;

            //Añadimos el registro de comando usado a la lista, junto con su userId y el nombre del comando
            usedCommandsList.Add(usedCommand);

            //Como vamos a hacer carga masiva, vamos rellenando la lista hasta completarla
            if (usedCommandsList.Count >= Constantes.maxCommandsUsed)
            {               
                // Cargamos los comandos utilizados en la base de datos
                result = new UsedCommandDatos().InsertUsedCommands(this.usedCommandsList);
                usedCommandsList.Clear();                
            }
            else
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Método para almacenar los últimos registros de comandos utilizados en la base de datos
        /// </summary>

        public Boolean chargeLastUsedCommands()
        {
            UsedCommandDatos usedCommandDatos = new UsedCommandDatos();
            Boolean result = false;

            try
            {
                // Cargamos el comando utilizado en la base de datos
                result = usedCommandDatos.InsertUsedCommands(this.usedCommandsList);
                usedCommandsList.Clear();
            }
            catch (Exception ex)
            {
                result = false;
                this.modLog.Error(ex);
            }

            return result;
        }

        /// <summary>
        /// Método para almacenar todos los usuarios que han introducido comandos en la base de datos
        /// </summary>
        /// <param name="usersList"></param>
        
        public Boolean chargeUsers(List<User> usersList)
        {
            Boolean result = false;
            UserDatos usr = new UserDatos();

            //Cargamos los usuarios del fichero de logs en la base de datos
            result = usr.InsertUsers(usersList);

            this.modLog.Info("Hemos insertado " + usersList.Count + " usuarios en la base de datos");

            return result;
        }

        /// <summary>
        /// Método para almacenar todos los comandos nuevos que aparecen en el fichero de logs
        /// </summary>
        /// <param name="commandsList"></param>

        public Boolean chargeCommands(List<Command> commandsList)
        {
            Boolean result = false;
            CommandDatos cmd = new CommandDatos();

            //Cargamos los comandos nuevos del fichero de logs en la base de datos
            result = cmd.InsertCommands(commandsList);

            this.modLog.Info("Hemos insertado " + commandsList.Count + " comandos en la base de datos");

            return result;
        }

        /// <summary>
        /// Método para obtener todos los comandos almacenados en la base de Datos
        /// </summary>

        public List<Command> getAllCommands()
        {
            List<Command> allCommands = new List<Command>();
            CommandDatos cmdData = new CommandDatos();

            allCommands = cmdData.GetAllCommands();

            return allCommands;
        }

        /// <summary>
        /// Método para obtener todos los usuarios almacenados en la base de Datos
        /// </summary>

        public List<User> getAllUsers()
        {
            List<User> allUsers = new List<User>();
            UserDatos usrData = new UserDatos();

            allUsers = usrData.GetAllUsers();

            return allUsers;
        }

        /// <summary>
        /// Método para obtener todas las categorías almacenados en la base de Datos
        /// </summary>

        public List<Category> getAllCategories()
        {
            List<Category> allCategories = new List<Category>();
            CategoryDatos catData = new CategoryDatos();

            allCategories = catData.GetAllCategories();

            return allCategories;
        }

        /// <summary>
        /// Método para comprobar si categorías almacenadas en la base de Datos
        /// </summary>
        
        public Boolean hayCategories()
        {
            CategoryDatos catData = new CategoryDatos();

            return catData.hayCategories();
        }

        /// <summary>
        /// Método para comprobar si categorías almacenadas en la base de Datos
        /// </summary>

        public Boolean hayCommandsUsed()
        {
            UsedCommandDatos uCmd = new UsedCommandDatos();

            return uCmd.hayUsedCommands();
        }        

        /// <summary>
        /// Método para borrar todos los datos de todas las tablas de la base de Datos
        /// </summary>

        public Boolean restartDataBase(BackgroundWorker worker)
        {
            Boolean result = true;
            Sequences sec = new Sequences();
            CommandDatos cmd = new CommandDatos();
            CategoryDatos cat = new CategoryDatos();
            
            try
            {
                worker.ReportProgress(4);
                result = result && cmd.DeleteAll();
                
                worker.ReportProgress(6);
                result = result && cat.DeleteAll();
                
                worker.ReportProgress(10);
                result = result && sec.restartBothSequences();                
            }
            catch (Exception ex)
            {
                result = false;
                this.modLog.Error(ex);
            }

            return result;
        }

        /// <summary>
        /// Método para borrar todos los datos de las tablas usuarios y comandos usados antes de cargar un nuevo fichero de logs a analizar de la base de Datos
        /// </summary>
         
        public Boolean clearDataBase(BackgroundWorker worker)
        {
            Boolean result = true;
            Sequences sec = new Sequences();
            UserDatos usr = new UserDatos();
            UsedCommandDatos used = new UsedCommandDatos();

            try
            {
                worker.ReportProgress(2);
                result = result && usr.DeleteAll();
                
                worker.ReportProgress(4);
                result = result && used.DeleteAll();
                
                worker.ReportProgress(6);
                result = result && sec.restartSequences();                
            }
            catch (Exception ex)
            {
                result = false;
                this.modLog.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// Método para dejar las tablas de la base de Datos totalmente limpias
        /// </summary>
         
        public Boolean clearAllDataBase(BackgroundWorker worker)
        {
            Boolean result = false;
            UserDatos usr = new UserDatos();
            CommandDatos cmd = new CommandDatos();
            CategoryDatos cat = new CategoryDatos();
            UsedCommandDatos used = new UsedCommandDatos();

            result = true;

            try
            {
                worker.ReportProgress(20, Constantes.getMessage("ReportProgress_BU"));
                result = result && usr.DeleteAll();
                
                worker.ReportProgress(40, Constantes.getMessage("ReportProgress_BCI"));
                result = result && cmd.DeleteAll();
                
                worker.ReportProgress(60, Constantes.getMessage("ReportProgress_BC"));
                result = result && cat.DeleteAll();
                
                worker.ReportProgress(80, Constantes.getMessage("ReportProgress_BL"));
                result = result && used.DeleteAll();                
            }
            catch (Exception ex)
            {
                result = false;
                this.modLog.Error(ex);
            }
            return result;
        }

        public Statistics getDbStatistics()
        {
            Statistics stat = new Statistics();

            if (stat.Connection = this.checkConnection())
            {
                if ((stat.BaseCommands = this.getBaseCommandsNumber()) > 0)
                {
                    stat.UsedCommands = this.getUsedCommandsNumber();
                    stat.CommonCommands = this.getCommonCommandsNumber();
                }
            }
            return stat;
        }

        #endregion

        #region "Métodos privados"

        /// <summary>
        /// Método para comprobar si existe conexión actualmente con la BBDD o si la conexión se ha interrumpido
        /// </summary>
        
        private bool checkConnection()
        {            
            return new DatosBase().checkConnection();
        }

        private int getBaseCommandsNumber()
        {
            return new CommandDatos().GetBaseCommandsNumber();
        }

        private int getUsedCommandsNumber()
        {
            return new UsedCommandDatos().GetUsedCommandsNumber();
        }

        private int getCommonCommandsNumber()
        {
            return new UsedCommandDatos().GetCommonCommandsNumber();
        }

        #endregion

    }
}
