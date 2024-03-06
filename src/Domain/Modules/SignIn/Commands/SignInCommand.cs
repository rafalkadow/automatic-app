using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.SignIn.Commands
{
    [Serializable]
    public class SignInCommand : BaseSignInCommand, IRequest<OperationResult>, ICommand
    {
    }
}