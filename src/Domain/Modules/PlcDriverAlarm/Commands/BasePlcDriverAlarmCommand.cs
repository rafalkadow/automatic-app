using Domain.Modules.Base.Commands;

namespace Domain.Modules.PlcDriverAlarm.Commands
{
    [Serializable]
    public class BasePlcDriverAlarmCommand : BaseModuleCommand
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}