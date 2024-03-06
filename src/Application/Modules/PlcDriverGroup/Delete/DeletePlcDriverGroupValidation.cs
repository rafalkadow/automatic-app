using Application.Modules.Base.Validations;
using Domain.Modules.Base.Models;
using Domain.Modules.PlcDriverGroup.Commands;
using FluentValidation;
using Domain.Interfaces;

namespace Application.Modules.PlcDriverGroup.Delete
{
    [Serializable]
    public class DeletePlcDriverGroupValidation : BaseValidation<DeletePlcDriverGroupCommand>
    {
        public DeletePlcDriverGroupValidation(IDbContext dbContext, IDefinitionModel definitionModel)
            : base(dbContext, definitionModel)
        {
            RuleFor(x => x.GuidList).NotNull().NotEmpty().WithMessage("The list 'Id' field doesn't be empty");
        }
    }
}