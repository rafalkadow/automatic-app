using Domain.Modules.Base.Queries;
using Domain.Modules.PlcDriverGroup.Models;

namespace Domain.Modules.PlcDriver.Queries
{
	[Serializable]
	public class GetPlcDriverBase : GetBaseResultFilter
	{
        public Guid PlcDriverGroupId { get; set; }

        public virtual PlcDriverGroupModel PlcDriverGroup { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? DeviceAddress { get; set; }
        public int DevicePort { get; set; }

        public int SlaveId { get; set; }

        public int TimeOut { get; set; }
    }
}