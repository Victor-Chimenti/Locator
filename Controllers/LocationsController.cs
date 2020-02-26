﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Locator.Models;
using NetTopologySuite;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace Locator.Controllers
{
    public class LocationsController : Controller
    {
        private readonly MaphawksContext _context;

        public const string SessionKeyLatitude = "latitude";
        public const string SessionKeyLongitude = "longitude";

        const string SessionKeyTime = "_Time";

        public string SessionInfo_Latitude { get; private set; }
        public string SessionInfo_Longitude { get; private set; }
        public string SessionInfo_CurrentTime { get; private set; }
        public string SessionInfo_SessionTime { get; private set; }
        public string SessionInfo_MiddlewareValue { get; private set; }

        public LocationsController(MaphawksContext context)
        {
            _context = context;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            var data = await _context.Locations.
                                Include(c => c.Contacts).
                                Include(s => s.SpecialQualities).
                                Include(h => h.DailyHours).
                                ToListAsync();

            var Latitude = Request.Cookies[SessionKeyLatitude];
            var Longitude = Request.Cookies[SessionKeyLongitude];

            // Requires: using Microsoft.AspNetCore.Http;
            if (string.IsNullOrEmpty(Latitude))
            {
                return View(data);
            }

            if (string.IsNullOrEmpty(Longitude))
            {
                return View(data);
            }

            // TODO, for now filter down to just 3 records
            data = data.GetRange(0, 3).ToList();

            return View(data);
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locations = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (locations == null)
            {
                return NotFound();
            }

            return View(locations);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,CoopLocationId,TakeCoopData,SoftDelete,Name,Address,City,County,State,PostalCode,Country,Latitude,Longitude,Hours,RetailOutlet,LocationType")] Locations locations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locations);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locations = await _context.Locations.FindAsync(id);
            if (locations == null)
            {
                return NotFound();
            }
            return View(locations);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LocationId,CoopLocationId,TakeCoopData,SoftDelete,Name,Address,City,County,State,PostalCode,Country,Latitude,Longitude,Hours,RetailOutlet,LocationType")] Locations locations)
        {
            if (id != locations.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationsExists(locations.LocationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(locations);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locations = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (locations == null)
            {
                return NotFound();
            }

            return View(locations);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var locations = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(locations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationsExists(string id)
        {
            return _context.Locations.Any(e => e.LocationId == id);
        }

        //[HttpPost]
        //public ActionResult GetUserCoords(string stringCoord)
        //{
        //    var locationInput = JsonSerializer.Deserialize<LocationInputModel>(stringCoord);
        //    return View(locationInput);
        //}

        //[HttpPost]
        //public IActionResult LocationSearch(IndexViewPageModel indexModel)
        //{
        //    var indexViewModel = new IndexViewPageModel
        //    {
        //        LocationInput = indexModel.LocationInput
        //    };

        //    var searchLocation = new Point(indexModel.LocationInput.Latitude, indexModel.LocationInput.Longitude) { SRID = 4326 };

        //    var tellerMachines = _child_context
        //        .TellerMachines
        //        .Select(teller => new { Place = teller, Distance = teller.Position.Distance(searchLocation) })
        //        .ToList();

        //    indexViewModel.TellerMachines = tellerMachines
        //        .OrderBy(x => x.Distance)
        //        .Select(t => new TellerMachineViewModel
        //        {
        //            Distance = Math.Round(t.Distance, 6),
        //            Latitude = t.Place.Position.X,
        //            Longitude = t.Place.Position.Y,
        //            Name = t.Place.Name
        //        }).ToList();

        //    return View("index", indexViewModel);
        //}
    }
}
