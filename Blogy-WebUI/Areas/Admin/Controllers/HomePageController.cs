using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using static Blogy_WebUI.Areas.Writer.Models.WeaherViewModel;

namespace Blogy_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageController : Controller
    {
        private readonly IArticleService _articleService;
        CommentManager CommentManager = new CommentManager(new EfCommentDal());
        AppUserManager AppUserManager = new AppUserManager(new EfAppUserDal());

        public HomePageController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            DateTime today = DateTime.Now;

            CultureInfo culture = new CultureInfo("tr-TR");

            DayOfWeek dayOfWeek = today.DayOfWeek;

            ViewBag.Today = culture.DateTimeFormat.GetDayName(dayOfWeek);
            ViewBag.Teknoloji = _articleService.TGetAll().Where(x => x.CategoryId == 1).Count();
            ViewBag.spor = _articleService.TGetAll().Where(x => x.CategoryId == 3).Count();
            ViewBag.saglık = _articleService.TGetAll().Where(x => x.CategoryId == 6).Count();
            ViewBag.egitim = _articleService.TGetAll().Where(x => x.CategoryId == 8).Count();
            ViewBag.kultursanat = _articleService.TGetAll().Where(x => x.CategoryId == 9).Count();
            ViewBag.ArticleCount = _articleService.TGetAll().Count();
            ViewBag.UserCount = AppUserManager.TGetAll().Count();
            ViewBag.CommentCount = CommentManager.TGetAll().Count();    

            return View();
        }
    }
}
