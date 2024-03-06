using Domain.Modules.Base.Queries;

namespace Domain.Modules.SignIn.Queries
{
    [Serializable]
    public class GetSignInBase : GetBaseResultFilter
    {
        public string? EmailSignIn { get; set; }
        public string? PasswordSignIn { get; set; }
        public bool RememberData { get; set; }
    }
}