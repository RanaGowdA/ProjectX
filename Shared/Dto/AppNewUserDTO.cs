using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared.Dto
{
    public class AppNewUserDTO
    {
        public string Name { get; set; }
        public string Enterprise { get; set; }
        public string Site { get; set; }
        public string Area { get; set; }
        public string Unit { get; set; }
        public string Cell { get; set; }
        public string EmailId { get; set; }

        public string Password { get; set; }
    }
}
