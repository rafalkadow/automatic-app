using Domain.Modules.Base.Commands;

namespace Domain.Modules.SignIn.Commands
{
    [Serializable]
    public class BaseSignInCommand : BaseModuleCommand
    {
        public string SignInEmail { get; set; }
        public string SignInPassword { get; set; }
    }
}