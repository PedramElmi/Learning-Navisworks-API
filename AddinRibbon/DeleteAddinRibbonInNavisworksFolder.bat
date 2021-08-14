set addinPath=C:\Program Files\Autodesk\Navisworks Manage 2022\Plugins\LearningNavisworksAPI

if exist "%addinPath%" ( del "%addinPath%\*.*" /q /s )

pause