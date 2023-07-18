using CustomerRelationshipManagement.Shared.Models.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared.Models
{
    public class TemplateConfiguration
    {
        public int Id { get; set; }
        public string Segment { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Organization { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }

        public TemplateConfiguration()
        {
            Segment = string.Empty;
            City = string.Empty;
            Region = string.Empty;
            Organization = string.Empty; 
        }
    }
}
