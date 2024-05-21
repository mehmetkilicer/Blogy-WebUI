using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework
{
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        BlogyContext context = new BlogyContext();

        public List<Article> GetArticlesWithUser()
        {
            var values = context.Articles.Include(x=>x.AppUser).ToList();
            return values;
        }

        public List<Article> GetArticlesByWriter(int id)
        {
            var values = context.Articles.Where(x => x.AppUserId == id).ToList();
            return values;
        }

        public List<Article> GetArticleWithWriter()
        {
            throw new NotImplementedException();
        }

        public Writer GetWriterInfoByArticleWriter(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> Last3PostList()
        {
            var values = context.Articles.OrderByDescending(x => x.CreatedDate).Take(3).ToList();
            return values;
        }

        public List<Article> Last5PostList()
        {
           var values = context.Articles.OrderByDescending(x=>x.CreatedDate).Take(5).ToList();
            return values;
        }

		public List<Article> GetArticleFilterList(string search)
		{
			var values = context.Articles.Where(x => x.Title.Contains(search)).Include(x => x.AppUser).ToList();
			return values;
		}

		//public List<Article> GetArticleWithWriter()
		//{
		//    var values = context.Articles.Include(x => x.Writer).ToList();
		//    return values;
		//}

		//public Writer GetWriterInfoByArticleWriter(int id)
		//{
		//    var values = context.Articles.Where(x => x.ArticleId == id).Select(y => y.Writer).FirstOrDefault();
		//    return values;
		//}
	}
}
