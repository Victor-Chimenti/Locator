using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locator.ViewModels
{
    public class IndexViewModel
    {
        //public SearchAreaInputModel SearchAreaInput { get; set; }
        public IEnumerable<LocationsViewModel> Locations { get; set; }
    }
}
