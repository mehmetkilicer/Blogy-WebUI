using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser> , IAppUserDal
    {
    }
}
