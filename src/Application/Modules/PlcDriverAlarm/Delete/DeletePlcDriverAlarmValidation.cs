using Application.Modules.Base.Validations;
using Domain.Modules.Base.Models;
using Domain.Modules.PlcDriverAlarm.Commands;
using FluentValidation;
using Domain.Interfaces;

namespace Application.Modules.PlcDriverAlarm.Delete
{
    [Serializable]
    public class DeletePlcDriverAlarmValidation : BaseValidation<DeletePlcDriverAlarmCommand>
    {
        public DeletePlcDriverAlarmValidation(IDbContext dbContext, IDefinitionModel definitionModel)
            : base(dbContext, definitionModel)
        {
            RuleFor(x => x.GuidList).NotNull().NotEmpty().WithMessage("The list 'Id' field doesn't be empty");
        }
    }
}