using Application.Modules.Base.Validations;
using Domain.Modules.Base.Models;
using Domain.Modules.PlcParameter.Commands;
using Domain.Modules.PlcParameter.Models;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Domain.Interfaces;

namespace Application.Modules.PlcParameter.Create
{
    [Serializable]
    public class CreatePlcParameterValidation : BaseValidation<CreatePlcParameterCommand>
    {
        public CreatePlcParameterValidation(IDbContext dbContext, IDefinitionModel definitionModel)
            : base(dbContext, definitionModel)
        {
            RuleFor(u => u.Id).Cascade(CascadeMode.Stop)
                   .NotEmpty().NotNull().WithMessage("Enter the field value 'Id'")
                   .Must(UniqueId)
                   .WithMessage("The 'Name' field must be unique");

            RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                   .NotEmpty().WithMessage("Enter the field value 'Name'")
                   .Must(x => x.Length >= 1 && x.Length <= 20).WithMessage("Name should be between 1 and 20 characters")
                   .Must(UniqueName)
                   .WithMessage("The 'Name' field must be unique");

        
            RuleFor(u => u.PlcDriverId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Enter the field value 'PlcDriverId'");

        }

        private bool UniqueId(BasePlcParameterCommand model, Guid? Id)
        {
            var result = false;
            result = !DbContext.GetQueryable<PlcParameterModel>().AsNoTracking().Any(u => u.Id == Id);
            return result;
        }

        private bool UniqueName(BasePlcParameterCommand model, string name)
        {
            var result = false;
            result = !DbContext.GetQueryable<PlcParameterModel>().AsNoTracking().Any(u => u.Id != model.Id && u.Name == name);
            return result;
        }
    }
}