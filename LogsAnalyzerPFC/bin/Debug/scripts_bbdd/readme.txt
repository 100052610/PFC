Para realizar la carga inicial de datos en Oracle 
bastará con ejecutar la siguiente sentencia en SQL*Plus:

@@{RUTA_CARPETA_SCRIPTS_BBDD}\make.sql

Este Script realizará automáticamente los siguientes pasos:
  1. Borrado de todos los objetos de la base de datos (datos, tablas, triggers, procedimientos).
  2. Creación de tablas, procedimientos, secuencias, triggers.
  3. Inserción de Informes predefinidos en la aplicación.
  
NOTA: Si se han creado informes nuevos, o se han realizado alguna modificación en los ya existentes para personalizarlos,
      es recomendable hacerse un nuevo backup de los datos almacenados en la tabla Query_Reports ya que, una vez se ejecute
      este script, esta tabla quedará en el estado inicial, sin las modificaciones que se hubieran realizado, manteniéndose, 
      eso sí, los procedimientos nuevos que se pudiesen haber creado en la base de datos.