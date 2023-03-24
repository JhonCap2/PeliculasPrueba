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
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(e => e.UserId);

            builder.Property(e => e.UserId)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(e => e.UserName)
                .IsRequired();

            builder.Property(e=>e.UserEmail)
                .IsRequired();

            builder.Property(e => e.User)
                .IsRequired();

            builder.Property(e=>e.Password)
                .IsRequired();
        }
    }
}
