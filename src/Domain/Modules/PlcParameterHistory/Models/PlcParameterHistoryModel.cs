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
	[Table(PlcParameterHistoryConsts.Table, Schema = BaseDatabaseConst.Base)]
	public class PlcParameterHistoryModel : BaseModel, IEntity
	{
		#region Fields

        [Required]
        [ForeignKey("PlcParameterId")]
        public Guid PlcParameterId { get; set; }

        public virtual PlcParameterModel PlcParameter { get; set; }
        public int Value { get; set; }
        public DateTime DateAddUTC { get; set; }
        #endregion Fields
    }
}