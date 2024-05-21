using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
		public List<Article> TGetArticleWithWriter();
        Writer TGetWriterInfoByArticleWriter(int id);
        List<Article> TGetArticlesByWriter(int id);
        List<Article> TGetArticlesWithUser();
        List<Article> TLast3PostList();
        List<Article> TLast5PostList();
		List<Article> TGetArticleFilterList(string search);



	}
}
