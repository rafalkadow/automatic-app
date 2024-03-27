using Domain.Modules.Base.Models;
using MediatR;
using Shared.Enums;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.Base.Commands
{
    [Serializable]
    public class BaseActionCommand : IRequest<OperationResult>, ICommand
    {
        public ICollection<Guid> GuidList { get; set; }

        public string ControllerName { get; set; }

    }
}