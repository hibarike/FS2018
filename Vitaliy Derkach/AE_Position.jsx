//Converts the 3d position of the Null 1 Layer (x1, y1, z1) to the screen coordinates (x2, y2).
app.project.activeItem.layers.addNull();
var myLayer = app.project.activeItem.layers[1];
myLayer.threeDLayer = false;
myLayer.position.expression = 'thisComp.layer("Null 1").toComp([0, 0, 0]);';
var folder = Folder.selectDialog("Select a folder for the output files");
$.write(folder);
        if (folder !== null) {
            var path = folder.toString() + "/AE_Position.txt";
var myFile=new File(path); 
myFile.open("w");
var myPosition = myLayer.position.value.toString().split(","); 
myFile.write(Number(myPosition[0]).toFixed(1) + " " + Number(myPosition[1]).toFixed(1));
$.write(myLayer.position.value);
myFile.close();
}
myLayer.remove();