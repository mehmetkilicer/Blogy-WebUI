using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Blogy.DtoLayer.CommentDtos;
using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.EntityFramework;

namespace Blogy_WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]

    public class CommentController : Controller
    {
        CommentManager CommentManager = new CommentManager(new EfCommentDal());
        private readonly UserManager<AppUser> _userManager;

        public CommentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = CommentManager.CommentListByUserId(user.Id);
            var result = values.Select(x => new CommentListByUserIdDto
            {
                ArticleTitle = x.Articles.Title,
                CommentId = x.CommentId,
                Content = x.Content,
                Date = x.CommentDate,
                UserImageUrl = x.AppUser.ImageUrl,
                UserNameSurname = x.AppUser.Name + " " + x.AppUser.Surname,
            }).ToList();
            return View(result);
        }

    }
}
