using Application.Extensions;
using Application.Modules.Base.Validations;
using Domain.Modules.Base.Consts;
using Domain.Modules.Base.Models;
using Domain.Modules.SignIn.Commands;
using FluentValidation;
using Domain.Interfaces;
using Domain.Modules.Identity;

namespace Application.Modules.SignIn.Validations
{
    [Serializable]
    public class SignInValidation : BaseValidation<SignInCommand>
    {
        public SignInValidation(IDbContext dbContext, IDefinitionModel definitionModel)
            : base(dbContext, definitionModel)
        {
            if (dbContext.GetQueryable<User>().Any())
            {
                RuleFor(u => u.SignInEmail).Cascade(CascadeMode.Stop)
                  .NotEmpty().WithMessage("Enter the field value 'E-mail'")
                  .Must(x => x.Length >= 5 && x.Length < 200).WithMessage("Email should be between 5 and 200 characters")
                  .Must(ExistsAccount).OverridePropertyName(BaseValidationConsts.FluentValidationErrorCustom)
                  .WithMessage("Failed to log in");
            }
        }

        private bool ExistsAccount(BaseSignInCommand model, string email)
        {
            var result = false;
            var password = model.SignInPassword.Encrypt();
            result = DbContext.GetQueryable<User>().Any(u => u.Email == email && u.PasswordHash == password);
            return result;
        }
    }
}