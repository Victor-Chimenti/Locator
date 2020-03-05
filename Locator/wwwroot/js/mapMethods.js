/**
 * @author Victor Chimenti
 * @file mapMethods.js
 */





// *** drop a marker on each atm provided by the database *** //
function createMarkerFromJsonRecord(record, i) {
    atmMarker = new google.maps.Marker({
        map: map,
        position: record.Position,
        title: record.Name,
        id: record.LocationId
    });
};




// *** initiate production of map markers *** //  
function processRecords() {
    for (let i = 0; i < records.length; i++) {
        let record = records[i];
        createMarkerFromJsonRecord(record, i);
    }
};




// *** send get request to the locations controller for clean data *** //  
function getJsonData() {
    $.ajax({
        traditional: true,
        url: '/LocationsController/CardJson',
        type: "GET",
        data: {},
        contentType: 'application/json',
        dataType: 'json',
        success: function (data) {
            // load the json objects into a global array
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
