using CustomerRelationshipManagement.Data.Models;

namespace CustomerRelationshipManagement.Server.Repo.Interfaces
{
    public interface IAdminAppRepository
    {
        Task<bool> RegisterUserAsync(AppUser AppUser);
    }
}
