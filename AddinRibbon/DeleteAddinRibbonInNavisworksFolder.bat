set addinPath=C:\Program Files\Autodesk\Navisworks Manage 2022\Plugins\LearningNavisworksAPI

IF EXIST ["%addinPath%"] (
    del "%addinPath%\*.*" /q /s
)

pause