cd %~dp0

svn update ../



rem build proj

"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\MSBuild.exe" ..\NingFan.Hrp.sln

copy ..\hrp.BLL\bin\Debug\hrp.BLL.dll ..\hrp.Web\bin\hrp.BLL.dll
copy ..\hrp.Model\bin\Debug\hrp.Model.dll ..\hrp.Web\bin\hrp.Model.dll
copy ..\hrp.xtgl\bin\Debug\hrp.xtgl.dll ..\hrp.Web\bin\hrp.xtgl.dll
copy ..\hrp.ylsbgl\bin\Debug\hrp.ylsbgl.dll ..\hrp.Web\bin\hrp.ylsbgl.dll
copy ..\NingFan.Utility\bin\Debug\NingFan.Utility.dll ..\hrp.Web\bin\NingFan.Utility.dll

rem ftp

ftp -s:ftp.txt

