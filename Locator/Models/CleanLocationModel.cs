using System.ComponentModel;
using DatabaseLibrary.Models;

namespace Locator.Models
{
    public partial class CleanLocationModel
    {
        public string LocationId { get; set; }

        [DisplayName("Institution")]
        public string Name { get; set; }

        [DisplayName("Type")]
        public LocationTypeEnum LocationType { get; set; }

        [DisplayName("Type Code")]
        public string LocationTypeCode { get; set; }

        [DisplayName("Street")]
        public string Address { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Zip Code")]
        public string PostalCode { get; set; }

        [DisplayName("State Code")]
        public StateEnum State { get; set; }

        [DisplayName("State")]
        public string StateTitle { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }

        [DisplayName("Latitude")]
        public decimal Latitude { get; set; } = 0.0M;

        [DisplayName("Longitude")]
        public decimal Longitude { get; set; } = 0.0M;

        [DisplayName("Retail Outlet")]
        public string RetailOutlet { get; set; }

        [DisplayName("Hours")]
        public string Hours { get; set; }

        [DisplayName("Phone")]
        public string Phone { get; set; }

        [DisplayName("Web Address")]
        public string WebAddress { get; set; }

        [DisplayName("Restricted Access")]
        public BooleanEnum RestrictedAccess { get; set; }

        [DisplayName("Accepts Deposits")]
        public BooleanEnum AcceptDeposit { get; set; }

        [DisplayName("Installation Type")]
        public string InstallationType { get; set; }

        [DisplayName("Drive Thru Only")]
        public BooleanEnum DriveThruOnly { get; set; }

        [DisplayName("Handicap Access")]
        public BooleanEnum HandicapAccess { get; set; }

        [DisplayName("Accepts Cash")]
        public BooleanEnum AcceptCash { get; set; }

        [DisplayName("Cashless")]
        public BooleanEnum Cashless { get; set; }

        [DisplayName("Self Service Only")]
        public BooleanEnum SelfServiceOnly { get; set; }

        [DisplayName("Surcharge")]
        public BooleanEnum Surcharge { get; set; }

        [DisplayName("On Military Base")]
        public BooleanEnum OnMilitaryBase { get; set; }

        [DisplayName("Military ID Required")]
        public BooleanEnum MilitaryIdRequired { get; set; }

        [DisplayName("Self Service Device")]
        public BooleanEnum SelfServiceDevice { get; set; }

        [DisplayName("CoinStar")]
        public BooleanEnum CoinStar { get; set; }

        [DisplayName("Teller Services")]
        public BooleanEnum TellerServices { get; set; }

        [DisplayName("24 Hour Express Box")]
        public BooleanEnum _24hourExpressBox { get; set; }

        [DisplayName("Partner Credit Union")]
        public BooleanEnum PartnerCreditUnion { get; set; }

        [DisplayName("Member Consultant")]
        public BooleanEnum MemberConsultant { get; set; }

        [DisplayName("Instant Debit Card Replacement")]
        public BooleanEnum InstantDebitCardReplacement { get; set; }


        [DisplayName("Notes")]
        public string AccessNotes { get; set; }

        [DisplayName("Position")]
        public PositionModel Position { get; set; }

        // This string will hold the list of all attributes and be passed through Display String
        public string ListBlockDisplayList { get; set; }

        // This string will hold the list of all attributes and be passed through Display String
        public string SubTitleDisplayList { get; set; }

        //// establish a default html tag for undefined, null attributes
        //string DefaultNoValueSubTitleString = @"<p class=""subTitle empty"" style=""display: none"";></p>";

        public CleanLocationModel(Locations data)
        {
            LocationId = data.LocationId;
            Name = data.Name;

            LocationType = LocationTypeEnumHelper.StringToEnum(data.LocationType);
            LocationTypeCode = LocationType.ToTitle();

            Address = data.Address;
            City = data.City;
            PostalCode = data.PostalCode;
            State = StateEnumHelper.StringToEnum(data.State);
            StateTitle = State.ToTitle();
            Country = data.Country;
            Latitude = data.Latitude; 
            Longitude = data.Longitude; 
            RetailOutlet = data.RetailOutlet;
            Hours = data.Hours;
         
            Phone = "";
            WebAddress = "";

            if (data.Contact != null)
            {
                if (!string.IsNullOrEmpty(data.Contact.Phone))
                {
                    Phone = data.Contact.Phone;
                }

                if (!string.IsNullOrEmpty(data.Contact.WebAddress))
                {
                    var protocol = "http://";
                    var secureProtocol = "https://";
                    if (!data.Contact.WebAddress.Contains(protocol) || !data.Contact.WebAddress.Contains(secureProtocol))
                    {
                        WebAddress = secureProtocol + data.Contact.WebAddress;
                    }
                    else
                    {
                        WebAddress = data.Contact.WebAddress;
                    }
                }
            }

            RestrictedAccess = BoolEnumHelper.StringToEnum(data.SpecialQualities.RestrictedAccess);
            AcceptDeposit = BoolEnumHelper.StringToEnum(data.SpecialQualities.AcceptDeposit);
            DriveThruOnly = BoolEnumHelper.StringToEnum(data.SpecialQualities.DriveThruOnly);
            HandicapAccess = BoolEnumHelper.StringToEnum(data.SpecialQualities.HandicapAccess);
            AcceptCash = BoolEnumHelper.StringToEnum(data.SpecialQualities.AcceptCash);
            Cashless = BoolEnumHelper.StringToEnum(data.SpecialQualities.Cashless);
            SelfServiceOnly = BoolEnumHelper.StringToEnum(data.SpecialQualities.SelfServiceOnly);
            Surcharge = BoolEnumHelper.StringToEnum(data.SpecialQualities.Surcharge);
            OnMilitaryBase = BoolEnumHelper.StringToEnum(data.SpecialQualities.OnMilitaryBase);
            MilitaryIdRequired = BoolEnumHelper.StringToEnum(data.SpecialQualities.MilitaryIdRequired);
            SelfServiceDevice = BoolEnumHelper.StringToEnum(data.SpecialQualities.SelfServiceDevice);
            CoinStar = BoolEnumHelper.StringToEnum(data.SpecialQualities.CoinStar);
            TellerServices = BoolEnumHelper.StringToEnum(data.SpecialQualities.TellerServices);
            _24hourExpressBox = BoolEnumHelper.StringToEnum(data.SpecialQualities._24hourExpressBox);
            PartnerCreditUnion = BoolEnumHelper.StringToEnum(data.SpecialQualities.PartnerCreditUnion);
            MemberConsultant = BoolEnumHelper.StringToEnum(data.SpecialQualities.MemberConsultant);
            InstantDebitCardReplacement = BoolEnumHelper.StringToEnum(data.SpecialQualities.InstantDebitCardReplacement);


            InstallationType = data.SpecialQualities.InstallationType;
            AccessNotes = data.SpecialQualities.AccessNotes;

            Position = new PositionModel(Latitude, Longitude);

            ListBlockDisplayList  = GetListDisplayStrings();
            SubTitleDisplayList = GetSubTitleDisplayStrings();
        }


        //<option class=""list-display {0}"" value=""{2}""></option>
        /// <summary>
        /// Use for Card Creation to improve performance for ajax
        /// </summary>

        // attributes with legit values get new html tags built
        public string BuildListBlockDisplayTag(string Key, string Label, string Value)
        {
            var listBlock = string.Format(@"<li class=""list-group-item""> {1} : <span class=""{0}"">{2}</span></li>", Key, Label, Value);

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
            ListBlockDisplayList += CreateBuildListBlockIfYes("SelfServiceDevice", "Self Service Device",SelfServiceDevice.ToTitle());
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
        public string BuildSubTitleDisplayTag(string Key, string Display, string Title)
        {
            var subTitle = string.Format(@"<p class=""subTitle {0} empty""></p>", Key);

            if (!string.IsNullOrEmpty(Title))
            {
                subTitle = string.Format(@"<p class=""subTitle {0}"" value='{2}'> {1} : {2} </p>", Key, Display, Title);
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
    }
}
