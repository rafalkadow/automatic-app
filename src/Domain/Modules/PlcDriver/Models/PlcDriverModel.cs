using Domain.Modules.Base.Consts;
using Domain.Modules.Base.Models;
using Domain.Modules.PlcDriver.Consts;
using Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Modules.PlcDriverGroup.Models;

namespace Domain.Modules.PlcDriver.Models
{
    /// <summary>
    /// PlcDriver
    /// </summary>
    [Serializable]
	[Index(nameof(Name), IsUnique = true)]
	[Table(PlcDriverConsts.Table, Schema = BaseDatabaseConst.Base)]
	public class PlcDriverModel : BaseModel, IEntity
	{
		#region Fields

        [Required]
        [ForeignKey("PlcDriverGroupId")]
        public Guid PlcDriverGroupId { get; set; }

        public virtual PlcDriverGroupModel PlcDriverGroup { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? Description { get; set; }

        public string? DeviceAddress { get; set; }
        public int DevicePort { get; set; }

        public int SlaveId { get; set; }

        public int TimeOut { get; set; }

        #endregion Fields
    }
}