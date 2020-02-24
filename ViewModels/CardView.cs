using Locator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locator.ViewModels
{
    public class CardView
    {
        public string CardName { get; set; }
        public string LocationName { get; set; }
        public int Id { get; set; }



        //public IEnumerable<Locations> Location { get; set; }


        //public string Key { get; set; }
        //public string Value { get; set; }
        //public List<KeyValuePair<string, string>> CardList { get; set; }


        //public CardView(Locations location)
        //{
        //    CardList = new List<KeyValuePair<string, string>>();

        //    _AddValue(location.LocationId);
        //    _AddValue(location.Name);
        //    _AddValue(location.Address);
        //    _AddValue(location.City);
        //    _AddValue(location.State);
        //    _AddValue(location.PostalCode);
        //    _AddValue(location.Hours);
        //    _AddValue(location.RetailOutlet);
        //    _AddValue(location.Latitude);
        //    _AddValue(location.Longitude);
        //    _AddValue(location.LocationType);

        //    if (location.Contacts != null)
        //    {
        //        _AddValue(location.Contacts.Phone);
        //        CardList.Add(location.Contacts.WebAddress);
        //    }

        //    if (location.SpecialQualities != null)
        //    {
        //        _AddValue(location.SpecialQualities.AccessNotes);
        //        _AddValue(location.SpecialQualities.InstallationType);
        //        _AddValue(location.SpecialQualities.HandicapAccess);
        //        _AddValue(location.SpecialQualities.DriveThruOnly);
        //        _AddValue(location.SpecialQualities.Surcharge);
        //        _AddValue(location.SpecialQualities.AcceptDeposit);
        //        _AddValue(location.SpecialQualities.AcceptCash);
        //        _AddValue(location.SpecialQualities.Cashless);
        //        _AddValue(location.SpecialQualities.SelfServiceDevice);
        //        _AddValue(location.SpecialQualities.SelfServiceOnly);
        //        _AddValue(location.SpecialQualities.OnMilitaryBase);
        //        _AddValue(location.SpecialQualities.MilitaryIdRequired);
        //        _AddValue(location.SpecialQualities.RestrictedAccess);
        //    }
        //}


        //private readonly Locations location;
    }
}
