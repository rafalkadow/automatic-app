using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.DictionaryOfParameterCategory.Commands
{
    [Serializable]
    public class CreateDictionaryOfParameterCategoryCommand : BaseDictionaryOfParameterCategoryCommand, ICommand, IRequest<OperationResult>
    {
    }
}