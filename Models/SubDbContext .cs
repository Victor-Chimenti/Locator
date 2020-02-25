using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locator.Models
{
    public class SubDbContext : MaphawksContext
    {

        public ILogger<SubDbContext> Logger { get; protected set; }

        public SubDbContext (DbContextOptions<SubDbContext> options, ILogger<SubDbContext> logger)
            : base(options)
        {
        }
    }
}
