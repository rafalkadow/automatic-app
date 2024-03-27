using MediatR;
using Shared.Enums;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.Base.Commands
{
    [Serializable]
    public class BaseActiveCommand : BaseActionCommand, IRequest<OperationResult>, ICommand
    {
        public RecordStatusEnum RecordStatus { get; set; }
    }
}