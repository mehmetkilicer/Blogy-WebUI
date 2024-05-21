using Microsoft.AspNetCore.Mvc;
using Blogy.DtoLayer.CommentDtos;
namespace Blogy_WebUI.ViewComponents.BlogDetailsViewComponents
{
    public class _SendCommentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            var value = new SendCommentDto()
            {
                ArticleID = id,
            };
            return View(value);
        }
    }
}
