/**
 * @author Victor Chimenti
 * @file site.js
 */


                    //if ($(".InstallationType:contains('drive')")) {
                    //    $('.card').removeClass('hideByDriveThruOnly');
                    //}

//var searchClasses = [];
var atmSearchClasses = new Array("Hours", "DriveThruOnly", "Surcharge", "AcceptDeposit");
var nfcSearchClasses = new Array("DriveThruOnly", "CoinStar", "TellerServices", "_24hourExpressBox", "PartnerCreditUnion", "MemberConsultant", "InstantDebitCardReplacement");
var visibleItems = [];



// check results for null
//$(function assignVisibleItems() {
//    // assign array of currently visible content items
//    visibleItems = $('.card').not('.hideByText,' +
//        ' .hideByHours,' +
//        ' .hideByDriveThruOnly,' +
//        ' .hideBySurcharge,' +
//        ' .hideByAcceptDeposit,' +
//        ' .hideByCoinStar,' +
//        ' .hideByTellerServices,' +
//        ' .hideBy_24hourExpressBox,' +
//        ' .hideByPartnerCreditUnion,' +
//        ' .hideByMemberConsultant,' +
//        ' .hideByInstantDebitCardReplacement');
//    // check to see if array is empty
//    if (visibleItems.length == 0) {
//        // when array is empty show the results message
//        $('.noResultsToShow').removeClass('hideResultsMessage');
//    } else {
//        // when array has content items suppress the results message
//        $('.noResultsToShow').addClass('hideResultsMessage');
//    }
//});




//   ***   Keyword Search   ***   //
$(function () {
    // After the DOM is ready, Wait until the window loads
    $(document).ready(function () {
        // Once window loads set a timeout delay
        setTimeout(function () {
            $(function () {
                // scan the keyword each character the user inputs
                $('#keyword_search').on('keyup', function () {
                    // Assign Search Key
                    var key = $(this).val().toLowerCase();
                    // filter the cards for the input key
                    $(function () {
                        $('.card').filter(function () {
                            // when the search key is not present in the item then hide the item
                            $(this).toggleClass('hideByText', !($(this).text().toLowerCase().indexOf(key) > -1));
                        });
                    });
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
                });
            });
            // Delay the .on keyup function
        }, 1);
    });
});




//   ***   24 Hours Filter   ***   //
$(function () {
    // After the DOM is ready, Wait until the window loads
    $(document).ready(function () {
        // Once window loads set a timeout delay
        setTimeout(function () {
            $(function () {
                // When the select box Hours changes - Execute change function
                $('#Hours').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the Hours card items in card
                    if ($('#Hours:checkbox').is(':checked', true)) {
                        if (key) {
                            $('.Hours').filter(function (i, e) {
                                var value = $(this).text();
                                // Check to see if the Key and Value are a Match
                                if (value.match(key)) {
                                    $(this).parents('.card').removeClass('hideByHours');
                                } else {
                                    $(this).parents('.card').addClass('hideByHours');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideByHours');
                        }
                    } else {
                        $('.card').removeClass('hideByHours');
                    }
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
                });
            });
            // Delay the change function
        }, 1);
    });
});




//   ***   Drive Thru Only   ***   //
$(function () {
    // After the DOM is ready, Wait until the window loads
    $(document).ready(function () {
        // Once window loads set a timeout delay
        setTimeout(function () {
            $(function () {
                // When the select box Drive Thru changes - Execute change function
                $('#DriveThruOnly').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the Drive Thru card items
                    if ($('#DriveThruOnly:checkbox').is(':checked', true)) {
                        if (key) {
                            $('.DriveThruOnly').filter(function (i, e) {
                                console.log("surcharge key:" + key);

                                var value = $(this).attr('data-value');
                                console.log("surcharge value:" + value);

                                // Check to see if the Key and Value are a Match
                                if (key === value) {
                                    $(this).parents('.card').removeClass('hideByDriveThruOnly');
                                } else {
                                    $(this).parents('.card').addClass('hideByDriveThruOnly');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideByDriveThruOnly');
                        }
                    } else {
                        $('.card').removeClass('hideByDriveThruOnly');
                    }
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
                });
            });
            // Delay the change function
        }, 1);
    });
});




//   ***   Surcharge   ***   //
$(function () {
    // After the DOM is ready, Wait until the window loads
    $(document).ready(function () {
        // Once window loads set a timeout delay
        setTimeout(function () {
            $(function () {
                // When the select box Drive Thru changes - Execute change function
                $('#Surcharge').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the Drive Thru card items
                    if ($('#Surcharge:checkbox').is(':checked', true)) {
                        if (key) {
                            $('.Surcharge').filter(function (i, e) {
                                var value = $(this).attr('data-value');
                                // Check to see if the Key and Value are a Match
                                if (key === value) {
                                    $(this).parents('.card').removeClass('hideBySurcharge');
                                } else {
                                    $(this).parents('.card').addClass('hideBySurcharge');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideBySurcharge');
                        }
                    } else {
                        $('.card').removeClass('hideBySurcharge');
                    }
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
                });
            });
            // Delay the change function
        }, 1);
    });
});




//   ***   Accepts Deposits   ***   //
$(function () {
    // After the DOM is ready, Wait until the window loads
    $(document).ready(function () {
        // Once window loads set a timeout delay
        setTimeout(function () {
            $(function () {
                // When the select box Drive Thru changes - Execute change function
                $('#AcceptDeposit').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the Drive Thru card items
                    if ($('#AcceptDeposit:checkbox').is(':checked', true)) {
                        if (key) {
                            $('.AcceptDeposit').filter(function (i, e) {
                                var value = $(this).attr('data-value');
                                // Check to see if the Key and Value are a Match
                                if (key === value) {
                                    $(this).parents('.card').removeClass('hideByAcceptDeposit');
                                } else {
                                    $(this).parents('.card').addClass('hideByAcceptDeposit');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideByAcceptDeposit');
                        }
                    } else {
                        $('.card').removeClass('hideByAcceptDeposit');
                    }
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
                });
            });
            // Delay the change function
        }, 1);
    });
});




