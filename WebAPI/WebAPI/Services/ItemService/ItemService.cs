using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services.ItemService
{
    public class ItemService: IItemService
    {
        private readonly AppDbContext _context;
        public ItemService(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            try
            {
                var result = await _context.Set<Item>().ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddAsync(Item item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            var result = await _context.Set<Item>().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result == null)
            {
                throw new Exception("No item found with the selected id");
            }
            return result;
        }

        public async Task<Item> UpdateItemAsync(Item item, int id)
        {
            Item oldItem = await _context.Set<Item>().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (oldItem == null)
            {
                throw new Exception("Not found");
            }
            oldItem.Price = item.Price;
            oldItem.Name = item.Name;
            oldItem.Description = item.Description;
            oldItem.Category = item.Category;

            EntityEntry entityEntry = _context.Entry<Item>(oldItem);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return oldItem;
        }
        public async Task DeleteItemAsync(int id)
        {
            try
            {
                Item item = await _context.Set<Item>().FirstOrDefaultAsync(x => x.Id == id);
                if (item == null) { throw new Exception("Not found"); }
                EntityEntry entityEntry = _context.Entry<Item>(item);
                entityEntry.State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                _context.Remove(item);
            }
            catch (Exception)
            {
                throw new Exception("Not found"); ;
            }
        }
    }
}
