using Domain.Modules.Base.Commands;
using Domain.Modules.PlcParameter.Models;

namespace Domain.Modules.PlcParameterHistory.Commands
{
    [Serializable]
    public class BasePlcParameterHistoryCommand : BaseModuleCommand
    {
        public Guid PlcParameterId { get; set; }
        public virtual PlcParameterModel PlcParameter { get; set; }
        public int Value { get; set; }
        public DateTime DateAddUTC { get; set; }
    }
}