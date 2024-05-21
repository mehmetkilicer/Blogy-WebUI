using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Blogy_WebUI.Dtos.BlogDtos;
using Blogy_WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Blogy_WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IContactService _contactService;
        public BlogController(IArticleService articleService, IContactService contactService)
        {
            _articleService = articleService;
            _contactService = contactService;
        }

        public IActionResult BlogList(string search)
        {
			if (!string.IsNullOrEmpty(search))
			{
				var articles = _articleService.TGetArticleFilterList(search);
                var result = articles.Select(x => new _GetArticleListDto()
                {
                    Content = x.Description,
                    Date = x.CreatedDate,
                    Id = x.ArticleId,
                    ImageUrl = x.CoverImageUrl,
                    Title = x.Title,
                    NameSurname = x.AppUser.Name + " " + x.AppUser.Surname,
                    UserImageUrl = x.AppUser.ImageUrl,
                    CategoryID = x.CategoryId
                }).ToList();
                ViewBag.Search = search;
				return View(result);
			}
            else
            {
				var values = _articleService.TGetArticlesWithUser();
				var result = values.Select(x => new _GetArticleListDto()
				{
					Content = x.Description,
					Date = x.CreatedDate,
					Id = x.ArticleId,
					ImageUrl = x.CoverImageUrl,
					Title = x.Title,
					NameSurname = x.AppUser.Name + " " + x.AppUser.Surname,
					UserImageUrl = x.AppUser.ImageUrl,
					CategoryID = x.CategoryId
				}).ToList();
				return View(result);
			}
		
        }
        public IActionResult BlogDetail(int id)
        {
            ViewBag.i = id;
            return View();
        }
        public IActionResult HomePage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ContactPage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ContactPage(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contact = new Contact
                {
                    Mail = model.Mail,
                    MessageBody = model.MessageBody,
                    MessageDate = DateTime.Now,
                    MessageStatus = true,
                    Name = model.Name,
                    Subject = model.Subject
                };
                _contactService.TInsert(contact);
                return RedirectToAction("ContactPage", "Blog");
            }
            return View();
        }
    }
}
