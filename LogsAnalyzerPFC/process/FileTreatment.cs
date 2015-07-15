using System;
using System.Linq;
using System.Text;
using Arquitectura.Log;
using System.ComponentModel;
using System.Collections.Generic;
using LogsAnalyzerPFC.process;
using LogsAnalyzerPFC.entidades;
using System.IO;
using LogsAnalyzerPFC.process.exceptions;

namespace LogsAnalyzerPFC
{
    class FileTreatment
    {

        #region "Atributos"

        private string fichIn;
        private ChargeData newData;
        private List<User> userList;
        private List<Command> commandList;
        private ModuloLog modLog = ModuloLog.GetInstance(Constantes.MODULO_LOG);

        int numLineas = 0;
        int comandos = 0;
        int logs = 0;

        #endregion

        #region "Constructores"

        public FileTreatment(string f1)
        {
            this.fichIn = f1;
            this.newData = ChargeData.getInstance();
            this.userList = new List<User>();
            this.commandList = new List<Command>();
        }

        #endregion

        #region "Métodos públicos"

        /// <summary>
        /// Método para tratar el fichero de logs que hay que analizar
        /// </summary>

        public void treatFile(BackgroundWorker worker)
        {
            int lines = 0;
            int actual = 0;
            int progress = 0;
            double total = 0.0;
            
            lines = this.firstReadFile();
            modLog.Info("En total se usan " + comandos + " comandos distintos en el fichero de logs");

            if (lines <= 0)
            {
                throw new AppProcessException("FileTreatmentErrorReadingFile1pass");
            }

            total = lines + this.userList.Count + this.commandList.Count;
            actual = 10;

            worker.ReportProgress(20, Constantes.getMessage("ReportProgress_CUyC"));

            // Cargamos los usuarios en la Base de Datos en la tabla USERS
            if (!this.newData.chargeUsers(this.userList))
            {
                throw new AppProcessException("FileTreatmentErrorLoadingUsers");
            }
            
            actual += this.userList.Count;
            progress = (int)((actual / total) * 100);
            
            worker.ReportProgress(progress);

            // Cargamos los nuevos comandos utilizados en la Base de Datos en la tabla COMMANDS
            if (!this.newData.chargeCommands(this.commandList))
            {
                throw new AppProcessException("FileTreatmentErrorLoadingNewCommands");
            }

            actual += this.commandList.Count;
            progress = (int)((actual / total) * 100);

            worker.ReportProgress(progress, Constantes.getMessage("ReportProgress_CL"));

            this.numLineas = 0;

            // Cargamos de nuevo los usuarios y comandos, para tener sus identificadores.
            this.userList = newData.getAllUsers();
            if (this.userList.Count == 0)
            {
                throw new AppProcessException("FileTreatmentErrorRetrievingAllUsers");
            }

            this.commandList = newData.getAllCommands();
            if (this.commandList.Count == 0)
            {
                throw new AppProcessException("FileTreatmentErrorRetrievingAllCommands");
            }

            lines = this.secondReadFile(worker, actual, total);
            if (lines <= 0)
            {
                throw new AppProcessException("FileTreatmentErrorReadingFile2pass");
            }

            if (!this.newData.chargeLastUsedCommands())
            {
                throw new AppProcessException("FileTreatmentErrorSavingPendingCommands");
            }

            modLog.Info("Hemos insertado " + logs + " comandos usados en la base de datos");
            modLog.Info("Fichero Analizado");
        }

        #endregion

        #region "Métodos privados"

        /// <summary>
        /// Método que hace la primera lectura del fichero cogiendo los Usuarios y Commandos de los registros log
        /// </summary>

        private int firstReadFile()
        {
            bool end = false;
            bool ok = true;
            string line;
            int i = 0;
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(fichIn);

                do
                {
                    line = sr.ReadLine();

                    if (sr.EndOfStream)
                    {
                        end = true;
                    }

                    ok = firstTreatFile(line);

                    i++;

                } while (!end && ok);

                if (!end)
                {
                    throw new Exception("Se finalizó la lectura del fichero antes de tiempo por un error al cargar/grabar en BBDD");
                }
            }
            catch (Exception ex)
            {
                i = -1;
                modLog.Error("Abortado el procesamiento del fichero (primera pasada) por encontrar un error en la línea " + i);
                modLog.Error(ex);                
            }
            finally
            {
                try
                {
                    if (sr != null)
                    {
                        sr.Close();
                    }
                }
                catch (Exception) { }
            }               

