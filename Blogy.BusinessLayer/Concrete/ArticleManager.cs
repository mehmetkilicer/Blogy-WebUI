using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public void TDelete(int id)
        {
            if (id !=0)
            {
                _articleDal.Delete(id);
            }
            else
            {
                //hata mesajı
            }
        }

        public List<Article> TGetAll()
        {
            return _articleDal.GetAll();
        }

		public List<Article> TGetArticleFilterList(string search)
		{
			return _articleDal.GetArticleFilterList(search);
		}

		public List<Article> TGetArticlesByWriter(int id)
        {
            return _articleDal.GetArticlesByWriter(id);
        }

        public List<Article> TGetArticlesWithUser()
        {
            return _articleDal.GetArticlesWithUser();
        }

        public List<Article> TGetArticleWithWriter()
		{
			return _articleDal.GetArticleWithWriter();
		}

        public List<Article> TGetByFilter(Expression<Func<Article, bool>> filter)
        {
            return _articleDal.GetByFilter(filter);
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public Writer TGetWriterInfoByArticleWriter(int id)
        {
            return _articleDal.GetWriterInfoByArticleWriter(id);
        }

        public void TInsert(Article entity)
        {
            _articleDal.Insert(entity);
        }

        public List<Article> TLast3PostList()
        {
            return _articleDal.Last3PostList();
        }

        public List<Article> TLast5PostList()
        {
            return _articleDal.Last5PostList();
        }

        public void TUpdate(Article entity)
        {
            _articleDal.Update(entity);
        }
    }
}
