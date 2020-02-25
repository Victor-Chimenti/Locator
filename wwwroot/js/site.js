/**
 * @author Victor Chimenti
 * @file site.js
 */




// function validateOnlyUserPosition
//function validateOnlyUserPosition(pos) {
//    console.log("userPosition: ", pos);
//}

function ajaxCallResult(result) {
    return result;
}

function returnValueToController(lat, lng) {
    $.ajax({
        url: "/LocationsController/GetUserCoords",
        data: { lat: lat, lng: lng },
        dataType: "json",
        success: function (result) {
            ajaxCallResult(result);
        },
        error: function (req, status, error) {
            ajaxCallResult("error");
        }
    });
}

function showError() {
    alert("Geolocation is not supported by this browser.");
}

// assign users coordinates
function assignPosition(position) {
    var lat = position.coords.latitude;
    var lng = position.coords.longitude;
    var userPosition = lat + ', ' + lng;
    //validateOnlyUserPosition(userPosition);
    returnValueToController(lat, lng);
}

// get users location on command
function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(assignPosition, showError);
    } else {
        alert("Geolocation is not supported by this browser.");
    }
}