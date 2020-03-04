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

        [DisplayName("Notes")]
        public string AccessNotes { get; set; }

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
                    WebAddress = data.Contact.WebAddress;
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

            // Convert Installation Type to enum?
            InstallationType = data.SpecialQualities.InstallationType;
            AccessNotes = data.SpecialQualities.AccessNotes;
        }
    }
}
