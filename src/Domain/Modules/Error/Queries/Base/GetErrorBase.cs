using Domain.Modules.Base.Queries;

namespace Domain.Modules.Error.Queries
{
	[Serializable]
	public class GetErrorBase : GetBaseResultFilter
	{
		public string? ErrorCode { get; set; }
		public string? ErrorName { get; set; }
		public string? ErrorDescription { get; set; }

		public string? ErrorUrl { get; set; }
		public string? UrlReturn { get; set; }
	}
}