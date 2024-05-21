using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.Controllers
{
    public class ErrorPageController : Controller
    {
		[AllowAnonymous]

		public IActionResult NotFound404()
        {
            return View();
        }
    }
}
