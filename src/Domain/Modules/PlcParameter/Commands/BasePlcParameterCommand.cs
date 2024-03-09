using Domain.Modules.Base.Commands;
using Domain.Modules.PlcDriver.Models;

namespace Domain.Modules.PlcParameter.Commands
{
    [Serializable]
    public class BasePlcParameterCommand : BaseModuleCommand
    {
        public Guid PlcDriverId { get; set; }

        public virtual PlcDriverModel PlcDriver { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Type { get; set; }
    }
}