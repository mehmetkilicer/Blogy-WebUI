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
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment> CommentListByUserId(int userId)
        {
            return _commentDal.CommentListByUserId(userId);
        }

        public void TDelete(int id)
        {
           _commentDal.Delete(id);
        }

        public List<Comment> TGetAll()
        {
           return _commentDal.GetAll();
        }

        public List<Comment> TGetByFilter(Expression<Func<Comment, bool>> filter)
        {
            return _commentDal.GetByFilter(filter);
        }

        public Comment TGetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> TGetCommentByArticleId(int id)
        {
            return _commentDal.GetCommentByArticleId(id);
        }

        public void TInsert(Comment entity)
        {
            _commentDal.Insert(entity);
        }

        public void TUpdate(Comment entity)
        {
            _commentDal.Update(entity);
        }
    }
}
