using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.DictionaryOfParameterInterval.Commands
{
    [Serializable]
    public class UpdateDictionaryOfParameterIntervalCommand : BaseDictionaryOfParameterIntervalCommand, IRequest<OperationResult>, ICommand
    {
    }
}