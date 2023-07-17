using CustomerRelationshipManagement.Data.Models;
using CustomerRelationshipManagement.Shared.Dto;
using CustomerRelationshipManagement.Shared.Models;
using CustomerRelationshipManagement.Shared.Models.Implementation;
using Microsoft.EntityFrameworkCore;

namespace CustomerRelationshipManagement.Server.Repo.Interfaces
{
    public interface IAdminAppRepository
    {
         // All Data
        public Task<List<EngagementModel>> GetEngagementModels();
        public Task<List<TemplateConfiguration>> GetTemplateConfigurations();
        public Task<List<Account>> GetAccounts();

        // Add 
        public Task<bool> AddEngagementModelEng(EngagementModel engagementModel);
        public Task<bool> AddTemplateConfiguration(TemplateConfiguration templateConfiguration);
        public Task<bool> AddProjectAccount(Account ProjectAccount);
        // Edit 
        public Task<bool> EditEngagementModel(DataIdDTO dataIdDTO);
        public Task<bool> EditTemplateConfigurations(TemplateConfiguration templateConfiguration);
        public Task<bool> EditProjectAccount(Account ProjectAccount);
        // Delete
        public Task<bool> DeleteEngagementModel(int EngagementModelId);
        public Task<bool> DeleteTemplateConfigurations(int TemplateConfigurationId);
        public Task<bool> DeleteProjectAccount(int ProjectAccountId);



    }
}
