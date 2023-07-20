using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared.Models.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; } 

        [ForeignKey("SegmentId")]
        public int SegmentId { get; set; }
        public Segment? Segment { get; set; }
    }
}
