using AutoMapper;
using CustomerRelationshipManagement.Data.Models;
using CustomerRelationshipManagement.Server.Repo.Interfaces;
using CustomerRelationshipManagement.Shared.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRelationshipManagement.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IAdminAppRepository _context; 

        public AdminController(IAdminAppRepository adminAppRepository)
        {
            _context = adminAppRepository; 
        }


        [HttpGet]
        public async Task<string> Get(AppUser AppUser)
        {
            return "ItsWorking";
        }

        [HttpPost("register")]
        public async Task<bool> Register(RegisterUserDto RegisterUser)
        {
            var result = await _context.RegisterUserAsync(RegisterUser);
            return result;
        }


    }
}
