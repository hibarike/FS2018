 "use strict";

    //current data
    var curLayer = app.activeDocument.activeLayer;
    var curLayers = app.activeDocument.artLayers.parent.layers;
    var curDocument = app.activeDocument;
    var beginerPath = "D:/Programming/JavaScript/PS/";

    hello();

    function hello(){
        // alert("previos name is " + curLayer.name);
        // curLayer.name = "first_layer";
        //curLayer.visible = false;

        for(var i = 0; i < curLayers.length; i++){
            curLayers[i].visible = false;
        }
    }

    function saveLayer(layer)
    {
        
        var path = new File(layer + ".png");
        var saveAsPNG = new PNGSaveOptions();
        saveAsPNG.formatOptions = FormatOptions.STANDARDBASELINE;
        saveAsPNG.quality = 11;

    }