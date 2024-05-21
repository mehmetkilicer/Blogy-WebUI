using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.Controllers
{
	[AllowAnonymous]

	public class StatisticController : Controller
    {
        private readonly ICategoryService _categoryService;

        public StatisticController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            ViewBag.v = _categoryService.TGetCategoryCount();
            return View();
        }
    }
}
