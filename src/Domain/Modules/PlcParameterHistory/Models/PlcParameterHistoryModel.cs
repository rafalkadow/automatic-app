using Domain.Modules.Base.Consts;
using Domain.Modules.Base.Models;
using Domain.Modules.PlcParameterHistory.Consts;
using Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Modules.PlcParameter.Models;

namespace Domain.Modules.PlcParameterHistory.Models
{
    /// <summary>
    /// PlcParameterHistory
    /// </summary>
    [Serializable]
	[Index(nameof(Name), IsUnique = true)]
	[Table(PlcParameterHistoryConsts.Table, Schema = BaseDatabaseConst.Base)]
	public class PlcParameterHistoryModel : BaseModel, IEntity
	{
		#region Fields

        [Required]
        [ForeignKey("PlcParameterId")]
        public Guid PlcParameterId { get; set; }

        public virtual PlcParameterModel PlcParameter { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        public string? Address { get; set; }
        public int Type { get; set; }
        public decimal ParameterValue { get; set; }
        public DateTime DateTimeReadUTC { get; set; }
        #endregion Fields
    }
}