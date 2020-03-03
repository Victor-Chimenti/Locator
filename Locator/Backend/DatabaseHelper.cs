using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLibrary.Models;
using Locator.Models;

namespace Locator.Backend
{
    public class DatabaseHelper : IDatabaseHelper
    {

        private MaphawksContext context;

        public DatabaseHelper(MaphawksContext context)
        {
            this.context = context;
        }

        public virtual async Task<List<Locations>> ReadMultipleRecordsAsync(bool isDeleted = false)
        {
            var result = await context.Locations
                         .Include(c => c.Contact)
                         .Include(s => s.SpecialQualities)
                         .Include(h => h.DailyHours)
                         .AsNoTracking()
                         .Where(record => record.SoftDelete == isDeleted)
                         .ToListAsync()
                         .ConfigureAwait(false);


            return result;
        }

        public virtual bool LocationIdNotUnique(string id)
        {
            var idExists = context.Locations.Where(x => x.LocationId.Equals(id)).Any();

            return idExists;
        }
    }
}
