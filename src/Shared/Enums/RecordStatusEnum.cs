using System.ComponentModel;

namespace Shared.Enums
{
    [Serializable]
    public enum RecordStatusEnum
    {
        [Description("AllRecords")]
        AllRecords = -1,

        [Description("Inactived")]
        Inactived = 0,

        [Description("Actived")]
        Actived,

        [Description("Archived")]
        Archived,

        [Description("Deleted")]
        Deleted,
    }
}