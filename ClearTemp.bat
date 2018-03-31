@echo off
echo ----删除临时文件和中间文件-----
del /F /S /Q *.ncp *.obj *.pch *.sbr *.tmp *.pdb *.bsc *.ilk *.ncb
echo ----删除Obj文件夹中的临时文件-----
del /F /S /Q .\ZCXJ_CS.Utilities\ConfigHelper\obj
del /F /S /Q .\ZCXJ_CS.Utilities\LogHelper\obj
del /F /S /Q .\ZCXJ_CS.Utilities\SerialPortHelper\obj
del /F /S /Q .\ZCXJ_CS.Utilities\SqliteHelper\obj
del /F /S /Q .\ZCXJ_CS.Utilities\JsonHelper\obj
del /F /S /Q .\ZCXJ_CS.Applications\obj
del /F /S /Q .\ZCXJ_CS.Domain\obj
del /F /S /Q .\ZCXJ_CS.Presentation\obj
del /F /S /Q .\ZCXJ_CS.Infrastructure\obj
del /F /S /Q .\ZCXJ_CS.Repository\obj
del /F /S /Q .\ZCXJ_CS.UI\UIBase\obj
del /F /S /Q .\ZCXJ_CS.UI\FormWorkTicket\obj
del /F /S /Q .\ZCXJ_CS.UI\FormTest\obj
del /F /S /Q .\ZCXJ_CS.UI\FormProdMonitor\obj
del /F /S /Q .\ZCXJ_CS.UI\FormTeamHandover\obj
del /F /S /Q .\ZCXJ_CS.UI\FormTurnoverCard\obj
del /F /S /Q .\ZCXJ_CS.UI\DlgFactorVerify\obj
del /F /S /Q .\ZCXJ_CS.UI\YgControls\obj
del /F /Q .\ZCXJ_CS.Presentation\bin\Plugins\UI\ConfigHelper.dll
del /F /Q .\ZCXJ_CS.Presentation\bin\Plugins\UI\EntityFramework.dll
del /F /Q .\ZCXJ_CS.Presentation\bin\Plugins\UI\JsonHelper.dll
del /F /Q .\ZCXJ_CS.Presentation\bin\Plugins\UI\LogHelper.dll
del /F /Q .\ZCXJ_CS.Presentation\bin\Plugins\UI\Newtonsoft.Json.dll
del /F /Q .\ZCXJ_CS.Presentation\bin\Plugins\UI\SerialPortHelper.dll
del /F /Q .\ZCXJ_CS.Presentation\bin\Plugins\UI\SqliteHelper.dll
del /F /Q .\ZCXJ_CS.Presentation\bin\Plugins\UI\SQLite.CodeFirst.dll
del /F /Q .\ZCXJ_CS.Presentation\bin\Plugins\UI\System.Data.SQLite.dll
del /F /Q .\ZCXJ_CS.Presentation\bin\Plugins\UI\ZCXJ_CS.Applications.dll
del /F /Q .\ZCXJ_CS.Presentation\bin\Plugins\UI\ZCXJ_CS.Domain.dll
del /F /Q .\ZCXJ_CS.Presentation\bin\Plugins\UI\ZCXJ_CS.Infrastructure.dll
del /F /Q .\ZCXJ_CS.Presentation\bin\Plugins\UI\ZCXJ_CS.Repository.dll

echo -----删除Bin目录下的临时文件------
cd .\ZCXJ_CS.Presentation\bin
del /F /Q *.vshost*
