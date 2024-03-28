using System.ComponentModel;

namespace Domain.Modules.PlcParameter.Enum
{
    [Serializable]
    public enum ParameterTypeEnum
    {
        [Description("Analog")]
        Analog = 0,

        [Description("Digital")]
        Digital,
    }
}