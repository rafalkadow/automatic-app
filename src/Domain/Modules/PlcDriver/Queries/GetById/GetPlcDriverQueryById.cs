using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.PlcDriver.Queries
{
    [Serializable]
    public class GetPlcDriverQueryById : GetPlcDriverBaseFilter, IQuery, IRequest<GetPlcDriverResultById>
    {
        public GetPlcDriverQueryById(Guid Id)
        {
            this.Id = Id;
        }
    }
}