using Microsoft.AspNetCore.Identity;

namespace CustomerRelationshipManagement.Data.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string UserCode { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
        public AppUser()
        {
        }
    }
}
