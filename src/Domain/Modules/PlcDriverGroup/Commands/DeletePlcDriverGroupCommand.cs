using Domain.Modules.Base.Commands;
using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.PlcDriverGroup.Commands
{
    [Serializable]
    public class DeletePlcDriverGroupCommand : BaseActionCommand, IRequest<OperationResult>, ICommand
    {
    }
}