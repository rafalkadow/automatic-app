using System.ComponentModel;

namespace Domain.Modules.PlcParameter.Enum
{
    [Serializable]
    public enum AlarmTypeEnum
    {
        [Description("Information")]
        Information = 0,

        [Description("Warning")]
        Warning,

        [Description("Alert")]
        Alert,
    }
}