set temppath=D:\GitHub\Learning-Navisworks-API\AddinRibbon\AddinRibbon.xaml

set addinPath=C:\Program Files\Autodesk\Navisworks Manage 2022\Plugins\LearningNavisworksAPI
set addinPath1=C:\Program Files\Autodesk\Navisworks Manage 2022\Plugins\LearningNavisworksAPI\en-US

set projImagePath=D:\GitHub\Learning-Navisworks-API\AddinRibbon\Images
set navisImagePath=C:\Program Files\Autodesk\Navisworks Manage 2022\Plugins\LearningNavisworksAPI\Images

mkdir "%addinPath1%"
mkdir "%navisImagePath%"

copy "%temppath%" "%addinPath%" /y
copy "%temppath%" "%addinPath1%" /y
xcopy /s /y "%projImagePath%" "%navisImagePath%"

pause