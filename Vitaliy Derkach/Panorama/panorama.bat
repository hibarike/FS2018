@echo off

If Not Exist "Images\" (
goto Final
)

If Not Exist "Images\*.jpg" (
goto Final
)

If Not Exist "Project\" (
md Project
)


pto_gen -o Project\project.pto Images\*.jpg
cpfind -o Project\project.pto --multirow --celeste Project\project.pto
cpclean -o Project\project.pto Project\project.pto
linefind -o Project\project.pto Project\project.pto
autooptimiser -a -m -l -s -o Project\project.pto Project\project.pto
pano_modify --canvas=AUTO --crop=AUTO -o Project\project.pto Project\project.pto
hugin_executor --stitching --prefix target Project\project.pto

If Not Exist "Target\" (
md Target
)

If Exist "target.tif" (
move "target.tif" "Target\target.tif"
)

Final:
exit