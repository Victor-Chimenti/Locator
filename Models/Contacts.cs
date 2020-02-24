using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Locator.Models
{
    public partial class Contacts
    {
        [Phone]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Url]
        [Display(Name = "Web Address")]
        public string WebAddress { get; set; }



        public string Fax { get; set; }
        public string LocationId { get; set; }

        public virtual Locations Location { get; set; }
    }
}
