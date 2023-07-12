using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared.Dto
{
    public class RegisterUserDto
    {
        public string AxcianId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }

        public RegisterUserDto() { 

        }
    }
}
