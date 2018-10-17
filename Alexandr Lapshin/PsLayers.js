// The program saves all layer in PNG files and layer's properties in JSON file
var doc = app.activeDocument;

if (doc.layers.length != 0) {
    savePng();
    saveJson();
}

// savePng saves all layers in files with name "layername.png"
function savePng() {
    var length = doc.layers.length - 1;
    var currentState = doc.historyStates[0]; // Snapshot
    var options = new PNGSaveOptions();
    options.quality = 12;

    var folder = new Folder(Folder.desktop + "/Photoshop");
    if (!folder.exists) {
        folder.create();
    }

    for (var i = 0; i <= length; i++) {
        for (var j = 0; j < length; j++) {
            doc.layers[j].visible = false;
        }
        doc.layers[length - i].visible = true;
        if (i != 0) doc.trim()
        var layerName = doc.layers[length - i].name; // Get layer name

        var file = new File(Folder.desktop + '/Photoshop/' + layerName + '.png');
        doc.saveAs(file, options, true);

        doc.activeHistoryState = currentState; // Back to start state(snapshot)
    }
}

// saveJson saves properties of layers in JSON file
function saveJson() {
    var length = doc.layers.length - 1;

    var folder = new Folder(Folder.desktop + "/Photoshop");
    if (!folder.exists) {
        folder.create();
    }

    var file = new File(Folder.desktop + "/Photoshop/PhotoshopJson.json");
    file.open("w");
    for (var i = 0; i <= length; i++) {
        var layerName = doc.layers[length - i].name; // Get layer name
        var layerPosition = doc.layers[length - i].bounds; // Get position of the layer
        file.write('"' + layerName + '": {\n');
        file.write('    "layerPosition": "' + layerPosition + '",\n');
        file.write('    "layerPath": "' + Folder.desktop + '/Photoshop/' + layerName + '.png"\n' + "}\n");
    }
    file.close();
}