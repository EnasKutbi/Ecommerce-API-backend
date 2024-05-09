
using api.EntityFramework;
using api.Helpers;
using Microsoft.EntityFrameworkCore;
namespace api.Service
{
    public class CategoryService
    {
        private AppDbContext _appDbContext;
        public CategoryService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    public async Task<IEnumerable<Category>> GetAllCategoryService()
    {
        return await _appDbContext.Categories.Include(category => category.Products).ToListAsync();
    }
    public async Task<Category?> GetCategoryById(Guid categoryId)
    {
        return await _appDbContext.Categories.Include(category => category.Products).FirstOrDefaultAsync(category => category.CategoryId == categoryId);
    }
    public async Task<Category> CreateCategoryService(Category newCategory)
    {
        
        newCategory.CategoryId = Guid.NewGuid();
        newCategory.Slug = Slug.GenerateSlug(newCategory.Name);
        newCategory.CreatedAt = DateTime.Now;
        _appDbContext.Categories.Add(newCategory); 
        await _appDbContext.SaveChangesAsync();
        return newCategory;
    }
    public async Task<Category?> UpdateCategoryService(Guid categoryId, Category updateCategory)
    {
        var existingCategory = _appDbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        if (existingCategory != null)
            {
                existingCategory.Name = updateCategory.Name;
                existingCategory.Description = updateCategory.Description;
                await _appDbContext.SaveChangesAsync();
            }
            return existingCategory;
        }
        public async Task<bool> DeleteCategoryService(Guid categoryId)
        {
            var categoryToRemove = _appDbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (categoryToRemove != null)
            {
                _appDbContext.Categories.Remove(categoryToRemove);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}