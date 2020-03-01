using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Locator.Models
{
    public partial class Locations
    {
        [Key]
        public string LocationID { get; set; }
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
        [Display(Name = "Hours")]
        public string Hours { get; set; }
        [Display(Name = "Retail Outlet")]
        public string RetailOutlet { get; set; }
        [Display(Name = "Location Type")]
        public string LocationType { get; set; }



        // position attributes will be converted to doubles then into a point in the view model
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        [Column(TypeName = "geometry")]
        public Geometry Point { get; set; }




        // unused attributes
        public string CoopLocationId { get; set; }
        public bool TakeCoopData { get; set; }
        public bool SoftDelete { get; set; }
        public string County { get; set; }
        public string Country { get; set; }


        // virtual points to member models
        public virtual SpecialQualities SpecialQualities { get; set; }
        public virtual Contacts Contacts { get; set; }
        public virtual DailyHours DailyHours { get; set; }
    }
}
