/**
 * @author Victor Chimenti
 * @file mapMethods.js
 */





// *** drop a marker on each atm provided by the database *** //
function createMarkerFromJsonRecord(record) {
    atmMarker = new google.maps.Marker({
        map: map,
        position: record.position,
        title: record.name,
        id: record.locationId
    });
};




// *** initiate production of map markers *** //  
function processRecords() {
    for (let i = 0; i < records.length; i++) {
        let record = records[i];
        createMarkerFromJsonRecord(record);
    }
};




// *** send get request to the locations controller for clean data *** //  
async function getJsonData() {
    $.ajax({
        traditional: true,
        url: '../locations/cardjson',
        type: "GET",
        data: {},
        contentType: 'application/json',
        success: function (data) {
            for (let i = 0; i < data.length; i++) {
                records[i] = data[i];
            }
        },
        error: function (jqXHR, exception) {
            alert('Internal Error : unable to parse locations record.');
        },
    }).done(function () {
        processRecords();
    });
};



            //var userPoint = data.ResultPoint;
            //var atmList = data.ResultList;
            //JSON.parse(JSON.stringify(data));
            //var obj = $.parseJSON(data);
            //for (key in obj) {
            //    if (obj.hasOwnProperty(key)) {
            //        var value = obj[key];
            //        userPoint = value;
            //    }
            //}
            //if (data.hasOwnProperty(ResultPoint)) {
            //    userPoint = data.ResultPoint;
            //}
            //if (data.hasOwnProperty(ResultList)) {
            //    atmList = data.ResultList;
            //}
            //console.log("point" + userPoint);
             // load the json objects into a global array