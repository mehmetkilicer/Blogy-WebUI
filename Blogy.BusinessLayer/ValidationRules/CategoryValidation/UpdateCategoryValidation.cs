using Blogy.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.CategoryValidation
{
    public class UpdateCategoryValidation : AbstractValidator<Category>
    {
        public UpdateCategoryValidation() 
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Bu Alanı Bos Gecemessiniz").MinimumLength(30).WithMessage("Lutfen kategori adını en fazla 30 karakter olarak giriniz").Equal("a").WithMessage("Lutfen kategori adına a harfi ekleyiniz");

        }

    }
}
