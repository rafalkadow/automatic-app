using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.Base.Commands
{
    [Serializable]
    public class BaseUpCommand : BaseActionCommand, IRequest<OperationResult>, ICommand
    {
        public ulong OrderId { get; set; }
    }
}