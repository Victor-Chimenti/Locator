/**
 * @author Victor Chimenti
 * @file cardMarkerDisplay.js
 */




// this fires on change from the wrapper and can access records but not visible items
$(function viewCards() {
    $('#filterSearch-wrapper').change(function () {
        console.log("cardMarkerDisplay");
        records.forEach(function (item) {
            console.log("record id: " + item.locationId);
        });
        gMarker.forEach(function (item) {
            console.log("visibleItems id: " + item.locationId);
        });
    });
});