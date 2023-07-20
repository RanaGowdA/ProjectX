using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagement.Shared.Models.AccountConfig
{
    public class Division
    {
        public int Id { get; set; }
        public string? Name { get; set; } 

        [ForeignKey("SegmentId")]
        public int SegmentId { get; set; }
        public Segment? Segment { get; set; }
    }
}
