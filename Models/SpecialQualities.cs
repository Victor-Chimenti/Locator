using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Locator.Models
{
    public partial class SpecialQualities
    {
        [Display(Name = "Installation Type")]
        public string InstallationType { get; set; }
        [Display(Name = "Notes")]
        public string AccessNotes { get; set; }

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




        public string LimitedTransactions { get; set; }
        public string EnvelopeRequired { get; set; }
        public string OnPremise { get; set; }
        public string Access { get; set; }

        public string LocationId { get; set; }
        public virtual Locations Location { get; set; }
    }
}
