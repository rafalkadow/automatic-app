using System.ComponentModel;

namespace Domain.Modules.PlcParameter.Enum
{
    [Serializable]
    public enum ModbusTypeEnum
    {
        [Description("Coils")]
        Coils = 0,

        [Description("DiscreteInputs")]
        DiscreteInputs,

        [Description("HoldingRegisters")]
        HoldingRegisters,

        [Description("InputRegisters")]
        InputRegisters,
    }
}