using Domain.Modules.Base.Models;
using FluentValidation;
using Domain.Interfaces;

namespace Application.Modules.Base.Validations
{
    [Serializable]
    public class BaseValidation<T> : AbstractValidator<T>
    {
        protected IDbContext DbContext { get; set; }

        protected IDefinitionModel Definition { get; set; }

        public BaseValidation(IDbContext dbContext, IDefinitionModel definitionModel)
        {
            this.DbContext = dbContext;
            this.Definition = definitionModel;
        }
    }
}