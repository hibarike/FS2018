var _layer = app.project.activeItem.layer(1);
_layer.threeDLayer = false;
_layer.position.expression = 'thisComp.layer("Null 1").toComp([0, 0, 0]);';
try{
    var folder = Folder.selectDialog("Выберите папку для сохранения файла");
    $.write(folder);
    var file = new File(folder.toString() + '/coordinates.txt');
    file.open('w');
}
catch(e){
    alert(e.message);
}
file.encoding = "UTF-8";
index = _layer.position.value.toString().length - 2;
file.write("Coordinates of layer: " + _layer.position.value.toString().replace(',', ' ').slice(0, index));
file.close();