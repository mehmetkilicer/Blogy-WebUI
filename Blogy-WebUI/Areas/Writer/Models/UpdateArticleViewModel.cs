using Blogy.EntityLayer.Concrete;

namespace Blogy_WebUI.Areas.Writer.Models
{
    public class UpdateArticleViewModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string? CoverImageUrl { get; set; }
  
    }
}
