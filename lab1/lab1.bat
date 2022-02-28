@echo off
cls
:start
echo vvedite disc
set /p d=""
echo vvedite pervoe rashirenie
set /p r1=""
echo vvedite vtoroe rashirenie
set /p r2=""
For /R %d% %%i In ("%r1%" "%r2%") Do (
	(echo %%i& Set Ok=True)
 	If Exist %%i (
		del %%i
	)
)
if "%Ok%"=="" (
	echo (Takogo diska net)