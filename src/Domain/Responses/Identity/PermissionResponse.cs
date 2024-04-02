using System.Collections.Generic;

namespace Domain.Responses.Identity
{
    public class PermissionResponse
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public List<RoleClaimResponse> RoleClaims { get; set; }
    }
}