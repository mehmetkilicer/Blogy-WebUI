using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.ViewComponents.BlogDetailsViewComponents
{
    public class _BlogDetailCommentComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _BlogDetailCommentComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.TGetCommentByArticleId(id);
            return View(values);
        }
    }
}
