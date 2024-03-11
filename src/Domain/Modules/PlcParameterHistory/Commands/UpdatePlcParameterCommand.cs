using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.PlcParameterHistory.Commands
{
    [Serializable]
    public class UpdatePlcParameterHistoryCommand : BasePlcParameterHistoryCommand, IRequest<OperationResult>, ICommand
    {
    }
}