rem The contents of the testset folder in which to place the bat-file:
rem Folders "expected" and "results" in each of which are images and json file.
rem "expected" - folder with etalon images
rem "resuts" - folder with images were made by our ps script
rem In folder expected folder .json must be named "expected.json"
rem In folder results folder .json must be named "result.json"

@echo OFF
@setlocal enableextensions enabledelayedexpansion

FC /B expected\expected.json results\result.json > nul
if ERRORLEVEL 1 (
echo FILES ARE NOT EQUAL
echo TEST IS NOT PASSED
pause
exit)
echo FILES ARE EQUAL
set etalonPicturesDir=%__CD__%expected\
cd results
set etalon=0.0000000000
for %%i in (*.png) do ( set res=
	for /F "skip=6 tokens=1,2,3 delims= " %%A in ('gm compare -metric mse %%i %etalonPicturesDir%%%i') do (
		set res=%%B)
	echo !res!
	if not !res!==%etalon% (
			echo TEST IS NOT PASSED
			pause
		exit))
echo IMAGES ARE EQUAL
echo TEST PASSED
pause
exit