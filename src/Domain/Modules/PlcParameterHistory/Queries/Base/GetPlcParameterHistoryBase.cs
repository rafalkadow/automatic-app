using Domain.Modules.Base.Queries;
using Domain.Modules.PlcParameter.Models;

namespace Domain.Modules.PlcParameterHistory.Queries
{
	[Serializable]
	public class GetPlcParameterHistoryBase : GetBaseResultFilter
	{
        public Guid PlcParameterId { get; set; }

        public virtual PlcParameterModel PlcParameter { get; set; }
        public int Value { get; set; }
        public DateTime DateAddUTC { get; set; }
    }
}