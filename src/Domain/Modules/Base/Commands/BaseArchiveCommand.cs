using MediatR;
using Shared.Enums;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.Base.Commands
{
    [Serializable]
    public class BaseArchiveCommand : BaseActionCommand, IRequest<OperationResult>, ICommand
    {
        public RecordStatusEnum RecordStatus { get; set; }
    }
}