using Blogy.EntityLayer.Concrete;
using Blogy_WebUI.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        List<CategoryCountDto> GeAlltCategoryCountDtos();
        int GetCategoryCount();
    }
}
