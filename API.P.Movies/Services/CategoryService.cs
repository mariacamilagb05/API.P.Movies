using API.P.Movies.DAL.Models;
using API.P.Movies.DAL.Models.Dtos;
using API.P.Movies.Repository.IRepository;
using API.P.Movies.Services.IServices;
using AutoMapper;
using Microsoft.Identity.Client;

namespace API.P.Movies.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        { 
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> CategoryExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateUpdateDto categoryCreateUpdateDto)
        {
            var categoryExists = await _categoryRepository.CategoryExistsByNameAsync(categoryCreateUpdateDto.Name);
            
            if (categoryExists)
            {
                throw new InvalidOperationException($"Ya existe una categoría con el nombre '{categoryCreateUpdateDto.Name}'");
            }

            //Mappear de DTO a la entidad/modelo Category
            var category = _mapper.Map<Category>(categoryCreateUpdateDto);

            //Crear la categoría en la base de datos
            var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated)
            {
                throw new InvalidOperationException("Ocurrió un error al crear la categoría");
            }

            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync(); //Llamando el método desde la capa de Repository

            return _mapper.Map<ICollection<CategoryDto>>(categories); //Mapeo la lista de categorías a una lista de categorías DTO
        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id); //Llamo al método del repositorio
            return _mapper.Map<CategoryDto>(category); //Mapeo la categoría a un CategoryDto y lo retorno
        }

        public async Task<CategoryDto> UpdateCategoryAsync(CategoryCreateUpdateDto categoryCreateUpdateDto, int id)
        {
            //Verificar si la categoría existe
            var existingCategory = await _categoryRepository.GetCategoryAsync(id);

            if (existingCategory == null)
            {
                throw new KeyNotFoundException($"No se encontró la categoría con Id {id}"); 
            }

            //Verificar si el nuevo nombre ya está en uso por otra categoría
            var categoryExistsByName = await _categoryRepository.CategoryExistsByNameAsync(categoryCreateUpdateDto.Name);

            if (categoryExistsByName)
            {
                throw new InvalidOperationException($"Ya existe una categoría con el nombre '{categoryCreateUpdateDto.Name}'");
            }

            //Mappear los cambios del DTO al modelo/entidad
            _mapper.Map(categoryCreateUpdateDto, existingCategory);

            //Actualizar la categoría en la base de datos
            var categoryUpdated = await _categoryRepository.UpdateCategoryAsync(existingCategory);

            if (!categoryUpdated)
            {
                throw new InvalidOperationException("Ocurrió un error al actualizar la categoría");
            }

            return _mapper.Map<CategoryDto>(existingCategory);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            //Verificar si la categoría existe
            var existingCategory = await _categoryRepository.GetCategoryAsync(id);

            if (existingCategory == null)
            {
                throw new InvalidOperationException($"No se encontró la categoría con Id {id}");
            }

            //Eliminar la categoría en la base de datos
            var categoryDeleted = await _categoryRepository.DeleteCategoryAsync(id);

            if (!categoryDeleted)
            {
                throw new InvalidOperationException("Ocurrió un error al eliminar la categoría");
            }

            return categoryDeleted;
        }
    }
}
