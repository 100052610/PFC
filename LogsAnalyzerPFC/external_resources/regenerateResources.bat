echo off
echo --------------------------------------------------------------
echo       Regenerando recursos externos de la aplicación...
echo --------------------------------------------------------------
.\ResGen.exe ReportsResources.resx
.\ResGen.exe ReportsResources.en.resx
echo --------------------------------------------------------------
echo       Recursos regenerados correctamente!
echo       Reinicie la aplicación para ver los cambios
echo --------------------------------------------------------------
pause