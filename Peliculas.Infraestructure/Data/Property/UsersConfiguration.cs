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
            builder.HasKey(e => e.UserId)
                .HasName("Id");

            builder.Property(e => e.UserId)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(e => e.UserName)
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(e=>e.UserEmail)
                .HasColumnName("Email")
                .IsRequired();

            builder.Property(e => e.User)
                .HasColumnName("User")
                .IsRequired();

            builder.Property(e=>e.Password)
                .HasColumnName("Password")
                .IsRequired();
        }
    }
}
