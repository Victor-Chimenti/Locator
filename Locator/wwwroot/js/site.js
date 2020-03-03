/**
 * @author Victor Chimenti
 * @file site.js
 */


//var atmSearchClasses = new Array("Hours", "DriveThruOnly", "Surcharge", "AcceptDeposit");
//var nfcSearchClasses = new Array("DriveThruOnly", "CoinStar", "TellerServices", "_24hourExpressBox", "PartnerCreditUnion", "MemberConsultant", "InstantDebitCardReplacement");
var visibleItems = [];



// check results for null
$(function assignVisibleItems() {
    // assign array of currently visible content items
    visibleItems = $('.card').not('.hideByText,' +
        ' .hideByHours,' +
        ' .hideByDriveThruOnly,' +
        ' .hideBySurcharge,' +
        ' .hideByAcceptDeposit,' +
        ' .hideByCoinStar,' +
        ' .hideByTellerServices,' +
        ' .hideBy_24hourExpressBox,' +
        ' .hideByPartnerCreditUnion,' +
        ' .hideByMemberConsultant,' +
        ' .hideByInstantDebitCardReplacement');
    // check to see if array is empty
    if (visibleItems.length == 0) {
        // when array is empty show the results message
        $('.noResultsToShow').removeClass('hideResultsMessage');
    } else {
        // when array has content items suppress the results message
        $('.noResultsToShow').addClass('hideResultsMessage');
    }
});
