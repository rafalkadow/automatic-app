using Domain.Modules.Base.Commands;
using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.DictionaryOfParameterInterval.Commands
{
    [Serializable]
    public class DeleteDictionaryOfParameterIntervalCommand : BaseActionCommand, IRequest<OperationResult>, ICommand
    {
    }
}