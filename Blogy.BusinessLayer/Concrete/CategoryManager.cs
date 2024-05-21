using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Blogy_WebUI.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TDelete(int id)
        {
            _categoryDal.Delete(id);           
        }

        public List<CategoryCountDto> TGeAlltCategoryCountDtos()
        {
            return _categoryDal.GeAlltCategoryCountDtos();
        }

        public List<Category> TGetAll()
        {
           return _categoryDal.GetAll();
        }

        public List<Category> TGetByFilter(Expression<Func<Category, bool>> filter)
        {
           return _categoryDal.GetByFilter(filter);
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public int TGetCategoryCount()
        {
           return _categoryDal.GetCategoryCount();
        }

        public void TInsert(Category entity)
        {
            _categoryDal.Insert(entity);
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
