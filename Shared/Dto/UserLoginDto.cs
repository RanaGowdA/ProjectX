using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared
{
	public class UserLoginDto
	{
		[JsonPropertyName("emailId")]
		public string EmailId { get; set; }

		[JsonPropertyName("password")]
		public string Password { get; set; }
	}
}
