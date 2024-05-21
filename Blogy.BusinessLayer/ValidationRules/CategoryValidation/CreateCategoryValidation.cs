using Blogy.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.CategoryValidation
{
    public class CreateCategoryValidation : AbstractValidator<Category>
    {
        public CreateCategoryValidation()  
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Bu Alanı Bos Gecemessiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori Adını en az 3 karakter olarak giriniz");
            RuleFor(x => x.CategoryName).MaximumLength(30).WithMessage("Kategori Adını en fazla 30 karakter olarak giriniz");
        }
    }
}
