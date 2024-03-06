using Domain.Modules.Base.Consts;
using Domain.Modules.Base.Models;
using Domain.Modules.PlcDriverGroup.Consts;
using Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Modules.PlcDriver.Models;

namespace Domain.Modules.PlcDriverGroup.Models
{
    /// <summary>
    /// PlcDriver Group
    /// </summary>
    [Serializable]
	[Index(nameof(Name), IsUnique = true)]
	[Table(PlcDriverGroupConsts.Table, Schema = BaseDatabaseConst.Base)]
	public class PlcDriverGroupModel : BaseModel, IEntity
	{
		#region Fields

		[Required]
		[StringLength(100)]
		public string? Name { get; set; }

		[StringLength(50)]
		public string? Description { get; set; }

        public ICollection<PlcDriverModel> PlcDriver { get; set; }

        #endregion Fields
    }
}