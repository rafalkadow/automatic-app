using Domain.Modules.Base.Commands;
using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.PlcDriver.Commands
{
    [Serializable]
    public class DeletePlcDriverCommand : BaseActionCommand, IRequest<OperationResult>, ICommand
    {
    }
}