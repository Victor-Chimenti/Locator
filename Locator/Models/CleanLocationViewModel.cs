using DatabaseLibrary.Models;
using System.Collections.Generic;

namespace Locator.Models
{
    public class CleanLocationViewModel
    {
        public List<CleanLocationModel_properties> CleanLocationList = new List<CleanLocationModel_properties>();

        public CleanLocationViewModel(List<Locations> data)
        {
            foreach (var item in data)
            {
                CleanLocationList.Add(new CleanLocationModel_properties(item));
            }
        }
    }
}
