using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Locator.Models
{
    public partial class Contacts
    {
        // contact items
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Display(Name = "Web Address")]
        public string WebAddress { get; set; }





        // unused schema items
        public string Fax { get; set; }
        public string LocationID { get; set; }
        public virtual Locations Location { get; set; }
    }
}
