using Domain.Modules.Base.Commands;
using Domain.Modules.PlcParameter.Models;

namespace Domain.Modules.DictionaryOfParameterCategory.Commands
{
    [Serializable]
    public class BaseDictionaryOfParameterCategoryCommand : BaseModuleCommand
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Value { get; set; }
    }
}