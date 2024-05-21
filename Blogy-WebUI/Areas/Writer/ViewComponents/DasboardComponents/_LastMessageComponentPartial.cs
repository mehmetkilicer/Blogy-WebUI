using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.EntityFramework;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.Areas.Writer.ViewComponents.DasboardComponents
{
    
    public class _LastMessageComponentPartial :ViewComponent
    {
        MessageManager MessageManager = new MessageManager(new EfMessageDal());
        private readonly UserManager<AppUser> _userManager;

        public _LastMessageComponentPartial( UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync(int p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Id;
            var messageList = MessageManager.Last3Message(p);
            return View(messageList);
        }
    }
}
