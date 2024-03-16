using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.DictionaryOfParameterCategory.Commands
{
    [Serializable]
    public class UpdateDictionaryOfParameterCategoryCommand : BaseDictionaryOfParameterCategoryCommand, IRequest<OperationResult>, ICommand
    {
    }
}