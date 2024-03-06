using Domain.Modules.Base.Queries;

namespace Domain.Modules.PlcDriverGroup.Queries
{
	[Serializable]
	public class GetPlcDriverGroupBase : GetBaseResultFilter
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
    }
}