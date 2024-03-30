using Application.Modules.Base.Validations;
using Domain.Modules.Base.Models;
using Domain.Modules.PlcParameterHistory.Commands;
using Domain.Modules.PlcParameterHistory.Models;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Domain.Interfaces;

namespace Application.Modules.PlcParameterHistory.Update
{
    [Serializable]
    public class UpdatePlcParameterHistoryValidation : BaseValidation<UpdatePlcParameterHistoryCommand>
    {
        public UpdatePlcParameterHistoryValidation(IDbContext dbContext, IDefinitionModel definitionModel)
            : base(dbContext, definitionModel)
        {
            RuleFor(u => u.PlcParameterId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Enter the field value 'PlcParameterId'");

        }
    }
}