using Domain.Modules.Base.Queries;
using Domain.Modules.PlcParameter.Models;

namespace Domain.Modules.PlcParameterHistory.Queries
{
	[Serializable]
	public class GetPlcParameterHistoryBase : GetBaseResultFilter
	{
        public Guid PlcParameterId { get; set; }

        public virtual PlcParameterModel PlcParameter { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Type { get; set; }
    }
}