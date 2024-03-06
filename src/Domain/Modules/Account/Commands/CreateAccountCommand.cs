using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.Account.Commands
{
    [Serializable]
    public class CreateAccountCommand : BaseAccountCommand, IRequest<OperationResult>, ICommand
    {
    }
}