using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared
{
    public class Contacts
    {

        // Name And Occupation
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        //public Gender Gender { get; set; }

        //public string Organization { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string Title { get; set; }

        // Contact Details 
        [Column(TypeName = "nvarchar(15)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string ContactNumber { get; set; }

        //[Column(TypeName = "nvarchar(15)")]
        //public string AlternateContactNumber { get; set; } 

        [Column(TypeName = "nvarchar(15)")]
        public string Fax { get; set; }

        public string Address { get; set; }

        //[Column(TypeName = "nvarchar(15)")]
        //public string LinkedIn { get; set; }

    }
}
