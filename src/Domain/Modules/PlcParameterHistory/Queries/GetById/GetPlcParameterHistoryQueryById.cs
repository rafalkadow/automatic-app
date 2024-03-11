using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.PlcParameterHistory.Queries
{
    [Serializable]
    public class GetPlcParameterHistoryQueryById : GetPlcParameterHistoryBaseFilter, IQuery, IRequest<GetPlcParameterHistoryResultById>
    {
        public GetPlcParameterHistoryQueryById(Guid Id)
        {
            this.Id = Id;
        }
    }
}