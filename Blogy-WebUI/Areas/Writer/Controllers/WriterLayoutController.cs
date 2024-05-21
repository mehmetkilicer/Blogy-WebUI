using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class WriterLayoutController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public WriterLayoutController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

   
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            return View(values);
        }
    }
}
