using API.P.Movies.DAL.Models;

namespace API.P.Movies.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetMoviesAsync(); //Retorna una lista de películas
        Task<Movie> GetMovieAsync(int id); //Retorna una película por su Id
        Task<bool> MovieExistsByIdAsync(int id); //Dice si una película existe por su Id
        Task<bool> MovieExistsByNameAsync(string name); //Dice si una película existe por su Nombre
        Task<bool> CreateMovieAsync(Movie movie); //Crea una película
        Task<bool> UpdateMovieAsync(Movie movie); //Actualiza una película
        Task<bool> DeleteMovieAsync(int id); //Elimina una película
    }
}
