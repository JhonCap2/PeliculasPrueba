using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peliculas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Infraestructure.Data.Property
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movies>
    {
        public void Configure(EntityTypeBuilder<Movies> builder)
        {
            builder.ToTable("Movies");
            builder.HasKey(e => e.IdMovie)
                .HasName("Id");

            builder.Property(e => e.IdMovie)
                .HasColumnName("IdMovie");

            builder.Property(e => e.IdClassification)
                .HasColumnName("IdClassification");

            builder.Property(e=>e.Title)
                .HasColumnName("Title")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.FrontPage)
                .HasColumnName("FrontPage")
                .IsRequired();

            builder.HasOne(d => d.IdClassificationNavigation)
                .WithMany(p => p.Movies)
                .HasForeignKey(d => d.IdClassification)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Classification_Movie");
        }
    }
}
