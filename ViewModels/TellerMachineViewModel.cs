using Locator.Models;
using Locator.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;
//using GeoAPI.Geometries;
//using Coordinate = NetTopologySuite.Geometries.Coordinate;

namespace Locator.ViewModels
{
    public class TellerMachineViewModel : Locations
    {
        public IEnumerable<Locations> Locations { get; private set; }

        public double Distance { get; set; }
        [Column(TypeName = "geometry")]
        public Point Position { get; set; }
        public TellerPosition TellerPosition { get; set; }


        public TellerMachineViewModel(Locations data)
        {
            // supress duplicate location id assignments
            if (data.SpecialQualities != null)
            {
                data.SpecialQualities.Location = null;
            }

            if (data.Contacts != null)
            {
                data.Contacts.Location = null;
            }

            if (data.DailyHours != null)
            {
                data.DailyHours.Location = null;
            }

            // assign local values
            LocationId = data.LocationId;
            Name = data.Name;
            Address = data.Address;
            City = data.City;
            State = data.State;
            PostalCode = data.PostalCode;
            Country = data.Country;
            Hours = data.Hours;
            RetailOutlet = data.RetailOutlet;
            LocationType = data.LocationType;
            Contacts = data.Contacts;
            SpecialQualities = data.SpecialQualities;
            DailyHours = data.DailyHours;
            Latitude = data.Latitude;
            Longitude = data.Longitude;

            // convert from coordinates from decimal to double
            TellerPosition = new TellerPosition
            {
                Lat = Convert.ToDouble(Latitude),
                Lng = Convert.ToDouble(Longitude)
            };

            // assign spatial coordinates
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            Position = geometryFactory.CreatePoint(new Coordinate(TellerPosition.Lat, TellerPosition.Lng));


        }
    }

    // helper class to convert from decimal to double
    public class TellerPosition
    {
        public double Lat { get; set; } = 0.0;
        public double Lng { get; set; } = 0.0;
    }
}
