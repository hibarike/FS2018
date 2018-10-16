//@includepath "~/JSON Action Manager/"
//@include "jamEngine.jsxinc"
//@include "jamJSON.jsxinc"

var doc = app.activeDocument;
var layer = doc.activeLayer;
var group = layer.parent.layers;
var objectArr = [];
var jsonData = {
    docWidth: 0, 
    docHeight: 0, 
    coordsArr: []
};
jsonData.docHeight = parseInt(doc.height.toString().replace(' px', ''));
jsonData.docWidth = parseInt(doc.width.toString().replace(' px', ''));

app.preferences.rulerUnits = Units.PIXELS;

unvisibleAll(group);

for(var i = 0; i < group.length; ++i)
{
    // переключаемся на другой слой и делаем его видимым
    switchLayer(i);

    // сохораняем текущее состояние документа
    var savedState = app.activeDocument.activeHistoryState;

    // получаем все необходимые нам координаты и обрезаем
    jsonData.coordsArr.push(getCoordinates(savedState));
    Trim(true, true, true, true);

    // сохраняем как отдельную картинку
    savePng(layer.name.toString());

    // откат на снепшот 
    doc.activeHistoryState = savedState;
}
// сохраняем данные с координатами в файл
var file = new File("~/Desktop/jstask/export.json");
if(file.open("w"))
{
    file.encoding = "UTF-8";
    file.write(jamJSON.stringify (jsonData));
    file.close;
}


//скрытие всех слоев
function unvisibleAll(group){
    for(var i = 0; i < group.length; i++){
        group[i].visible = false;
    }
} 
//тримминг
function Trim(up, left, down, right){
    app.activeDocument.trim(TrimType.TOPLEFT, up, left, down, right);
}


//координаты левого верхнего и правого нижнего угла
// изображения после тримминга относительно предыдущего слоя
function getCoordinates(savedState){
    var obj = { name: app.activeDocument.activeLayer.name.toString(),
        left_x: 0, 
        left_y: 0,
        right_x: 0, 
        right_y: 0
    };
    var doc = app.activeDocument;
    // правый нижний 
    Trim(false, false, true, true);
    obj.right_x = parseInt(doc.width.toString().replace(' px', ''));
    obj.right_y = parseInt(doc.height.toString().replace(' px', ''));

    //левый верхний
    Trim(false, true, false, true);
    var abs_width = parseInt(doc.width.toString().replace(' px', ''));
    doc.activeHistoryState = savedState;

    Trim(false, false, false, true);
    obj.left_x = parseInt(doc.width.toString().replace(' px', '')) - abs_width;
    doc.activeHistoryState = savedState;

    Trim(true, false, true, false);
    var abs_height = parseInt(doc.height.toString().replace(' px', ''));
    doc.activeHistoryState = savedState;

    Trim(false, false, true, false);
    obj.left_y = parseInt(doc.height.toString().replace(' px', '')) - abs_height;
    doc.activeHistoryState = savedState;

    return obj;
}

function savePng(name)
{
    var options = new ExportOptionsSaveForWeb();
    options.quality = 70;
    options.format = SaveDocumentType.JPEG;
    options.optimized = true;
    var path = new File("C:/Users/Vlad/Desktop/jstask/" + name + ".png");
    doc.exportDocument(path, ExportType.SAVEFORWEB,options);
}

function switchLayer(i)
{
    layer.visible = false;
    doc.activeLayer =  group[i];
    layer = doc.activeLayer;
    layer.visible = true;
}
