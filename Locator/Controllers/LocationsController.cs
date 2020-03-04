using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using DatabaseLibrary.Models;

using Locator.Backend;
using Locator.Models;


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

            return new JsonResult(cleanResults);
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

            var point = new PositionModel(Latitude, Longitude);



            // Change the call to IndexAsync, to pass in a TakeIndex, TakeSize, and Point to get spacial search for Take Size number of records

            //  var dirtyResults = await backend.IndexAsync(100,0,point).ConfigureAwait(false);
            var dirtyResults = await backend.IndexAsync().ConfigureAwait(false);
            var cleanResults = new CleanLocationViewModel(dirtyResults);

            //// TODO, for now filter down to just num records
            cleanResults.CleanLocationList = cleanResults.CleanLocationList.GetRange(0, 28);

            return cleanResults;
        }
    }
}
