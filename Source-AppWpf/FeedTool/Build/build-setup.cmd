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

:: put TortoiseSVN path for SubWCRev if installed
:: ----------------------------------------------
:: set path=%programfiles%\TortoiseSVN\bin;%path%
:: @SubWCRev "%cd%" "%cd%\Properties\AssemblyInfo.cs.rev" "%cd%\Properties\AssemblyInfo.cs"

@%windir%\Microsoft.Net\Framework\v4.0.30319\msbuild setup/compileSetup.proj /p:ProjectDir=%cd%
::%windir%\Microsoft.Net\Framework\v4.0.30319\msbuild build/setup/compileSetup.proj /p:ProjectDir=%cd%
pause