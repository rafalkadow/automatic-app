using Application.Modules.Base.Validations;
using Domain.Modules.Base.Models;
using FluentValidation;
using Domain.Interfaces;
using Domain.Modules.Account.Commands;
using Domain.Modules.Account;

namespace Application.Modules.Account.Validations
{
    [Serializable]
    public class CreateAccountValidation : BaseValidation<CreateAccountCommand>
    {
        public CreateAccountValidation(IDbContext dbContext, IDefinitionModel definitionModel)
            : base(dbContext, definitionModel)
        {
            RuleFor(u => u.Id).Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage("Enter the field value 'Id'")
                 .When(x => x.Id != null && x.Id != Guid.Empty)
                 .Must(UniqueGuid)
                 .WithMessage("The 'Id' field must be unique")
                 .When(x => x.Id != null && x.Id != Guid.Empty);
;

            RuleFor(u => u.AccountEmail).Cascade(CascadeMode.Stop)
                   .NotEmpty().WithMessage("Enter the field value 'Email'")
                   .Must(x => x.Length >= 5 && x.Length <= 200).WithMessage("Email should be between 5 and 200 characters")
                   .Must(UniqueEmail)
                   .WithMessage("The 'Email' field must be unique");

            RuleFor(u => u.AccountPassword).Cascade(CascadeMode.Stop)
                   .NotEmpty().WithMessage("Enter the field value 'Password'")
                   .Must(x => x.Length >= 5 && x.Length <= 200).WithMessage("Password should be between 5 and 200 characters");
        }

        private bool UniqueGuid(BaseAccountCommand model, Guid? id)
        {
            var result = false;
            result = !DbContext.GetQueryable<AccountModel>().Any(u => u.Id == id);
            return result;
        }

        private bool UniqueEmail(BaseAccountCommand model, string email)
        {
            var result = false;
            result = !DbContext.GetQueryable<AccountModel>().Any(u => u.AccountEmail == email);
            return result;
        }
    }
}