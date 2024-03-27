
using Shared.Interfaces;

namespace Domain.Modules.Base.Commands
{
    [Serializable]
    public class BaseUpDownCommand : ICommand
    {
        public ulong OrderId { get; set; }
    }
}