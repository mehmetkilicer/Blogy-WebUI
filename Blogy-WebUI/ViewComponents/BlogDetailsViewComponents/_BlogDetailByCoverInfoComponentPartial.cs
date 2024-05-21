using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.ViewComponents.BlogDetailsViewComponents
{
    public class _BlogDetailByCoverInfoComponentPartial : ViewComponent
    {
        BlogyContext _context = new BlogyContext();

        AppUserManager _appUserManager = new AppUserManager(new EfAppUserDal());
        private readonly IArticleService _articleService;

        public _BlogDetailByCoverInfoComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            

            var values = _articleService.TGetById(id);
            //_context.Users.Where(u => u.Id == p.ReceiverId)
            //    .Select(u => u.Name)
            //    .FirstOrDefault();
            var userıd= values.AppUserId;
           var username= _context.Users.Where(u => u.Id == userıd).Select(u => u.Name).FirstOrDefault();
            var usersurname = _context.Users.Where(u => u.Id == userıd).Select(u => u.Surname).FirstOrDefault();
            var userımg= _context.Users.Where(u => u.Id == userıd).Select(u => u.ImageUrl).FirstOrDefault();
           var date= values.CreatedDate.ToShortDateString();
            ViewBag.v=username+" "+usersurname;
            ViewBag.v1 = userımg;
            ViewBag.v2 = date;

            return View(values);
        }
    }
}
