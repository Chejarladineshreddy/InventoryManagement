using Entitites;
using InventoryManagement.DatabaseActions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModalClasses;

namespace Database.Controllers
{
    //[ApiController]
    [Route("/products/")]
    public class ProductCRUDController : Controller
    {
        private ProductDB _Productdb { get; set; }

        public ProductCRUDController(ProductDB productdbacess)
        {
            _Productdb = productdbacess;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ProductDto productDetails)
        {
            _Productdb.AddProduct(new Product()
            {
                CategoryName = productDetails.CategoryName,
                Name = productDetails.Name,
                Price = (double)productDetails.Price,
                Description= productDetails.Description,
                CategoryId= (long) productDetails.CategoryId
            });

            String res = await _Productdb.ViewProducts();
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] String name)
        {
            _Productdb.RemoveProduct(new Product() { Name = name });

            String res = await _Productdb.ViewProducts();
            return Ok(res);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] ProductDto productDto)
        {
            _Productdb.UpdateProduct(productDto, ModelState);

            String res = await _Productdb.ViewProducts();
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> ViewAll()
        {
            String res = await _Productdb.ViewProducts();
            return Ok(res);
        }
    }
}
