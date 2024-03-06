using Application.Modules.Base.Validations;
using Domain.Modules.Base.Models;
using Domain.Modules.PlcDriverGroup.Commands;
using Domain.Modules.PlcDriverGroup.Models;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Domain.Interfaces;

namespace Application.Modules.PlcDriverGroup.Create
{
    [Serializable]
    public class CreatePlcDriverGroupValidation : BaseValidation<CreatePlcDriverGroupCommand>
    {
        public CreatePlcDriverGroupValidation(IDbContext dbContext, IDefinitionModel definitionModel)
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

            RuleFor(u => u.Description).Cascade(CascadeMode.Stop)
                   .NotEmpty().WithMessage("Enter the field value 'Description'")
                   .Must(x => x.Length >= 1 && x.Length <= 20).WithMessage("Description should be between 1 and 20 characters");
        }
        private bool UniqueId(BasePlcDriverGroupCommand model, Guid? Id)
        {
            var result = false;
            result = !DbContext.GetQueryable<PlcDriverGroupModel>().AsNoTracking().Any(u => u.Id == Id);
            return result;
        }

        private bool UniqueName(BasePlcDriverGroupCommand model, string name)
        {
            var result = false;
            result = !DbContext.GetQueryable<PlcDriverGroupModel>().AsNoTracking().Any(u => u.Id != model.Id && u.Name == name);
            return result;
        }
    }
}