using CustomerRelationshipManagement.Data;
using CustomerRelationshipManagement.Data.Models;
using CustomerRelationshipManagement.Server.Repo.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace CustomerRelationshipManagement.Server.Repo.Implementations
{
    public class AdminAppRepo : IAdminAppRepository
    {
        private readonly IMemoryCache _memory;
        private readonly AdminDbContext _context;

        public AdminAppRepo(AdminDbContext adminDbContext, IMemoryCache memoryCache)
        {
            _context = adminDbContext;
            _memory = memoryCache;
        }

        public async Task<bool> RegisterUserAsync(AppUser AppUser)
        {
            _context.Update(AppUser);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
