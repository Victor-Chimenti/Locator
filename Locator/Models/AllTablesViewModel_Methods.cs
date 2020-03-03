using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLibrary.Models;
using Locator.Models;

namespace Locator.Models
{
    public partial class AllTablesViewModel
    {

        public AllTablesViewModel()
        {
            locations = new List<Locations>();
        }

        public AllTablesViewModel(Locations location = null)
        {
            locations = new List<Locations>();

            if (location is null)
            {
                return;
            }



            //Begin translating location properties to ViewModel



            // Locations Properties
            Address = location.Address;
            City = location.City;
            Country = location.Country;
            Hours = location.Hours;
            Latitude = location.Latitude;
            LocationId = location.LocationId;
            LocationType = ConvertStringToLocationTypeEnum(location.LocationType);
            Longitude = location.Longitude;
            Name = location.Name;
            PostalCode = location.PostalCode;
            RetailOutlet = location.RetailOutlet;
            State = ConvertStringToStateEnum(location.State);



            // Contacts Properties
            if (!(location.Contact is null))
            {
                Phone = location.Contact.Phone;
                WebAddress = location.Contact.WebAddress;
            }




            // SpecialQualities Properties 
            if (!(location.SpecialQualities is null))
            {
                AcceptCash = ConvertStringToBooleanEnum(location.SpecialQualities.AcceptCash);
                AcceptDeposit = ConvertStringToBooleanEnum(location.SpecialQualities.AcceptDeposit);
                AccessNotes = location.SpecialQualities.AccessNotes;
                Cashless = ConvertStringToBooleanEnum(location.SpecialQualities.Cashless);
                DriveThruOnly = ConvertStringToBooleanEnum(location.SpecialQualities.DriveThruOnly);
                HandicapAccess = ConvertStringToBooleanEnum(location.SpecialQualities.HandicapAccess);
                InstallationType = location.SpecialQualities.InstallationType;
                MilitaryIdRequired = ConvertStringToBooleanEnum(location.SpecialQualities.MilitaryIdRequired);
                OnMilitaryBase = ConvertStringToBooleanEnum(location.SpecialQualities.OnMilitaryBase);
                RestrictedAccess = ConvertStringToBooleanEnum(location.SpecialQualities.RestrictedAccess);
                SelfServiceDevice = ConvertStringToBooleanEnum(location.SpecialQualities.SelfServiceDevice);
                SelfServiceOnly = ConvertStringToBooleanEnum(location.SpecialQualities.SelfServiceOnly);
                Surcharge = ConvertStringToBooleanEnum(location.SpecialQualities.Surcharge);
            }
        }




        public static Locations GetNewLocation(AllTablesViewModel newLocation)
        {
            if (newLocation is null)
            {
                return null;
            }

            Locations location = new Locations();
            location.Address = newLocation.Address;
            location.City = newLocation.City;
            location.Country = newLocation.Country ?? null;
            location.Hours = newLocation.Hours ?? null;
            location.Latitude = newLocation.Latitude;
            location.LocationId = newLocation.LocationId;
            location.LocationType = ConvertLocationTypeEnumToString(newLocation.LocationType);
            location.Longitude = newLocation.Longitude;
            location.Name = newLocation.Name ?? null;
            location.PostalCode = newLocation.PostalCode;
            location.RetailOutlet = newLocation.RetailOutlet ?? null;
            location.State = newLocation.State.ToString();
            return location;
        }




        public static Contacts GetNewContact(AllTablesViewModel newLocation)
        {
            if (newLocation is null)
            {
                return null;
            }

            Contacts contact = new Contacts();
            contact.LocationId = newLocation.LocationId;
            contact.Phone = newLocation.Phone;
            contact.WebAddress = newLocation.WebAddress;


            if (contact.AllPropertiesAreNull())
            {
                return null;
            }

            return contact;
        }




        public static SpecialQualities GetNewSpecialQualities(AllTablesViewModel newLocation)
        {
            if (newLocation is null)
            {
                return null;
            }

            SpecialQualities specialQuality = new SpecialQualities();
            specialQuality.AcceptCash = ConvertBooleanEnumToString(newLocation.AcceptCash);
            specialQuality.AcceptDeposit = ConvertBooleanEnumToString(newLocation.AcceptDeposit);
            specialQuality.AccessNotes = newLocation.AccessNotes;
            specialQuality.Cashless = ConvertBooleanEnumToString(newLocation.Cashless);
            specialQuality.DriveThruOnly = ConvertBooleanEnumToString(newLocation.DriveThruOnly);
            specialQuality.HandicapAccess = ConvertBooleanEnumToString(newLocation.HandicapAccess);
            specialQuality.InstallationType = newLocation.InstallationType;
            specialQuality.LocationId = newLocation.LocationId;
            specialQuality.MilitaryIdRequired = ConvertBooleanEnumToString(newLocation.MilitaryIdRequired);
            specialQuality.OnMilitaryBase = ConvertBooleanEnumToString(newLocation.OnMilitaryBase);
            specialQuality.RestrictedAccess = ConvertBooleanEnumToString(newLocation.RestrictedAccess);
            specialQuality.SelfServiceDevice = ConvertBooleanEnumToString(newLocation.SelfServiceDevice);
            specialQuality.SelfServiceOnly = ConvertBooleanEnumToString(newLocation.SelfServiceOnly);
            specialQuality.Surcharge = ConvertBooleanEnumToString(newLocation.Surcharge);


            if (specialQuality.AllPropertiesAreNull())
            {
                return null;
            }

            return specialQuality;
        }




