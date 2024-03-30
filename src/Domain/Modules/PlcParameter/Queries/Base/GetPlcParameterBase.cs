using Domain.Modules.Base.Enums;
using Domain.Modules.Base.Queries;
using Domain.Modules.PlcDriver.Models;
using Domain.Modules.PlcParameter.Enum;

namespace Domain.Modules.PlcParameter.Queries
{
	[Serializable]
	public class GetPlcParameterBase : GetBaseResultFilter
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
        public int MinimumValue { get; set; }
        public int MaximumValue { get; set; }
    }
}