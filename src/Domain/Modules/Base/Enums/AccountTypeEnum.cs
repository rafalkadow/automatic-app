using System.ComponentModel;

namespace Domain.Modules.Base.Enums
{
	[Serializable]
	public enum AccountTypeEnum
	{
		None = 0,

		[Description("Administrator")]
		Administrator = 1,

		[Description("Moderator")]
		Moderator,

		[Description("Użytkownik")]
		User,
	}
}