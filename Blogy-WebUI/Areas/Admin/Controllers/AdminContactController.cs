using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.EntityFramework;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        private readonly UserManager<AppUser> _userManager;

        public AdminContactController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Inbox(int p)
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Id;
            var messageList = messageManager.GetListReceiverMessage(p);
            return View(messageList);
        }
    }
}
