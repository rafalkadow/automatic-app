using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.PlcDriverAlarm.Queries
{
    [Serializable]
    public class GetPlcDriverAlarmQueryById : GetPlcDriverAlarmBaseFilter, IQuery, IRequest<GetPlcDriverAlarmResultById>
    {
        public GetPlcDriverAlarmQueryById(Guid Id)
        {
            this.Id = Id;
        }
    }
}