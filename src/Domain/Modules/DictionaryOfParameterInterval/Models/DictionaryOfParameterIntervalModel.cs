using Domain.Modules.Base.Consts;
using Domain.Modules.Base.Models;
using Domain.Modules.DictionaryOfParameterInterval.Consts;
using Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public string? Code { get; set; }
        public int Value { get; set; }

        #endregion Fields
    }
}