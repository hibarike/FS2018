 "use strict";

//@includepath "~/JSON Action Manager/"
//@include "jamEngine.jsxinc"
//@include "jamJSON.jsxinc" 

//-----------------------start_Main_block------------------------------
    //possibility performance 
    var canWork = true;

    //default path
    var beginerPath = "D:/Programming/JavaScript/PStask/";
    //layerData
     dataJSON = {
        coordinates : [] 
     };

    //current data
    try{
        var curLayerRef = app.activeDocument.activeLayer;
        var curLayersRef = app.activeDocument.artLayers.parent.layers;
        var curDocumentRef = app.activeDocument;
        canWork = true;
    }
    catch(e){
        canWork = false;
        alert("Document or layer not found.");
    }

    //if script can work
    if(canWork){
        saveCutLayer();
        layerByLayer(true);
        createDataJSON(dataJSON);
    }
//-----------------------end_Main_block------------------------------

    //make every layer visible/invisible
    function layerByLayer(paramInvis){
        for(var i = 0; i < curLayersRef.length; i++){
            curLayersRef[i].visible = paramInvis;
        }
    }

    //set new active layer
    function setNextLayer(layerID){
        layerByLayer(false);
        curLayersRef[layerID].visible = true;
        curDocumentRef.activeLayer = curLayersRef[layerID];
    }

    //creating data file with coordinates
    function createDataJSON(coordData){
        var jsonFile = new File(beginerPath + "data/CoordData.json");
        if(jsonFile.open("w")) {
            jsonFile.encoding = "UTF-8";
            jsonFile.write(jamJSON.stringify(coordData));
            jsonFile.close;
        }
    }

    //save file as ".png"
    function saveLayer(sLayerName){
        var path = new File(beginerPath +"img/" + sLayerName + ".png");
        var saveAsPNG = new PNGSaveOptions();
        saveAsPNG.formatOptions = FormatOptions.STANDARDBASELINE;
        saveAsPNG.quality = 11;
        app.activeDocument.saveAs(path, saveAsPNG, true, Extension.LOWERCASE);
    }

    //trim a layer
    function layerTrim(top, left, bottom, right){
        curDocumentRef.trim(TrimType.TOPLEFT, top, left, bottom, right);
    }

    // set dataBounds and name of a layer
    function BoundsToCoords(layer){
        var pos = layer.bounds;
        
        var retData = {
            layerName : "",
            x1 : 0, x2 : 0,
            y1 : 0, y2 : 0
        };

        retData.layerName = layer.name;
        retData.x1 = parseInt(pos[0]); 
        retData.x2 = parseInt(pos[2]);
        retData.y1 = parseInt(pos[1]); 
        retData.y2 = parseInt(pos[3]);

        return retData;
        /*
            x1 = bounds[0], x2 = bounds[2]
            y1 = bounds[1], y2 = bounds[3]
        */
    }

    //save a cuts layer
    function saveCutLayer(){
        //use pixels for describing size properties
        // app.preferences.rulerUnits = Units.PIXELS;

        for(var j = 0; j < curLayersRef.length; j++)
        {
            //layerByLayer(false);
            setNextLayer(j);
            var currentState = curDocumentRef.activeHistoryState;
            dataJSON.coordinates.push(BoundsToCoords(curDocumentRef.activeLayer));
            layerTrim(true, true, true, true);
            saveLayer(curLayersRef[j].name);
            curDocumentRef.activeHistoryState = currentState;
        }
    }
