using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared.Dto
{
    public class LoginResult
    {
        public string Message { get; set; }
        public string Email { get; set; }
        public string JwtBearer { get; set; }
        public bool Success { get; set; }
    }
}
