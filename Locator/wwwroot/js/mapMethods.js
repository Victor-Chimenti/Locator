/**
 * @author Victor Chimenti
 * @file mapMethods.js
 */





// drop a marker on each atm provided by the database
function createMarkerFromJsonRecord(record, i) {
    atmMarker = new google.maps.Marker({
        map: map,
        position: record.position,
        title: rawName,
        id: markerId
    });




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


// function validateOnlyUserPosition
//function validateOnlyUserPosition(pos) {
//    console.log("userPosition: ", pos);
//}

//function ajaxCallResult(result) {
//    return result;
//}

//function returnValueToController(lat, lng) {
//    $.ajax({
//        traditional: true,
//        url: "/LocationsController/GetUserCoords",
//        type: "GET",
//        data: {},
//        contentType: 'application/json',
//        dataType: "json",
//        success: function (result) {
//            ajaxCallResult(result);
//        },
//        error: function (req, status, error) {
//            ajaxCallResult("error");
//        }
//    });
//}

//function showError() {
//    alert("Error: Geolocation is not supported by this browser.");
//}

//// assign users coordinates
//function assignPosition(position) {
//    var lat = position.coords.latitude;
//    var lng = position.coords.longitude;
//    var userPosition = lat + ', ' + lng;
//    //validateOnlyUserPosition(userPosition);
//    returnValueToController(lat, lng);
//}

//// get users location on command
//function getLocation() {
//    if (navigator.geolocation) {
//        navigator.geolocation.getCurrentPosition(assignPosition, showError);
//    } else {
//        alert("Geolocation is not supported by current browser.");
//    }
//}