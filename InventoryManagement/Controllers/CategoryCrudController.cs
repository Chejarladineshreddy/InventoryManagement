
using Entitites;
//using ModalClass;
using ModalClasses;
using InventoryManagement.DatabaseActions;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    [ApiController]
    [Route("/Category")]
    public class CategoryDb : Controller
    {
        private Categorydb _categoryDb;

        public CategoryDb(Categorydb categoryDb)
        {
            _categoryDb = categoryDb;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            return Json(await _categoryDb.ViewAllCategoriesAsync());
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCategoryAsync(String name)
        {
            return Json(await _categoryDb.GetProductByCategoryAsync(name));
        }

        [HttpPost]
        public async Task<IActionResult> PostCategoryAsync([FromForm] CategoryDto categoryDto)
        {
            await _categoryDb.AddCategoryAsync(categoryDto);
            return Json(await _categoryDb.ViewAllCategoriesAsync());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryAsync([FromForm] CategoryDto categoryDto)
        {
            await _categoryDb.DeleteCategoryAsync(categoryDto);
            return Json(await _categoryDb.ViewAllCategoriesAsync());
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] CategoryDto categoryDto)
        {
            await _categoryDb.UpdateCategoryAsync(categoryDto, ModelState);
            return Json(await _categoryDb.ViewAllCategoriesAsync());
        }
    }
}
