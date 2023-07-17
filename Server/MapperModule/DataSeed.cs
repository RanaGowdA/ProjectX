using CustomerRelationshipManagement.Data;
using CustomerRelationshipManagement.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CustomerRelationshipManagement.Server.MapperModule
{
    public class DataSeed
    {
        public static async Task SeedData(AdminDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (!await userManager.Users.AnyAsync())
            {

                //Create a List of Roles
                var roles = new List<AppRole>
                { new AppRole{Name = "SuperAdmin"},new AppRole{Name = "Admin"} };

                //Add the Roles to the Database
                foreach (var role in roles)
                {
                    var result = await roleManager.CreateAsync(role);
                }

                //Create Users
                var rana = new AppUser
                {
                    UserName = "rana.gowd",
                    Name = "Rana Gowd AE",
                    Email = "rana.gowd@axiscades.com"
                };
                await userManager.CreateAsync(rana, "Pa$$w0rd");
                await userManager.AddToRoleAsync(rana, "SuperAdmin");

                var sriram = new AppUser
                {
                    UserName = "sriram",
                    Name = "Sriram JK",
                    Email = "sriram.jayakrishna@axiscades.in"
                };
                await userManager.CreateAsync(rana, "Pa$$w0rd");
                await userManager.AddToRoleAsync(rana, "Admin");
            } 
 
        }
    }
}
