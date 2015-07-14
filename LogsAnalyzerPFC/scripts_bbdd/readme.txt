Para realizar la carga inicial de datos en Oracle 
bastar� con ejecutar la siguiente sentencia en SQL*Plus:

@@{RUTA_CARPETA_SCRIPTS_BBDD}\make.sql

Este Script realizar� autom�ticamente los siguientes pasos:
  1. Borrado de todos los objetos de la base de datos (datos, tablas, triggers, procedimientos).
  2. Creaci�n de tablas, procedimientos, secuencias, triggers.
  3. Inserci�n de Informes predefinidos en la aplicaci�n.
  
NOTA: Si se han creado informes nuevos, o se han realizado alguna modificaci�n en los ya existentes para personalizarlos,
      es recomendable hacerse un nuevo backup de los datos almacenados en la tabla Query_Reports ya que, una vez se ejecute
      este script, esta tabla quedar� en el estado inicial, sin las modificaciones que se hubieran realizado, manteni�ndose, 
      eso s�, los procedimientos nuevos que se pudiesen haber creado en la base de datos.