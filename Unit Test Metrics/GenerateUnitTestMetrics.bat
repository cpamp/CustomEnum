REM Create a 'GeneratedReports' folder if it does not exist
if not exist "%~dp0GeneratedReports" mkdir "%~dp0GeneratedReports"
 if not exist "%~dp0GeneratedReports\ReportGenerator Output" mkdir "%~dp0GeneratedReports\ReportGenerator Output"

 REM Remove any previously created test output directories
CD %~dp0
FOR /D /R %%X IN (%USERNAME%*) DO RD /S /Q "%%X"

REM Remove any previous test execution files to prevent issues overwriting
IF EXIST "%~dp0CustomEnum.trx" del "%~dp0CustomEnum.trx%"
 
REM Run the tests against the targeted output
call :RunOpenCoverUnitTestMetrics
 
REM Generate the report output based on the test results
if %errorlevel% equ 0 (
 call :RunReportGeneratorOutput
)
 
REM Launch the report
if %errorlevel% equ 0 (
 call :RunLaunchReport
)
exit /b %errorlevel%
 
:RunOpenCoverUnitTestMetrics
"%~dp0..\packages\OpenCover.4.6.519\Tools\OpenCover.Console.exe" ^
-register:user ^
-target:"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%~dp0..\CustomEnum.Tests\bin\Debug\CustomEnum.Tests.dll\" /resultsfile:\"%~dp0CustomEnum.trx\"" ^
-filter:"+[CustomEnum*]* -[CustomEnum.Tests]* -[*]CustomEnum.RouteConfig" ^
-mergebyhash ^
-skipautoprops ^
-output:"%~dp0\GeneratedReports\CustomEnumReport.xml"
exit /b %errorlevel%
 
:RunReportGeneratorOutput
"%~dp0..\packages\ReportGenerator.3.0.2\Tools\ReportGenerator.exe" ^
-reports:"%~dp0\GeneratedReports\CustomEnumReport.xml" ^
-targetdir:"%~dp0\GeneratedReports\ReportGenerator Output"
exit /b %errorlevel%
 
:RunLaunchReport
start "report" "%~dp0\GeneratedReports\ReportGenerator Output\index.htm"
exit /b %errorlevel%