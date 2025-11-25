using API.P.Movies.DAL.Models;
using API.P.Movies.DAL.Models.Dtos;

namespace API.P.Movies.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync();
        Task<MovieDto> GetMovieAsync(int id);
        Task<bool> CreateMovieAsync(Movie movie);
        Task<bool> UpdateMovieAsync(Movie movie);
        Task<bool> DeleteMovieAsync(int id);
    }
}
