
rem folders "expected" and "results" and 2 jsons need be located together with this bat file.

@echo OFF
@setlocal enableextensions enabledelayedexpansion
rem Testing jsons
set jsonString=
for /F "tokens=* skip=1" %%A in ('fc expected.json result.json') do (
	set jsonString=%%A
	echo !jsonString!
	echo !jsonString! | findstr differences > nul
	if errorlevel 1 (
		echo Json files are not equal. Test is not passed.
		pause
		exit
	)
)
echo Jsons are equal.
rem Testing images
rem We need be sure about existing of results and expected folders . 
rem "expected" - folder with etalon images
set etalonPicturesDir=%__CD__%expected\
rem "resuts" - folder with images were made by our ps script
cd results
set etalon=0.0000000000
for %%i in (*) do (
	set res=
	for /F "skip=6 tokens=1,2,3 delims= " %%A in ('gm compare -metric mse %%i %etalonPicturesDir%%%i') do (
		set res=%%B
	)
	echo !res!
	if not !res!==%etalon% (
			echo Test is not passed. :(
			pause
		exit
	)
)
echo Images are equal.
echo Test passed! :)
pause
exit