using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagement.Shared.Models.AccountConfig
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
