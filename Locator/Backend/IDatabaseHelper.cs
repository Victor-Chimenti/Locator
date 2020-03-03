using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using DatabaseLibrary.Models;
using System.Collections.Generic;
using Locator.Models;

namespace Locator.Backend
{
    public class IDatabaseHelper
    {

        public Task<List<Locations>> ReadMultipleRecordsAsync(bool isDeleted = false);

        public bool LocationIdNotUnique(string id);
    }
}
