using Application.Extensions;
using Application.Modules.Base.Validations;
using Domain.Modules.Account;
using Domain.Modules.Base.Consts;
using Domain.Modules.Base.Models;
using Domain.Modules.SignIn.Commands;
using FluentValidation;
using Domain.Interfaces;

namespace Application.Modules.SignIn.Validations
{
    [Serializable]
    public class SignInValidation : BaseValidation<SignInCommand>
    {
        public SignInValidation(IDbContext dbContext, IDefinitionModel definitionModel)
            : base(dbContext, definitionModel)
        {
            if (dbContext.GetQueryable<AccountModel>().Any())
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
            result = DbContext.GetQueryable<AccountModel>().Any(u => u.AccountEmail == email && u.AccountPassword == password);
            return result;
        }
    }
}