using Application.Modules.Base.Validations;
using Domain.Modules.Base.Models;
using Domain.Modules.DictionaryOfParameterCategory.Commands;
using FluentValidation;
using Domain.Interfaces;

namespace Application.Modules.DictionaryOfParameterCategory.Delete
{
    [Serializable]
    public class DeleteDictionaryOfParameterCategoryValidation : BaseValidation<DeleteDictionaryOfParameterCategoryCommand>
    {
        public DeleteDictionaryOfParameterCategoryValidation(IDbContext dbContext, IDefinitionModel definitionModel)
            : base(dbContext, definitionModel)
        {
            RuleFor(x => x.GuidList).NotNull().NotEmpty().WithMessage("The list 'Id' field doesn't be empty");
        }
    }
}