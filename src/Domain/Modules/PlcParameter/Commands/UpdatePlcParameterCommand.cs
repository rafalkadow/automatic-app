using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.PlcParameter.Commands
{
    [Serializable]
    public class UpdatePlcParameterCommand : BasePlcParameterCommand, IRequest<OperationResult>, ICommand
    {
    }
}