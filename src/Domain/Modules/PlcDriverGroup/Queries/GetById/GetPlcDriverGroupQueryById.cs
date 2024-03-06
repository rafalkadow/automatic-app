using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.PlcDriverGroup.Queries
{
    [Serializable]
    public class GetPlcDriverGroupQueryById : GetPlcDriverGroupBaseFilter, IQuery, IRequest<GetPlcDriverGroupResultById>
    {
        public GetPlcDriverGroupQueryById(Guid Id)
        {
            this.Id = Id;
        }
    }
}