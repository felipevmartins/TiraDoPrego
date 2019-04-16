using TiraDoPrego.Api.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiraDoPrego.Api.Model
{
    public class PrestadorContext : DbContext
    {
        public DbSet<Prestador> prestadores { get; set; }

        public PrestadorContext(DbContextOptions<PrestadorContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new PrestadorMap(modelBuilder.Entity<Prestador>());
        }
    }
}
