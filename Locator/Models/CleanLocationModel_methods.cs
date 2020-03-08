using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLibrary.Models;

namespace Locator.Models
{
    public partial class CleanLocationModel
    {

        public CleanLocationModel(Locations data)
        {
            // assign locations model attributes
            if (data != null)
            {
                if (!string.IsNullOrEmpty(data.LocationId))
                {
                    LocationId = data.LocationId;
                }
                if (!string.IsNullOrEmpty(data.Name))
                {
                    Name = data.Name;
                }
                if (!string.IsNullOrEmpty(data.LocationType))
                {
                    LocationType = LocationTypeEnumHelper.StringToEnum(data.LocationType);
                    LocationTypeCode = LocationType.ToTitle();
                }
                if (!string.IsNullOrEmpty(data.Address))
                {
                    Address = data.Address;
                }
                if (!string.IsNullOrEmpty(data.City))
                {
                    City = data.City;
                }
                if (!string.IsNullOrEmpty(data.PostalCode))
                {
                    PostalCode = data.PostalCode;
                }
                if (!string.IsNullOrEmpty(data.State))
                {
                    State = StateEnumHelper.StringToEnum(data.State);
                    StateTitle = State.ToTitle();
                }
                if (!string.IsNullOrEmpty(data.Country))
                {
                    Country = data.Country;
                }
                if (!string.IsNullOrEmpty(data.RetailOutlet))
                {
                    RetailOutlet = data.RetailOutlet;
                }
                if (!string.IsNullOrEmpty(data.Hours))
                {
                    Hours = data.Hours;
                }
                if (!data.Latitude.Equals(null))
                {
                    Latitude = data.Latitude;
                }
                if (!data.Longitude.Equals(null))
                {
                    Longitude = data.Longitude;
                }


                // create a lat lng object for google map
                if ((!Latitude.Equals(null)) && (!Longitude.Equals(null)))
                {
                    Position = new PositionModel(Latitude, Longitude);
                }
            }



            // assign contact model attributes
            if (data.Contact != null)
            {
                if (!string.IsNullOrEmpty(data.Contact.Phone))
                {
                    Phone = data.Contact.Phone;
                }

                if (!string.IsNullOrEmpty(data.Contact.WebAddress))
                {
                    var protocol = "http";
                    var secureProtocol = "https://";
                    var commercialDomain = ".com";
                    var netDomain = ".net";
                    var nonProfitDomain = ".org";
                    if (!data.Contact.WebAddress.Contains(protocol))
                    {
                        if (data.Contact.WebAddress.Contains(commercialDomain) || data.Contact.WebAddress.Contains(netDomain) || data.Contact.WebAddress.Contains(nonProfitDomain))
                        {
                            WebAddress = secureProtocol + data.Contact.WebAddress;
                        }
                    }
                    else
                    {
                        if (data.Contact.WebAddress.Contains(commercialDomain) || data.Contact.WebAddress.Contains(netDomain) || data.Contact.WebAddress.Contains(nonProfitDomain))
                        {
                            WebAddress = data.Contact.WebAddress;
                        }
                    }
                }
            }


            // assign special qualities model attributes
            if (data.SpecialQualities != null)
            {
                if (!string.IsNullOrEmpty(data.SpecialQualities.HandicapAccess))
                {
                    HandicapAccess = BoolEnumHelper.StringToEnum(data.SpecialQualities.HandicapAccess);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.Surcharge))
                {
                    Surcharge = BoolEnumHelper.StringToEnum(data.SpecialQualities.Surcharge);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.DriveThruOnly))
                {
                    DriveThruOnly = BoolEnumHelper.StringToEnum(data.SpecialQualities.DriveThruOnly);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.RestrictedAccess))
                {
                    RestrictedAccess = BoolEnumHelper.StringToEnum(data.SpecialQualities.RestrictedAccess);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.AcceptDeposit))
                {
                    AcceptDeposit = BoolEnumHelper.StringToEnum(data.SpecialQualities.AcceptDeposit);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.AcceptCash))
                {
                    AcceptCash = BoolEnumHelper.StringToEnum(data.SpecialQualities.AcceptCash);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.Cashless))
                {
                    Cashless = BoolEnumHelper.StringToEnum(data.SpecialQualities.Cashless);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.SelfServiceDevice))
                {
                    SelfServiceOnly = BoolEnumHelper.StringToEnum(data.SpecialQualities.SelfServiceDevice);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.SelfServiceOnly))
                {
                    SelfServiceOnly = BoolEnumHelper.StringToEnum(data.SpecialQualities.SelfServiceOnly);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.OnMilitaryBase))
                {
                    OnMilitaryBase = BoolEnumHelper.StringToEnum(data.SpecialQualities.OnMilitaryBase);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.MilitaryIdRequired))
                {
                    MilitaryIdRequired = BoolEnumHelper.StringToEnum(data.SpecialQualities.MilitaryIdRequired);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.CoinStar))
                {
                    CoinStar = BoolEnumHelper.StringToEnum(data.SpecialQualities.CoinStar);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.TellerServices))
                {
                    TellerServices = BoolEnumHelper.StringToEnum(data.SpecialQualities.TellerServices);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities._24hourExpressBox))
                {
                    _24hourExpressBox = BoolEnumHelper.StringToEnum(data.SpecialQualities._24hourExpressBox);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.PartnerCreditUnion))
                {
                    PartnerCreditUnion = BoolEnumHelper.StringToEnum(data.SpecialQualities.PartnerCreditUnion);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.MemberConsultant))
                {
                    MemberConsultant = BoolEnumHelper.StringToEnum(data.SpecialQualities.MemberConsultant);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.InstantDebitCardReplacement))
                {
                    InstantDebitCardReplacement = BoolEnumHelper.StringToEnum(data.SpecialQualities.InstantDebitCardReplacement);
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.InstallationType))
                {
                    InstallationType = data.SpecialQualities.InstallationType;
                }
                if (!string.IsNullOrEmpty(data.SpecialQualities.AccessNotes))
                {
                    AccessNotes = data.SpecialQualities.AccessNotes;
                }

                // call to generate list for razor page
                SubTitleDisplayList = GetSubTitleDisplayStrings();
                ListBlockDisplayList = GetListDisplayStrings();
                FooterBlockQuoteDisplay = GetFooterBlockQuoteDisplayStrings();
            }
        }




        // attributes with legit values get new html tags built
        public string BuildSubTitleDisplayTag(string Key, string Display, string Title)
        {
            var subTitle = string.Format(@"<p class=""subTitle {0} empty""></p>", Key);

            if (!string.IsNullOrEmpty(Title))
            {
                subTitle = string.Format(@"<p class=""subTitle {0}"" value='{2}'> {1}: {2} </p>", Key, Display, Title);
            }

            return subTitle;
        }

        public string GetSubTitleDisplayStrings()
        {
            // start an empty string
            SubTitleDisplayList = "";

            // declare attribute variables w/arguments
            SubTitleDisplayList += BuildSubTitleDisplayTag("Hours", "Hours", Hours);
            SubTitleDisplayList += BuildSubTitleDisplayTag("RetailOutlet", "Retail Outlet", RetailOutlet);
            SubTitleDisplayList += BuildSubTitleDisplayTag("InstallationType", "Installation Type", InstallationType);
            SubTitleDisplayList += BuildSubTitleDisplayTag("AccessNotes", "Notes", AccessNotes);


            return SubTitleDisplayList;
        }





        //<option class=""list-display {0}"" value=""{2}""></option>
        /// <summary>
        /// Use for Card Creation to improve performance for ajax
        /// </summary>

        // attributes with legit values get new html tags built
        public string BuildListBlockDisplayTag(string Key, string Label, string Value)
        {
            var listBlock = string.Format(@"<li class=""list-group-item""> {1}: <span class=""{0}"">{2}</span></li>", Key, Label, Value);

            return listBlock;
        }

        public string BuildDefaultListBlockDisplayTag(string Key)
        {
            var defaultListBlock = string.Format(@"<li class=""list-group-item {0} empty"">{0}</li>", Key);

            return defaultListBlock;
        }

        public string CreateBuildListBlockIfYes(string Key, string Label, string Value)
        {
            if (Value.Equals("Yes"))
            {
                return BuildListBlockDisplayTag(Key, Label, Value);
            }
            return BuildDefaultListBlockDisplayTag(Key);
        }

        public string CreateBuildListBlockIfNo(string Key, string Label, string Value)
        {
            if (Value.Equals("No"))
            {
                return BuildListBlockDisplayTag(Key, Label, Value);
            }
            return BuildDefaultListBlockDisplayTag(Key);
        }

        public string GetListDisplayStrings()
        {
            // start an empty string
            ListBlockDisplayList = "";

            // declare attribute variables w/arguments
            ListBlockDisplayList += CreateBuildListBlockIfYes("HandicapAccess", "Handicap Access", HandicapAccess.ToTitle());
            ListBlockDisplayList += CreateBuildListBlockIfNo("Surcharge", "Surcharge", Surcharge.ToTitle());
            ListBlockDisplayList += CreateBuildListBlockIfYes("DriveThruOnly", "Drive Thru Only", DriveThruOnly.ToTitle());
            ListBlockDisplayList += CreateBuildListBlockIfYes("AcceptsDeposits", "Accepts Deposits", AcceptDeposit.ToTitle());
            ListBlockDisplayList += CreateBuildListBlockIfYes("AcceptsCash", "Accepts Cash", AcceptCash.ToTitle());
            ListBlockDisplayList += CreateBuildListBlockIfYes("Cashless", "Cashless", Cashless.ToTitle());
            ListBlockDisplayList += CreateBuildListBlockIfYes("SelfServiceDevice", "Self Service Device", SelfServiceDevice.ToTitle());
            ListBlockDisplayList += CreateBuildListBlockIfYes("SelfServiceOnly", "Self Service Only", SelfServiceOnly.ToTitle());
            ListBlockDisplayList += CreateBuildListBlockIfYes("OnMilitaryBase", "On Military Base", OnMilitaryBase.ToTitle());
            ListBlockDisplayList += CreateBuildListBlockIfYes("MilitaryIDRequired", "Military ID Required", MilitaryIdRequired.ToTitle());
            ListBlockDisplayList += CreateBuildListBlockIfYes("RestrictedAccess", "Restricted Access", RestrictedAccess.ToTitle());
            ListBlockDisplayList += CreateBuildListBlockIfYes("CoinStar", "CoinStar", CoinStar.ToTitle());
            ListBlockDisplayList += CreateBuildListBlockIfYes("TellerServices", "Teller Services", TellerServices.ToTitle());
            ListBlockDisplayList += CreateBuildListBlockIfYes("_24hourExpressBox", "24 Hour Express Box", _24hourExpressBox.ToTitle());
            ListBlockDisplayList += CreateBuildListBlockIfNo("PartnerCreditUnion", "Partner Credit Union", PartnerCreditUnion.ToTitle());
            ListBlockDisplayList += CreateBuildListBlockIfYes("MemberConsultant", "Member Consultant", MemberConsultant.ToTitle());
            ListBlockDisplayList += CreateBuildListBlockIfYes("InstantDebitCardReplacement", "Instant Debit Card Replacement", InstantDebitCardReplacement.ToTitle());


            return ListBlockDisplayList;
        }



        // attributes with legit values get new html tags built
        public string BuildFooterBlockQuoteDisplayTag(string Key, string Label, string Value)
        {
            var footerBlockQuote = string.Format(@"<blockquote class=""blockquote my-1 pt-1""><h5 class=""blockquote-footer {0} empty""><cite title =""{2}"">{1}: {2}</cite></h5></blockquote>", Key, Label, Value);

            return footerBlockQuote;
        }

        // default footer blockquote tag
        public string BuildDefaultFooterBlockQuoteDisplayTag(string Key)
        {
            var defaultFooterBlockQuote = string.Format(@"<blockquote><h5 class=""blockquote-footer {0} empty""></h5></blockquote>", Key);

            return defaultFooterBlockQuote;
        }
        
        // check for unknown value and create appropriate tag
        public string CreateFooterBlockQuoteDisplayTag(string Key, string Label, string Value)
        {
            // TODO: this breaks if (Value.Equals("Unknown"))
            if (Value != null)
            {
                return BuildDefaultFooterBlockQuoteDisplayTag(Key);
            }
            return BuildFooterBlockQuoteDisplayTag(Key, Label, Value);
        }

        // convert installation type into footer blockquote
        public string GetFooterBlockQuoteDisplayStrings()
        {
            FooterBlockQuoteDisplay = "";

            FooterBlockQuoteDisplay += CreateFooterBlockQuoteDisplayTag("InstallationType", "Location Type", InstallationType);

            return FooterBlockQuoteDisplay;
        }
    }
}
