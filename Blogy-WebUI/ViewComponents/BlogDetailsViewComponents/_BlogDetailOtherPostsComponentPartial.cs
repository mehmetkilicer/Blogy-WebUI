using Blogy.BusinessLayer.Abstract;
using Blogy_WebUI.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.ViewComponents.BlogDetailsViewComponents
{
    public class _BlogDetailOtherPostsComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _BlogDetailOtherPostsComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TLast3PostList();
            var result = values.Select(x => new Last3BlogDto
            {
                CreatedDate = x.CreatedDate,
                ArticleID = x.ArticleId,
                CoverImageUrl = x.CoverImageUrl,
                Title = x.Title,
            }).ToList();
            return View(result);
        }
    }
}
