using Shared.Enums;

namespace Shared.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }

        Guid CreatedUserId { get; set; }

        string? CreatedUserName { get; set; }

        DateTime? CreatedOnDateTimeUTC { get; set; }

        Guid? ModifiedUserId { get; set; }

        string? ModifiedUserName { get; set; }

        DateTime? ModifiedOnDateTimeUTC { get; set; }
        RecordStatusEnum RecordStatus { get; set; }
        ulong OrderId { get; set; }
    }
}