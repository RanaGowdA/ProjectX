using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Data.Models
{
    public static class RoleConstants
    {
        public static string SuperAdminRole { get; } = "SuperMan";
        public static string WebAdminRole { get; } = "HeMan";
        public static string AdminRole { get; } = "CommonMan";
    }
}
