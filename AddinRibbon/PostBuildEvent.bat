set temppath=C:\Users\ASUS  ROG  G731GV\OneDrive\Codes C#\Navisworks\NavisworksTutorialPart3\AddinRibbon\AddinRibbon\AddinRibbon.xaml

set addinPath=C:\Program Files\Autodesk\Navisworks Manage 2021\Plugins\LearningNavisworksAPI
set addinPath1=C:\Program Files\Autodesk\Navisworks Manage 2021\Plugins\LearningNavisworksAPI\en-US

set projImagePath=C:\Users\ASUS  ROG  G731GV\OneDrive\Codes C#\Navisworks\NavisworksTutorialPart3\AddinRibbon\AddinRibbon\Images
set navisImagePath=C:\Program Files\Autodesk\Navisworks Manage 2021\Plugins\LearningNavisworksAPI\Images

mkdir "%addinPath1%"
mkdir "%navisImagePath%"

copy "%temppath%" "%addinPath%" /y
copy "%temppath%" "%addinPath1%" /y
xcopy /s /y "%projImagePath%" "%navisImagePath%"

pause