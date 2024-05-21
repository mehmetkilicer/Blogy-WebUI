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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void TDelete(int id)
        {
            _contactDal.Delete(id);
        }

        public List<Contact> TGetAll()
        {
            return _contactDal.GetAll();
        }

        public List<Contact> TGetByFilter(Expression<Func<Contact, bool>> filter)
        {
            return _contactDal.GetByFilter(filter);
        }

        public Contact TGetById(int id)
        {
            return _contactDal.GetById(id);
        }

        public void TInsert(Contact entity)
        {
           _contactDal.Insert(entity);
        }

        public void TUpdate(Contact entity)
        {
           _contactDal.Update(entity);
        }
    }
}
