using CustomerRelationshipManagement.Data.Models;
using CustomerRelationshipManagement.Server.Repo.Interfaces;
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
        public async Task<bool> Register(AppUser AppUser)
        {
            var result = await _context.RegisterUserAsync(AppUser);
            return result;
        }


    }
}
