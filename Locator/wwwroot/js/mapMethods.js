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



function createSearchAreaMarker(user) {

    // drop pin on user location
    var userMarker = new google.maps.Marker({
        animation: google.maps.Animation.DROP,
        icon: {
            path: google.maps.SymbolPath.CIRCLE,
            fillColor: '#4470D6',
            fillOpacity: 1,
            scale: 9,
            strokeColor: '#F4F5F5',
            strokeWeight: 3
        },
        map: map,
        position: new google.maps.LatLng(user.lat, user.lng),
        title: 'My Location',
    });

    // center and zoom map on user location
    map.setCenter(user);
    map.setZoom(15);


    //map.setCenter(userMarker.getPosition());


    // double click on user location marker to delete it
    userMarker.addListener('dblclick', function () {
        userMarker.setMap(null);
    });
}




// *** initiate production of map markers *** //  
function processRecords(searchArea) {
    for (let i = 0; i < records.length; i++) {
        let record = records[i];
        createMarkerFromJsonRecord(record);
    }
    createSearchAreaMarker(searchArea);
};




// *** send get request to the locations controller for clean data *** //  
async function getJsonData() {

    // assign function scope variables to unmarshal json object
    var doubleLat;
    var doubleLng;
    var userPosition = {}

    $.ajax({
        traditional: true,
        url: '../locations/cardjson',
        type: "GET",
        data: {},
        contentType: 'application/json',
        success: function (data) {

            // process and assign location data
            doubleLat = parseFloat(data.point.lat);
            doubleLng = parseFloat(data.point.lng);
            userPosition = { lat: doubleLat, lng: doubleLng };

            // add clean location list to global js array
            for (let i = 0; i < data.cleanLocationList.length; i++) {
                records[i] = data.cleanLocationList[i];
            }
        },

        error: function (xhr, status, error) {
            var err = JSON.parse(xhr.responseText);
            alert(err.Message);
        },

    }).done(function () {

        // initiate call to map marker functions
        processRecords(userPosition);
    });
};
