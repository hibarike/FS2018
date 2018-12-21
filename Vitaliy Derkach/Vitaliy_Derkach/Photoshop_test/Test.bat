@ echo off
setlocal enabledelayedexpansion
echo The result of testing:>result.txt
rem This section compares expected images with test images
@ echo Please wait...
for %%f in (layers_expected\*) do (
if "%%~xf" == ".png" (
if exist ps_layers\%%~nxf ( 
magick compare -metric ae ps_layers\%%~nxf layers_expected\%%~nxf :none 2> buff.txt
set /p diff=<buff.txt
echo !diff! >ff.txt
if !diff! == 0 (
echo %%~nxf - true>>result.txt
) else (
echo %%~nxf - false>>result.txt
)
) else (
echo %%~nxf isn`t exist in testing layers.>>result.txt
)
) else (
echo %%~nxf isn't png file.>>result.txt
)
)
del buff.txt
rem This section compares expected JSON file with test JSON file. 
fc /w scripts\expected_layers1.json scripts\ps_layers.json 1>nul 2>nul
if ERRORLEVEL 2 goto Absent
if ERRORLEVEL 1 goto Different
echo JSON files ARE equal.>>result.txt
goto Final
:Absent
echo The JSON file is'not found.>>result.txt
goto Final
:Different
if exist scripts\expected_layers2.json (
fc /w scripts\expected_layers2.json scripts\ps_layers.json 1>nul 2>nul
if ERRORLEVEL 0 (
echo JSON files ARE equal.>>result.txt
goto Final
) 
)
echo JSON files are NOT equal.>>result.txt
goto Final
:Final
echo Look the result into the file result.txt
pause
exit