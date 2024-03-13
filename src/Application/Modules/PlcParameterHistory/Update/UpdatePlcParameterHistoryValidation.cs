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
            RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                   .NotEmpty().WithMessage("Enter the field value 'Name'")
                   .Must(x => x.Length >= 1 && x.Length <= 20).WithMessage("Name should be between 1 and 20 characters")
                   .Must(UniqueName)
                   .WithMessage("The 'Name' field must be unique");

   
            RuleFor(u => u.PlcParameterId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Enter the field value 'PlcParameterId'");

        }

        private bool UniqueName(BasePlcParameterHistoryCommand model, string name)
        {
            var result = false;
            result = !DbContext.GetQueryable<PlcParameterHistoryModel>().AsNoTracking().Any(u => u.Id != model.Id && u.Name == name);
            return result;
        }

    }
}