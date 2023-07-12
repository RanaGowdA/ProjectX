using CustomerRelationshipManagement.Data;
using CustomerRelationshipManagement.Data.Models;
using CustomerRelationshipManagement.Server.Repo.Interfaces;
using CustomerRelationshipManagement.Shared.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace CustomerRelationshipManagement.Server.Repo.Implementations
{
    public class AdminAppRepo : IAdminAppRepository
    {
        private readonly IMemoryCache _memory;
        private readonly AdminDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminAppRepo(AdminDbContext adminDbContext, 
            IMemoryCache memoryCache,
            RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = adminDbContext;
            _memory = memoryCache;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserDto RegisterUser)
        {
            AppUser appUser = new AppUser();
            appUser.AXCIANId = RegisterUser.AxcianId;
            appUser.PhoneNumber = RegisterUser.PhoneNumber;
            appUser.Password = RegisterUser.Password;
            appUser.Email = RegisterUser.Email;
            _context.Users.Update(appUser);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == result); 
            }
            var roles = RegisterUser.Roles.Split(',').ToList();
            var appRoles = new List<AppRole>();
            foreach (var role in roles)
            {
                AppRole appRole = new AppRole();
                appRole.Name = role;
                appRole.NormalizedName = role;
                appRoles.Add(appRole);
            }
            await _context.Roles.AddRangeAsync(appRoles);
            return result > 0;
        }
    }
}
