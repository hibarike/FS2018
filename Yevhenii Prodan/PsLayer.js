//The program saves each layer as individual file, and save json file with properties for each layers
var doc = app.activeDocument;//Get the currently opened Photoshop document

if(doc.layers.length > 1)
{  
 var folder = new Folder(doc.path+"/PsLayers")
    if(!folder.exists)
        folder.create()
    saveLayers(doc);
    saveJson(doc);
}


function saveLayers(doc)
{
    var length = doc.layers.length;                         // Layer's count
    var State = doc.historyStates[0];                     // Snapshot
    var layerName;
    //Hide all the layers
    for(var i=0; i<length-1; i++) {
        for(var j=0; j<length-1; j++) {
            doc.layers[j].visible = false;
        }
        doc.layers[length - i - 2].visible = true;
        doc.trim();
        layerName = doc.layers[length - i - 2].name;        // Get layer name
        var file = new File(doc.path  + '/PsLayers/' + layerName + '.png');


        var options = new PNGSaveOptions();
        options.quality = 10;

        doc.saveAs(file, options, true);
        doc.activeHistoryState = State;                   // Back to start state(snapshot)
    }

    for(var i=0; i<length; i++) {
        doc.layers[i].visible = true;
    }



    
}


function saveJson(doc) {
     var length = doc.layers.length - 1;
     var file = new File(doc.path + "/PsLayers/PhotoshopJson.json");
    file.open("w");
    for (var i = 0; i <= length; i++) {
        var layerName = doc.layers[length - i].name; // Get layer name
        var layerPosition = doc.layers[length - i].bounds; // Get position of the layer
        file.write('"' + layerName + '": {\n');
        file.write('    "layerPosition": "' + layerPosition + '",\n');
        file.write('    "layerPath": "' + doc.path + '/PsLayers/' + layerName + '.png"\n' + "}\n");
    }
    file.close();
}