using Blogy.BusinessLayer.Abstract;
using Blogy.DtoLayer.CommentDtos;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.Controllers
{
	[AllowAnonymous]

	public class CommentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICommentService _commentService;

        public CommentController(UserManager<AppUser> userManager, ICommentService commentService)
        {
            _userManager = userManager;
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(SendCommentDto model)
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);

            _commentService.TInsert(new Comment()
            {
                AppUserID = currentUser.Id,
                ArticleId = model.ArticleID,
                Content = model.Message,
                CommentDate = DateTime.Now,
                ImageUrl = currentUser.ImageUrl,
                NameSurname = currentUser.Name+" "+currentUser.Surname,
                Status =true,
                Email = currentUser.Email,
            });

            return RedirectToAction("BlogDetail", "Blog", new { @id = model.ArticleID });
        }
    }
}
