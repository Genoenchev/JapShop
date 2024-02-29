using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task AddAsync(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            try
            {
                Category category = await _context.Set<Category>().FirstOrDefaultAsync(x => x.Id == id);
                if (category == null) { throw new Exception("Not found"); }
                EntityEntry entityEntry = _context.Entry<Category>(category);
                entityEntry.State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                _context.Remove(category);
            }
            catch (Exception)
            {
                throw new Exception("Not found"); ;
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            try
            {
                var result = await _context.Set<Category>().ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Category> UpdateCategoryAsync(Category category, int id)
        {

            Category oldCategory = await _context.Set<Category>().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (oldCategory == null)
            {
                throw new Exception("Not found");
            }
            oldCategory.Name = category.Name;
            EntityEntry entityEntry = _context.Entry<Category>(oldCategory);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return oldCategory;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var result = await _context.Set<Category>().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result == null)
            {
                throw new Exception("No item found with the selected id");
            }
            return result;
        }
    }
}
