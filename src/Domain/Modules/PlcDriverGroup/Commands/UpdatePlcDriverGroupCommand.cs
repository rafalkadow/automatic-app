using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.PlcDriverGroup.Commands
{
    [Serializable]
    public class UpdatePlcDriverGroupCommand : BasePlcDriverGroupCommand, IRequest<OperationResult>, ICommand
    {
    }
}