using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared.Models
{
    public class RoleVm
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }

        public RoleVm()
        {
        }

        public RoleVm(string name, bool isSelected)
        {
            Name = name;
            IsSelected = isSelected;
        }
    }
}
