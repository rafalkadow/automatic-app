using Domain.Modules.Base.Consts;
using Domain.Modules.Base.Models;
using Domain.Modules.PlcParameter.Consts;
using Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Modules.PlcDriver.Models;
using Domain.Modules.Base.Enums;
using Domain.Modules.PlcParameter.Enum;

namespace Domain.Modules.PlcParameter.Models
{
    /// <summary>
    /// PlcParameter
    /// </summary>
    [Serializable]
	[Index(nameof(Name), IsUnique = true)]
	[Table(PlcParameterConsts.Table, Schema = BaseDatabaseConst.Base)]
	public class PlcParameterModel : BaseModel, IEntity
	{
		#region Fields

        [Required]
        [ForeignKey("PlcDriverId")]
        public Guid PlcDriverId { get; set; }

        public virtual PlcDriverModel PlcDriver { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        public int Address { get; set; }
        public AccessModeTypeEnum AccessModeType { get; set; }
        public ModbusTypeEnum ModbusTypeEnum { get; set; }
        public ParameterTypeEnum ParameterType { get; set; }
        public YesNoEnum ModbusVisibility { get; set; }
        public YesNoEnum RecordToDatabase { get; set; }
        public int MaximumValue { get; set; }
        public int MinimumValue { get; set; }
        #endregion Fields
    }
}