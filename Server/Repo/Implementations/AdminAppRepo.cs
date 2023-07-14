using CustomerRelationshipManagement.Data;
using CustomerRelationshipManagement.Data.Models;
using CustomerRelationshipManagement.Server.Repo.Interfaces;
using CustomerRelationshipManagement.Shared.Dto;
using CustomerRelationshipManagement.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerRelationshipManagement.Server.Repo.RepoImplementation
{
    public class AdminAppRepo : IAdminAppRepository
    {
        private readonly AdminDbContext _context;

        public AdminAppRepo(AdminDbContext context)
        {
            _context = context;
        }

        public Task<bool> AddEngagementModelEng(EngagementModel engagementModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddTemplateConfiguration(TemplateConfiguration templateConfiguration)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEngagementModel(DataIdDTO dataIdDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTemplateConfigurations(TemplateConfiguration templateConfiguration)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditEngagementModel(DataIdDTO dataIdDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditTemplateConfigurations(TemplateConfiguration templateConfiguration)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> GetAppUserByAxicianIdAsync(string AxcianId)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.AXCIANId == AxcianId);
        }

        public async Task<AppUser> GetAppUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<EngagementModel>> GetEngagementModels()
        {
            return await _context.EngagementModels.ToListAsync();
        }

        public async Task<List<TemplateConfiguration>> GetTemplateConfigurations()
        {
            return await _context.TemplateConfigurations.ToListAsync();
        }

        public DbSet<AppUser> GetUsersDbSet()
        {
            return _context.Users;
        }
    }
}