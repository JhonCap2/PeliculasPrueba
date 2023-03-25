using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peliculas.Api.Response;
using Peliculas.Core.DTOs;
using Peliculas.Core.Entities;
using Peliculas.Core.Interface;

namespace Peliculas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private IMoviesRepository _movieRepository;
        private readonly IMapper _mapper;
        public MoviesController(IMoviesRepository moviesRepository, IMapper mapper)
        {
            _movieRepository = moviesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieRepository.GetMovies();
            var movieDto = _mapper.Map<IEnumerable<MoviesDto>>(movies);
            var response = new ApiResponse<IEnumerable<MoviesDto>>(movieDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movies = await _movieRepository.GetMovies(id);
            var movieDto = _mapper.Map<MoviesDto>(movies);
            var response = new ApiResponse<MoviesDto>(movieDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertMovie(Movies newmovie)
        {
            await _movieRepository.InsertMovie(newmovie);
            var movieDto = _mapper.Map<MoviesDto>(newmovie);
            var reponse = new ApiResponse<MoviesDto>(movieDto);
            return Ok(reponse);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateMovie(MoviesDto upmovie)
        {
            var movie = _mapper.Map<Movies>(upmovie);
            await _movieRepository.UpdateMovie(movie);
            var reponse = new ApiResponse<Movies>(movie);
            return Ok(reponse);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            var movie = await _movieRepository.DeleteMovie(id);
            return Ok(movie);
        }
    }
}
