using Domain.Modules.Base.Commands;
using Domain.Modules.PlcDriverGroup.Models;

namespace Domain.Modules.PlcDriver.Commands
{
    [Serializable]
    public class BasePlcDriverCommand : BaseModuleCommand
    {
        public Guid PlcDriverGroupId { get; set; }

        public virtual PlcDriverGroupModel PlcDriverGroup { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? DeviceAddress { get; set; }
        public int DevicePort { get; set; }

        public int SlaveId { get; set; }

        public int TimeOut { get; set; }
    }
}