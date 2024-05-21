using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class WriterController : Controller
    {
        AppUserManager _appUserManager = new AppUserManager(new EfAppUserDal());

        public IActionResult Index()
        {
           var values = _appUserManager.TGetAll().Where(x => x.Name != "Admin").ToList();
            return View(values);
        }
    }
}
