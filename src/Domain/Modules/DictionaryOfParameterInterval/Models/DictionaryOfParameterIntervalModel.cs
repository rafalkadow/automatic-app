using Domain.Modules.Base.Consts;
using Domain.Modules.Base.Models;
using Domain.Modules.DictionaryOfParameterInterval.Consts;
using Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Modules.PlcDriver.Models;

namespace Domain.Modules.DictionaryOfParameterInterval.Models
{
    /// <summary>
    /// DictionaryOfParameterInterval
    /// </summary>
    [Serializable]
	[Index(nameof(Name), IsUnique = true)]
	[Table(DictionaryOfParameterIntervalConsts.Table, Schema = BaseDatabaseConst.Base)]
	public class DictionaryOfParameterIntervalModel : BaseModel, IEntity
	{
		#region Fields

        [Required]
        [ForeignKey("PlcDriverId")]
        public Guid PlcDriverId { get; set; }

        public virtual PlcDriverModel PlcDriver { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        public string? Address { get; set; }
        public int Type { get; set; }

        #endregion Fields
    }
}