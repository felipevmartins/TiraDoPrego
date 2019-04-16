using TiraDoPrego.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiraDoPrego.Api.Maps
{
    public class PrestadorMap
    {
        public PrestadorMap(EntityTypeBuilder<Prestador> entityBuilder)
        {
            entityBuilder.HasKey(x => x.id);
            entityBuilder.ToTable("prestadores");

            entityBuilder.Property(x => x.id).HasColumnName("id");
            entityBuilder.Property(x => x.nome).HasColumnName("nome");
            entityBuilder.Property(x => x.latitude).HasColumnName("latitude");
            entityBuilder.Property(x => x.longitude).HasColumnName("longitude");
            entityBuilder.Property(x => x.horario).HasColumnName("horario");
            entityBuilder.Property(x => x.telefone).HasColumnName("telefone");
        }
    }
}
