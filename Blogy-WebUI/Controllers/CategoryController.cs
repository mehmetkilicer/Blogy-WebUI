using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.Controllers
{
	[AllowAnonymous]

	public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _categoryService.TGetAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _categoryService.TInsert(category);
            return RedirectToAction("index");
        }
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var valu = _categoryService.TGetById(id);
            return View(valu);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return RedirectToAction("index");
        }
    }
}
