using Application.Modules.Base.Validations;
using Domain.Modules.Base.Models;
using Domain.Modules.PlcParameterHistory.Commands;
using FluentValidation;
using Domain.Interfaces;

namespace Application.Modules.PlcParameterHistory.Delete
{
    [Serializable]
    public class DeletePlcParameterHistoryValidation : BaseValidation<DeletePlcParameterHistoryCommand>
    {
        public DeletePlcParameterHistoryValidation(IDbContext dbContext, IDefinitionModel definitionModel)
            : base(dbContext, definitionModel)
        {
            RuleFor(x => x.GuidList).NotNull().NotEmpty().WithMessage("The list 'Id' field doesn't be empty");
        }
    }
}