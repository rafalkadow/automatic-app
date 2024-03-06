using Domain.Modules.Base.Models;
using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.Base.Commands
{
    [Serializable]
    public class BaseActionCommand : IRequest<OperationResult>, ICommand
    {
        public ICollection<Guid> GuidList { get; set; } = new List<Guid>();

        public string? ControllerName { get; set; }

        public Guid? ModifiedUserId { get; set; }

        public string? ModifiedUserName { get; set; }

        public DateTime? ModifiedOnDateTimeUTC { get; set; }
 
        public IDefinitionModel? Definition { get; set; }
    }
}