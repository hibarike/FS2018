//@includepath "~/JSON Action Manager/"
//@include "jamEngine.jsxinc"
//@include "jamJSON.jsxinc"

var layers = app.activeDocument.artLayers.parent.layers;
var layer = app.activeDocument.activeLayer;
var doc = app.activeDocument;



//сохранить слой
function SavePNG(idx){
    var OptionsPNG = new PNGSaveOptions();
    OptionsPNG.quality = 10;
    var filepath = File(app.activeDocument.path + "/" + layers[idx].name + ".png");
    app.activeDocument.saveAs(filepath, OptionsPNG, true, Extension.LOWERCASE);
}

function switchLayer(idx){
    for(var i = 0; i < layers.length; i++){
        layers[i].visible = false;
    }
    layers[idx].visible = true;
    app.activeDocument.activeLayer = layers[idx];
}

//не виден ни один слой
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
        right_y: 0};
    var doc = app.activeDocument;
    // right down point;
    Trim(false, false, true, true);
    obj.right_x = parseInt(doc.width.toString().replace(' px', ''));
    obj.right_y = parseInt(doc.height.toString().replace(' px', ''));
    doc.activeHistoryState = savedState;
    //left up point
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

var main_obj = {default_width: 0, default_height: 0, coordinatesarr: []};
app.preferences.rulerUnits = Units.PIXELS;
main_obj.default_height = parseInt(doc.height.toString().replace(" px", ""));
main_obj.default_width = parseInt(doc.width.toString().replace(" px", ""));
unvisibleAll(layers);
for (var i = 0; i < layers.length; i++){
    switchLayer(i);
    var savedState = app.activeDocument.activeHistoryState;
    main_obj.coordinatesarr.push(getCoordinates(savedState));
    Trim(true, true, true, true);
    SavePNG(i);
    app.activeDocument.activeHistoryState = savedState;
} 

var file = new File(app.activeDocument.path + '/export.json');
if(file.open("w"))
{
    file.encoding = "UTF-8";
    file.write(jamJSON.stringify (main_obj));
    file.close;
}