using Application.Modules.Base.Validations;
using Domain.Modules.Base.Models;
using Domain.Modules.PlcParameter.Commands;
using FluentValidation;
using Domain.Interfaces;

namespace Application.Modules.PlcParameter.Delete
{
    [Serializable]
    public class DeletePlcParameterValidation : BaseValidation<DeletePlcParameterCommand>
    {
        public DeletePlcParameterValidation(IDbContext dbContext, IDefinitionModel definitionModel)
            : base(dbContext, definitionModel)
        {
            RuleFor(x => x.GuidList).NotNull().NotEmpty().WithMessage("The list 'Id' field doesn't be empty");
        }
    }
}