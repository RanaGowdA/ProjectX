using CustomerRelationshipManagement.Data.Models;
using CustomerRelationshipManagement.Shared.Dto;
using CustomerRelationshipManagement.Shared.Utilities;

namespace CustomerRelationshipManagement.Server.MapperModule
{
    public class Map
    {

        public static AppUser CreateAppUserFromAppUserCreateVm(AppNewUserDTO input)
        {
            var newUser = new AppUser
            {
                UserName = input.Name.ToPascalCase(),
                UserCode = input.AXCIANId.ToUpper(),
            };

            return newUser;
        }



    }
}
