 "use strict";
//-----------------------start_Main_block------------------------------
    //possibility performance 
    var canWork = true;

    //default path
    var beginerPath = "D:/Programming/JavaScript/PStask/img/";

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
    }
//-----------------------end_Main_block------------------------------

    //var pos = getLayerBounds(curLayerRef);
    //alert("x: " + pos[0].value + ", y: " + pos[1].value);
   // alert(getLayerBounds(curLayerRef));

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

    //save file as ".png"
    function saveLayer(sLayerName){
        var path = new File(beginerPath + sLayerName + ".png");
        var saveAsPNG = new PNGSaveOptions();
        saveAsPNG.formatOptions = FormatOptions.STANDARDBASELINE;
        saveAsPNG.quality = 11;
        app.activeDocument.saveAs(path, saveAsPNG, true, Extension.LOWERCASE);
    }

    //trim a layer
    function layerTrim(top, left, bottom, right){
        curDocumentRef.trim(TrimType.TOPLEFT, top, left, bottom, right);
    }

    // return bounds of a layer
    function getLayerBounds(layer){
        return layer.bounds;
    }

    //save a cuts layer
    function saveCutLayer(){
        for(var j = 0; j < curLayersRef.length; j++)
        {
            layerByLayer(false);
            setNextLayer(j);
            var currentState = curDocumentRef.activeHistoryState;
            layerTrim(true, true, true, true);
            saveLayer(curLayersRef[j].name);
            curDocumentRef.activeHistoryState = currentState;
        }
    }
