using Microsoft.AspNetCore.Identity;

namespace Blogy_WebUI.Models
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = "Lutfen en az 6 karakter sifre giriniz"
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Lutfen en az 1 tane buyuk harf giriniz"
            };
        }
    }
}
