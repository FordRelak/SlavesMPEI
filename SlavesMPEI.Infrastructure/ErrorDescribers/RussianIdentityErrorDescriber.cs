using Microsoft.AspNetCore.Identity;

namespace SlavesMPEI.Infrastructure.ErrorDescribers
{
    public class RussianIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = nameof(PasswordTooShort), Description = $"Минимальная длина пароль {length} символов." }; }
    }
}