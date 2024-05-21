using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogy_WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    //[Route("Writer/Dashboard/")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly BlogyContext _blogContext;

        public DashboardController(UserManager<AppUser> userManager, BlogyContext blogContext)
        {
            _userManager = userManager;
            _blogContext = blogContext;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.numberOfMessagesSent = _blogContext.Messages.Where(x => x.SenderId == user.Id).ToList().Count();
            ViewBag.articleCount = _blogContext.Articles.Where(x => x.AppUserId == user.Id).ToList().Count();
            ViewBag.incomingMessagecount = _blogContext.Messages.Where(x => x.ReceiverId == user.Id).ToList().Count();
            ViewBag.commentCount = _blogContext.Comments.Where(x => x.AppUserID == user.Id).ToList().Count();

            return View();
        }
    }
}
