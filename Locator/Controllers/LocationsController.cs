using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatabaseLibrary.Models;
using Locator.Backend;
using Locator.Models;
using System.Collections.Generic;
using System.Linq;
using NetTopologySuite;
using NetTopologySuite.Geometries;


namespace Locator.Controllers
{
    public class LocationsController : Controller
    {
        private readonly MaphawksContext _context;

        private LocationsBackend backend;

        public LocationsController(MaphawksContext context, LocationsBackend backend = null)
        {
            _context = context;

            // Fork to allow for mocking out backend
            if (backend != null)
            {
                this.backend = backend;
            }
            else
            {
                this.backend = new LocationsBackend(_context);
            }
        }



        public async Task<IActionResult> Index()
        {
            var cleanResults = await GetCleanViewModel();

            return View(cleanResults);
        }



        [Produces("application/json")]
        public async Task<JsonResult> CardJson()
        {
            var Latitude = Request.Cookies["latitude"];
            var Longitude = Request.Cookies["longitude"];

            if (string.IsNullOrEmpty(Latitude))
            {
                Latitude = "47.490209";
            }

            if (string.IsNullOrEmpty(Longitude))
            {
                Longitude = "-122.272126";
            }

            var point = new PositionModel(Latitude, Longitude);

            var cleanResults = await GetCleanViewModel();

            // assign user coordinates
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            Point userPoint = geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(point.Lat, point.Lng));
            // update distance value based on user coordinates
            foreach (var value in cleanResults.CleanLocationList)
            {
                value.MyDistance = value.MyPoint.Distance(userPoint);
            }
            // sort the clean results list by distance
            var cleanSortedList = cleanResults.CleanLocationList
                .OrderBy(x => x.MyDistance).ToList();



            var data = new
            {
                point,
                cleanSortedList
            };


            return new JsonResult(data);
        }




        public async Task<CleanLocationViewModel> GetCleanViewModel()
        {

            //var dirtyResults = await backend.IndexAsync(100, 0, point).ConfigureAwait(false);
            var dirtyResults = await backend.IndexAsync().ConfigureAwait(false);


            var cleanResults = new CleanLocationViewModel(dirtyResults);
            cleanResults.CleanLocationList = cleanResults.CleanLocationList.GetRange(0, 16);

            return cleanResults;
        }
    }
}