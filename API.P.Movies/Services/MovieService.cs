using API.P.Movies.DAL.Models;
using API.P.Movies.DAL.Models.Dtos;
using API.P.Movies.Repository.IRepository;
using API.P.Movies.Services.IServices;
using AutoMapper;

namespace API.P.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public Task<bool> CreateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = _movieRepository.GetMoviesAsync();

            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public Task<bool> UpdateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
