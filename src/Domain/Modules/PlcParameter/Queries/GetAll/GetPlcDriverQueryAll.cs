using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.PlcParameter.Queries
{
    [Serializable]
    public class GetPlcParameterQueryAll : GetPlcParameterBaseFilter, IRequest<IEnumerable<GetPlcParameterResultAll>>, IQuery
    {
    }
}