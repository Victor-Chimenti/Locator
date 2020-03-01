using System;
using System.Collections.Generic;

namespace Locator.Models
{
    public partial class Contacts
    {
        public string LocationID { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string WebAddress { get; set; }

        public virtual Locations Location { get; set; }
    }
}
