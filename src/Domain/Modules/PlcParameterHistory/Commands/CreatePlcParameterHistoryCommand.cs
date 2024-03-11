using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.PlcParameterHistory.Commands
{
    [Serializable]
    public class CreatePlcParameterHistoryCommand : BasePlcParameterHistoryCommand, ICommand, IRequest<OperationResult>
    {
    }
}