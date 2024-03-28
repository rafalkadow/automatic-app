using System.ComponentModel;

namespace Domain.Modules.PlcParameter.Enum
{
    [Serializable]
    public enum AccessModeTypeEnum
    {
        [Description("Read")]
        Read = 0,

        [Description("Write")]
        Write,

        [Description("ReadAndWrite")]
        ReadAndWrite,
    }
}