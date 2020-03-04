using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DatabaseLibrary.Models;
using Locator.Models;

namespace Locator.Backend
{
    public class LocationsBackend
    {
        private DatabaseHelper db;



        public LocationsBackend(MaphawksContext context)
        {
            db = new DatabaseHelper(context);
        }


        public virtual async Task<List<AllTablesViewModel>> IndexAsync()
        {
            var locations_list = new List<AllTablesViewModel>();


            locations_list = await db.ReadMultipleRecordsAsync().ConfigureAwait(false); // Select * join all tables


            foreach (var location in locations_list)
            {
                ConvertDbStringsToEnums(location);
            }
            return locations_list;
        }




        private static Locations ConvertDbStringsToEnums(Locations location)
        {
            var state = AllTablesViewModel.ConvertStringToStateEnum(location.State);
            var locationType = AllTablesViewModel.ConvertStringToLocationTypeEnum(location.LocationType);



            location.State = state.GetType().GetMember(state.ToString()).First().GetCustomAttribute<DisplayAttribute>().Name;


            location.LocationType = locationType.GetType().GetMember(locationType.ToString()).First().GetCustomAttribute<DisplayAttribute>().Name;

            return location;
        }
    }
}
