using Blogy.EntityLayer.Concrete;
using Blogy_WebUI.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        List<CategoryCountDto> TGeAlltCategoryCountDtos();

        int TGetCategoryCount();
    }
}
