prompt ===========================================
prompt =          LOADING DATABASE OBJECTS       =
prompt ===========================================

set feedback off
set define off

prompt
prompt Creating table CATEGORIES
prompt =========================
prompt
create table ROOT.CATEGORIES
(
  ID   NUMBER(4) not null,
  NAME VARCHAR2(100) not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on column ROOT.CATEGORIES.ID
  is 'Identificador de la Categoría';
comment on column ROOT.CATEGORIES.NAME
  is 'Nombres de todas las categorías a tener en cuenta';
alter table ROOT.CATEGORIES
  add constraint PK_CATEGORIES primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table CHART_TYPES
prompt ==========================
prompt
create table ROOT.CHART_TYPES
(
  ID          NUMBER(2) not null,
  NAME        VARCHAR2(30) not null,
  DESCRIPTION VARCHAR2(50) not null,
  HAS_AXIS    NUMBER(1) default 0 not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on column ROOT.CHART_TYPES.ID
  is 'Identificador del tipo de gráfica';
comment on column ROOT.CHART_TYPES.NAME
  is 'Nombre del tipo de gráfica';
comment on column ROOT.CHART_TYPES.DESCRIPTION
  is 'Descripción del tipo de gráfica';
comment on column ROOT.CHART_TYPES.HAS_AXIS
  is 'Indica si el tipo de gráfico admite ejes (X,Y) y sus correspondientes textos descriptivos';
alter table ROOT.CHART_TYPES
  add constraint PK_CHART_TYPES primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table ROOT.CHART_TYPES
  add constraint UK_CHART_TYPES_NAME unique (NAME)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table COMMANDS
prompt =======================
prompt
create table ROOT.COMMANDS
(
  ID          NUMBER(8) not null,
  NAME        VARCHAR2(100) not null,
  DIFFICULTY  NUMBER(4) not null,
  IMPACT      NUMBER(8) not null,
  CATEGORY_ID NUMBER(4) not null,
  NUM_PARAMS  NUMBER(4) not null,
  DESCRIPTION VARCHAR2(300) not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on column ROOT.COMMANDS.ID
  is 'Identificador del Comando';
comment on column ROOT.COMMANDS.NAME
  is 'Nombre del comando de linux';
comment on column ROOT.COMMANDS.DIFFICULTY
  is 'Grado de dificultad de uso del comando';
comment on column ROOT.COMMANDS.IMPACT
  is 'Impacto que puede llegar a tener su uso';
comment on column ROOT.COMMANDS.CATEGORY_ID
  is 'Identificador de la categoría a la que pertenece';
comment on column ROOT.COMMANDS.NUM_PARAMS
  is 'Número de parámetros que acepta el comando';
comment on column ROOT.COMMANDS.DESCRIPTION
  is 'Breve descripción de la funcionalidad del comando ';
alter table ROOT.COMMANDS
  add constraint PK_COMMANDS primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table ROOT.COMMANDS
  add constraint FK_CMD_CAT foreign key (CATEGORY_ID)
  references ROOT.CATEGORIES (ID) on delete cascade;

prompt
prompt Creating table USERS
prompt ====================
prompt
create table ROOT.USERS
(
  ID   NUMBER(8) not null,
  NAME VARCHAR2(100) not null,
  U_ID NUMBER(8) not null,
  S_ID NUMBER(8) not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on column ROOT.USERS.ID
  is 'Identificador del Usuario';
comment on column ROOT.USERS.NAME
  is 'Nombre del Usuario';
comment on column ROOT.USERS.U_ID
  is 'Identificador del usuario dentro del fichero';
comment on column ROOT.USERS.S_ID
  is 'Identificador de la aplicación utilizada por el usuario';
alter table ROOT.USERS
  add constraint PK_USERS primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table ROOT.USERS
  add constraint UN_USERS unique (U_ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table COMMANDS_USED
prompt ============================
prompt
create table ROOT.COMMANDS_USED
(
  ID         NUMBER(12) not null,
  COMMAND_ID NUMBER(8) not null,
  USER_ID    NUMBER(8) not null,
  ID_SNOOPY  NUMBER(8) not null,
  USE_DATE   DATE not null,
  NUM_PARAMS NUMBER(4) not null,
  PARAMS     VARCHAR2(500)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on column ROOT.COMMANDS_USED.ID
  is 'Identificador del registro de Comando Utilizado';
comment on column ROOT.COMMANDS_USED.COMMAND_ID
  is 'Identificador del Comando en la tabla COMMANDS';
comment on column ROOT.COMMANDS_USED.USER_ID
  is 'Identificador del usuario en la tabla USERS';
comment on column ROOT.COMMANDS_USED.ID_SNOOPY
  is 'Identificador de la línea del Snoopy';
comment on column ROOT.COMMANDS_USED.USE_DATE
  is 'Fecha completa en la que se ha registrado el uso del comando';
comment on column ROOT.COMMANDS_USED.NUM_PARAMS
  is 'Número de parámetros que acompañan al comando';
comment on column ROOT.COMMANDS_USED.PARAMS
  is 'Cadena con los parámetros utilizados junto al comando principal. En caso de tener más que los marcados, se acortará la cadena al tamaño máximo aceptado.';
alter table ROOT.COMMANDS_USED
  add constraint PK_COMMANDS_USED primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table ROOT.COMMANDS_USED
  add constraint FK_CMD_USED_CMD foreign key (COMMAND_ID)
  references ROOT.COMMANDS (ID) on delete cascade;
alter table ROOT.COMMANDS_USED
  add constraint FK_CMD_USED_USR foreign key (USER_ID)
  references ROOT.USERS (ID) on delete cascade;

prompt
prompt Creating table REPORT_TEMPLATES
prompt ===============================
prompt
create table ROOT.REPORT_TEMPLATES
(
  ID      NUMBER(2) not null,
  NAME    VARCHAR2(15) not null,
  COLUMNS NUMBER(1) not null,
  SERIES  NUMBER(1) not null,
  RANGE_X VARCHAR2(2) not null,
  RANGE_Y VARCHAR2(2) not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on column ROOT.REPORT_TEMPLATES.ID
  is 'Identificador de la plantilla';
comment on column ROOT.REPORT_TEMPLATES.NAME
  is 'Nombre de la plantilla (nombre de la pestaña excel)';
comment on column ROOT.REPORT_TEMPLATES.COLUMNS
  is 'Número de columnas utlizadas';
comment on column ROOT.REPORT_TEMPLATES.SERIES
  is 'Número de series de datos que se utilizarán';
comment on column ROOT.REPORT_TEMPLATES.RANGE_X
  is 'Celda de inicio para las series de datos';
comment on column ROOT.REPORT_TEMPLATES.RANGE_Y
  is 'Columna de fin para las series de datos';
alter table ROOT.REPORT_TEMPLATES
  add constraint PK_REPORT_TEMPLATES primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table ROOT.REPORT_TEMPLATES
  add constraint UK_REPORT_TEMPLATES_NAME unique (NAME)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table QUERY_REPORTS
prompt ============================
prompt
create table ROOT.QUERY_REPORTS
(
  ID              NUMBER(4) not null,
  NAME            VARCHAR2(10) not null,
  STORE_PROCEDURE VARCHAR2(100) not null,
  DESCRIPTION     VARCHAR2(300) not null,
  CHART_TYPE      NUMBER(2) not null,
  TEMPLATE        NUMBER(2) not null,
  FILTERS         NUMBER(1) default 0 not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on column ROOT.QUERY_REPORTS.ID
  is 'Identificador de la QueryReport';
comment on column ROOT.QUERY_REPORTS.NAME
  is 'Clave para identificar el informe en la aplicación';
comment on column ROOT.QUERY_REPORTS.STORE_PROCEDURE
  is 'Nombre del Procedimiento almacenado que contiene la QueryReport';
comment on column ROOT.QUERY_REPORTS.DESCRIPTION
  is 'Clave para la descripción del informe en la excel/pdf';
comment on column ROOT.QUERY_REPORTS.CHART_TYPE
  is 'Indica el tipo de gráfico que se utilizará para generar este informe';
comment on column ROOT.QUERY_REPORTS.TEMPLATE
  is 'Indica la plantilla utilizada por el informe actual';
comment on column ROOT.QUERY_REPORTS.FILTERS
  is 'Indica el tipo de filtrado que admite el informe';
alter table ROOT.QUERY_REPORTS
  add constraint PK_QUERY_REPORTS primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table ROOT.QUERY_REPORTS
  add constraint UNIQUE_KEY_NAME unique (NAME)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table ROOT.QUERY_REPORTS
  add constraint FK_QUERY_REPORTS_CHART foreign key (CHART_TYPE)
  references ROOT.CHART_TYPES (ID);
alter table ROOT.QUERY_REPORTS
  add constraint FK_QUERY_REPORTS_TEMPLATE foreign key (TEMPLATE)
  references ROOT.REPORT_TEMPLATES (ID);

prompt
prompt Creating sequence SEQ_CATEGORIES
prompt ================================
prompt
create sequence ROOT.SEQ_CATEGORIES
minvalue 0
maxvalue 9999
start with 10
increment by 1
cache 20;

prompt
prompt Creating sequence SEQ_COMMANDS
prompt ==============================
prompt
create sequence ROOT.SEQ_COMMANDS
minvalue 0
maxvalue 9999
start with 2210
increment by 1
cache 20;

prompt
prompt Creating sequence SEQ_COMMANDS_USED
prompt ===================================
prompt
create sequence ROOT.SEQ_COMMANDS_USED
minvalue 0
maxvalue 999999999999999
start with 289872
increment by 1
cache 20;

prompt
prompt Creating sequence SEQ_USERS
prompt ===========================
prompt
create sequence ROOT.SEQ_USERS
minvalue 0
maxvalue 99999999
start with 33
increment by 1
cache 20;

prompt
prompt Creating procedure PL_INSERT_CATEGORIES
prompt =======================================
prompt
create or replace procedure root.PL_INSERT_CATEGORIES
(
  P_NAME       IN CATEGORIES.NAME%TYPE
)

is

 v_counter NUMBER;

begin

  select count(*) into v_counter
  from CATEGORIES C
  where c.name = P_NAME;

  if v_counter=0 then

  INSERT INTO CATEGORIES (ID, NAME)
  VALUES (SEQ_CATEGORIES.NEXTVAL, P_NAME);

  COMMIT;

  end if;

end PL_INSERT_CATEGORIES;
/

prompt
prompt Creating procedure PL_INSERT_COMMANDS
prompt =====================================
prompt
create or replace procedure root.PL_INSERT_COMMANDS
(
  P_NAME        IN COMMANDS.NAME%TYPE,
  P_DESCRIPTION IN COMMANDS.DESCRIPTION%TYPE
)

is

 v_counter    NUMBER;
 v_id         NUMBER;
 v_category   NUMBER;
 v1_seq_value NUMBER;
 v2_seq_value NUMBER;

begin

  select count(*) into v_counter
  from COMMANDS C
  where c.name = P_NAME;

  if v_counter=0 then

    select count(*) into v_category
    from CATEGORIES T
    where UPPER(T.NAME) = 'OTHERS';

    if v_category=0 then

      SELECT SEQ_CATEGORIES.NEXTVAL INTO v1_seq_value FROM dual;

      INSERT INTO CATEGORIES (ID, NAME) VALUES (v1_seq_value, 'Others');
      COMMIT;

    end if;

    select T.ID into v_id
    from CATEGORIES T
    where UPPER(T.NAME) = 'OTHERS';

    SELECT SEQ_COMMANDS.NEXTVAL INTO v2_seq_value FROM dual;

    INSERT INTO COMMANDS (ID, NAME, CATEGORY_ID, NUM_PARAMS, DIFFICULTY, IMPACT, DESCRIPTION)
    VALUES (v2_seq_value, P_NAME, v_id, 0, 0, 0, P_DESCRIPTION);

    COMMIT;

  end if;

end PL_INSERT_COMMANDS;
/

prompt
prompt Creating procedure PL_INSERT_COMMANDS_INICIAL
prompt =============================================
prompt
create or replace procedure root.PL_INSERT_COMMANDS_INICIAL
(
  P_NAME        IN COMMANDS.NAME%TYPE,
  P_ID_CATEGORY IN COMMANDS.CATEGORY_ID%TYPE,
  P_NUM_PARAMS  IN COMMANDS.NUM_PARAMS%TYPE,
  P_DIFFICULTY  IN COMMANDS.DIFFICULTY%TYPE,
  P_IMPACT      IN COMMANDS.IMPACT%TYPE,
  P_DESCRIPTION IN COMMANDS.DESCRIPTION%TYPE
)

is

 v_counter NUMBER;

begin

  select count(*) into v_counter
  from COMMANDS C
  where c.name = P_NAME;

  if v_counter=0 then

  INSERT INTO COMMANDS (ID, NAME, CATEGORY_ID, NUM_PARAMS, DIFFICULTY, IMPACT, DESCRIPTION)
  VALUES (SEQ_COMMANDS.NEXTVAL, P_NAME, P_ID_CATEGORY, P_NUM_PARAMS, P_DIFFICULTY, P_IMPACT, P_DESCRIPTION);

  COMMIT;

  end if;

end PL_INSERT_COMMANDS_INICIAL;
/

prompt
prompt Creating procedure PL_INSERT_USED_COMMANDS
prompt ==========================================
prompt
create or replace procedure root.PL_INSERT_USED_COMMANDS
(
  P_COMMAND_ID IN COMMANDS_USED.COMMAND_ID%TYPE,
  P_USER_ID    IN COMMANDS_USED.USER_ID%TYPE,
  P_ID_SNOOPY  IN COMMANDS_USED.ID_SNOOPY%TYPE,
  P_USE_DATE   IN COMMANDS_USED.USE_DATE%TYPE,
  P_NUM_PARAMS IN COMMANDS_USED.NUM_PARAMS%TYPE,
  P_PARAMS     IN COMMANDS_USED.PARAMS%TYPE
)

is

begin
       INSERT INTO COMMANDS_USED (ID, COMMAND_ID, USER_ID, ID_SNOOPY, USE_DATE, NUM_PARAMS, PARAMS)
       VALUES (SEQ_COMMANDS_USED.NEXTVAL, P_COMMAND_ID, P_USER_ID, P_ID_SNOOPY, P_USE_DATE, P_NUM_PARAMS, P_PARAMS);

end PL_INSERT_USED_COMMANDS;
/

prompt
prompt Creating procedure PL_INSERT_USERS
prompt ==================================
prompt
create or replace procedure root.PL_INSERT_USERS
(
  P_NAME  IN USERS.NAME%TYPE,
  P_U_ID  IN USERS.U_ID%TYPE,
  P_S_ID  IN USERS.S_ID%TYPE
)

is

 v_counter NUMBER;

begin

  select count(*) into v_counter
  from USERS U
  where U.U_ID = P_U_ID;

  if v_counter=0 then

  INSERT INTO USERS (ID, NAME, U_ID, S_ID)
  VALUES (SEQ_USERS.NEXTVAL, P_NAME, P_U_ID, P_S_ID);

  COMMIT;

  end if;

end PL_INSERT_USERS;
/

prompt
prompt Creating procedure PL_RESTART_ALL_SEQUENCES
prompt ===========================================
prompt
create or replace procedure root.PL_RESTART_ALL_SEQUENCES

is

  p1_seq_name VARCHAR2(100) := 'SEQ_CATEGORIES';
  p2_seq_name VARCHAR2(100) := 'SEQ_COMMANDS';
  p3_seq_name VARCHAR2(100) := 'SEQ_COMMANDS_USED';
  p4_seq_name VARCHAR2(100) := 'SEQ_USERS';
  l_val number;

begin

  execute immediate
  'select ' || p1_seq_name || '.nextval from dual' INTO l_val;
  execute immediate
  'alter sequence ' || p1_seq_name || ' increment by -' || l_val || ' minvalue 0';
  execute immediate
  'select ' || p1_seq_name || '.nextval from dual' INTO l_val;
  execute immediate
  'alter sequence ' || p1_seq_name || ' increment by 1 minvalue 0';

  execute immediate
  'select ' || p2_seq_name || '.nextval from dual' INTO l_val;
  execute immediate
  'alter sequence ' || p2_seq_name || ' increment by -' || l_val || ' minvalue 0';
  execute immediate
  'select ' || p2_seq_name || '.nextval from dual' INTO l_val;
  execute immediate
  'alter sequence ' || p2_seq_name || ' increment by 1 minvalue 0';

  execute immediate
  'select ' || p3_seq_name || '.nextval from dual' INTO l_val;
  execute immediate
  'alter sequence ' || p3_seq_name || ' increment by -' || l_val || ' minvalue 0';
  execute immediate
  'select ' || p3_seq_name || '.nextval from dual' INTO l_val;
  execute immediate
  'alter sequence ' || p3_seq_name || ' increment by 1 minvalue 0';

  execute immediate
  'select ' || p4_seq_name || '.nextval from dual' INTO l_val;
  execute immediate
  'alter sequence ' || p4_seq_name || ' increment by -' || l_val || ' minvalue 0';
  execute immediate
  'select ' || p4_seq_name || '.nextval from dual' INTO l_val;
  execute immediate
  'alter sequence ' || p4_seq_name || ' increment by 1 minvalue 0';

end PL_RESTART_ALL_SEQUENCES;
/

prompt
prompt Creating procedure PL_RESTART_BOTH_SEQUENCES
prompt ============================================
prompt
create or replace procedure root.PL_RESTART_BOTH_SEQUENCES

is

  p1_seq_name VARCHAR2(100) := 'SEQ_COMMANDS';
  p2_seq_name VARCHAR2(100) := 'SEQ_CATEGORIES';
  l_val_1 number;
  l_val_2 number;

begin

  execute immediate
  'select ' || p1_seq_name || '.nextval from dual' INTO l_val_1;
  execute immediate
  'alter sequence ' || p1_seq_name || ' increment by -' || l_val_1 || ' minvalue 0';
  execute immediate
  'select ' || p1_seq_name || '.nextval from dual' INTO l_val_1;
  execute immediate
  'alter sequence ' || p1_seq_name || ' increment by 1 minvalue 0';

  execute immediate
  'select ' || p2_seq_name || '.nextval from dual' INTO l_val_2;
  execute immediate
  'alter sequence ' || p2_seq_name || ' increment by -' || l_val_2 || ' minvalue 0';
  execute immediate
  'select ' || p2_seq_name || '.nextval from dual' INTO l_val_2;
  execute immediate
  'alter sequence ' || p2_seq_name || ' increment by 1 minvalue 0';

end PL_RESTART_BOTH_SEQUENCES;
/

prompt
prompt Creating procedure PL_RESTART_SEQUENCES
prompt =======================================
prompt
create or replace procedure root.PL_RESTART_SEQUENCES

is

  p1_seq_name VARCHAR2(100) := 'SEQ_COMMANDS_USED';
  p2_seq_name VARCHAR2(100) := 'SEQ_USERS';
  l_val_1 number;
  l_val_2 number;

begin

  execute immediate
  'select ' || p1_seq_name || '.nextval from dual' INTO l_val_1;
  execute immediate
  'alter sequence ' || p1_seq_name || ' increment by -' || l_val_1 || ' minvalue 0';
  execute immediate
  'select ' || p1_seq_name || '.nextval from dual' INTO l_val_1;
  execute immediate
  'alter sequence ' || p1_seq_name || ' increment by 1 minvalue 0';

  execute immediate
  'select ' || p2_seq_name || '.nextval from dual' INTO l_val_2;
  execute immediate
  'alter sequence ' || p2_seq_name || ' increment by -' || l_val_2 || ' minvalue 0';
  execute immediate
  'select ' || p2_seq_name || '.nextval from dual' INTO l_val_2;
  execute immediate
  'alter sequence ' || p2_seq_name || ' increment by 1 minvalue 0';

end PL_RESTART_SEQUENCES;
/

prompt
prompt Creating procedure Q_COMMANDS_BY_CATEGORY
prompt =========================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_COMMANDS_BY_CATEGORY

(P_REF OUT SYS_REFCURSOR)

IS

BEGIN

OPEN P_REF

FOR

  SELECT T.NAME AS CAT, COUNT(C.NAME) AS NUM_CMD
  FROM CATEGORIES T, COMMANDS C
  WHERE C.CATEGORY_ID = T.ID
  GROUP BY T.NAME
  ORDER BY T.NAME;

END Q_COMMANDS_BY_CATEGORY;
/

prompt
prompt Creating procedure Q_COMMANDS_BY_CATEGORY_COMP
prompt ==============================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_COMMANDS_BY_CATEGORY_COMP

(FILTER_USER IN NUMBER, P_REF OUT SYS_REFCURSOR)

IS

BEGIN

OPEN P_REF

FOR

  SELECT S1.NAME AS CAT, S1.COUNTER AS TOTAL, NVL(S2.COUNTER, 0) AS USED
  FROM ( SELECT T.NAME, COUNT(C.NAME) AS COUNTER
         FROM CATEGORIES T, COMMANDS C
         WHERE C.CATEGORY_ID = T.ID
         GROUP BY T.NAME) S1,
       ( SELECT T.NAME, COUNT(C.NAME) AS COUNTER
         FROM   CATEGORIES T, COMMANDS C,
              ( SELECT DISTINCT COMMAND_ID
                FROM COMMANDS_USED
                WHERE (FILTER_USER IS NULL OR COMMANDS_USED.USER_ID = FILTER_USER)) CU
         WHERE C.ID = CU.COMMAND_ID AND
               C.CATEGORY_ID = T.ID
         GROUP BY T.NAME) S2
  WHERE S1.NAME = S2.NAME(+)
  ORDER BY S1.NAME;

END Q_COMMANDS_BY_CATEGORY_COMP;
/

prompt
prompt Creating procedure Q_COMMANDS_USED_BY_CATEGORY
prompt ==============================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_COMMANDS_USED_BY_CATEGORY

(FILTER_USER IN NUMBER, FILTER_CATEGORY IN NUMBER, P_REF OUT SYS_REFCURSOR)

IS

BEGIN

OPEN P_REF

FOR

  SELECT C.NAME AS CAT, NVL(T.COUNTER, 0) AS NUM_CMD_USED
  FROM  CATEGORIES C,
       (SELECT T.ID, COUNT(C.NAME) AS COUNTER
        FROM CATEGORIES T, COMMANDS_USED CU, COMMANDS C
        WHERE C.CATEGORY_ID = T.ID AND
              CU.COMMAND_ID = C.ID AND
             (FILTER_USER IS NULL OR CU.USER_ID = FILTER_USER) AND
             (FILTER_CATEGORY IS NULL OR C.CATEGORY_ID = FILTER_CATEGORY)
        GROUP BY T.ID) T
  WHERE C.ID = T.ID(+)
  ORDER BY C.NAME;

END Q_COMMANDS_USED_BY_CATEGORY;
/

prompt
prompt Creating procedure Q_COMMANDS_USED_BY_USERS
prompt ===========================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_COMMANDS_USED_BY_USERS

(FILTER_USER IN NUMBER, FILTER_COMMAND IN NUMBER, FILTER_CATEGORY IN NUMBER, P_REF OUT SYS_REFCURSOR)

IS

BEGIN

OPEN P_REF

FOR

  SELECT X.*

  FROM ( SELECT U.NAME AS US, C.NAME AS CMD, U.NAME || ' - ' || C.NAME AS U_CMD, T.Nº AS V
         FROM  COMMANDS C, USERS U,
              (SELECT USER_ID, COMMAND_ID, COUNT(COMMAND_ID) as Nº
               FROM COMMANDS_USED T, COMMANDS C
               WHERE  T.COMMAND_ID = C.ID AND
                     (FILTER_USER IS NULL OR T.USER_ID = FILTER_USER) AND
                     (FILTER_COMMAND IS NULL OR T.COMMAND_ID = FILTER_COMMAND) AND
                     (FILTER_CATEGORY IS NULL OR C.CATEGORY_ID = FILTER_CATEGORY)
               GROUP BY USER_ID, COMMAND_ID) T
         WHERE C.ID = T.COMMAND_ID AND U.ID = T.USER_ID
         ORDER BY T.Nº DESC ) X

  WHERE ROWNUM <= 25;

END Q_COMMANDS_USED_BY_USERS;
/

prompt
prompt Creating procedure Q_DIFFERENT_COMMANDS_BY_USER
prompt ===============================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_DIFFERENT_COMMANDS_BY_USER

(FILTER_USER IN NUMBER, FILTER_CATEGORY IN NUMBER, P_REF OUT SYS_REFCURSOR)

IS

BEGIN

OPEN P_REF

FOR

  SELECT U.NAME AS US, J.NUM_CMD
  FROM USERS U,
      (SELECT T.USER_ID AS US, COUNT(T.COMMAND_ID) AS NUM_CMD
       FROM (SELECT USER_ID, COMMAND_ID, COUNT(COMMAND_ID) AS Nº
             FROM COMMANDS_USED T, COMMANDS C
             WHERE  C.ID = T.COMMAND_ID AND
                   (FILTER_USER IS NULL OR T.USER_ID = FILTER_USER) AND
                   (FILTER_CATEGORY IS NULL OR C.CATEGORY_ID = FILTER_CATEGORY)
             GROUP BY USER_ID, COMMAND_ID) T
       GROUP BY T.USER_ID) J
  WHERE J.US = U.ID
  ORDER BY J.NUM_CMD DESC;

end Q_DIFFERENT_COMMANDS_BY_USER;
/

prompt
prompt Creating procedure Q_MOST_DIFFICULTY_USERS
prompt ==========================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_MOST_DIFFICULTY_USERS

(FILTER_USER IN NUMBER, FILTER_CATEGORY IN NUMBER, P_REF OUT SYS_REFCURSOR)

IS

BEGIN

OPEN P_REF

FOR

  SELECT X.*
  FROM ( SELECT  U.NAME AS US, T.COUNTER AS DIF
         FROM USERS U,
             (SELECT S.USER_ID, ROUND(AVG(C.DIFFICULTY), 2) AS COUNTER
              FROM COMMANDS_USED S, COMMANDS C
              WHERE  S.COMMAND_ID = C.ID AND
                    (FILTER_USER IS NULL OR S.USER_ID = FILTER_USER) AND
                    (FILTER_CATEGORY IS NULL OR C.CATEGORY_ID = FILTER_CATEGORY)
              GROUP BY S.USER_ID
              ORDER BY COUNTER DESC) T
         WHERE U.ID = T.USER_ID ) X
  WHERE ROWNUM <= 10;

END Q_MOST_DIFFICULTY_USERS;
/

prompt
prompt Creating procedure Q_MOST_IMPACT_USERS
prompt ======================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_MOST_IMPACT_USERS

(FILTER_USER IN NUMBER, FILTER_CATEGORY IN NUMBER, P_REF OUT SYS_REFCURSOR)

IS

BEGIN

OPEN P_REF

FOR

  SELECT X.*
  FROM ( SELECT U.NAME AS US, T.COUNTER AS IMP
         FROM USERS U,
             (SELECT S.USER_ID, ROUND(AVG(C.IMPACT), 2) AS COUNTER
              FROM COMMANDS_USED S, COMMANDS C
              WHERE S.COMMAND_ID = C.ID  AND
                   (FILTER_USER IS NULL OR S.USER_ID = FILTER_USER) AND
                   (FILTER_CATEGORY IS NULL OR C.CATEGORY_ID = FILTER_CATEGORY)
              GROUP BY S.USER_ID
              ORDER BY COUNTER DESC) T
         WHERE U.ID = T.USER_ID) X
  WHERE ROWNUM <= 10;

END Q_MOST_IMPACT_USERS;
/

prompt
prompt Creating procedure Q_MOST_PARAMS_USERS
prompt ======================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_MOST_PARAMS_USERS

(FILTER_USER IN NUMBER, FILTER_CATEGORY IN NUMBER, P_REF OUT SYS_REFCURSOR)

IS

BEGIN

OPEN P_REF

FOR

  SELECT X.*
  FROM ( SELECT U.NAME AS US, T.COUNTER AS PARAMS
         FROM USERS U,
              ( SELECT S.USER_ID, ROUND(AVG(C.NUM_PARAMS), 2) AS COUNTER
                FROM COMMANDS_USED S, COMMANDS C
                WHERE S.COMMAND_ID = C.ID AND
                     (FILTER_USER IS NULL OR S.USER_ID = FILTER_USER) AND
                     (FILTER_CATEGORY IS NULL OR C.CATEGORY_ID = FILTER_CATEGORY)
                GROUP BY S.USER_ID
                ORDER BY COUNTER DESC) T
         WHERE U.ID = T.USER_ID) X
  WHERE ROWNUM <= 10;

END Q_MOST_PARAMS_USERS;
/

prompt
prompt Creating procedure Q_MOST_USED_COMMAND_BY_USER
prompt ==============================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_MOST_USED_COMMAND_BY_USER

(FILTER_USER IN NUMBER, FILTER_COMMAND IN NUMBER, FILTER_CATEGORY IN NUMBER, P_REF OUT SYS_REFCURSOR)

IS

BEGIN

OPEN P_REF

FOR

  SELECT U.NAME AS US, J.CMD, U.NAME || ' - ' || J.CMD AS U_CMD, J.Nº AS V
  FROM USERS U,
      (SELECT T.US, MAX(T.CMD) KEEP (DENSE_RANK LAST ORDER BY T.Nº) AS CMD, MAX(T.Nº) AS Nº
       FROM (SELECT T.USER_ID AS US, C.NAME AS CMD, COUNT(T.COMMAND_ID) AS Nº
             FROM COMMANDS_USED T, COMMANDS C
             WHERE T.COMMAND_ID = C.ID AND
                  (FILTER_USER IS NULL OR T.USER_ID = FILTER_USER) AND
                  (FILTER_COMMAND IS NULL OR T.COMMAND_ID = FILTER_COMMAND) AND
                  (FILTER_CATEGORY IS NULL OR C.CATEGORY_ID = FILTER_CATEGORY)
             GROUP BY T.USER_ID, C.NAME) T
       GROUP BY T.US) J
  WHERE U.ID = J.US
  ORDER BY U.NAME ASC;

END Q_MOST_USED_COMMAND_BY_USER;
/

prompt
prompt Creating procedure Q_MOST_USED_COMMANDS
prompt =======================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_MOST_USED_COMMANDS

(FILTER_USER IN NUMBER, FILTER_COMMAND IN NUMBER, FILTER_CATEGORY IN NUMBER, P_REF OUT SYS_REFCURSOR)

IS

BEGIN

OPEN P_REF

FOR

  SELECT X.*
  FROM (SELECT C.NAME AS CMD, COUNT(COMMAND_ID) AS V
        FROM COMMANDS_USED T, COMMANDS C
        WHERE T.COMMAND_ID = C.ID AND
             (FILTER_USER IS NULL OR T.USER_ID = FILTER_USER) AND
             (FILTER_COMMAND IS NULL OR T.COMMAND_ID = FILTER_COMMAND) AND
             (FILTER_CATEGORY IS NULL OR C.CATEGORY_ID = FILTER_CATEGORY)
        GROUP BY C.NAME
        ORDER BY V DESC) X
  WHERE ROWNUM <= 25;

END Q_MOST_USED_COMMANDS;
/

prompt
prompt Creating procedure Q_SUMMARY_COMMANDS_COUNT
prompt ===========================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_SUMMARY_COMMANDS_COUNT (P_REF OUT SYS_REFCURSOR) IS
BEGIN
OPEN P_REF
FOR

    SELECT X.COMMAND || ' (' || X.TOTAL_TIMES || ')' AS COMMAND_TOTAL, X.DIFF_USERS
    FROM
        (SELECT M.NAME AS COMMAND, T1.TOTAL_TIMES, T2.DIFF_USERS
        FROM
            COMMANDS M,

            (SELECT C.COMMAND_ID, COUNT(*) AS TOTAL_TIMES
             FROM COMMANDS_USED C
             GROUP BY C.COMMAND_ID) T1,

            (SELECT S.COMMAND_ID, COUNT(*) AS DIFF_USERS
             FROM
                (SELECT COMMAND_ID, USER_ID FROM COMMANDS_USED
                 GROUP BY COMMAND_ID, USER_ID) S
             GROUP BY COMMAND_ID) T2

        WHERE T1.COMMAND_ID = T2.COMMAND_ID
        AND T1.COMMAND_ID = M.ID
        AND T2.COMMAND_ID = M.ID
        ORDER BY T2.DIFF_USERS DESC, T1.TOTAL_TIMES DESC) X
    WHERE ROWNUM <= 25
    ORDER BY X.DIFF_USERS ASC, X.TOTAL_TIMES ASC;

END Q_SUMMARY_COMMANDS_COUNT;
/

prompt
prompt Creating procedure Q_SUMMARY_COMMANDS_TIMES
prompt ===========================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_SUMMARY_COMMANDS_TIMES (P_REF OUT SYS_REFCURSOR) IS
BEGIN
OPEN P_REF
FOR

  SELECT X.*
  FROM
    (SELECT M.NAME || ' (' || S.NAME || ')' AS COMMAND_AND_USER, R2.TIMES AS MOST_USER_TIMES, R1.TIMES AS TOTAL_TIMES
     FROM
         COMMANDS M,
         USERS S,

         -- TOTAL
        (SELECT COMMAND_ID, COUNT(*) AS TIMES
         FROM COMMANDS_USED U
         GROUP BY COMMAND_ID) R1,

         -- MAS USADO
        (SELECT T2.COMMAND_ID, T2.USER_ID, T1.TIMES
         FROM
               (SELECT COMMAND_ID, USER_ID, COUNT(*) AS TIMES FROM COMMANDS_USED U
                GROUP BY COMMAND_ID, USER_ID) T1,

               (SELECT T.COMMAND_ID, MAX(T.USER_ID) KEEP (DENSE_RANK LAST ORDER BY T.TIMES) AS USER_ID
                FROM (
                     SELECT COMMAND_ID, USER_ID, COUNT(*) AS TIMES FROM COMMANDS_USED U
                     GROUP BY COMMAND_ID, USER_ID) T
                GROUP BY T.COMMAND_ID) T2

        WHERE T1.COMMAND_ID = T2.COMMAND_ID AND T1.USER_ID = T2.USER_ID) R2

    WHERE R1.COMMAND_ID = R2.COMMAND_ID
    AND R1.COMMAND_ID = M.ID
    AND R2.COMMAND_ID = M.ID
    AND R2.USER_ID = S.ID
    ORDER BY R1.TIMES DESC) X
  WHERE ROWNUM <= 25
  ORDER BY X.TOTAL_TIMES ASC;

END Q_SUMMARY_COMMANDS_TIMES;
/

prompt
prompt Creating procedure Q_SUMMARY_COMMANDS_TIMES_PUSER
prompt =================================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_SUMMARY_COMMANDS_TIMES_PUSER (FILTER_USER IN NUMBER, P_REF OUT SYS_REFCURSOR) IS
BEGIN
OPEN P_REF
FOR

  SELECT X.*
  FROM
    (SELECT
         M.NAME || ' (' || S.NAME || ')' AS COMMAND_AND_USER,
         R1.TIMES AS TOTAL_TIMES,
         R2.TIMES AS MOST_USER_TIMES,
         NVL(R3.TIMES, 0) AS FILTER_TIMES
     FROM
         COMMANDS M,
         USERS S,

         -- TOTAL
        (SELECT COMMAND_ID, COUNT(*) AS TIMES
         FROM COMMANDS_USED U
         GROUP BY COMMAND_ID) R1,

         -- MAS USADO
        (SELECT T2.COMMAND_ID, T2.USER_ID, T1.TIMES
         FROM
               (SELECT COMMAND_ID, USER_ID, COUNT(*) AS TIMES FROM COMMANDS_USED U
                GROUP BY COMMAND_ID, USER_ID) T1,

               (SELECT T.COMMAND_ID, MAX(T.USER_ID) KEEP (DENSE_RANK LAST ORDER BY T.TIMES) AS USER_ID
                FROM (
                     SELECT COMMAND_ID, USER_ID, COUNT(*) AS TIMES FROM COMMANDS_USED U
                     GROUP BY COMMAND_ID, USER_ID) T
                GROUP BY T.COMMAND_ID) T2

         WHERE T1.COMMAND_ID = T2.COMMAND_ID AND T1.USER_ID = T2.USER_ID) R2,

         -- FILTRADO
        (SELECT COMMAND_ID, COUNT(*) AS TIMES
         FROM COMMANDS_USED U
         WHERE U.USER_ID = FILTER_USER
         GROUP BY COMMAND_ID) R3

    WHERE R1.COMMAND_ID = M.ID
    AND R2.COMMAND_ID = M.ID
    AND R3.COMMAND_ID(+) = M.ID
    AND R2.USER_ID = S.ID
    ORDER BY NVL(R3.TIMES, 0) DESC, R2.TIMES DESC) X

  WHERE ROWNUM <= 25
  ORDER BY X.FILTER_TIMES ASC, X.TOTAL_TIMES ASC;

END Q_SUMMARY_COMMANDS_TIMES_PUSER;
/

prompt
prompt Creating procedure Q_SUMMARY_USERS_COUNT
prompt ========================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_SUMMARY_USERS_COUNT (P_REF OUT SYS_REFCURSOR) IS
BEGIN
OPEN P_REF
FOR

    SELECT X.APP_USER || ' (' || X.TOTAL_TIMES || ')' AS USED_TOTAL, X.DIFF_COMMANDS AS NUM_CMD
    FROM
        (SELECT U.NAME AS APP_USER, T1.TOTAL_TIMES, T2.DIFF_COMMANDS
        FROM
            USERS U,

            (SELECT C.USER_ID, COUNT(*) AS TOTAL_TIMES
             FROM COMMANDS_USED C
             GROUP BY C.USER_ID) T1,

            (SELECT S.USER_ID, COUNT(*) AS DIFF_COMMANDS
             FROM
                (SELECT USER_ID, COMMAND_ID FROM COMMANDS_USED
                 GROUP BY USER_ID, COMMAND_ID) S
             GROUP BY S.USER_ID) T2

        WHERE T1.USER_ID = T2.USER_ID
        AND T1.USER_ID = U.ID
        AND T2.USER_ID = U.ID
        ORDER BY T2.DIFF_COMMANDS DESC, T1.TOTAL_TIMES DESC) X
    WHERE ROWNUM <= 25
    ORDER BY X.DIFF_COMMANDS ASC, X.TOTAL_TIMES ASC;

END Q_SUMMARY_USERS_COUNT;
/

prompt
prompt Creating procedure Q_SUMMARY_USERS_TIMES
prompt ========================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_SUMMARY_USERS_TIMES (P_REF OUT SYS_REFCURSOR) IS
BEGIN
OPEN P_REF
FOR

    SELECT X.*
      FROM
        (SELECT S.NAME || ' (' || M.NAME || ')' AS USER_AND_COMMAND, R2.TIMES AS MOST_COMMAND_TIMES, R1.TIMES AS TOTAL_TIMES
         FROM
             COMMANDS M,
             USERS S,

             -- TOTAL
            (SELECT USER_ID, COUNT(*) AS TIMES
             FROM COMMANDS_USED U
             GROUP BY USER_ID) R1,

             -- MAS USADO
            (SELECT T2.USER_ID, T2.COMMAND_ID, T1.TIMES
             FROM
                   (SELECT USER_ID, COMMAND_ID, COUNT(*) AS TIMES FROM COMMANDS_USED U
                    GROUP BY USER_ID, COMMAND_ID) T1,

                   (SELECT T.USER_ID, MAX(T.COMMAND_ID) KEEP (DENSE_RANK LAST ORDER BY T.TIMES) AS COMMAND_ID
                    FROM (
                         SELECT USER_ID, COMMAND_ID, COUNT(*) AS TIMES FROM COMMANDS_USED U
                         GROUP BY USER_ID, COMMAND_ID) T
                    GROUP BY T.USER_ID) T2

            WHERE T1.COMMAND_ID = T2.COMMAND_ID AND T1.USER_ID = T2.USER_ID) R2

        WHERE R1.USER_ID = S.ID
        AND R2.USER_ID = S.ID
        AND R2.COMMAND_ID = M.ID
        ORDER BY R1.TIMES DESC) X
      WHERE ROWNUM <= 25
      ORDER BY X.TOTAL_TIMES ASC;

END Q_SUMMARY_USERS_TIMES;
/

prompt
prompt Creating procedure Q_SUMMARY_USERS_TIMES_PCMD
prompt =============================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_SUMMARY_USERS_TIMES_PCMD (FILTER_COMMAND IN NUMBER, P_REF OUT SYS_REFCURSOR) IS
BEGIN
OPEN P_REF
FOR

  SELECT X.*
  FROM
    (SELECT
         S.NAME || ' (' || M.NAME || ')' AS USER_AND_COMMAND,
         R1.TIMES AS TOTAL_TIMES,
         R2.TIMES AS MOST_COMMAND_TIMES,
         NVL(R3.TIMES, 0) AS FILTER_TIMES
     FROM
         COMMANDS M,
         USERS S,

         -- TOTAL
            (SELECT USER_ID, COUNT(*) AS TIMES
             FROM COMMANDS_USED U
             GROUP BY USER_ID) R1,

         -- MAS USADO
        (SELECT T2.USER_ID, T2.COMMAND_ID, T1.TIMES
         FROM
               (SELECT USER_ID, COMMAND_ID, COUNT(*) AS TIMES FROM COMMANDS_USED U
                GROUP BY USER_ID, COMMAND_ID) T1,

               (SELECT T.USER_ID, MAX(T.COMMAND_ID) KEEP (DENSE_RANK LAST ORDER BY T.TIMES) AS COMMAND_ID
                FROM (
                     SELECT USER_ID, COMMAND_ID, COUNT(*) AS TIMES FROM COMMANDS_USED U
                     GROUP BY USER_ID, COMMAND_ID) T
                GROUP BY T.USER_ID) T2

         WHERE T1.COMMAND_ID = T2.COMMAND_ID AND T1.USER_ID = T2.USER_ID) R2,

         -- FILTRADO
        (SELECT USER_ID, COUNT(*) AS TIMES
         FROM COMMANDS_USED U
         WHERE U.COMMAND_ID = FILTER_COMMAND
         GROUP BY U.USER_ID) R3

    WHERE R1.USER_ID = S.ID
    AND R2.USER_ID = S.ID
    AND R3.USER_ID(+) = S.ID
    AND R2.COMMAND_ID = M.ID
    ORDER BY NVL(R3.TIMES, 0) DESC, R2.TIMES DESC) X

  WHERE ROWNUM <= 25
  ORDER BY X.FILTER_TIMES ASC, X.TOTAL_TIMES ASC;

END Q_SUMMARY_USERS_TIMES_PCMD;
/

prompt
prompt Creating procedure Q_TOTAL_COMMANDS_BY_USER
prompt ===========================================
prompt
CREATE OR REPLACE PROCEDURE ROOT.Q_TOTAL_COMMANDS_BY_USER

(FILTER_USER IN NUMBER, FILTER_COMMAND IN NUMBER, FILTER_CATEGORY IN NUMBER, P_REF OUT SYS_REFCURSOR)

IS

BEGIN

OPEN P_REF

FOR

  SELECT U.NAME as US, T.Nº
  FROM USERS U,
      (SELECT USER_ID as US, COUNT(T.USER_ID) AS Nº
       FROM COMMANDS_USED T, COMMANDS C
       WHERE  T.COMMAND_ID = C.ID AND
             (FILTER_USER IS NULL OR T.USER_ID = FILTER_USER) AND
             (FILTER_COMMAND IS NULL OR T.COMMAND_ID = FILTER_COMMAND) AND
             (FILTER_CATEGORY IS NULL OR C.CATEGORY_ID = FILTER_CATEGORY)
       GROUP BY USER_ID) T
  WHERE T.US = U.ID
  ORDER BY Nº DESC;

END Q_TOTAL_COMMANDS_BY_USER;
/

prompt
prompt Creating trigger TGR_QUERY_REPORTS_INSERT
prompt =========================================
prompt
CREATE OR REPLACE TRIGGER ROOT.TGR_QUERY_REPORTS_INSERT
BEFORE INSERT
   ON QUERY_REPORTS
   FOR EACH ROW

DECLARE
   v_count number;

BEGIN

   -- Buscamos el nombre del procedimiento almacenado en la tabla de procedimientos de Oracle
   SELECT COUNT(*) INTO v_count
   FROM all_procedures p
   WHERE p.OBJECT_NAME = :new.store_procedure;

   IF NVL(v_count,0) = 0 THEN
     RAISE_APPLICATION_ERROR(-20500, 'STORED_PROCEDURE column must be an existant stored procedure in DB.');
   END IF;

END;
/

set feedback on
set define on
prompt Done.