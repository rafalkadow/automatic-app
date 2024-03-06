using Application.Modules.Base.Validations;
using Domain.Modules.Base.Models;
using FluentValidation;
using Domain.Interfaces;
using Domain.Modules.Account.Commands;

namespace Application.Modules.Account.Delete
{
    [Serializable]
    public class DeleteAccountValidation : BaseValidation<DeleteAccountCommand>
    {
        public DeleteAccountValidation(IDbContext dbContext, IDefinitionModel definitionModel)
            : base(dbContext, definitionModel)
        {
            RuleFor(x => x.GuidList).NotNull().NotEmpty().WithMessage("The list 'Id' field doesn't be empty");
        }
    }
}