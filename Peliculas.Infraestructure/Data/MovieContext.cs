using Microsoft.EntityFrameworkCore;
using Peliculas.Core.Entities;
using Peliculas.Infraestructure.Data.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Infraestructure.Data
{
    public partial class MovieContext : DbContext
    {
        public MovieContext()
        {
            
        }

        public MovieContext(DbContextOptions<MovieContext>options)
            : base(options) 
        { 
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Movies>Movies { get; set; }
        public virtual DbSet<Classifications> Classifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new ClassificationConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
