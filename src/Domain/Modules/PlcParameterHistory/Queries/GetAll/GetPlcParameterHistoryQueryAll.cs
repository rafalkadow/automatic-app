using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.PlcParameterHistory.Queries
{
    [Serializable]
    public class GetPlcParameterHistoryQueryAll : GetPlcParameterHistoryBaseFilter, IRequest<IList<GetPlcParameterHistoryResultAll>>, IQuery
    {
    }
}