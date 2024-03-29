using Domain.Modules.Base.Consts;
using Domain.Modules.Base.Models;
using Domain.Modules.PlcDriverAlarm.Consts;
using Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Modules.PlcDriver.Models;
using Domain.Modules.PlcParameter.Enum;
using Domain.Modules.PlcParameter.Models;

namespace Domain.Modules.PlcDriverAlarm.Models
{
    /// <summary>
    /// PlcDriver Alarm
    /// </summary>
    [Serializable]
	[Index(nameof(Name), IsUnique = true)]
	[Table(PlcDriverAlarmConsts.Table, Schema = BaseDatabaseConst.Base)]
	public class PlcDriverAlarmModel : BaseModel, IEntity
	{
		#region Fields

        public Guid PlcDriverId { get; set; }
        public virtual PlcDriverModel PlcDriver { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [StringLength(100)]
        public string? Description { get; set; }
        public AlarmTypeEnum AlarmType { get; set; }

        public Guid TriggerParameterId { get; set; }
        public virtual PlcParameterModel TriggerParameter { get; set; }
        public Guid ResetParameterId { get; set; }
        public virtual PlcParameterModel ResetParameter { get; set; }

        #endregion Fields
    }
}