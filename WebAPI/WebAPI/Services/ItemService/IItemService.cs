using WebAPI.Models;

namespace WebAPI.Services.ItemService
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task AddAsync(Item item);
        //Task<IEnumerable<Item>> GetAllFilteredAsync(ItemMask filter);
        Task<Item> UpdateItemAsync(Item item, int id);
        Task DeleteItemAsync(int id);
        Task<Item> GetByIdAsync(int id);
    }
}
