using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared.Models.Models
{
    public class ProjectAccount
    {
        public int Id { get; set; }
        public string Organization { get; set; }
        public List<Segment> Segments { get; set; }
    }
}
