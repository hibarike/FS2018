function saveLayers() {
    var length = app.activeDocument.artLayers.length;
    if (length !== 0) {
        var OriginalUnit = preferences.rulerUnits;
        preferences.rulerUnits = Units.PIXELS;
        var saveState = app.activeDocument.activeHistoryState;
        var pngSaveOptions = new PNGSaveOptions();    

            for (var i = 0; i < length; i++) {
                for (var j = 0; j < length; j++) {
                    if (i == j) {
                        app.activeDocument.artLayers[j].visible = true;
                    }
                    else {
                        app.activeDocument.artLayers[j].visible = false;
                    }
                }

                var fileName = app.activeDocument.artLayers[i].name + ".png";
                app.activeDocument.trim(TrimType.TOPLEFT, true, true, true, true);
                pngFile = new File(Folder.desktop + "/" + fileName);
                app.activeDocument.saveAs(pngFile, pngSaveOptions, true, Extension.LOWERCASE);
                
                app.activeDocument.activeHistoryState = saveState;
            }
        preferences.rulerUnits = OriginalUnit;
    }
    return;
}
 
function saveToJSON() {
    var length = app.activeDocument.artLayers.length;
    if (length !== 0) {

        var file = new File(Folder.desktop + "/layers.json");
        file.open("w");
        file.write("{\n\"layers\":[");
         for (var i = 0; i < length; i++) {
           
            var position = app.activeDocument.artLayers[i].bounds;  //An array of coordinates that describes the bounding rectangle of the layer.
            var x1 = position[0].value;
            var y1 = position[1].value;
            var x2 = position[2].value;
            var y2 = position[3].value;
            var fileName = app.activeDocument.artLayers[i].name + ".png";
            file.write("\n\t{\"name\":" + "\"" + fileName + "\"" + ", \"x1\":" + "\"" + x1 + "\"" + ", \"y1\":" + "\"" + y1 + "\"" +
            ", \"x2\":" + "\"" + x2 + "\"" + ", \"y2\":" + "\"" + y2 + "\"}");
            if ((i + 1) < length) {
                file.write(",");
            }
        }
        file.write("\n]\n}");
        file.close();
    }
    return;
} 

saveLayers();
saveToJSON();
alert("Done!");
