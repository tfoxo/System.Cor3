@set msb=%windir%\microsoft.net\framework\v4.0.30319\msbuild
@%windir%\microsoft.net\framework\v4.0.30319\msbuild.exe MultiMarkDown.proj /p:startPath="%CD%" /target:Clean
pause