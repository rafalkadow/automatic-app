using Domain.Modules.Base.Queries;
using Domain.Modules.PlcDriver.Models;
using Domain.Modules.PlcParameter.Enum;
using Domain.Modules.PlcParameter.Models;

namespace Domain.Modules.PlcDriverAlarm.Queries
{
	[Serializable]
	public class GetPlcDriverAlarmBase : GetBaseResultFilter
	{
        public Guid PlcDriverId { get; set; }
        public virtual PlcDriverModel PlcDriver { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public AlarmTypeEnum AlarmType { get; set; }

        public Guid TriggerParameterId { get; set; }
        public virtual PlcParameterModel TriggerParameter { get; set; }
        public Guid ResetParameterId { get; set; }
        public virtual PlcParameterModel ResetParameter { get; set; }
    }
}