@echo off
set xpos=0
set zpos=0

for /f "tokens=*" %%a in (input) do call :Proc %%a
call :Results

:Proc
set val=%1
set num=%2

echo %val% | findstr /r "forward" > nul && (
    set /a xpos+=%num% && goto :EOF
) 

echo %val% | findstr /r "up" > nul && (
    set /a zpos-=%num% && goto :EOF
) 

echo %val% | findstr /r "down" > nul && (
    set /a zpos+=%num% && goto :EOF
) 
goto :EOF

:Results
set /a answer=xpos*zpos
echo Answer: %answer%
goto :EOF