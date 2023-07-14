using AutoMapper;
using CustomerRelationshipManagement.Data.Models;
using CustomerRelationshipManagement.Server.MapperModule;
using CustomerRelationshipManagement.Server.Repo.Interfaces;
using CustomerRelationshipManagement.Shared.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CustomerRelationshipManagement.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IAdminAppRepository _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AdminController(IAdminAppRepository adminAppRepository,
                                    UserManager<AppUser> userManager,
                                    RoleManager<AppRole> roleManager)
        {
            _context = adminAppRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [HttpGet]
        public async Task<string> Get(AppUser AppUser)
        {
            return "ItsWorking";
        }

        //[HttpPost("register")]
        //public async Task<bool> Register(RegisterUserDto RegisterUser)
        //{
        //    var result = await _context.RegisterUserAsync(RegisterUser);
        //    return result;
        //}

        [HttpPost("registerUser")]
        public async Task<bool> RegisterUser(AppNewUserDTO appNewUserDTO)
        {

            var newUser = Map.CreateAppUserFromAppUserCreateVm(appNewUserDTO);
            var isExisting = await _context.GetUsersDbSet().FirstOrDefaultAsync(u => u.AXCIANId.Equals(appNewUserDTO.AXCIANId));

            if (isExisting != null)
            {
                ModelState.AddModelError(nameof(appNewUserDTO.AXCIANId),
                    "AXCIAN Id is already existing in Database.");
                return false;
            }

            var result = await _userManager.CreateAsync(newUser, appNewUserDTO.Password);
            if (result.Succeeded)
            {
                var message = $"{newUser.UserName} was added successfully. ";
                var user = await _context.GetAppUserByAxicianIdAsync(newUser.AXCIANId);

                var roleResult = await _userManager.AddToRoleAsync(user, RoleConstants.SuperAdminRole);
                if (!roleResult.Succeeded)
                {
                    message = message + $"{RoleConstants.SuperAdminRole} could'nt be added. ";
                }
                roleResult = await _userManager.AddToRoleAsync(user, RoleConstants.SuperAdminRole);
                if (!roleResult.Succeeded)
                {
                    message = message + $"{RoleConstants.SuperAdminRole} could'nt be added.";
                    return false;
                }
            }
            return true; 
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var appUser = await _context.GetAppUserByIdAsync(id);
            var userVm = Map.AppUserToAppUserEditDetialsVm(appUser);
            var appRoles = await _roleManager.Roles.ToListAsync();
            foreach (var role in appRoles)
            {
                if (await _userManager.IsInRoleAsync(appUser, role.Name))
                    userVm.Roles.Add(new RoleVm(role.Name, isSelected: true));
                else
                    userVm.Roles.Add(new RoleVm(role.Name, isSelected: false));
            }
            return View(userVm);
        }
    }
}
