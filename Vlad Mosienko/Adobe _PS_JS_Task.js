//@includepath "~/JSON Action Manager/"
//@include "jamEngine.jsxinc"
//@include "jamJSON.jsxinc"

var doc = app.activeDocument;
var layer = doc.activeLayer;
var group = layer.parent.layers;
var jsonData = {
    docWidth: 0, 
    docHeight: 0, 
    coordsArr: []
};
//writing main size of a document to json
jsonData.docHeight = parseInt(doc.height.toString().replace(' px', ''));
jsonData.docWidth = parseInt(doc.width.toString().replace(' px', ''));
//use pixels for describing size properties
app.preferences.rulerUnits = Units.PIXELS;

unvisibleAll(group);

for(var i = 0; i < group.length; ++i) {
    // switch to another layer and do it visible
    switchLayer(i);

    // save current state of a document
    var savedState = app.activeDocument.activeHistoryState;

    // get all layers coordinates
    jsonData.coordsArr.push(getCoordinates(savedState));
    // trimming 
    Trim(true, true, true, true);

    // save trimmed layer as a separate png file
    savePng(layer.name.toString(), "C:/Users/Vlad/Desktop/jstask/");

    // rollback to snapshot
    doc.activeHistoryState = savedState;
}

// save data with coordinates to file
var file = new File("~/Desktop/jstask/export.json");
if(file.open("w")) {
    file.encoding = "UTF-8";
    file.write(jamJSON.stringify (jsonData));
    file.close;
}

// make invisible all layers
function unvisibleAll(group) {
    for(var i = 0; i < group.length; i++) {
        group[i].visible = false;
    }
} 

// trimming
function Trim(up, left, down, right) {
    app.activeDocument.trim(TrimType.TOPLEFT, up, left, down, right);
}


// get coords of upper left and lower right angles
// of image after trimming
function getCoordinates(savedState) {
    var obj = { 
        name: app.activeDocument.activeLayer.name.toString(),
        left_x: 0, 
        left_y: 0,
        right_x: 0, 
        right_y: 0
    };
    var doc = app.activeDocument;
    // lower right
    Trim(false, false, true, true);
    obj.right_x = parseInt(doc.width.toString().replace(' px', ''));
    obj.right_y = parseInt(doc.height.toString().replace(' px', ''));

    // upper left
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

function savePng(name, path) {
    var options = new ExportOptionsSaveForWeb();
    options.quality = 70;
    options.format = SaveDocumentType.JPEG;
    options.optimized = true;
    var path = new File(path + name + ".png");
    doc.exportDocument(path, ExportType.SAVEFORWEB,options);
}

function switchLayer(i) {
    layer.visible = false;
    doc.activeLayer =  group[i];
    layer = doc.activeLayer;
    layer.visible = true;
}
