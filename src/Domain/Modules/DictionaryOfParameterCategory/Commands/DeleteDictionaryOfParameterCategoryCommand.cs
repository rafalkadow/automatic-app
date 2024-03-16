using Domain.Modules.Base.Commands;
using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.DictionaryOfParameterCategory.Commands
{
    [Serializable]
    public class DeleteDictionaryOfParameterCategoryCommand : BaseActionCommand, IRequest<OperationResult>, ICommand
    {
    }
}