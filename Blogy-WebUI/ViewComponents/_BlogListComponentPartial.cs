using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Blogy_WebUI.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.ViewComponents
{
    public class _BlogListComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _BlogListComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }
       
     
        public IViewComponentResult Invoke()
        {
            
            var values = _articleService.TGetAll();
            var result = values.Select(x => new _GetArticleListDto()
            {
                Content =x.Description,
                Date =x.CreatedDate,
                Id =x.ArticleId,
                ImageUrl =x.CoverImageUrl,
                Title =x.Title,
                NameSurname = x.AppUser.Name+" "+ x.AppUser.Surname,
                UserImageUrl =x.AppUser.ImageUrl,
                CategoryID =x.CategoryId
            }).ToList();
            return View(result);
        }
    }
}
