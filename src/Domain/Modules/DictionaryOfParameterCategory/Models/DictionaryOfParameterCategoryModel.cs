using Domain.Modules.Base.Consts;
using Domain.Modules.Base.Models;
using Domain.Modules.DictionaryOfParameterCategory.Consts;
using Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Modules.DictionaryOfParameterCategory.Models
{
    /// <summary>
    /// DictionaryOfParameterCategory
    /// </summary>
    [Serializable]
	[Index(nameof(Name), IsUnique = true)]
	[Table(DictionaryOfParameterCategoryConsts.Table, Schema = BaseDatabaseConst.Base)]
	public class DictionaryOfParameterCategoryModel : BaseModel, IEntity
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