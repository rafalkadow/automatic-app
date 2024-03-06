using Domain.Modules.Base.Models;
using Domain.Modules.Interfaces;

namespace Domain.Modules.Base.Validations
{
	[Serializable]
    public class ValidationBase : IValidation
    {
        internal readonly IDefinitionModel definitionModel;

        public ValidationBase(IDefinitionModel definitionModel)
        {
            this.definitionModel = definitionModel;
        }
    }
}