using Entitites;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.DatabaseActions
{ 
    public partial class Categorydb
    {
        public async Task<List<Product>> GetProductByCategoryAsync(string categoryName)
        {
            int count = _db.Categories.Count(p => p.Name == categoryName);
            List<Product> exisitngProducts = await _db.Categories.SelectMany(p => p.Products).ToListAsync();
            return exisitngProducts;
        }
    }
}
