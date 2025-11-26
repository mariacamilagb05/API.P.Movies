using API.P.Movies.DAL.Models;
using API.P.Movies.DAL.Models.Dtos;

namespace API.P.Movies.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync();
        Task<MovieDto> GetMovieAsync(int id);
        Task<bool> MovieExistsByIdAsync(int id);
        Task<bool> MovieExistsByNameAsync(string name);
        Task<MovieDto> CreateMovieAsync(MovieCreateDto movieCreateDto);
        Task<bool> UpdateMovieAsync(Movie movie);
        Task<bool> DeleteMovieAsync(int id);
    }
}
