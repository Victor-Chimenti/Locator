using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locator.ViewModels
{
    public class SearchAreaInputModel
    {
        //public double Latitude { get; set; }
        //public double Longitude { get; set; }
    }
}




//public SearchAreaInputModel SearchAreaInput { get; set; }



//if (string.IsNullOrEmpty(Latitude))
//{
//    return View(data);
//}

//if (string.IsNullOrEmpty(Longitude))
//{
//    return View(data);
//}

//var indexViewModel = new IndexViewModel {};

//var data = await _context.Locations.
//    Include(c => c.Contacts).
//    Include(s => s.SpecialQualities).
//    Include(h => h.DailyHours).
//    ToListAsync();

//var Latitude = Request.Cookies["latitude"];
//var Longitude = Request.Cookies["longitude"];

//if (string.IsNullOrEmpty(Latitude))
//{
//    Latitude = "47.490209";
//}
//if (string.IsNullOrEmpty(Longitude))
//{
//    Longitude = "-122.272126";
//}
//try
//{
//    lat = Convert.ToDouble(Latitude);
//}
//catch (FormatException)
//{
//    Console.WriteLine("Unable to convert '{0}' to a Double.", Latitude);
//}
//try
//{
//    lng = Convert.ToDouble(Longitude);
//}
//catch (FormatException)
//{
//    Console.WriteLine("Unable to convert '{0}' to a Double.", Longitude);
//}
//var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
//var searchArea = geometryFactory.CreatePoint(new Coordinate(lat, lng));
////var searchArea = new Point(lat, lng) { SRID = 4326 };


//var locations = await _context
//    .Locations
//    .Include(c => c.Contacts)
//    .Include(s => s.SpecialQualities)
//    .Include(h => h.DailyHours)
//    .Select(t => new { Place = t, Distance = t.Point.Distance(searchArea) })
////    .ToListAsync();

////indexViewModel.Locations = locations
//    .OrderBy(x => x.Distance)
//    //.Select(t => new LocationsViewModel
//    //{
//    //    Distance = Math.Round(t.Distance, 6),
//    //    Latitude = t.Place.Location.X,
//    //    Longitude = t.Place.Location.Y,
//    //    Name = t.Place.Name
//    //})
//    .ToListAsync();



//// TODO, for now filter down to just 3 records
////data = data.GetRange(0, 28).ToList();

//return View(locations);