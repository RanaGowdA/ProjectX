using CustomerRelationshipManagement.Data.Models;
using CustomerRelationshipManagement.Shared.Dto;
using CustomerRelationshipManagement.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerRelationshipManagement.Server.Repo.Interfaces
{
    public interface IAdminAppRepository
    {
         // All Data
        public Task<List<EngagementModel>> GetEngagementModels();
        public Task<List<TemplateConfiguration>> GetTemplateConfigurations();

        // Add 
        public Task<bool> AddEngagementModelEng(EngagementModel engagementModel);
        public Task<bool> AddTemplateConfiguration(TemplateConfiguration templateConfiguration);
        // Edit 
        public Task<bool> EditEngagementModel(DataIdDTO dataIdDTO);
        public Task<bool> EditTemplateConfigurations(TemplateConfiguration templateConfiguration);
        // Delete
        public Task<bool> DeleteEngagementModel(DataIdDTO dataIdDTO);
        public Task<bool> DeleteTemplateConfigurations(TemplateConfiguration templateConfiguration);


        DbSet<AppUser> GetUsersDbSet();


        Task<AppUser> GetAppUserByAxicianIdAsync(string AxcianId);
        Task<AppUser> GetAppUserByIdAsync(int id);

    }
}
