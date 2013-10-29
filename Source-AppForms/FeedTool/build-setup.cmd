::==============================================================
:: This file is here for reference
:: * outdated as of adding to a github repo.
::==============================================================
::@set dotnet2=%windir%\Microsoft.Net\Framework\v2.0.50727
::@set dotnet35=%windir%\Microsoft.Net\Framework\v3.5
::@set dotnet4=%windir%\Microsoft.Net\Framework\v4.0.30319
::==============================================================
::@set sdk=D:\dev\win\lib\Microsoft SDKs\Windows\V6.1\Bin
::==============================================================
:: using NET4
::@set path=%dotnet4%;%sdk%;%path%
::==============================================================
:: GO
::msbuild build/setup/compileSetup.proj /p:ProjectDir=%cd%

:: Note that TortoiseSVN needs to be a part of the path in order
:: for SubWCRev to be available.
:: If it hasn't been added to your path (and is installed).
::==============================================================
set path=%programfiles%\TortoiseSVN\bin;%path%
::==============================================================

@SubWCRev "%cd%" "%cd%\Properties\AssemblyInfo.cs.rev" "%cd%\Properties\AssemblyInfo.cs"

@ECHO.
@ECHO AssemblyInfo.cs regenerated (unless some kind of error)
@ECHO.
@PAUSE

%windir%\Microsoft.Net\Framework\v4.0.30319\msbuild build/setup/compileSetup.proj /p:ProjectDir=%cd%
