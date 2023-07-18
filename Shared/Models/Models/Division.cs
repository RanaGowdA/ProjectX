using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared.Models.Models
{
    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; } 

        [ForeignKey("SegmentId")]
        public int SegmentId { get; set; }
        public Segment Segment { get; set; }
    }
}
