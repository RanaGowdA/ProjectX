using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared.Models
{
    public class RoleAddDto
    { 
        public string Name { get; set; }
        public string RolesList { get; set; }
        public bool ReadOnly { get; set; }

    }
}
