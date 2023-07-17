 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CustomerRelationshipManagement.Shared;
using CustomerRelationshipManagement.Shared.Models.Implementation;

namespace CustomerRelationshipManagement.Shared
{
    public interface ILead
    {
        [Key]
        public int LeadId { get; set; } 

        [Column(TypeName = "nvarchar(50)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(50)")]
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


        [ForeignKey("OpportunityId")]
        public int OpportunityId { get; set; }
        public Opportunity Opportunity { get; set; }

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public Account Account { get; set; }


        public string BusinessType { get; set; }
        public string Offering { get; set; }
        public string ServiceLines { get; set; }



    }
}
