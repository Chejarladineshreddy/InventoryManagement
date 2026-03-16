using Entitites;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModalClasses;

namespace InventoryManagement.DatabaseActions
{
    public partial class Categorydb
    {
        private InventoryDbContext _db;

        public Categorydb(InventoryDbContext inventoryDbContext)
        {
            _db = inventoryDbContext;
        }

        public async Task<bool> AddCategoryAsync(CategoryDto category)
        {
            var existingProduct = _db.Categories.FirstOrDefault(cat => cat.Name == category.Name);

            if (existingProduct == null)
            {
                var newCategory = new Category() { Name = category.Name, Description = category.Description };
                await _db.Categories.AddAsync(newCategory);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteCategoryAsync(CategoryDto category)
        {
            var existingProduct = _db.Categories.FirstOrDefault(cat => cat.Name == category.Name);

            if (existingProduct != null)
            {
                // Note: The screenshot shows a variable 'newCategory' being declared but not used here 
                // while the existingProduct is removed.
                _db.Categories.Remove(existingProduct);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateCategoryAsync(CategoryDto category, ModelStateDictionary modelState)
        {
            var existingProduct = _db.Categories.FirstOrDefault(cat => cat.Name == category.Name);

            if (existingProduct != null)
            {
                category.Patch.ApplyTo(existingProduct);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<CategoryDto>> ViewAllCategoriesAsync()
        {
            List<CategoryDto> allCategories = new List<CategoryDto>();
            allCategories.AddRange(_db.Categories.Select(cat => new CategoryDto()
            {
                Name = cat.Name,
                Description = cat.Description
            }));

            return allCategories;
        }
    }
}
