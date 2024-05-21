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
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void TDelete(int id)
        {
            _appUserDal.Delete(id);
        }

        public List<AppUser> TGetAll()
        {
            return _appUserDal.GetAll();
        }

        public List<AppUser> TGetByFilter(Expression<Func<AppUser, bool>> filter)
        {
            return _appUserDal.GetByFilter(filter);
        }

        public AppUser TGetById(int id)
        {
           return _appUserDal.GetById(id);
        }

        public void TInsert(AppUser entity)
        {
           _appUserDal.Insert(entity);
        }

        public void TUpdate(AppUser entity)
        {
            _appUserDal.Update(entity);
        }
    }
}
