using Blogy.EntityLayer.Concrete;
using Blogy_WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSigninViewModel model)
        {
            if (model.Username !=null && model.Password != null)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password,false,true);
                if (result.Succeeded)
                {
                    return RedirectToAction("MyBlogList", "Blog", new { area = "Writer" });


                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı ve sifre hatalı");
                }
            }
            else 
            {
                ModelState.AddModelError("", "Lutfen alanları bos gecmeyin!");
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }        
          
        
    }
}
