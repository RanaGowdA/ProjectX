using CustomerRelationshipManagement.Shared.Models;
using CustomerRelationshipManagement.Shared.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared.Dto
{
    public class AccountDto 
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [JsonPropertyName("Title")]
        public string Title { get; set; }
        [JsonPropertyName("Organization")]
        public string Organization { get; set; }
        [JsonPropertyName("EmailAddress")]
        public string EmailAddress { get; set; }
        [JsonPropertyName("Phone")]
        public string Phone { get; set; }
        [JsonPropertyName("MobilePhone")]
        public string MobilePhone { get; set; }
        [JsonPropertyName("Fax")]
        public string Fax { get; set; }
        [JsonPropertyName("WebSite")]
        public string WebSite { get; set; }
        [JsonPropertyName("Industry")]
        public string Industry { get; set; }
        [JsonPropertyName("NumberOfEmployees")]
        public int NumberOfEmployees { get; set; }
        [JsonPropertyName("Address1")]
        public string Address1 { get; set; }
        [JsonPropertyName("City")]
        public string City { get; set; }
        [JsonPropertyName("State")]
        public string State { get; set; }
        [JsonPropertyName("PostalCode")]
        public string PostalCode { get; set; }
        [JsonPropertyName("Country")]
        public string Country { get; set; }
        [JsonPropertyName("Geo")]
        public string Geo { get; set; }
        [JsonPropertyName("CreatedById")]
        public int CreatedById { get; set; }
        [JsonPropertyName("ModifiedById")]
        public int ModifiedById { get; set; }
         
    }
}
