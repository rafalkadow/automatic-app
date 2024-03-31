using Microsoft.AspNetCore.Identity;

namespace Domain.Modules.Identity
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }

        public Role()
           : base()
        {
            RoleClaims = new HashSet<RoleClaim>();
        }

        public Role(string roleName, string roleDescription = null)
            : base(roleName)
        {
            RoleClaims = new HashSet<RoleClaim>();
            Description = roleDescription;
        }
    }
}