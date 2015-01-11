@echo off
REM To Install the CodeHtmler LiveWriter Plugin
REM Copy CodeHtmler.dll and CodeHtmler.LiveWriterPlugin.dll into %Program Files%\Windows Live\Writer\Plugins

setlocal

set PLUGINDIR="%ProgramFiles%\Windows Live\Writer\Plugins\"
set CODELOCATION=%~dp0

IF "%1" NEQ "" set CODELOCATION=%~dp1

XCOPY /D /Y /R "%CODELOCATION%CodeHtmler.dll" %PLUGINDIR%
XCOPY /D /Y /R "%CODELOCATION%CodeHtmler.LiveWriterPlugin.dll" %PLUGINDIR%

endlocal