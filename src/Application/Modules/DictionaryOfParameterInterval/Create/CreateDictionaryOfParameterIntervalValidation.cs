using Application.Modules.Base.Validations;
using Domain.Modules.Base.Models;
using Domain.Modules.DictionaryOfParameterInterval.Commands;
using Domain.Modules.DictionaryOfParameterInterval.Models;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Domain.Interfaces;

namespace Application.Modules.DictionaryOfParameterInterval.Create
{
    [Serializable]
    public class CreateDictionaryOfParameterIntervalValidation : BaseValidation<CreateDictionaryOfParameterIntervalCommand>
    {
        public CreateDictionaryOfParameterIntervalValidation(IDbContext dbContext, IDefinitionModel definitionModel)
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
        
        }

        private bool UniqueId(BaseDictionaryOfParameterIntervalCommand model, Guid? Id)
        {
            var result = false;
            result = !DbContext.GetQueryable<DictionaryOfParameterIntervalModel>().AsNoTracking().Any(u => u.Id == Id);
            return result;
        }

        private bool UniqueName(BaseDictionaryOfParameterIntervalCommand model, string name)
        {
            var result = false;
            result = !DbContext.GetQueryable<DictionaryOfParameterIntervalModel>().AsNoTracking().Any(u => u.Id != model.Id && u.Name == name);
            return result;
        }
    }
}