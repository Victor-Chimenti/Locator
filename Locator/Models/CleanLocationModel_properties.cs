using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DatabaseLibrary.Models;

namespace Locator.Models
{
    public partial class CleanLocationModel
    {
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string LocationId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [DisplayName("Institution")]
        public string Name { get; set; }

        [DisplayName("Type")]
        public LocationTypeEnum LocationType { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [DisplayName("Type Code")]
        public string LocationTypeCode { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [DisplayName("Street")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [DisplayName("Zip Code")]
        public string PostalCode { get; set; }

        [DisplayName("State Code")]
        public StateEnum State { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [DisplayName("State")]
        public string StateTitle { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [DisplayName("Country")]
        public string Country { get; set; }

        [DisplayName("Latitude")]
        public decimal Latitude { get; set; } = 0.0M;

        [DisplayName("Longitude")]
        public decimal Longitude { get; set; } = 0.0M;

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [DisplayName("Retail Outlet")]
        public string RetailOutlet { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [DisplayName("Hours")]
        public string Hours { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [DisplayName("Phone")]
        [Phone]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [DisplayName("Web Address")]
        [Url]
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

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [DisplayName("Notes")]
        public string AccessNotes { get; set; }

        [DisplayName("Position")]
        public PositionModel Position { get; set; }

        // This string will hold the list of all attributes and be passed through Display String
        public string ListBlockDisplayList { get; set; }

        // This string will hold the list of all attributes and be passed through Display String
        public string SubTitleDisplayList { get; set; }

        // This string will hold the list of all attributes that are displayed with the footer blockquote
        public string FooterBlockQuoteDisplay { get; set; }


        //// establish a default html tag for undefined, null attributes
        //string DefaultNoValueSubTitleString = @"<p class=""subTitle empty"" style=""display: none"";></p>";
    }
}

