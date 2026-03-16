using Entitites;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using ModalClasses;

namespace InventoryManagement.DatabaseActions
{
    public class ProductDB
    {
        InventoryDbContext _db;

        public ProductDB(InventoryDbContext db)
        {
            _db = db;
        }

        public bool AddProduct(Product Newproduct)
        {
            Product? product = _db.Products.FirstOrDefault(p => p.Name == Newproduct.Name);
            if (product == null)
            {
                _db.Products.Add(Newproduct);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveProduct(Product Newproduct)
        {
            Product? product = _db.Products.FirstOrDefault(p => p.Name == Newproduct.Name);
            if (product == null)
            {
                return false;
            }
            else
            {
                _db.Remove(product);
                _db.SaveChanges();
                return true;
            }
        }

        public bool UpdateProduct(ProductDto productDto, ModelStateDictionary modelState)
        {
            Product? existingProduct = _db.Products.FirstOrDefault(p => p.Name == productDto.Name);

            if (existingProduct != null)
            {
                productDto.Patch.ApplyTo(existingProduct);
                _db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<String> ViewProducts()
        {
            String str = "";
            List<Product> products = await _db.Products.ToListAsync();

            foreach (var product in products)
            {
                str += product.Id + " " + product.Name + " " + product.Price + " " + product.CategoryName + "\n";
            }

            return str;
        }
    }
}
