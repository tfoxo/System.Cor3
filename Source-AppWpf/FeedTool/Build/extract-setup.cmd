::==============================================================
:: This file is here for reference
:: * outdated as of adding to a github repo.
::==============================================================
::@set dotnet2=%windir%\Microsoft.Net\Framework\v2.0.50727
::@set dotnet35=%windir%\Microsoft.Net\Framework\v3.5
::@set dotnet4=%windir%\Microsoft.Net\Framework\v4.0.30319
::--------------------------------------------------------------
::@set sdk=D:\dev\win\lib\Microsoft SDKs\Windows\V6.1\Bin
::--------------------------------------------------------------
:: using NET4
::@set path=%dotnet4%;%sdk%;%path%
::--------------------------------------------------------------
::msbuild build/setup/compileSetup.proj /p:ProjectDir=%cd%
::==============================================================

@set binout=D:\DEV\WIN\CS_ROOT\Projects\github-cor3\Source-AppWpf\FeedTool\bin\
@set inno=c:\Program Files\Inno Setup 5\
@set inno=c:\Program Files (x86)\Inno Setup 5\
@set path="%inno%";%~dp0bin;%path%
::--------------------------------------------------------------
@echo Extracting CefSharp-v1.25
@title Extracting CefSharp-v1.25
@7za x -y -o%binout% "%~dp0CefSharp-v1.25.zip%"
@echo.
@echo chromium-dev-tools
@title chromium-dev-tools
@7za x -y -o%binout% "CefSharp-chromium-dev-tools.zip%"
@echo.
@echo PRESS A KEY TO COMPILE SETUP
@echo CLOSE WINDOW TO EXIT
@echo.
@echo =======================================
@build-setup