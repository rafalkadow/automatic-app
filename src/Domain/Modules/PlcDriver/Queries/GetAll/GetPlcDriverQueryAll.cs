using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.PlcDriver.Queries
{
    [Serializable]
    public class GetPlcDriverQueryAll : GetPlcDriverBaseFilter, IRequest<IList<GetPlcDriverResultAll>>, IQuery
    {
    }
}