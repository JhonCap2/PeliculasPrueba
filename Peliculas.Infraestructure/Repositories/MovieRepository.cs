using Microsoft.EntityFrameworkCore;
using Peliculas.Core.Entities;
using Peliculas.Core.Interface;
using Peliculas.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Infraestructure.Repositories
{
    public class MovieRepository : IMoviesRepository
    {
        private readonly MovieContext _context;

        public MovieRepository(MovieContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteMovie(int id)
        {
            var currentmovie = await GetMovies(id);
            _context.Movies.Remove(currentmovie);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<Movies>> GetMovies()
        {
            var movies = await _context.Movies.Include(x => x.IdClassificationNavigation).ToListAsync();
            return movies;
        }

        public async Task<Movies> GetMovies(int id)
        {
            var movie = await _context.Movies.SingleOrDefaultAsync(x=>x.IdMovie == id);
            return movie;
        }

        public async Task InsertMovie(Movies newmovies)
        {
            await _context.Movies.AddAsync(newmovies);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateMovie(Movies movies)
        {
            var currentmovie = await GetMovies(movies.IdMovie);
            currentmovie.IdClassification = movies.IdClassification;
            currentmovie.Title = movies.Title;
            currentmovie.Description = movies.Description;
            currentmovie.Cover = movies.Cover;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
