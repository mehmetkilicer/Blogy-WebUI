using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer.Concrete;
using Blogy_WebUI.Dtos.CategoryDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {

        BlogyContext context = new BlogyContext();

        public List<CategoryCountDto> GeAlltCategoryCountDtos()
        {
            var values = context.Articles.GroupBy(x => x.CategoryId).Select(y => new CategoryCountDto()
            {
                CategoryID = y.Key,
                Name = context.Categories.Where(x => x.CategoryId == y.Key).Select(z => z.CategoryName).FirstOrDefault(),
                Count = y.Count(),
            }).ToList();
            return values;
        }

        public int GetCategoryCount()
        {
            return context.Categories.Count();
        }
    }
}
