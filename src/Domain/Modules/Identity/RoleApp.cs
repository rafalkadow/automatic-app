using Microsoft.AspNetCore.Identity;

namespace Domain.Modules.Identity
{
    public class RoleApp : IdentityRole<Guid>
    {
        public string Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public virtual ICollection<RoleAppClaim> RoleClaims { get; set; }

        public RoleApp()
           : base()
        {
            RoleClaims = new HashSet<RoleAppClaim>();
        }

        public RoleApp(string roleName, string roleDescription = null)
            : base(roleName)
        {
            RoleClaims = new HashSet<RoleAppClaim>();
            Description = roleDescription;
        }
    }
}