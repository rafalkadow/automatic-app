using Application.Modules.Base.Validations;
using Domain.Modules.Base.Models;
using Domain.Modules.PlcParameterHistory.Commands;
using Domain.Modules.PlcParameterHistory.Models;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Domain.Interfaces;

namespace Application.Modules.PlcParameterHistory.Create
{
    [Serializable]
    public class CreatePlcParameterHistoryValidation : BaseValidation<CreatePlcParameterHistoryCommand>
    {
        public CreatePlcParameterHistoryValidation(IDbContext dbContext, IDefinitionModel definitionModel)
            : base(dbContext, definitionModel)
        {
            RuleFor(u => u.Id).Cascade(CascadeMode.Stop)
                   .NotEmpty().NotNull().WithMessage("Enter the field value 'Id'")
                   .Must(UniqueId)
                   .WithMessage("The 'Id' field must be unique");

            RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                   .NotEmpty().WithMessage("Enter the field value 'Name'")
                   .Must(x => x.Length >= 1 && x.Length <= 20).WithMessage("Name should be between 1 and 20 characters")
                   .Must(UniqueName)
                   .WithMessage("The 'Name' field must be unique");

        
            RuleFor(u => u.PlcParameterId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Enter the field value 'PlcParameterId'");

        }

        private bool UniqueId(BasePlcParameterHistoryCommand model, Guid? Id)
        {
            var result = false;
            result = !DbContext.GetQueryable<PlcParameterHistoryModel>().AsNoTracking().Any(u => u.Id == Id);
            return result;
        }

        private bool UniqueName(BasePlcParameterHistoryCommand model, string name)
        {
            var result = false;
            result = !DbContext.GetQueryable<PlcParameterHistoryModel>().AsNoTracking().Any(u => u.Id != model.Id && u.Name == name);
            return result;
        }
    }
}