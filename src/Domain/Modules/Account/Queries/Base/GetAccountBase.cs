using Domain.Modules.Base.Queries;

namespace Domain.Modules.Account.Queries.Base
{
	[Serializable]
	public class GetAccountBase : GetBaseResultFilter
	{
		public string? AccountEmail { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? PhoneNumber { get; set; }
		public string? AccountPassword { get; set; }
		public int AccountTypeId { get; set; }
		public string? AccountTypeName { get; set; }

    }
}