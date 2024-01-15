using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Magazin_Alimentar.Models;

namespace Magazin_Alimentar.Data
{
    public class Magazin_AlimentarContext : DbContext
    {
        public Magazin_AlimentarContext (DbContextOptions<Magazin_AlimentarContext> options)
            : base(options)
        {
        }

        public DbSet<Magazin_Alimentar.Models.Produs> Produs { get; set; } = default!;

        public DbSet<Magazin_Alimentar.Models.Producator>? Producator { get; set; }
    }
}
