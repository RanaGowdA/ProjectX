

using CustomerRelationshipManagement.Shared.Models;
using CustomerRelationshipManagement.Shared.Models.Implementation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CustomerRelationshipManagement.Shared
{
    public class Lead : ILead
    { 
        public int LeadId { get; set; }
        // IsLeadCreatedFromOpportunity
        public bool IsLCFO { get; set; }
        // IsLeadCreatedFromLead
        public bool IsLCFL { get; set; }
        // IsLeadCreatedFromProject
        public bool IsLCFP { get; set; }
        public string Description { get; set; }
        public string TagList { get; set; }
        public LeadStatus LeadStatus { get; set; }
        public VisibiltyType Visiblity { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public LeadSource LeadSource { get; set; }
        public SalesType SalesType { get; set; }
        public int ForecastedValue { get; set; }
        public Currency ForecastedValueCurrency { get; set; }
        public int CreatedById { get; set; } 
        public SalesTypeNature SalesTypeNature { get; set; }


        public string BusinessType { get; set; }
        public string Offering { get; set; }
        public string ServiceLines { get; set; }
        public int OpportunityId { get; set; }
        public Opportunity Opportunity { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public Lead()
        {
            Description = string.Empty;
            TagList = string.Empty;
            Visiblity = 0;
            BusinessType = string.Empty;
            Offering = string.Empty;
            ServiceLines = string.Empty; 
        }
    }
}
