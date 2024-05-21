using Blogy.EntityLayer.Concrete;
using Blogy_WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.Controllers
{
	[AllowAnonymous]

	public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateRegistorViewModel p)
        {
            if(p.Password != null) 
            
            {
                AppUser appUser = new AppUser()
                {
                    Name = p.Name,
                    Email = p.Email,
                    Surname = p.Surname,
                    UserName = p.UserName,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,

                };

                var result = await _userManager.CreateAsync(appUser, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
          
            return View();
        }
    }
}
