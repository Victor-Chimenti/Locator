using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using Locator.Models;


namespace Locator.Entities
{
    // Child class inherits from the Locations Model
    public class TellerMachine : Locations
    {
        public IEnumerable<Locations> Locations { get; private set; }

        public int Id { get; set; }
        public double Distance { get; set; }
        [Column(TypeName = "geometry")]
        public Point Position { get; set; }
        public TellerPosition TellerPosition { get; set; }


        public TellerMachine(Locations data)
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
