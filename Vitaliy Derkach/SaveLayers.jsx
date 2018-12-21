//Appointment: saves all layers of document as PNG files and creates new JSON file, which contains PNG filename and the position of  layers of document
if (app.documents.length !== 0) {
    SaveLayersToPNG(app.activeDocument);
    LayersToJSON(app.activeDocument);
}


//Saves all layers of document as PNG files
function SaveLayersToPNG(doc) {
    
    var length = doc.artLayers.length;
    if (length !== 0) {
        var OriginalUnit = preferences.rulerUnits;
        preferences.rulerUnits = Units.PIXELS;
        var lengthState = doc.historyStates.length;
        var saveState = doc.activeHistoryState;
        var pngSaveOptions = new PNGSaveOptions();
        var folder = new Folder(Folder.desktop + "/Vitaliy_Derkach/Photoshop_test/ps_layers");
        if (!folder.exists) {
            folder.create();
        }
        if (length !== 1) {
            for (var i = 0; i < length; i++) {
                for (var j = 0; j < length; j++) {
                    if (i == j) {
                        doc.artLayers[j].visible = true;
                    }
                    else {
                        doc.artLayers[j].visible = false;
                    }
                }
                var handle = doc.artLayers[i].name + ".png";
                doc.trim(TrimType.TOPLEFT, false, false, false, false) //Trims the transparent area around the image
                jpgFile = new File(Folder.desktop + "/Vitaliy_Derkach/Photoshop_test/ps_layers/" + handle);
                doc.saveAs(jpgFile, pngSaveOptions, true, Extension.LOWERCASE);
            }


        }
        else {
            var handle = doc.artLayers[0].name + ".png";
            jpgFile = new File(Folder.desktop + "/Vitaliy_Derkach/Photoshop_test/ps_layers/" + handle);
            doc.saveAs(jpgFile, pngSaveOptions, true, Extension.LOWERCASE);
        }
        doc.activeHistoryState = doc.historyStates[lengthState - 1];
        app.purge(PurgeTarget.UNDOCACHES);
        doc.activeHistoryState = saveState;
        preferences.rulerUnits = OriginalUnit;
    }
    return;
}

// Creates new JSON file, which contains PNG filename and the position of  layers of document
function LayersToJSON(doc) {
    var length = doc.artLayers.length;
    if (length !== 0) {
        var folder = new Folder(Folder.desktop + "/Vitaliy_Derkach/Photoshop_test/scripts");
        if (!folder.exists) {
            folder.create();
        }
        var file = new File(Folder.desktop + "/Vitaliy_Derkach/Photoshop_test/scripts/ps_layers.json");
        file.open("w");
        file.write("{\n\"layers\":[");

        for (var i = 0; i < length; i++) {
           
            var position = doc.artLayers[i].bounds;  //An array of coordinates that describes the bounding rectangle of the layer.
            var x1 = position[0].value;
            var y1 = position[1].value;
            var x2 = position[2].value;
            var y2 = position[3].value;
            var handle = doc.artLayers[i].name + ".png";
            file.write("\n\t{\"name\":" + "\"" + handle + "\"" + ", \"x1\":" + "\"" + x1 + "\"" + ", \"y1\":" + "\"" + y1 + "\"" +
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