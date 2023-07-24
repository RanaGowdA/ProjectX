using AutoMapper;
using CustomerRelationshipManagement.Data;
using CustomerRelationshipManagement.Data.Models;
using CustomerRelationshipManagement.Server.MapperModule;
using CustomerRelationshipManagement.Server.Repo.Interfaces;
using CustomerRelationshipManagement.Shared;
using CustomerRelationshipManagement.Shared.Dto;
using CustomerRelationshipManagement.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MudBlazor;
using System.IdentityModel.Tokens.Jwt;

namespace CustomerRelationshipManagement.Server.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly AdminDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AdminController(AdminDbContext context,
                                    UserManager<AppUser> userManager,
                                    RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [HttpGet("get")]
        public async Task<string> Get()
        { 
            return "ItsWorking";
        }

        /////**
        ////* Gets a list of users for Admin
        ////*
        ////* @return json
        ////**/
        //[Authorize(Roles = "SuperMan")]
        //[HttpGet]
        //public async Task<ActionResult> GetUsers()
        //{
        //    var users = await _userManager.Users
        //      .Where(u => u.IsDeleted == 0)
        //      .Include(r => r.UserRoles)
        //      .ThenInclude(r => r.AppRole)
        //      .Select(u => new
        //      {
        //          u.Id,
        //          Username = u.UserName,
        //          Usercode = u.UserCode,
        //          u.Name,
        //          u.Email,
        //          Role = u.UserRoles.Select(r => r.AppRole.Name).ToList()
        //      })
        //      .ToListAsync();

        //    return Ok(users);
        //}

        /////**
        //// * Gets the user details
        //// *
        //// * @param string username
        //// * @return json
        //// **/
        //[Authorize(Roles = "SuperMan")]
        //[HttpGet("{username}")]
        //public async Task<ActionResult> GetUser(string username)
        //{
        //    var user = await _userManager.Users
        //      .Include(r => r.UserRoles)
        //      .ThenInclude(r => r.AppRole)
        //      .Select(u => new
        //      {
        //          u.Id,
        //          Username = u.UserName,
        //          u.Name,
        //          u.Email,
        //          Role = u.UserRoles.Select(r => r.AppRole.Name).ToList()
        //      }).SingleOrDefaultAsync(u => u.Username == username.ToLower());

        //    return Ok(user);
        //}

        /////**
        //// * Add a new user from Admin
        //// *
        //// * @param UserAddDto addDto
        //// * @return string
        //// **/
        ////[Authorize(Roles = "SuperMan")]
        //[HttpPost("AddUser")]
        //public async Task<ActionResult> AddUser(UserLoginDto addDto)
        //{
        //    var userExists = await _userManager.Users.AnyAsync(x => x.UserName == addDto.UserName.ToLower());
        //    if (userExists)
        //    {
        //        var userExisting = await _userManager.Users
        //              .Where(u => u.UserName == addDto.UserName.ToLower() && u.Email.ToLower() == addDto.Email.ToLower() && u.IsDeleted == 1)
        //              .SingleOrDefaultAsync();
        //        if (!EqualityComparer<AppUser>.Default.Equals(userExisting, default))
        //        {
        //            userExisting.IsDeleted = 0;
        //            _context.Entry(userExisting).State = EntityState.Modified;
        //            await _context.SaveChangesAsync();
        //            return Created("User created successfully", "");
        //        }
        //        else
        //        {
        //            return BadRequest("Username is taken");
        //        }
        //    }

        //    var user = new AppUser
        //    {
        //        UserName = addDto.UserName.ToLower(),
        //        UserCode = addDto.UserCode.ToLower(),
        //        Email = addDto.Email.ToLower(),
        //        Name = addDto.Name
        //    };

        //    var result = await _userManager.CreateAsync(user, "Pa$$w0rd");
        //    if (!result.Succeeded) return BadRequest(result.Errors);

        //    var roleExist = await _roleManager.RoleExistsAsync(addDto.Role.ToUpper());
        //    if (!roleExist)
        //    {
        //        var appRole = new AppRole
        //        {
        //            Name = addDto.Role.ToUpper()
        //        };
        //        var roleResults = await _roleManager.CreateAsync(appRole);
        //    }
        //    var roleResult = await _userManager.AddToRoleAsync(user, addDto.Role.ToUpper());
        //    if (!roleResult.Succeeded) return BadRequest(result.Errors);

        //    return Created("User created successfully", "");
        //}

        /////**
        //// * Updates the user details
        //// *
        //// * @param UserAddDto updateDto
        //// * @return string
        //// **/
        //[Authorize(Roles = "SuperMan")]
        //[HttpPut]
        //public async Task<ActionResult> UpdateUser(UserLoginDto updateDto)
        //{
        //    //var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    var user = await _userManager.Users
        //        .Include(r => r.UserRoles)
        //        .ThenInclude(r => r.AppRole)
        //        .SingleOrDefaultAsync(u => u.UserName == updateDto.UserName.ToLower());

        //    user.Name = updateDto.Name;
        //    user.Email = updateDto.Email;
        //    user.UserCode = updateDto.UserCode;

        //    //Get the User Roles and then remove them and add the new roles back in
        //    var roles = user.UserRoles.Select(r => r.AppRole.Name).ToList();
        //    await _userManager.RemoveFromRolesAsync(user, roles);
        //    await _userManager.AddToRoleAsync(user, updateDto.Role);

        //    _context.Entry(user).State = EntityState.Modified;
        //    if (await _context.SaveChangesAsync() > 0) return Ok(updateDto.UserName + " updated sucessfully");

        //    return BadRequest("Failed to Update User");
        //}

        /////**
        //// * Deletes a User
        //// *
        //// * @param string username
        //// * @return string
        //// **/
        //[Authorize(Roles = "SuperMan")]
        //[HttpDelete("{username}")]
        //public async Task<ActionResult> DeleteUser(string username)
        //{
        //    //var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //    var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == username.ToLower());

        //    if (EqualityComparer<AppUser>.Default.Equals(user, default))
        //    {
        //        return BadRequest("User Does not Exist");
        //    }
        //    else
        //    {
        //        user.IsDeleted = 1;

        //        _context.Entry(user).State = EntityState.Modified;
        //        if (await _context.SaveChangesAsync() > 0) return Ok(username + " Deleted");
        //    }

        //    return BadRequest("Failed to Delete User");
        //}


        ///// <summary>
        ///// Gets the list of roles
        ///// </summary> 
        ///// <returns>json</returns> 
        //[Authorize(Roles = "SuperMan")]
        //[HttpGet]
        //public async Task<ActionResult> FetchRoles()
        //{
        //    var roles = await _roleManager.Roles
        //    .Select(r => new
        //    {
        //        id = r.Id,
        //        name = r.Name
        //    })
        //    .Where(r => r.name != "Admin")
        //    .ToListAsync();

        //    return Ok(roles);
        //}

        ///// <summary>
        ///// Adds a new role
        ///// </summary> 
        ///// <param name="roleDto" </param>
        ///// <returns>json</returns> 
        ////[Authorize(Roles = "SuperMan")]
        //[HttpPost("AddRole")]
        //public async Task<ActionResult> AddRole(RoleAddDto roleDto)
        //{
        //    var role = await _roleManager.Roles.SingleOrDefaultAsync(r => r.NormalizedName == roleDto.Name.ToUpper());
        //    if (EqualityComparer<AppRole>.Default.Equals(role, default))
        //    {
        //        var newRole = new AppRole { Name = roleDto.Name };
        //        await _roleManager.CreateAsync(newRole);
        //        return Created("Created", new { newRole.Id, newRole.Name });
        //    }
        //    else
        //    {
        //        //Updated
        //        await _roleManager.UpdateAsync(role);
        //        return Ok(new { role.Id, role.Name });
        //    }
        //}



    }
}
