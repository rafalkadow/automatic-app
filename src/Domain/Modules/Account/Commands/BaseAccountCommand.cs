using Domain.Modules.Base.Commands;
using Domain.Modules.Base.Enums;

namespace Domain.Modules.Account.Commands
{
    [Serializable]
    public class BaseAccountCommand : BaseModuleCommand
    {
        public required string AccountEmail { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public required string AccountPassword { get; set; }
        public string? RepeatPassword { get; set; }
        public int AccountTypeId { get; set; } = (int)AccountTypeEnum.None;
        public string? AccountTypeName { get; set; }

    }
}