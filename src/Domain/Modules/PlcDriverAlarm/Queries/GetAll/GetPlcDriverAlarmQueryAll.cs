using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.PlcDriverAlarm.Queries
{
    [Serializable]
    public class GetPlcDriverAlarmQueryAll : GetPlcDriverAlarmBaseFilter, IRequest<IList<GetPlcDriverAlarmResultAll>>, IQuery
    {
    }
}