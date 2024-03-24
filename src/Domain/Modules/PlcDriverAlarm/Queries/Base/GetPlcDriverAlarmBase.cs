using Domain.Modules.Base.Queries;

namespace Domain.Modules.PlcDriverAlarm.Queries
{
	[Serializable]
	public class GetPlcDriverAlarmBase : GetBaseResultFilter
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
    }
}