using CustomerRelationshipManagement.Shared.Models.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared.Models 
{
    public class EngagementModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }

        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public EngagementModel()
        {
            Name = string.Empty;
            Organization = string.Empty;
        }
    }
}
