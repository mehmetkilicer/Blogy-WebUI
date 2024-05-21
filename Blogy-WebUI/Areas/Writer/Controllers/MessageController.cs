using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.EntityFramework;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;

namespace Blogy_WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    //[Route("Writer/Message/")]
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        AppUserManager _appUserManager = new AppUserManager(new EfAppUserDal()); 
        private readonly UserManager<AppUser> _userManager;
        BlogyContext _context = new BlogyContext();

        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _appUserManager.TGetAll();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            List<SelectListItem> values =(from x in _context.Users.ToList()
                                          select new SelectListItem
                                          {
                                              Text = $"{x.Name} {x.Surname}",
                                              Value = x.Id.ToString()
                                          }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message p)
        {
            //List<SelectListItem> values1 = (from x in _context.Users.ToList()
            //                                select new SelectListItem
            //                                {
            //                                    Text = x.Name,
            //                                    Value = x.Id.ToString()
            //                                }).ToList();
            //ViewBag.Values = values1;

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p.DateTime = DateTime.Now;
            p.SenderId = values.Id;
            p.ImportantMessage = true;
            p.MessageTrash = false;
            p.ImageUrl = values.ImageUrl;
            p.Name = values.Name;
            p.Surname = values.Surname;

            var receiverName = _context.Users.Where(u => u.Id == p.ReceiverId)
                .Select(u => u.Name)
                .FirstOrDefault();


            var receiverSurName = _context.Users.Where(u => u.Id == p.ReceiverId)
            .Select(u => u.Surname)
            .FirstOrDefault();

            var receiverImage = _context.Users.Where(u => u.Id == p.ReceiverId)
        .Select(u => u.ImageUrl)
        .FirstOrDefault();

            p.ReceiverSurname = receiverSurName;
            p.ReceiverName = receiverName;
            p.ReceiverImageUrl = receiverImage;

            messageManager.TInsert(p);
            return Redirect("SendMessage");


        }
        public async Task<IActionResult> Inbox(int p)
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Id;
            var messageList = messageManager.GetListReceiverMessage(p);
            return View(messageList);
        }

        public IActionResult MessageDetails(int id)
        {
            var value = messageManager.TGetById(id);
            return View(value);
        }


    }
}
