using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.PlcDriver.Commands
{
    [Serializable]
    public class CreatePlcDriverCommand : BasePlcDriverCommand, ICommand, IRequest<OperationResult>
    {
    }
}