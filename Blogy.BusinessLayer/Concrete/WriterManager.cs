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
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void TDelete(int id)
        {
            _writerDal.Delete(id);
        }

        public List<Writer> TGetAll()
        {
           return _writerDal.GetAll();
        }

        public List<Writer> TGetByFilter(Expression<Func<Writer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Writer TGetById(int id)
        {
            return _writerDal.GetById(id);
        }

        public void TInsert(Writer entity)
        {
            _writerDal.Insert(entity);
        }

        public void TUpdate(Writer entity)
        {
            _writerDal.Update(entity);
        }
    }
}
