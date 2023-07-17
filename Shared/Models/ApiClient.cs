using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared.Models
{
    public class ApiClient
    {
        [Key]
        public int Id { get; set; }

        public Guid ClientId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
