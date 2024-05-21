using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.ViewComponents.AboutComponent
{

    public class _AboutComponentPartial : ViewComponent
    {
        AppUserManager _appUserManager = new AppUserManager(new EfAppUserDal());
        public IViewComponentResult Invoke()
        {
            var values = _appUserManager.TGetAll();
            return View(values);
        }

    }
}
