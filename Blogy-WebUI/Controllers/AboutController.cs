using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.Controllers
{
	[AllowAnonymous]

	public class AboutController : Controller
    {

		private readonly AppUser _appUser;
        public IActionResult Index()
        {
            return View();
        }
    }
}
