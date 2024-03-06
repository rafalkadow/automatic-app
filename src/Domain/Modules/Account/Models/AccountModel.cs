using Domain.Modules.Account.Consts;
using Domain.Modules.Base.Consts;
using Domain.Modules.Base.Models;
using Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.Modules.Account
{
	[Serializable]
	[Index(nameof(AccountEmail), IsUnique = true)]
	[Table(AccountConsts.Table, Schema = BaseDatabaseConst.Base)]
	public class AccountModel : BaseModel, IEntity
	{
		#region Fields

		[Required]
		[StringLength(200)]
		public required string AccountEmail { get; set; }

		[StringLength(200)]
		public string? FirstName { get; set; }

		[StringLength(200)]
		public string? LastName { get; set; }

		[StringLength(200)]
		public string? PhoneNumber { get; set; }

		[StringLength(200)]
		public required string AccountPassword { get; set; }

		public int AccountTypeId { get; set; }

		[StringLength(200)]
		public required string AccountTypeName { get; set; }

        #endregion Fields
    }
}