using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {
        List<Article> GetArticleWithWriter();
        Writer GetWriterInfoByArticleWriter(int id);
        List<Article> GetArticlesByWriter(int id);
        List<Article> GetArticlesWithUser();
        List<Article> Last3PostList();
        List<Article> Last5PostList();
		List<Article> GetArticleFilterList(string search);

	}
}
