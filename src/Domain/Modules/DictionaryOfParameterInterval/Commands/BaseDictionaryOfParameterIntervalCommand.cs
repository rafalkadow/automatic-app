using Domain.Modules.Base.Commands;
using Domain.Modules.PlcParameter.Models;

namespace Domain.Modules.DictionaryOfParameterInterval.Commands
{
    [Serializable]
    public class BaseDictionaryOfParameterIntervalCommand : BaseModuleCommand
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Value { get; set; }
    }
}