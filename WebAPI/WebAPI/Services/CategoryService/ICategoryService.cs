using WebAPI.Models;

namespace WebAPI.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category category);
        //Task<IEnumerable<Item>> GetAllFilteredAsync(ItemMask filter);
        Task<Category> UpdateCategoryAsync(Category category, int id);
        Task DeleteCategoryAsync(int id);
        Task<Category> GetByIdAsync(int id);
    }
}
