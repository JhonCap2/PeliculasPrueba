using Peliculas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Core.Interface
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<Movies>> GetMovies();
        Task<Movies> GetMovie(int id);
        Task InsertMovie(Movies newmovies);
        Task <bool> UpdateMovie(Movies movies);
        Task <bool> DeleteMovie(int id);
    }
}
