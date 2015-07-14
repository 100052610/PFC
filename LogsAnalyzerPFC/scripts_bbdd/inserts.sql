prompt ===========================================
prompt =          INSERTING TABLES RECORDS       =
prompt ===========================================

set feedback off
set define off

prompt
prompt Loading ROOT.CATEGORIES
prompt =======================
prompt
prompt Table is empty

prompt
prompt Loading ROOT.CHART_TYPES
prompt ========================
prompt
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (1, 'xlColumnClustered', 'Clustered Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (2, 'xlColumnStacked', 'Stacked Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (3, 'xlColumnStacked100', '100% Stacked Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (4, 'xl3DColumnClustered', '3D Clustered Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (5, 'xl3DColumnStacked', '3D Stacked Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (6, 'xl3DColumnStacked100', '3D 100% Stacked Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (7, 'xlBarClustered', 'Clustered Bar', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (8, 'xlBarStacked', 'Stacked Bar', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (9, 'xlBarStacked100', '100% Stacked Bar', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (10, 'xl3DBarClustered', '3D Clustered Bar', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (11, 'xl3DBarStacked', '3D Stacked Bar', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (12, 'xl3DBarStacked100', '3D 100% Stacked Bar', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (13, 'xlLineStacked', 'Stacked Line', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (14, 'xlLineStacked100', '100% Stacked Line', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (15, 'xlLineMarkers', 'Line with Markers', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (16, 'xlLineMarkersStacked', 'Stacked Line with Markers', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (17, 'xlLineMarkersStacked100', '100% Stacked Line with Markers', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (18, 'xlPieOfPie', 'Pie of Pie', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (19, 'xlPieExploded', 'Exploded Pie', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (20, 'xl3DPieExploded', 'Exploded 3D Pie', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (21, 'xlBarOfPie', 'Bar of Pie', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (22, 'xlXYScatterSmooth', 'Scatter with Smoothed Lines', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (23, 'xlXYScatterSmoothNoMarkers', 'Scatter with Smoothed Lines and No Data Markers', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (24, 'xlXYScatterLines', 'Scatter with Lines.', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (25, 'xlXYScatterLinesNoMarkers', 'Scatter with Lines and No Data Markers', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (26, 'xlAreaStacked', 'Stacked Area', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (27, 'xlAreaStacked100', '100% Stacked Area', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (28, 'xl3DAreaStacked', '3D Stacked Area', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (29, 'xl3DAreaStacked100', '100% Stacked Area', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (30, 'xlDoughnutExploded', 'Exploded Doughnut', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (31, 'xlRadarMarkers', 'Radar with Data Markers', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (32, 'xlRadarFilled', 'Filled Radar', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (33, 'xlSurface', '3D Surface', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (34, 'xlSurfaceWireframe', '3D Surface (wireframe)', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (35, 'xlSurfaceTopView', 'Surface (Top View)', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (36, 'xlSurfaceTopViewWireframe', 'Surface (Top View wireframe)', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (37, 'xlBubble', 'Bubble', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (38, 'xlBubble3DEffect', 'Bubble with 3D effects', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (39, 'xlStockHLC', 'High-Low-Close', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (40, 'xlStockOHLC', 'Open-High-Low-Close', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (41, 'xlStockVHLC', 'Volume-High-Low-Close', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (42, 'xlStockVOHLC', 'Volume-Open-High-Low-Close', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (43, 'xlCylinderColClustered', 'Clustered Cone Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (44, 'xlCylinderColStacked', 'Stacked Cone Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (45, 'xlCylinderColStacked100', '100% Stacked Cylinder Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (46, 'xlCylinderBarClustered', 'Clustered Cylinder Bar', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (47, 'xlCylinderBarStacked', 'Stacked Cylinder Bar', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (48, 'xlCylinderBarStacked100', '100% Stacked Cylinder Bar', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (49, 'xlCylinderCol', '3D Cylinder Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (50, 'xlConeColClustered', 'Clustered Cone Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (51, 'xlConeColStacked', 'Stacked Cone Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (52, 'xlConeColStacked100', '100% Stacked Cone Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (53, 'xlConeBarClustered', 'Clustered Cone Bar', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (54, 'xlConeBarStacked', 'Stacked Cone Bar', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (55, 'xlConeBarStacked100', '100% Stacked Cone Bar', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (56, 'xlConeCol', '3D Cone Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (57, 'xlPyramidColClustered', 'Clustered Pyramid Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (58, 'xlPyramidColStacked', 'Stacked Pyramid Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (59, 'xlPyramidColStacked100', '100% Stacked Pyramid Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (60, 'xlPyramidBarClustered', 'Clustered Pyramid Bar', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (61, 'xlPyramidBarStacked', 'Stacked Pyramid Bar', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (62, 'xlPyramidBarStacked100', '100% Stacked Pyramid Bar', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (63, 'xlPyramidCol', '3D Pyramid Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (64, 'xl3DColumn', '3D Column', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (65, 'xlLine', 'Line', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (66, 'xl3DLine', '3D Line', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (67, 'xl3DPie', '3D Pie', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (68, 'xlPie', 'Pie', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (69, 'xlXYScatter', 'Scatter', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (70, 'xl3DArea', '3D Area', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (71, 'xlArea', 'Area', 1);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (72, 'xlDoughnut', 'Doughnut', 0);
insert into ROOT.CHART_TYPES (ID, NAME, DESCRIPTION, HAS_AXIS)
values (73, 'xlRadar', 'Radar', 0);
commit;
prompt 73 records loaded

prompt
prompt Loading ROOT.COMMANDS
prompt =====================
prompt
prompt Table is empty

prompt
prompt Loading ROOT.USERS
prompt ==================
prompt
prompt Table is empty

prompt
prompt Loading ROOT.COMMANDS_USED
prompt ==========================
prompt
prompt Table is empty

prompt
prompt Loading ROOT.REPORT_TEMPLATES
prompt =============================
prompt
insert into ROOT.REPORT_TEMPLATES (ID, NAME, COLUMNS, SERIES, RANGE_X, RANGE_Y)
values (1, 'P_1', 2, 1, 'A3', 'B');
insert into ROOT.REPORT_TEMPLATES (ID, NAME, COLUMNS, SERIES, RANGE_X, RANGE_Y)
values (2, 'P_2', 4, 1, 'C3', 'D');
insert into ROOT.REPORT_TEMPLATES (ID, NAME, COLUMNS, SERIES, RANGE_X, RANGE_Y)
values (3, 'P_3', 3, 2, 'A3', 'C');
insert into ROOT.REPORT_TEMPLATES (ID, NAME, COLUMNS, SERIES, RANGE_X, RANGE_Y)
values (4, 'P_4', 4, 3, 'A3', 'D');
commit;
prompt 4 records loaded

prompt
prompt Loading ROOT.QUERY_REPORTS
prompt ==========================
prompt
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (1, 'Q_MUC', 'Q_MOST_USED_COMMANDS', 'D_MUC', 68, 1, 7);
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (2, 'Q_MUCU', 'Q_MOST_USED_COMMAND_BY_USER', 'D_MUCU', 10, 2, 7);
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (3, 'Q_TCU', 'Q_TOTAL_COMMANDS_BY_USER', 'D_TCU', 72, 1, 7);
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (4, 'Q_DCU', 'Q_DIFFERENT_COMMANDS_BY_USER', 'D_DCU', 10, 1, 5);
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (5, 'Q_CAU', 'Q_COMMANDS_USED_BY_USERS', 'D_CAU', 10, 2, 7);
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (6, 'Q_CC', 'Q_COMMANDS_BY_CATEGORY', 'D_CC', 20, 1, 0);
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (7, 'Q_CUC', 'Q_COMMANDS_USED_BY_CATEGORY', 'D_CUC', 20, 1, 5);
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (8, 'Q_CCC', 'Q_COMMANDS_BY_CATEGORY_COMP', 'D_CCC', 3, 3, 4);
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (9, 'Q_MDU', 'Q_MOST_DIFFICULTY_USERS', 'D_MDU', 11, 1, 5);
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (10, 'Q_MIU', 'Q_MOST_IMPACT_USERS', 'D_MIU', 11, 1, 5);
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (11, 'Q_MPU', 'Q_MOST_PARAMS_USERS', 'D_MPU', 11, 1, 5);
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (12, 'Q_SCT', 'Q_SUMMARY_COMMANDS_TIMES', 'D_SCT', 7, 3, 0);
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (13, 'Q_SCC', 'Q_SUMMARY_COMMANDS_COUNT', 'D_SCC', 7, 1, 0);
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (14, 'Q_SUT', 'Q_SUMMARY_USERS_TIMES', 'D_SUT', 7, 3, 0);
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (15, 'Q_SUC', 'Q_SUMMARY_USERS_COUNT', 'D_SUC', 7, 1, 0);
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (16, 'Q_SCTU', 'Q_SUMMARY_COMMANDS_TIMES_PUSER', 'D_SCTU', 7, 4, 4);
insert into ROOT.QUERY_REPORTS (ID, NAME, STORE_PROCEDURE, DESCRIPTION, CHART_TYPE, TEMPLATE, FILTERS)
values (17, 'Q_SUTC', 'Q_SUMMARY_USERS_TIMES_PCMD', 'D_SUTC', 7, 4, 2);
commit;
prompt 17 records loaded

set feedback on
set define on
prompt Done.