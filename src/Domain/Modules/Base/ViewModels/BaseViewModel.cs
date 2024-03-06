using Shared.Enums;
using Shared.Interfaces;

namespace Domain.Modules.Base.ViewModels
{
    [Serializable]
    public abstract class BaseViewModel : ICloneable, IEntity
    {
        public Guid Id { get; set; }

        public Guid CreatedUserId { get; set; }

        public string? CreatedUserName { get; set; }

        public DateTime? CreatedOnDateTimeUTC { get; set; }

        public Guid? ModifiedUserId { get; set; }

        public string? ModifiedUserName { get; set; }

        public DateTime? ModifiedOnDateTimeUTC { get; set; }

        public RecordStatusEnum RecordStatus { get; set; } = RecordStatusEnum.Actived;

        public ulong OrderId { get; set; }

        public string GetCurrentDateTime
        { get { return DateTime.UtcNow.ToLocalTime().ToShortDateString(); } }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}