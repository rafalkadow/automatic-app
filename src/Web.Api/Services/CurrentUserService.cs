using Application.Interfaces.Services;
using Domain.Modules.Base.Extensions;
using System.Security.Claims;

namespace Web.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            string UserStr = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (UserStr.IsGuid())
                UserId = new Guid(UserStr);
            Claims = httpContextAccessor.HttpContext?.User?.Claims.AsEnumerable().Select(item => new KeyValuePair<string, string>(item.Type, item.Value)).ToList();
        }

        public Guid UserId { get; }
        public List<KeyValuePair<string, string>> Claims { get; set; }
    }
}