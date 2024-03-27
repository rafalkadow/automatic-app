using Shared.Attributes;
using Shared.Enums;

namespace Domain.Modules.Base.Commands
{
    [Serializable]
    public class BaseModuleCommand
    {
        public Guid? Id { get; set; }

        public RecordStatusEnum RecordStatus { get; set; }

        [SwaggerIgnore]
        public ulong OrderId { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}