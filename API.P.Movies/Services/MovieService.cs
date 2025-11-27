using API.P.Movies.DAL.Models;
using API.P.Movies.DAL.Models.Dtos;
using API.P.Movies.Repository;
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

        public async Task<bool> MovieExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> MovieExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieCreateUpdateDto)
        {
            var movieExists = await _movieRepository.MovieExistsByNameAsync(movieCreateUpdateDto.Name);
            
            if (movieExists)
            {
                throw new InvalidOperationException($"Ya existe una película con el nombre '{movieCreateUpdateDto.Name}'");
            }

            //Mappear de DTO a la entidad/modelo Movie
            var movie = _mapper.Map<Movie>(movieCreateUpdateDto);

            //Crear la película en la base de datos
            var movieCreated = await _movieRepository.CreateMovieAsync(movie);

            if (!movieCreated)
            {
                throw new InvalidOperationException("Ocurrió un error al crear la película");
            }

            var movieDto = _mapper.Map<MovieDto>(movie);
            return movieDto;
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id); //Llamo al método del repositorio
            return _mapper.Map<MovieDto>(movie); //Mapeo la categoría a un CategoryDto y lo retorno
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync(); //Llamando el método desde la capa de Repository

            return _mapper.Map<ICollection<MovieDto>>(movies); //Mapeo la lista de categorías a una lista de categorías DTO
        }

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto movieCreateUpdateDto, int id)
        {
            //Verificar si la película existe
            var existingMovie = await _movieRepository.GetMovieAsync(id);
            
            if (existingMovie == null)
            {
                throw new KeyNotFoundException($"No se encontró la película con Id {id}");
            }

            //Verificar si el nuevo nombre ya está en uso por otra película
            var movieExistsByName = await _movieRepository.MovieExistsByNameAsync(movieCreateUpdateDto.Name);

            if (movieExistsByName)
            {
                throw new InvalidOperationException($"Ya existe una película con el nombre '{movieCreateUpdateDto.Name}'");
            }

            //Mappear los cambios del DTO al modelo/entidad
            _mapper.Map(movieCreateUpdateDto, existingMovie);

            //Actualizar la película en la base de datos
            var movieUpdated = await _movieRepository.UpdateMovieAsync(existingMovie);

            if (!movieUpdated)
            {
                throw new InvalidOperationException("Ocurrió un error al actualizar la película");
            }

            return _mapper.Map<MovieDto>(existingMovie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            //Verificar si la película existe
            var existingMovie = await _movieRepository.GetMovieAsync(id);

            if (existingMovie == null)
            {
                throw new InvalidOperationException($"No se encontró la película con Id {id}");
            }

            //Eliminar la película en la base de datos
            var movieDeleted = await _movieRepository.DeleteMovieAsync(id);

            if (!movieDeleted)
            {
                throw new InvalidOperationException("Ocurrió un error al eliminar la película");
            }

            return movieDeleted;
        }
    }
}
