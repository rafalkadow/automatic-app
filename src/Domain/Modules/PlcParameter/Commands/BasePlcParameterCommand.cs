using Domain.Modules.Base.Commands;
using Domain.Modules.Base.Enums;
using Domain.Modules.PlcDriver.Models;
using Domain.Modules.PlcParameter.Enum;

namespace Domain.Modules.PlcParameter.Commands
{
    [Serializable]
    public class BasePlcParameterCommand : BaseModuleCommand
    {
        public Guid PlcDriverId { get; set; }
        public virtual PlcDriverModel PlcDriver { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Address { get; set; }
        public AccessModeTypeEnum AccessModeType { get; set; }
        public ModbusTypeEnum ModbusTypeEnum { get; set; }
        public ParameterTypeEnum ParameterType { get; set; }
        public YesNoEnum ModbusVisibility { get; set; }
        public YesNoEnum RecordToDatabase { get; set; }
        public int MaximumValue { get; set; }
        public int MinimumValue { get; set; }
    }
}