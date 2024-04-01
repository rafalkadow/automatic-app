using Microsoft.AspNetCore.Identity;

namespace Domain.Modules.Identity
{
    public class RoleAppClaim : IdentityRoleClaim<Guid>
    {
        public string? Description { get; set; }
        public string? Group { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public virtual RoleApp Role { get; set; }

        public RoleAppClaim() 
            : base()
        {
        }

        public RoleAppClaim(string roleClaimDescription = null, string roleClaimGroup = null) 
            : base()
        {
            Description = roleClaimDescription;
            Group = roleClaimGroup;
        }
    }
}