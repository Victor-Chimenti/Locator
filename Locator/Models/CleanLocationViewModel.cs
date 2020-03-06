using DatabaseLibrary.Models;
using System.Collections.Generic;
using Locator.Models;

namespace Locator.Models
{
    public class CleanLocationViewModel
    {
        public PositionModel point;
        public List<CleanLocationModel> CleanLocationList = new List<CleanLocationModel>();

        public CleanLocationViewModel(List<Locations> data, PositionModel point)
        {
            this.point = point;
            foreach (var item in data)
            {
                CleanLocationList.Add(new CleanLocationModel(item));
            }
        }
    }
}
