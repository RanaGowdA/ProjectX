using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared
{
    public class AuthDto
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
