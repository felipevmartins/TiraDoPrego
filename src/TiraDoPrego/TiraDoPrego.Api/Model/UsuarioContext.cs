using TiraDoPrego.Api.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiraDoPrego.Api.Model
{
    public class UsuarioContext : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }

        public UsuarioContext(DbContextOptions<UsuarioContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new UsuarioMap(modelBuilder.Entity<Usuario>());
        }
    }
}
