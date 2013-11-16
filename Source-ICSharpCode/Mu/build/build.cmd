@ECHO OFF
SET CURRENT=%~dp0
SET MUBIN=%CURRENT%..\bin\debug
SET BASE=%CURRENT%..\..\..
SET BDIR=%base%\build\bin-7z
SET PATH=%BDIR%;%PATH%

del mu.sdaddin
7za.exe a -tzip "mu.sdaddin" "%MUBIN%\*"
