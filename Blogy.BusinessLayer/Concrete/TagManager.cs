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
    public class TagManager : ITagService
    {
        private readonly ITagDal _tagDal;

        public TagManager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }

        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tag> TGetAll()
        {
           return _tagDal.GetAll();
        }

        public List<Tag> TGetByFilter(Expression<Func<Tag, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Tag TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Tag entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Tag entity)
        {
            throw new NotImplementedException();
        }
    }
}
