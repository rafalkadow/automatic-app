using Application.Modules.Base.Validations;
using Domain.Modules.Base.Models;
using Domain.Modules.DictionaryOfParameterInterval.Commands;
using FluentValidation;
using Domain.Interfaces;

namespace Application.Modules.DictionaryOfParameterInterval.Delete
{
    [Serializable]
    public class DeleteDictionaryOfParameterIntervalValidation : BaseValidation<DeleteDictionaryOfParameterIntervalCommand>
    {
        public DeleteDictionaryOfParameterIntervalValidation(IDbContext dbContext, IDefinitionModel definitionModel)
            : base(dbContext, definitionModel)
        {
            RuleFor(x => x.GuidList).NotNull().NotEmpty().WithMessage("The list 'Id' field doesn't be empty");
        }
    }
}