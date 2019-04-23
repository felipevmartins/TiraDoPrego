using TiraDoPrego.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiraDoPrego.Api.Maps
{
    public class UsuarioMap
    {
        public UsuarioMap(EntityTypeBuilder<Usuario> entityBuilder)
        {
            entityBuilder.HasKey(x => x.id);
            entityBuilder.ToTable("usuarios");

            entityBuilder.Property(x => x.id).HasColumnName("id");
            entityBuilder.Property(x => x.login).HasColumnName("login");
            entityBuilder.Property(x => x.password).HasColumnName("password");
            entityBuilder.Property(x => x.email).HasColumnName("email");
            entityBuilder.Property(x => x.admin).HasColumnName("admin");
        }
    }
}
