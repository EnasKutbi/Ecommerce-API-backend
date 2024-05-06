using src.Helpers;

public class CategoryService
{ 
    public static List<Category> _categories = new List<Category>() {
    new Category{
        CategoryId = Guid.Parse("75424b9b-cbd4-49b9-901b-056dd1c6a020"),
        Name = "Computer & Tablets",
        Slug = "computer-&-tablets",
        Description = "This category includes a wide range of devices, including desktop computers, laptops, tablets, and accessories such as keyboards, mice, and styluses. Customers can find products related to computing and mobile productivity in this category.",
        CreatedAt = DateTime.Now
    },
    new Category{
        CategoryId = Guid.Parse("24508f7e-94ec-4f0b-b8d6-e8e16a9a3b29"),
        Name = "Computer Supplies",
        Slug = "computer-supplies",
        Description = "This category focuses on essential supplies and peripherals for computers, including cables, adapters, storage devices (such as USB flash drives and external hard drives), printer supplies (such as ink cartridges and toner), and other accessories needed to enhance or maintain computer systems.",
        CreatedAt = DateTime.Now
    },
    new Category{
        CategoryId = Guid.Parse("87e5c4f3-d3e5-4e16-88b5-809b2b08b773"),
        Name = "Smartphones",
        Slug = "smartphones",
        Description = "This category features a variety of smartphones from different manufacturers, including popular brands like Apple, Samsung, Google, and others. Customers can browse through the latest models, compare features, and find the perfect smartphone to meet their needs.",
        CreatedAt = DateTime.Now
    }
};

    public async Task<IEnumerable<Category>> GetAllCategoryService()
    {
        return await Task.FromResult(_categories.AsEnumerable());
    }
    public Task<Category?> GetCategoryById(Guid categoryId)
    {
        return Task.FromResult(_categories.Find(category => category.CategoryId == categoryId));
    }
    public async Task<Category> CreateCategoryService(Category newCategory)
    {
        await Task.CompletedTask;
        newCategory.CategoryId = Guid.NewGuid();
        newCategory.Slug = Slug.GenerateSlug(newCategory.Name);
        newCategory.CreatedAt = DateTime.Now;
        _categories.Add(newCategory); 
        return newCategory;
    }
    public async Task<Category> UpdateCategoryService(Guid categoryId, Category updateCategory)
    {
        await Task.CompletedTask;
        var existingCategory = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
        if (existingCategory != null)
        {
            existingCategory.Name = updateCategory.Name;
            existingCategory.Description = updateCategory.Description;

        }
        return existingCategory;
    }
    public async Task<bool> DeleteCategoryService(Guid categoryId)
    {
        await Task.CompletedTask;
        var categoryToRemove = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
        if (categoryToRemove != null)
        {
            _categories.Remove(categoryToRemove);
            return true;
        }
        return false;
    }

}