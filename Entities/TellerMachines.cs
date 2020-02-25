using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite;
using GeoAPI.Geometries;
using Locator.Models;


namespace Locator.Entities
{
    public class TellerMachines
    {

        [Key]
        public string LocationId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string PostalCode { get; set; }
        [Display(Name = "Latitude")]
        public decimal Latitude { get; set; }
        [Display(Name = "Longitude")]
        public decimal Longitude { get; set; }
        [Display(Name = "Hours")]
        public string Hours { get; set; }
        [Display(Name = "Retail Outlet")]
        public string RetailOutlet { get; set; }
        [Display(Name = "Location Type")]
        public string LocationType { get; set; }
        public virtual Contacts Contacts { get; set; }
        public virtual DailyHours DailyHours { get; set; }
        public virtual SpecialQualities SpecialQualities { get; set; }

        [Column(TypeName = "geometry")]
        public IPoint Location { get; set; }
    }
}
