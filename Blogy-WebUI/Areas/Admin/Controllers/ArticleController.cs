using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ArticleController : Controller
    {

        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            var values = _articleService.TGetArticlesWithUser();
            return View(values);
        }
    }
}
