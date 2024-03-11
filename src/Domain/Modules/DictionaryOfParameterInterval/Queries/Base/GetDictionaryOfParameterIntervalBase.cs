using Domain.Modules.Base.Queries;
using Domain.Modules.PlcDriver.Models;

namespace Domain.Modules.DictionaryOfParameterInterval.Queries
{
	[Serializable]
	public class GetDictionaryOfParameterIntervalBase : GetBaseResultFilter
	{
        public Guid PlcDriverId { get; set; }

        public virtual PlcDriverModel PlcDriver { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Type { get; set; }
    }
}