namespace Blogy_WebUI.Dtos.BlogDtos
{
    public class _GetArticleListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string NameSurname { get; set; }
        public string UserImageUrl { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int CategoryID { get; set; }
    }
}
