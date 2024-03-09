using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.PlcParameter.Queries
{
    [Serializable]
    public class GetPlcParameterQueryById : GetPlcParameterBaseFilter, IQuery, IRequest<GetPlcParameterResultById>
    {
        public GetPlcParameterQueryById(Guid Id)
        {
            this.Id = Id;
        }
    }
}