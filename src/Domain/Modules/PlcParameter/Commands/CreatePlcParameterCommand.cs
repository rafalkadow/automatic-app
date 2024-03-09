using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.PlcParameter.Commands
{
    [Serializable]
    public class CreatePlcParameterCommand : BasePlcParameterCommand, ICommand, IRequest<OperationResult>
    {
    }
}