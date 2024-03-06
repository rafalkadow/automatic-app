using Domain.Modules.Base.Commands;

namespace Domain.Modules.PlcDriverGroup.Commands
{
    [Serializable]
    public class BasePlcDriverGroupCommand : BaseModuleCommand
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}