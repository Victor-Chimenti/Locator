using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Locator.Models
{
    public partial class SpecialQualities
    {
        // subtitle attributes
        [Display(Name = "Installation Type")]
        public string InstallationType { get; set; }
        [Display(Name = "Notes")]
        public string AccessNotes { get; set; }


        // list item attributes
        [Display(Name = "Handicap Access")]
        public string HandicapAccess { get; set; }
        [Display(Name = "Drive Thru Only")]
        public string DriveThruOnly { get; set; }
        [Display(Name = "Surcharge")]
        public string Surcharge { get; set; }
        [Display(Name = "Accept Deposit")]
        public string AcceptDeposit { get; set; }
        [Display(Name = "Accept Cash")]
        public string AcceptCash { get; set; }
        [Display(Name = "Cashless")]
        public string Cashless { get; set; }
        [Display(Name = "Self Service Device")]
        public string SelfServiceDevice { get; set; }
        [Display(Name = "Self Service Only")]
        public string SelfServiceOnly { get; set; }
        [Display(Name = "On Military Base")]
        public string OnMilitaryBase { get; set; }
        [Display(Name = "Military ID Required")]
        public string MilitaryIdRequired { get; set; }
        [Display(Name = "Restricted Access")]
        public string RestrictedAccess { get; set; }


        // NFC attributes
        [Display(Name = "CoinStar")]
        public string CoinStar { get; set; }
        [Display(Name = "Teller Services")]
        public string TellerServices { get; set; }
        [Display(Name = "24 Hour Express Box")]
        public string _24hourExpressBox { get; set; }
        [Display(Name = "Partner Credit Union")]
        public string PartnerCreditUnion { get; set; }
        [Display(Name = "Member Consultant")]
        public string MemberConsultant { get; set; }
        [Display(Name = "Instant Debit Card Replacement")]
        public string InstantDebitCardReplacement { get; set; }






        // unused schema items
        public string EnvelopeRequired { get; set; }
        public string OnPremise { get; set; }
        public string Access { get; set; }
        public string LimitedTransactions { get; set; }





        // virtual pointer to Locations Model
        public string LocationID { get; set; }
        public virtual Locations Location { get; set; } = null;
    }
}
