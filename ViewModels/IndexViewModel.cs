using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locator.ViewModels
{
    public class IndexViewModel
    {
        public LocationInputModel LocationInput { get; set; }
        public List<TellerMachineViewModel> TellerMachines { get; set; }
    }
}
