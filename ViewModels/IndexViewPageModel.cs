using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locator.Models;
using Locator.Entities;

namespace Locator.ViewModels
{
    public class IndexViewPageModel
    {
        public LocationInputModel LocationInput { get; set; }
        public List<TellerMachineViewModel> TellerMachines { get; set; }
    }
}
