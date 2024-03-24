using Domain.Modules.Base.Commands;
using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.PlcDriverAlarm.Commands
{
    [Serializable]
    public class DeletePlcDriverAlarmCommand : BaseActionCommand, IRequest<OperationResult>, ICommand
    {
    }
}