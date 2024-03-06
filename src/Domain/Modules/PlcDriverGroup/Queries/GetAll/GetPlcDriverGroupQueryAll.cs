using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.PlcDriverGroup.Queries
{
    [Serializable]
    public class GetPlcDriverGroupQueryAll : GetPlcDriverGroupBaseFilter, IRequest<IList<GetPlcDriverGroupResultAll>>, IQuery
    {
    }
}