using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Locator.Models
{
    public class LocationCard {

        public int CardId { get; set; }
        public string CardName { get; set; }

        public virtual ICollection<Locations> Location { get; set; }

    };
}
