using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Watermelon.Models
{
    public partial class LocationContext : DbContext
    {
        public DbSet<Airport> Airport { get; set; }
        public DbSet<City> City { get; set; }

        public LocationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
