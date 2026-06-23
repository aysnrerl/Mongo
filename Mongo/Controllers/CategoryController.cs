using Microsoft.AspNetCore.Mvc;
using Mongo.Dtos.CategoryDto;
using Mongo.Service.CategoryServices;

namespace Mongo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
            await _categoryService.CreateCategoryAsync(dto);
            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            var values = await _categoryService.GetCategoryByIdAsync(id);
            var model = new UpdateCategoryDto
            {
                CategoryId = values.CategoryId,
                CategoryName = values.CategoryName,
                Description = values.Description,
                IconUrl = values.IconUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
            await _categoryService.UpdateCategoryAsync(dto);
            return RedirectToAction("CategoryList");
        }
    }
}