        private static string ConvertBooleanEnumToString(BooleanEnum? booleanEnum)
        {
            switch (booleanEnum)
            {
                case BooleanEnum.N:
                    return "N";
                case BooleanEnum.Y:
                    return "Y";
                default:
                    return null;
            }
        }




        private static BooleanEnum ConvertStringToBooleanEnum(string booleanAsStringFromDb)
        {
            switch (booleanAsStringFromDb)
            {
                case "N":
                    return BooleanEnum.N;
                case "Y":
                    return BooleanEnum.Y;
                default:
                    return BooleanEnum.NULL;
            }
        }




        private static BooleanEnum ConvertBoolToBooleanEnum(bool? booleanValueFromDb)
        {
            if ((bool)booleanValueFromDb)
            {
                return BooleanEnum.Y;
            }

            return BooleanEnum.N;
        }




        public static StateEnum ConvertStringToStateEnum(string stateValueFromDb)
        {

            if (stateValueFromDb == "AL")
            {
                return StateEnum.AL;
            }
            else if (stateValueFromDb == "AK")
            {
                return StateEnum.AK;
            }
            else if (stateValueFromDb == "AZ")
            {
                return StateEnum.AZ;
            }
            else if (stateValueFromDb == "AR")
            {
                return StateEnum.AR;
            }
            else if (stateValueFromDb == "CA")
            {
                return StateEnum.CA;
            }
            else if (stateValueFromDb == "CO")
            {
                return StateEnum.CO;
            }
            else if (stateValueFromDb == "CT")
            {
                return StateEnum.CT;
            }
            else if (stateValueFromDb == "DE")
            {
                return StateEnum.DE;
            }
            else if (stateValueFromDb == "DC")
            {
                return StateEnum.DC;
            }
            else if (stateValueFromDb == "FL")
            {
                return StateEnum.FL;
            }
            else if (stateValueFromDb == "GA")
            {
                return StateEnum.GA;
            }
            else if (stateValueFromDb == "GU")
            {
                return StateEnum.GU;
            }
            else if (stateValueFromDb == "HI")
            {
                return StateEnum.HI;
            }
            else if (stateValueFromDb == "ID")
            {
                return StateEnum.ID;
            }
            else if (stateValueFromDb == "IL")
            {
                return StateEnum.IL;
            }
            else if (stateValueFromDb == "IN")
            {
                return StateEnum.IN;
            }
            else if (stateValueFromDb == "IA")
            {
                return StateEnum.IA;
            }
            else if (stateValueFromDb == "KS")
            {
                return StateEnum.KS;
            }
            else if (stateValueFromDb == "KY")
            {
                return StateEnum.KY;
            }
            else if (stateValueFromDb == "LA")
            {
                return StateEnum.LA;
            }
            else if (stateValueFromDb == "ME")
            {
                return StateEnum.ME;
            }
            else if (stateValueFromDb == "MD")
            {
                return StateEnum.MD;
            }
            else if (stateValueFromDb == "MA")
            {
                return StateEnum.MA;
            }
            else if (stateValueFromDb == "MI")
            {
                return StateEnum.MI;
            }
            else if (stateValueFromDb == "MN")
            {
                return StateEnum.MN;
            }
            else if (stateValueFromDb == "MS")
            {
                return StateEnum.MS;
            }
            else if (stateValueFromDb == "MO")
            {
                return StateEnum.MO;
            }
            else if (stateValueFromDb == "MT")
            {
                return StateEnum.MT;
            }
            else if (stateValueFromDb == "NE")
            {
                return StateEnum.NE;
            }
            else if (stateValueFromDb == "NV")
            {
                return StateEnum.NV;
            }
            else if (stateValueFromDb == "NH")
            {
                return StateEnum.NH;
            }
            else if (stateValueFromDb == "NJ")
            {
                return StateEnum.NJ;
            }
            else if (stateValueFromDb == "NM")
            {
                return StateEnum.NM;
            }
            else if (stateValueFromDb == "NY")
            {
                return StateEnum.NY;
            }
            else if (stateValueFromDb == "NC")
            {
                return StateEnum.NC;
            }
            else if (stateValueFromDb == "ND")
            {
                return StateEnum.ND;
            }
            else if (stateValueFromDb == "OH")
            {
                return StateEnum.OH;
            }
            else if (stateValueFromDb == "OK")
            {
                return StateEnum.OK;
            }
            else if (stateValueFromDb == "OR")
            {
                return StateEnum.OR;
            }
            else if (stateValueFromDb == "PA")
            {
                return StateEnum.PA;
            }
            else if (stateValueFromDb == "RI")
            {
                return StateEnum.RI;
            }
            else if (stateValueFromDb == "SC")
            {
                return StateEnum.SC;
            }
            else if (stateValueFromDb == "SD")
            {
                return StateEnum.SD;
            }
            else if (stateValueFromDb == "TN")
            {
                return StateEnum.TN;
            }
            else if (stateValueFromDb == "TX")
            {
                return StateEnum.TX;
            }
            else if (stateValueFromDb == "UT")
            {
                return StateEnum.UT;
            }
            else if (stateValueFromDb == "VT")
            {
                return StateEnum.VT;
            }
            else if (stateValueFromDb == "VA")
            {
                return StateEnum.VA;
            }
            else if (stateValueFromDb == "WA")
            {
                return StateEnum.WA;
            }
            else if (stateValueFromDb == "WV")
            {
                return StateEnum.WV;
            }
            else if (stateValueFromDb == "WI")
            {
                return StateEnum.WI;
            }
            else if (stateValueFromDb == "WY")
            {
                return StateEnum.WY;
            }
            else if (stateValueFromDb == "AB")
            {
                return StateEnum.AB;
            }
            else if (stateValueFromDb == "BC")
            {
                return StateEnum.BC;
            }
            else if (stateValueFromDb == "MB")
            {
                return StateEnum.MB;
            }
            else if (stateValueFromDb == "NB")
            {
                return StateEnum.NB;
            }
            else if (stateValueFromDb == "NL")
            {
                return StateEnum.NL;
            }
            else if (stateValueFromDb == "NS")
            {
                return StateEnum.NS;
            }
            else if (stateValueFromDb == "ON")
            {
                return StateEnum.ON;
            }
            else if (stateValueFromDb == "QC")
            {
                return StateEnum.QC;
            }
            else if (stateValueFromDb == "SK")
            {
                return StateEnum.SK;
            }
            else if (stateValueFromDb == "AE")
            {
                return StateEnum.AE;
            }
            else
            {
                return StateEnum.PR;
            }
        }





