prompt ===========================================
prompt =          DELETING DATABASE OBJECTS      =
prompt ===========================================

set feedback off
set define off

prompt
prompt Dropping ROOT.TRIGGERS
prompt ======================
prompt
DROP TRIGGER ROOT.TGR_QUERY_REPORTS_INSERT;

prompt
prompt Dropping ROOT.PROCEDURES
prompt ========================
prompt
DROP PROCEDURE ROOT.Q_COMMANDS_BY_CATEGORY;
DROP PROCEDURE ROOT.Q_COMMANDS_BY_CATEGORY_COMP;
DROP PROCEDURE ROOT.Q_COMMANDS_USED_BY_CATEGORY;
DROP PROCEDURE ROOT.Q_COMMANDS_USED_BY_USERS;
DROP PROCEDURE ROOT.Q_DIFFERENT_COMMANDS_BY_USER;
DROP PROCEDURE ROOT.Q_MOST_DIFFICULTY_USERS;
DROP PROCEDURE ROOT.Q_MOST_IMPACT_USERS;
DROP PROCEDURE ROOT.Q_MOST_PARAMS_USERS;
DROP PROCEDURE ROOT.Q_MOST_USED_COMMAND_BY_USER;
DROP PROCEDURE ROOT.Q_MOST_USED_COMMANDS;
DROP PROCEDURE ROOT.Q_SUMMARY_COMMANDS_COUNT;
DROP PROCEDURE ROOT.Q_SUMMARY_COMMANDS_TIMES;
DROP PROCEDURE ROOT.Q_SUMMARY_COMMANDS_TIMES_PUSER;
DROP PROCEDURE ROOT.Q_SUMMARY_USERS_COUNT;
DROP PROCEDURE ROOT.Q_SUMMARY_USERS_TIMES;
DROP PROCEDURE ROOT.Q_SUMMARY_USERS_TIMES_PCMD;
DROP PROCEDURE ROOT.Q_TOTAL_COMMANDS_BY_USER;
DROP PROCEDURE ROOT.PL_INSERT_CATEGORIES;
DROP PROCEDURE ROOT.PL_INSERT_COMMANDS_INICIAL;
DROP PROCEDURE ROOT.PL_INSERT_USED_COMMANDS;
DROP PROCEDURE ROOT.PL_INSERT_USERS;
DROP PROCEDURE ROOT.PL_INSERT_COMMANDS;
DROP PROCEDURE ROOT.PL_RESTART_ALL_SEQUENCES;
DROP PROCEDURE ROOT.PL_RESTART_BOTH_SEQUENCES;
DROP PROCEDURE ROOT.PL_RESTART_SEQUENCES;

prompt
prompt Dropping ROOT.TABLES
prompt ====================
prompt
DROP TABLE ROOT.COMMANDS_USED CASCADE CONSTRAINTS;
DROP TABLE ROOT.QUERY_REPORTS CASCADE CONSTRAINTS;
DROP TABLE ROOT.CHART_TYPES CASCADE CONSTRAINTS;
DROP TABLE ROOT.REPORT_TEMPLATES CASCADE CONSTRAINTS;
DROP TABLE ROOT.USERS CASCADE CONSTRAINTS;
DROP TABLE ROOT.CATEGORIES CASCADE CONSTRAINTS;
DROP TABLE ROOT.COMMANDS CASCADE CONSTRAINTS;

prompt
prompt Dropping ROOT.SEQUENCES
prompt =======================
prompt
DROP SEQUENCE ROOT.SEQ_CATEGORIES;
DROP SEQUENCE ROOT.SEQ_COMMANDS;
DROP SEQUENCE ROOT.SEQ_COMMANDS_USED;
DROP SEQUENCE ROOT.SEQ_USERS;

set feedback on
set define on
prompt Done.