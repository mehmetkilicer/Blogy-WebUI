using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Blogy_WebUI.Areas.Writer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy_WebUI.Areas.Writer.Controllers
{
	[Area("Writer")]
    //[Route("Writer/Blog/")]
    public class BlogController : Controller
    {
      
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public BlogController(UserManager<AppUser> userManager, IArticleService articleService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> MyBlogList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //ViewBag.id = user.Id + " " + user.Name + " " + user.Surname;
            var values = _articleService.TGetArticlesByWriter(user.Id);
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateBlog()
        {
            List<SelectListItem> values = (from x in _categoryService.TGetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(Article article)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            article.AppUserId = user.Id;
            //article.WriterId = 1;
            article.CreatedDate = DateTime.Now;
            _articleService.TInsert(article);
            return RedirectToAction("MyBlogList");
        }
        public IActionResult DeleteBlog(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("MyBlogList");
        }
        [HttpGet]
        public IActionResult UpdateBlog(int id) 
        {
            var value = _articleService.TGetById(id);
            List<SelectListItem> values = (from x in _categoryService.TGetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            var model = new UpdateArticleViewModel
            {
                Title = value.Title,
                ArticleId = id,
                CategoryId = value.CategoryId,
                Description = value.Description,
                CoverImageUrl = value.CoverImageUrl
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateArticleViewModel article)
        {
            var values =_articleService.TGetById(article.ArticleId);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            values.AppUserId = user.Id;
            values.CreatedDate = values.CreatedDate;
            values.Title = article.Title;
            values.Description = article.Description;   
            values.CoverImageUrl = article.CoverImageUrl;
            values.CategoryId = article.CategoryId;

            _articleService.TUpdate(values);
            return RedirectToAction("MyBlogList");
        }
    }
}
