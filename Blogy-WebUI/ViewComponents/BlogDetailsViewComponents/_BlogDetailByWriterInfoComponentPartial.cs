using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy_WebUI.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;

namespace Blogy_WebUI.ViewComponents.BlogDetailsViewComponents
{
    public class _BlogDetailByWriterInfoComponentPartial : ViewComponent
    {
        BlogyContext _context = new BlogyContext();
        private readonly IArticleService _articleService;

        public _BlogDetailByWriterInfoComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(int id)
        {
            //var values = _articleService.TGetWriterInfoByArticleWriter(id);
            var values =_articleService.TGetById(id);
            var userıd = values.AppUserId;
            var username = _context.Users.Where(u => u.Id == userıd).Select(u => u.Name).FirstOrDefault();
            var usersurname = _context.Users.Where(u => u.Id == userıd).Select(u => u.Surname).FirstOrDefault();
            var userımg = _context.Users.Where(u => u.Id == userıd).Select(u => u.ImageUrl).FirstOrDefault();
            var userdescription = _context.Users.Where(u => u.Id == userıd).Select(u => u.Description).FirstOrDefault();


            ViewBag.v = username + " " + usersurname;
            ViewBag.v1 = userımg;
            ViewBag.v2 = userdescription;
            return View();
        }
    }
}
