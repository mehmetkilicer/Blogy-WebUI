using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]

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
    }
}
