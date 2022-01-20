using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Orar.Models;

namespace Orar.Data
{
    public class OrarContext : DbContext
    {
        public OrarContext (DbContextOptions<OrarContext> options)
            : base(options)
        {
        }

        public DbSet<Orar.Models.Profesor> Profesor { get; set; }

        public DbSet<Orar.Models.Materie> Materie { get; set; }

        public DbSet<Orar.Models.Clasa> Clasa { get; set; }
    }
}
