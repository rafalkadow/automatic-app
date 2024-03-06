using System.Security.Claims;

namespace Domain.Interfaces
{
    public interface IUserAccessor
    {
        public ClaimsPrincipal User();

        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
	}
}