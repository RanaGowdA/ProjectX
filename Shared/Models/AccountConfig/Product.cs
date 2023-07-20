using CustomerRelationshipManagement.Shared.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared.Models.AccountConfig
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("ProjectAccountId")]
        public int ProjectAccountId { get; set; }
        public ProjectAccount? ProjectAccount { get; set; }
    }
}
