set addinPath=C:\Program Files\Autodesk\Navisworks Manage 2021\Plugins\LearningNavisworksAPI

IF EXIST ["%addinPath%"] (
    del "%addinPath%\*.*" /q /s
)

pause