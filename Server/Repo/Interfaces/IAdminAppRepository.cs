using CustomerRelationshipManagement.Data.Models;
using CustomerRelationshipManagement.Shared.Dto;

namespace CustomerRelationshipManagement.Server.Repo.Interfaces
{
    public interface IAdminAppRepository
    {
        Task<bool> RegisterUserAsync(RegisterUserDto RegisterUser);
    }
}
