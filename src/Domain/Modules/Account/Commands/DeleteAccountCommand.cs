using Domain.Modules.Base.Commands;
using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.Account.Commands
{
    [Serializable]
    public class DeleteAccountCommand : BaseActionCommand, IRequest<OperationResult>, ICommand
    {
    }
}