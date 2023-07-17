using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared
{
	public class UserLoginDto
	{

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserCode { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Enter valid Email address")]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
