using Locator.Models;
using Locator.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locator.ViewModels
{
    public class TellerMachineViewModel
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
        public double Distance { get; set; }
        public virtual Contacts Contacts { get; set; }
        public virtual DailyHours DailyHours { get; set; }
        public virtual SpecialQualities SpecialQualities { get; set; }

    }
}
