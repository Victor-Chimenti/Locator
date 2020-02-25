using Locator.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locator.Models
{
    public class SubDbContext : MaphawksContext
    {

        public SubDbContext (DbContextOptions<SubDbContext> options)
            : base(options)
        {
        }

        public DbSet<TellerMachineViewModel> TellerMachineViewModels { get; set; }

    }
}
