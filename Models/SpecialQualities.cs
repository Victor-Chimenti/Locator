using System;
using System.Collections.Generic;

namespace Locator.Models
{
    public partial class SpecialQualities
    {
        public string LocationID { get; set; }
        public string RestrictedAccess { get; set; }
        public string AcceptDeposit { get; set; }
        public string AcceptCash { get; set; }
        public string EnvelopeRequired { get; set; }
        public string OnMilitaryBase { get; set; }
        public string OnPremise { get; set; }
        public string Surcharge { get; set; }
        public string Access { get; set; }
        public string AccessNotes { get; set; }
        public string InstallationType { get; set; }
        public string HandicapAccess { get; set; }
        public string Cashless { get; set; }
        public string DriveThruOnly { get; set; }
        public string LimitedTransactions { get; set; }
        public string MilitaryIdRequired { get; set; }
        public string SelfServiceDevice { get; set; }
        public string SelfServiceOnly { get; set; }
        public string CoinStar { get; set; }
        public string TellerServices { get; set; }
        public string _24hourExpressBox { get; set; }
        public string PartnerCreditUnion { get; set; }
        public string MemberConsultant { get; set; }
        public string InstantDebitCardReplacement { get; set; }

        public virtual Locations Location { get; set; }
    }
}
