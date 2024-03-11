using Domain.Modules.Base.Commands;
using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.PlcParameterHistory.Commands
{
    [Serializable]
    public class DeletePlcParameterHistoryCommand : BaseActionCommand, IRequest<OperationResult>, ICommand
    {
    }
}