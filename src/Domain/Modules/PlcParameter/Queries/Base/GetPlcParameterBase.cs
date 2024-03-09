using Domain.Modules.Base.Queries;
using Domain.Modules.PlcDriver.Models;

namespace Domain.Modules.PlcParameter.Queries
{
	[Serializable]
	public class GetPlcParameterBase : GetBaseResultFilter
	{
        public Guid PlcDriverId { get; set; }

        public virtual PlcDriverModel PlcDriver { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Type { get; set; }
    }
}