/**
 * @author Victor Chimenti
 * @file filterCards.js
 */




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
                });
                assignVisibleItems();
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
                    assignVisibleItems();
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
                                var value = $(this).attr('data-value');
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
                    assignVisibleItems();
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
                    assignVisibleItems();
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
                    assignVisibleItems();
                });
            });
            // Delay the change function
        }, 1);
    });
});




//   ***   Coin Star   ***   //
$(function () {
    // After the DOM is ready, Wait until the window loads
    $(document).ready(function () {
        // Once window loads set a timeout delay
        setTimeout(function () {
            $(function () {
                // When the select box Drive Thru changes - Execute change function
                $('#CoinStar').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the Drive Thru card items
                    if ($('#CoinStar:checkbox').is(':checked', true)) {
                        if (key) {
                            $('.CoinStar').filter(function (i, e) {
                                var value = $(this).attr('data-value');
                                // Check to see if the Key and Value are a Match
                                if (key === value) {
                                    $(this).parents('.card').removeClass('hideByCoinStar');
                                } else {
                                    $(this).parents('.card').addClass('hideByCoinStar');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideByCoinStar');
                        }
                    } else {
                        $('.card').removeClass('hideByCoinStar');
                    }
                    assignVisibleItems();
                });
            });
            // Delay the change function
        }, 1);
    });
});




//   ***   Teller Services   ***   //
$(function () {
    // After the DOM is ready, Wait until the window loads
    $(document).ready(function () {
        // Once window loads set a timeout delay
        setTimeout(function () {
            $(function () {
                // When the select box Drive Thru changes - Execute change function
                $('#TellerServices').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the Drive Thru card items
                    if ($('#TellerServices:checkbox').is(':checked', true)) {
                        if (key) {
                            $('.TellerServices').filter(function (i, e) {
                                var value = $(this).attr('data-value');
                                // Check to see if the Key and Value are a Match
                                if (key === value) {
                                    $(this).parents('.card').removeClass('hideByTellerServices');
                                } else {
                                    $(this).parents('.card').addClass('hideByTellerServices');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideByTellerServices');
                        }
                    } else {
                        $('.card').removeClass('hideByTellerServices');
                    }
                    assignVisibleItems();
                });
            });
            // Delay the change function
        }, 1);
    });
});




//   ***   24 Hour Express Box   ***   //
$(function () {
    // After the DOM is ready, Wait until the window loads
    $(document).ready(function () {
        // Once window loads set a timeout delay
        setTimeout(function () {
            $(function () {
                // When the select box Drive Thru changes - Execute change function
                $('#_24hourExpressBox').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the Drive Thru card items
                    if ($('#_24hourExpressBox:checkbox').is(':checked', true)) {
                        if (key) {
                            $('._24hourExpressBox').filter(function (i, e) {
                                var value = $(this).attr('data-value');
                                // Check to see if the Key and Value are a Match
                                if (key === value) {
                                    $(this).parents('.card').removeClass('hideBy_24hourExpressBox');
                                } else {
                                    $(this).parents('.card').addClass('hideBy_24hourExpressBox');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideBy_24hourExpressBox');
                        }
                    } else {
                        $('.card').removeClass('hideBy_24hourExpressBox');
                    }
                    assignVisibleItems();
                });
            });
            // Delay the change function
        }, 1);
    });
});




//   ***   Partner Credit Union   ***   //
$(function () {
    // After the DOM is ready, Wait until the window loads
    $(document).ready(function () {
        // Once window loads set a timeout delay
        setTimeout(function () {
            $(function () {
                // When the select box Drive Thru changes - Execute change function
                $('#PartnerCreditUnion').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the Drive Thru card items
                    if ($('#PartnerCreditUnion:checkbox').is(':checked', true)) {
                        if (key) {
                            $('.PartnerCreditUnion').filter(function (i, e) {
                                var value = $(this).attr('data-value');
                                // Check to see if the Key and Value are a Match
                                if (key === value) {
                                    $(this).parents('.card').removeClass('hideByPartnerCreditUnion');
                                } else {
                                    $(this).parents('.card').addClass('hideByPartnerCreditUnion');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideByPartnerCreditUnion');
                        }
                    } else {
                        $('.card').removeClass('hideByPartnerCreditUnion');
                    }
                    assignVisibleItems();
                });
            });
            // Delay the change function
        }, 1);
    });
});




//   ***   Member Consultant   ***   //
$(function () {
    // After the DOM is ready, Wait until the window loads
    $(document).ready(function () {
        // Once window loads set a timeout delay
        setTimeout(function () {
            $(function () {
                // When the select box Drive Thru changes - Execute change function
                $('#MemberConsultant').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the Drive Thru card items
                    if ($('#MemberConsultant:checkbox').is(':checked', true)) {
                        if (key) {
                            $('.MemberConsultant').filter(function (i, e) {
                                var value = $(this).attr('data-value');
                                // Check to see if the Key and Value are a Match
                                if (key === value) {
                                    $(this).parents('.card').removeClass('hideByMemberConsultant');
                                } else {
                                    $(this).parents('.card').addClass('hideByMemberConsultant');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideByMemberConsultant');
                        }
                    } else {
                        $('.card').removeClass('hideByMemberConsultant');
                    }
                    assignVisibleItems();
                });
            });
            // Delay the change function
        }, 1);
    });
});




//   ***   Instant Debit Card Replacement   ***   //
$(function () {
    // After the DOM is ready, Wait until the window loads
    $(document).ready(function () {
        // Once window loads set a timeout delay
        setTimeout(function () {
            $(function () {
                // When the select box Drive Thru changes - Execute change function
                $('#InstantDebitCardReplacement').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the Drive Thru card items
                    if ($('#InstantDebitCardReplacement:checkbox').is(':checked', true)) {
                        if (key) {
                            $('.InstantDebitCardReplacement').filter(function (i, e) {
                                var value = $(this).attr('data-value');
                                // Check to see if the Key and Value are a Match
                                if (key === value) {
                                    $(this).parents('.card').removeClass('hideByInstantDebitCardReplacement');
                                } else {
                                    $(this).parents('.card').addClass('hideByInstantDebitCardReplacement');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideByInstantDebitCardReplacement');
                        }
                    } else {
                        $('.card').removeClass('hideByInstantDebitCardReplacement');
                    }
                    assignVisibleItems();
                });
            });
            // Delay the change function
        }, 1);
    });
});
