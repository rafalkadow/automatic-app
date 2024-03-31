using Microsoft.AspNetCore.Identity;

namespace Domain.Modules.Identity
{
    public class RoleClaim : IdentityRoleClaim<string>
    {
        public string Description { get; set; }
        public string Group { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public virtual Role Role { get; set; }

        public RoleClaim() 
            : base()
        {
        }

        public RoleClaim(string roleClaimDescription = null, string roleClaimGroup = null) 
            : base()
        {
            Description = roleClaimDescription;
            Group = roleClaimGroup;
        }
    }
}