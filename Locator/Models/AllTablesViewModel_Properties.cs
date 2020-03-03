using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DatabaseLibrary.Models;

namespace Locator.Models
{
    public partial class AllTablesViewModel
    {
        #region Locations Properties
        [Required]
        public string LocationId { get; set; }

        [DisplayName("Institution")]
        #nullable enable
        public string? Name { get; set; }

        [Required]
        [DisplayName("Type")]
        [EnumDataType(typeof(LocationTypeEnum))]
        public LocationTypeEnum LocationType { get; set; }

        [Required]
        [DisplayName("Street")]
        public string Address { get; set; }

        [Required]
        [DisplayName("City")]
        public string City { get; set; }

        [Required]
        [DisplayName("Zip Code")]
        public string PostalCode { get; set; }

        [DisplayName("County")]
        #nullable enable
        public string? County { get; set; }

        [Required]
        [DisplayName("State")]
        [EnumDataType(typeof(StateEnum))]
        public StateEnum State { get; set; }

        [DisplayName("Country")]
        #nullable enable
        public string? Country { get; set; }

        [Required]
        [DisplayName("Latitude")]
        public decimal Latitude { get; set; } = 0.0M;

        [Required]
        [DisplayName("Longitude")]
        public decimal Longitude { get; set; } = 0.0M;

        [DisplayName("Retail Outlet")]
        #nullable enable
        public string? RetailOutlet { get; set; }

        [DisplayName("Hours")]
        #nullable enable
        public string? Hours { get; set; }
        #endregion



        #region Contacts Properties
        [DisplayName("Phone")]
        public string? Phone { get; set; }

        [DisplayName("Web Address")]
        public string? WebAddress { get; set; }
        #endregion



        #region Special Qualities Properties
        [DisplayName("Restricted Access")]
        #nullable enable
        public BooleanEnum? RestrictedAccess { get; set; }

        [DisplayName("Accepts Deposits")]
        #nullable enable
        public BooleanEnum? AcceptDeposit { get; set; }

        [DisplayName("Access")]
        #nullable enable
        public BooleanEnum? Access { get; set; }

        [DisplayName("Installation Type")]
        #nullable enable
        public string? InstallationType { get; set; }

        [DisplayName("Drive Thru Only")]
        #nullable enable
        public BooleanEnum? DriveThruOnly { get; set; }

        [DisplayName("Handicap Access")]
        #nullable enable
        public BooleanEnum? HandicapAccess { get; set; }

        [DisplayName("Accepts Cash")]
        #nullable enable
        public BooleanEnum? AcceptCash { get; set; }

        [DisplayName("Cashless")]
        #nullable enable
        public BooleanEnum? Cashless { get; set; }

        [DisplayName("Self Service Only")]
        #nullable enable
        public BooleanEnum? SelfServiceOnly { get; set; }

        [DisplayName("Surcharge")]
        #nullable enable
        public BooleanEnum? Surcharge { get; set; }

        [DisplayName("On Military Base")]
        #nullable enable
        public BooleanEnum? OnMilitaryBase { get; set; }

        [DisplayName("Military ID Required")]
        #nullable enable
        public BooleanEnum? MilitaryIdRequired { get; set; }

        [DisplayName("Self Service Device")]
        #nullable enable
        public BooleanEnum? SelfServiceDevice { get; set; }

        [DisplayName("Notes")]
        #nullable enable
        [StringLength(100)]
        public string? AccessNotes { get; set; }
        #endregion



        public List<Locations> locations { get; set; }
    }
}
