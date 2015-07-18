echo off
echo --------------------------------------------------------------
echo       Regenerando recursos externos de la aplicaci¢n...
echo --------------------------------------------------------------
.\ResGen.exe ReportsResources.resx
.\ResGen.exe ReportsResources.en.resx
echo --------------------------------------------------------------
echo       Recursos regenerados correctamente!
echo       Reinicie la aplicaci¢n para ver los cambios
echo --------------------------------------------------------------
pause