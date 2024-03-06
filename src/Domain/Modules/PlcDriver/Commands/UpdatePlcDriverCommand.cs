using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.PlcDriver.Commands
{
    [Serializable]
    public class UpdatePlcDriverCommand : BasePlcDriverCommand, IRequest<OperationResult>, ICommand
    {
    }
}