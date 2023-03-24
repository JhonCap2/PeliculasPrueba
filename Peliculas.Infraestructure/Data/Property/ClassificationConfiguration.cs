using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peliculas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Infraestructure.Data.Property
{
    public class ClassificationConfiguration : IEntityTypeConfiguration<Classifications>
    {
        public void Configure(EntityTypeBuilder<Classifications> builder)
        {
            builder.ToTable("Classifications");
            builder.HasKey(e => e.IdClassification)
                .HasName("Id");

            builder.Property(e => e.IdClassification)
                .HasColumnName("IdClassification");
                
            builder.Property(e=>e.Name)
                .HasColumnName("Name")
                .HasMaxLength(60);
        }
    }
}
