using Microsoft.AspNetCore.Identity;

namespace CustomerRelationshipManagement.Data.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string AXCIANId { get; set; }
        public string Password { get; set; }

        public AppUser()
        {
            Password = string.Empty;
        }
    }
}
