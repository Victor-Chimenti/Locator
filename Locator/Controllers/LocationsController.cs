using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatabaseLibrary.Models;
using Locator.Backend;
using Locator.Models;
using System.Collections.Generic;

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
            var cleanResults = await GetCleanViewModel();

            return new JsonResult(cleanResults.CleanLocationList);
        }




        public async Task<CleanLocationViewModel> GetCleanViewModel()
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


            // Change the call to IndexAsync, to pass in a TakeIndex, TakeSize, and Point to get spacial search for Take Size number of records
            //var point = new PositionModel(Latitude, Longitude);
            //var dirtyResults = await backend.IndexAsync(100, 0, point).ConfigureAwait(false);
            var dirtyResults = await backend.IndexAsync().ConfigureAwait(false);


            var cleanResults = new CleanLocationViewModel(dirtyResults);
            cleanResults.CleanLocationList = cleanResults.CleanLocationList.GetRange(0, 512);

            return cleanResults;
        }
    }
}