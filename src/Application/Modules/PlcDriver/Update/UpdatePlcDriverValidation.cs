using Application.Modules.Base.Validations;
using Domain.Modules.Base.Models;
using Domain.Modules.PlcDriver.Commands;
using Domain.Modules.PlcDriver.Models;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Domain.Interfaces;

namespace Application.Modules.PlcDriver.Update
{
    [Serializable]
    public class UpdatePlcDriverValidation : BaseValidation<UpdatePlcDriverCommand>
    {
        public UpdatePlcDriverValidation(IDbContext dbContext, IDefinitionModel definitionModel)
            : base(dbContext, definitionModel)
        {
            RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                   .NotEmpty().WithMessage("Enter the field value 'Name'")
                   .Must(x => x.Length >= 1 && x.Length <= 20).WithMessage("Name should be between 1 and 20 characters")
                   .Must(UniqueName)
                   .WithMessage("The 'Name' field must be unique");

            RuleFor(u => u.Description).Cascade(CascadeMode.Stop)
                   .NotEmpty().WithMessage("Enter the field value 'Description'")
                   .Must(x => x.Length >= 1 && x.Length <= 20).WithMessage("Description should be between 1 and 20 characters");

            RuleFor(u => u.PlcDriverGroupId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Enter the field value 'PlcDriverGroupId'");

        }

        private bool UniqueName(BasePlcDriverCommand model, string name)
        {
            var result = false;
            result = !DbContext.GetQueryable<PlcDriverModel>().AsNoTracking().Any(u => u.Id != model.Id && u.Name == name);
            return result;
        }

    }
}