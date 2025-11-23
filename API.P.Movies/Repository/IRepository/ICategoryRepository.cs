using API.P.Movies.DAL.Models;

namespace API.P.Movies.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync(); //Retorna una lista de categorías
        Task<Category> GetCategoryAsync(int id); //Retorna una categoría por su Id
        Task<bool> CategoryExistsByIdAsync(int id); //Dice si una categoría existe por su Id
        Task<bool> CategoryExistsByNameAsync(string name); //Dice si una categoría existe por su Nombre
        Task<bool> CreateCategoryAsync(Category category); //Crea una categoría
        Task<bool> UpdateCategoryAsync(Category category); //Actualiza una categoría
        Task<bool> DeleteCategoryAsync(int id); //Elimina una categoría
    }
}
