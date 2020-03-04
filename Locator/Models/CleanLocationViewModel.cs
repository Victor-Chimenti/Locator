using DatabaseLibrary.Models;
using System.Collections.Generic;

namespace Locator.Models
{
    public class CleanLocationViewModel
    {
        public List<CleanLocationModel> CleanLocationList = new List<CleanLocationModel>();

        public CleanLocationViewModel(List<Locations> locationData)
        {
            foreach (var obj in locationData)
            {
                CleanLocationList.Add(new CleanLocationModel(obj));
            }
        }
    }
}
