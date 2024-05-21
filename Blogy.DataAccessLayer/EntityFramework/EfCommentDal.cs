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
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        BlogyContext BlogyContext = new BlogyContext();

        public List<Comment> CommentListByUserId(int userId)
        {
            return BlogyContext.Comments.Where(x => x.AppUserID == userId).Include(x => x.Articles).Include(x => x.AppUser).OrderByDescending(x => x.CommentDate).ToList();
        }

        public List<Comment> GetCommentByArticleId(int id)
        {
            var values = BlogyContext.Comments.Where(x=>x.ArticleId== id).ToList();
            return values;
        }
    }
}
