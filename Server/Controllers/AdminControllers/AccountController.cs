using CustomerRelationshipManagement.Data.Models;
using CustomerRelationshipManagement.Shared.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WeCare.WebAPI.Utilities;

namespace CustomerRelationshipManagement.Server.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _userRoleManager;
        private readonly IConfiguration _configuration;
        public AccountController(IConfiguration configuration, UserManager<AppUser> userManager,
                             SignInManager<AppUser> signInManager, RoleManager<AppRole> userRoleManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
            _userRoleManager = userRoleManager;
        }

        /// <summary>
        /// Validates authorised user
        /// </summary>
        /// <returns>string Success or Failure</returns> 
        [HttpGet("validate")]
        public async Task<bool> Validate()
        {

            var AppRole1 = new AppRole
            {
                Name = RoleConstants.SuperAdminRole
            };

            var AppRole2 = new AppRole
            {
                Name = RoleConstants.AdminRole
            };
            var AppRole3 = new AppRole
            {
                Name = RoleConstants.WebAdminRole
            };

            ////Seed Roles
            //await _userRoleManager.CreateAsync(AppRole1);
            //await _userRoleManager.CreateAsync(AppRole2);
            //await _userRoleManager.CreateAsync(AppRole3);

            //Seed Default User
            var defaultUser = new AppUser
            {
                UserName = "superadmin",
                Email = "superadmin@gmail.com",
                Name = "superadmin",
                UserCode = "AXCIAN00001",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var user = await _userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await _userManager.CreateAsync(defaultUser, "Pa$$word");
                await _userManager.AddToRoleAsync(defaultUser, RoleConstants.SuperAdminRole);
                await _userManager.AddToRoleAsync(defaultUser, RoleConstants.AdminRole);
                await _userManager.AddToRoleAsync(defaultUser, RoleConstants.WebAdminRole);
            }
            return true;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<LoginResult> Login(LoginDto loginDto)
        {
            LoginResult loginResult = new LoginResult();
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Email == loginDto.Username.ToLower());

            if (user == null)
            {
                loginResult.Success = false;
                loginResult.Message = "Username is invalid";
                return loginResult;
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                loginResult.Success = false;
                loginResult.Message = "Password is invalid";
                return loginResult;
            }

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));


            var token = JwtHelper.GenerateJwtToken(user, claims,
                    _configuration["Jwt:Key"], _configuration["Jwt:Issuer"], validDays: 90);
            loginResult.Success = true;
            loginResult.Message = "Login successfull";
            loginResult.JwtBearer = token;
            loginResult.Email = user.Email;

            return loginResult;
        }







    }


}
