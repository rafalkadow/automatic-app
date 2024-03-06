using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Modules.Base.Models
{
    [Serializable]
    [Index(nameof(OrderId), IsUnique = false)]
    public abstract class BaseModel : ICloneable, IEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey("CreatedUserId")]
        public Guid CreatedUserId { get; set; }

        [StringLength(200)]
        public string? CreatedUserName { get; set; }

        public DateTime? CreatedOnDateTimeUTC { get; set; }

        public Guid? ModifiedUserId { get; set; }

        public string? ModifiedUserName { get; set; }
        public DateTime? ModifiedOnDateTimeUTC { get; set; }

        [Required]
        [MaxLength(25)]
        public RecordStatusEnum RecordStatus { get; set; }

        [Required]
        public ulong OrderId { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}