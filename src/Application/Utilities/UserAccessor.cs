using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application.Utilities
{
	public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _accessor;

		public UserAccessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor ?? throw new ArgumentNullException(nameof(accessor));

			if (User() != null)
            {
                string UserStr = User().Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
                if (!string.IsNullOrEmpty(UserStr))
                {
                    UserGuid = new Guid(UserStr);
                    UserName = User().Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
                }
            }
			
		}

        public UserAccessor()
        {
        }

        public ClaimsPrincipal User()
        {
            if (_accessor != null && _accessor.HttpContext != null && _accessor.HttpContext.User != null)
                return _accessor.HttpContext.User;
            else
                return null;
        }

        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
    }
}