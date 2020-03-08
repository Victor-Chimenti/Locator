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
            //var json = JSON.parse(data);
            //var myJSON = JSON.stringify(json);
            //var newData = userData.data.userList;
            console.log("data: " + data);
            userPosition = JSON.stringify(data.point);
            //var incommingList = JSON.parse(data.cleanResults.CleanLocationList);

            console.log("userPosition: " + userPosition);
            //console.log("incommingList: " + incommingList);
            // load the json objects into a global array
            for (let i = 0; i < data.cleanLocationList.length; i++) {
                records[i] = data.cleanLocationList[i];
            }
        },
        error: function (xhr, status, error) {
            var err = JSON.parse(xhr.responseText);
            alert(err.Message);
        },
        //error: function (jqXHR, exception) {
        //    //alert('Internal Error : unable to parse locations record.');
        //},
    }).done(function () {
        processRecords();
    });
};
