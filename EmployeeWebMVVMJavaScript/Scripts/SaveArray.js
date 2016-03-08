//this is generic and can be put in a different .js file
function saveArray(itemsArray,/*you can not pass those*/prefix, excludeProp, recognizeFunction, validateProp) {
    var l = itemsArray.length;
    if (l == 0) {

        return "";
    }

    var propNames = refProps(itemsArray[0], excludeProp, recognizeFunction); // you can pass null on exclude to add all properties
    var nr = 0;
    var strData = "";
    for (var i = 0; i < l; i++) {
        var objToSave = itemsArray[i];
        //you can pass here another function to recognize which object can be saved
        //if(!canBeSaved(objSave) continue;
        for (var j = 0; j < propNames.length; j++) {
            var nameProp = propNames[j];
            var val = objToSave[nameProp];
            var t = (typeof val).toLowerCase();
            if (t == 'function') {
                val = objToSave[nameProp]();
            }

            if (validateProp) {
                if (!validateProp(nameProp, val, objToSave, i)) {
                    return "";
                }
            }
            strData += "&" + prefix + "[" + nr + "]." + nameProp;

            strData += "=" + val;
        }
        nr++;

    }
    return strData;
}