            return i;
        }

        /// <summary>
        /// Método que hace la segunda lectura del fichero - registros del Uso de Comandos
        /// </summary>

        private int secondReadFile(BackgroundWorker worker, int actual, double total)
        {
            bool end = false;
            bool ok = true;
            int progress = 0;
            string line = "";
            int i = 0;
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(fichIn);

                do
                {
                    line = sr.ReadLine();

                    if (sr.EndOfStream)
                    {
                        end = true;
                    }

                    ok = secondTreatFile(line);
                    i++;
                    
                    // Report current progress
                    actual++;
                    progress = (int)((actual / total) * 100);
                    worker.ReportProgress(progress);

                } while (!end && ok);

                if (!end)
                {
                    throw new Exception("Se finalizó la lectura del fichero antes de tiempo por un error al cargar/grabar en BBDD");
                }
            }
            catch (Exception ex)
            {
                i = -1;
                modLog.Error("Abortado el procesamiento del fichero (segunda pasada) por encontrar un error en la línea " + i);
                modLog.Error(ex);
            }
            finally
            {
                try
                {
                    if (sr != null)
                    {
                        sr.Close();
                    }
                }
                catch (Exception) { }
            }

            return i;
        }

        /// <summary>
        /// Método encargado de realizar el tratamiento de los usuarios y comandos
        /// </summary>
        /// <param name="line"></param>
        
        private Boolean firstTreatFile(string line)
        {
            numLineas++;
            Boolean result = false;
            int numChar = 0;
            User user = new User();
            Command command = new Command();

            // Cada línea del fichero contiene cuatro grupos de datos: FECHA / ID_SNOOPY / USUARIO / COMANDO
            // Jan 20 06:35:03 horus snoopy[16936]: [unknown, uid:65534 sid:16933]: sed s/\t +

            line = line.Trim();

            // En este método sólo los encargaremos de tratar el grupo de datos del usuario y el comando
            // Para ello, nos quedamos sólo con los datos que hay después del segundo corchete de la línea

            numChar = line.IndexOf(']');
            line = line.Substring(numChar + 4);

            // USUARIO                                                      // unknown, uid:65534 sid:16933]

            // Guardamos el NAME del usuario                         
            numChar = line.IndexOf(",");
            user.Name = line.Substring(0, numChar);

            // Saltamos directamente al uid
            numChar = line.IndexOf(':') + 1;
            line = line.Substring(numChar);

            // Guardamos el UID del usuario
            numChar = line.IndexOf(' ');
            user.U_id = Int32.Parse(line.Substring(0, numChar));

            // Saltamos directamente al sid
            numChar = line.IndexOf(':') + 1;
            line = line.Substring(numChar);

            // Guardamos el SID del usuario
            numChar = line.IndexOf(']');
            user.S_id = Int32.Parse(line.Substring(0, numChar));

            // Si aún no está en la lista de usuarios, guardamos el usuario en la lista para después almacenarlos todos juntos en la base de datos
            if (!userList.Contains(user))
            {
                this.userList.Add(user);
            }

            // Saltamos directamente al último grupo de datos
            // COMANDOS                                                     // sed s/\t +

            numChar = line.IndexOf(':');
            line = line.Substring(numChar + 1 + 1);

            // Cogemos el nombre del comando
            numChar = line.IndexOf(' ');

            if (numChar == -1)
            {
                command.Name = this.verifyName(line);
            }
            else
            {
                command.Name = this.verifyName(line.Substring(0, numChar));
            }

            // Si aún no está en la lista de comandos nuevos, guardamos el comando en la lista para después almacenarlos todos juntos en la base de datos
            if (!command.Name.Equals("") && !commandList.Contains(command))
            {
                comandos++;
                this.commandList.Add(command);                
            }
            else
            {
                if (command.Name.Equals(""))
                {
                    modLog.Warning("Se ha descartado el comando utilizado en la línea " + numLineas + " del fichero de logs, por no ser un comando correcto.");                    
                }                
            }

            result = true;

            return result;
        }

        /// <summary>
        /// Método encargado de verificar si el nombre del comando es correcto
        /// </summary>
        /// <param name="line"></param>
        /// 
        private string verifyName(string name)
        {
            int numChar = 0;
            int firstPos = 0;
            String nameAux = name;

            if (nameAux[0].Equals('/'))
            {
                firstPos = nameAux.LastIndexOf('/');
                if (nameAux.Length == firstPos+1)
                {
                    nameAux = "";
                }
                else
                {
                    nameAux = nameAux.Substring(firstPos + 1);
                    numChar = nameAux.IndexOf(' ');

                    if (numChar != -1)
                    {
                        nameAux = nameAux.Substring(firstPos + 1, numChar);
                    }
                }
            }

            return nameAux;
        }

        /// <summary>
        /// Método encargado de realizar el tratamiento de los registros de los logs almacenados
        /// </summary>
        /// <param name="line"></param>
        
        private Boolean secondTreatFile(string line)
        {
            numLineas++;
            Boolean result = false;
            int numChar = 0;
            int userId = 0;
            int numParam = 0;
            String commandName = "";
            User usr = new User();
            Command cmd = new Command();
            UsedCommand cmd_used = new UsedCommand();

            // Cada línea del fichero contiene cuatro grupos de datos: FECHA / ID_SNOOPY / USUARIO / COMANDO
            // Jan 20 06:35:03 horus snoopy[16936]: [unknown, uid:65534 sid:16933]: sed s/\t +

            line = line.Trim();

            // En este método nos encargaremos de capturar toda la información del registro LOG almacenado
            // Fecha, ID_Snoopy, ID_Usuario, ID_Comando, Parámetros

            // FECHA                                                        // Jan 20 06:25:08 horus
            // Cogemos la fecha
            cmd_used.UsedDate = DateTime.ParseExact(line.Substring(0, 15), "MMM dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            // Saltamos directamente hasta el siguiente grupo de datos:
            line = line.Substring(29);

            // ID_SNOOPY                                                    // snoopy[16936]
            // Cogemos el Id_Snoopy
            numChar = line.IndexOf(']');
            cmd_used.IdSnoopy = Int32.Parse(line.Substring(0, numChar));

            // Saltamos directamente hasta el siguiente grupo de datos:

            line = line.Substring(numChar + 4);

            // USUARIO                                                      // [unknown, uid:65534 sid:16933]

            // Saltamos directamente al uid
            numChar = line.IndexOf(':') + 1;
            line = line.Substring(numChar);

            // Cogemos el UID del usuario y lo buscamos en la lista para coger el Identificador que tiene en nuestra base de datos
            numChar = line.IndexOf(' ');
            userId = Int32.Parse(line.Substring(0, numChar));

            usr = this.userList.Find(user => user.U_id == userId);
            cmd_used.User_id = usr.Id_user;

            // Saltamos directamente al último grupo de datos
            numChar = line.IndexOf(']');
            line = line.Substring(numChar + 1 + 1 +1);

            // COMANDOS                                                     // sed s/\t +

            // Cogemos el nombre del comando
            numChar = line.IndexOf(' ');

            if (numChar == -1)
            {
                commandName = this.verifyName(line);
            }
            else
            {
                commandName = this.verifyName(line.Substring(0, numChar));

                // Cogemos los parámetros
                line = line.Substring(numChar + 1);

                if (line.Length <= Constantes.maxParams)
                {
                    cmd_used.Parameters = line;
                }
                else
                {
                    cmd_used.Parameters = line.Substring(0, Constantes.maxParams);
                }

                while (line != null && line !="")
                {
                    numChar = line.IndexOf(' ');
                    if (numChar == -1)
                    {
                        numParam++;
                        line = null;
                    }
                    else
                    {
                        numParam++;
                        line = line.Substring(numChar + 1);
                    }
                }
                cmd_used.Num_params = numParam;
            }

            // Buscamos el comando en la lista para coger el Identificador que tiene en nuestra base de datos
            cmd = this.commandList.Find(command => (command.Name == commandName));

            if (cmd != null)
            {
                cmd_used.Command_id = cmd.Id_command;

                // Insertamos el registro del comando utilizado en la base de datos
                logs++;
                result = this.newData.chargeUsedCommand(cmd_used);
            }
            else
            {
                modLog.Warning("Se ha descartado el registro log almacenado en la línea " + numLineas + " del fichero de logs por NO encontrarse el comando que utiliza.");
                result = true;
            }

            return result;
        }

        #endregion
    
    }
}