        public static LocationTypeEnum ConvertStringToLocationTypeEnum(string locationTypeValueFromDb)
        {
            if (locationTypeValueFromDb == "A")
            {
                return LocationTypeEnum.A;
            }
            else
            {
                return LocationTypeEnum.S;
            }
        }





        private static string ConvertLocationTypeEnumToString(LocationTypeEnum locationTypeEnum)
        {
            if (locationTypeEnum == LocationTypeEnum.A)
            {
                return "A";
            }
            else
            {
                return "S";
            }
        }




        public bool InstatiateViewModelPropertiesWithOneLocation(Locations referenceLocation = null)
        {
            if (referenceLocation == null) // get first location
            {
                referenceLocation = locations.First();
            }
            AcceptCash = ConvertStringToBooleanEnum(referenceLocation.SpecialQualities.AcceptCash);
            AcceptDeposit = ConvertStringToBooleanEnum(referenceLocation.SpecialQualities.AcceptDeposit);
            AccessNotes = referenceLocation.SpecialQualities.AccessNotes;
            Address = referenceLocation.Address;
            Cashless = ConvertStringToBooleanEnum(referenceLocation.SpecialQualities.Cashless);
            City = referenceLocation.City;
            CoopLocationId = referenceLocation.CoopLocationId;
            Country = referenceLocation.Country;
            DriveThruOnly = ConvertStringToBooleanEnum(referenceLocation.SpecialQualities.DriveThruOnly);
            HandicapAccess = ConvertStringToBooleanEnum(referenceLocation.SpecialQualities.HandicapAccess);
            Hours = referenceLocation.Hours;
            InstallationType = referenceLocation.SpecialQualities.InstallationType;
            Latitude = referenceLocation.Latitude;
            LocationId = referenceLocation.LocationId;
            LocationType = ConvertStringToLocationTypeEnum(referenceLocation.LocationType);
            Longitude = referenceLocation.Longitude;
            MilitaryIdRequired = ConvertStringToBooleanEnum(referenceLocation.SpecialQualities.MilitaryIdRequired);
            Name = referenceLocation.Name;
            OnMilitaryBase = ConvertStringToBooleanEnum(referenceLocation.SpecialQualities.OnMilitaryBase);
            Phone = referenceLocation.Contact.Phone;
            PostalCode = referenceLocation.PostalCode;
            RestrictedAccess = ConvertStringToBooleanEnum(referenceLocation.SpecialQualities.RestrictedAccess);
            RetailOutlet = referenceLocation.RetailOutlet;
            SelfServiceDevice = ConvertStringToBooleanEnum(referenceLocation.SpecialQualities.SelfServiceDevice);
            SelfServiceOnly = ConvertStringToBooleanEnum(referenceLocation.SpecialQualities.SelfServiceOnly);
            State = ConvertStringToStateEnum(referenceLocation.State);
            Surcharge = ConvertStringToBooleanEnum(referenceLocation.SpecialQualities.Surcharge);
            WebAddress = referenceLocation.Contact.WebAddress;
            return true;
        }


    }
}
