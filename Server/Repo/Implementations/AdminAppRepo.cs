//using CustomerRelationshipManagement.Data;
//using CustomerRelationshipManagement.Data.Models;
//using CustomerRelationshipManagement.Server.Repo.Interfaces;
//using CustomerRelationshipManagement.Shared;
//using CustomerRelationshipManagement.Shared.Dto;
//using CustomerRelationshipManagement.Shared.Models;
//using CustomerRelationshipManagement.Shared.Models.Implementation;
//using CustomerRelationshipManagement.Shared.Models.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using static System.Net.WebRequestMethods;

//namespace CustomerRelationshipManagement.Server.Repo.RepoImplementation
//{
//    public class AdminAppRepo : IAdminAppRepository
//    {
//        private readonly AdminDbContext _context;

//        public AdminAppRepo(AdminDbContext context)
//        {
//            _context = context;
//        }

//        public Task<bool> AddEngagementModelEng(EngagementModel engagementModel)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<bool> AddProjectAccount(Account ProjectAccount)
//        {
//            ProjectAccount.CreatedOn = DateTime.UtcNow;
//            await _context.Accounts.AddAsync(ProjectAccount);
//            var result = await _context.SaveChangesAsync();
//            return result > 0;
//        }

//        public async Task<bool> AddTemplateConfiguration(TemplateConfiguration templateConfiguration)
//        {
//            await _context.TemplateConfigurations.AddAsync(templateConfiguration);
//            var result = await _context.SaveChangesAsync();
//            return result > 0;
//        }

//        public Task<bool> DeleteEngagementModel(int EngagementModelId)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<bool> DeleteProjectAccount(int ProjectAccountId)
//        {
//            var savedProjectAccount = await _context.Accounts.Where(s => s.Id == ProjectAccountId).FirstOrDefaultAsync();
//            if (savedProjectAccount != null)
//            {
//                try
//                {
//                    _context.Accounts.Remove(savedProjectAccount);
//                    var result = await _context.SaveChangesAsync();
//                    if (result > 0)
//                    {
//                        return true;
//                    }
//                }
//                catch (Exception e)
//                {
//                    throw;
//                }
//            }
//            return false;
//        }

//        public Task<bool> DeleteTemplateConfigurations(int TemplateConfigurationId)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> EditEngagementModel(DataIdDTO dataIdDTO)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<bool> EditProjectAccount(Account ProjectAccount)
//        {
//            ProjectAccount.ModifiedOn = DateTime.UtcNow;
//            var savedProjectAccount = await _context.Accounts.Where(s => s.Id == ProjectAccount.Id).FirstOrDefaultAsync();
//            if (savedProjectAccount != null)
//            {
//                try
//                {
//                    _context.Entry(savedProjectAccount).CurrentValues.SetValues(ProjectAccount);
//                    var result = await _context.SaveChangesAsync();
//                    if (result > 0)
//                    {
//                        return true;
//                    }
//                }
//                catch (Exception e)
//                {
//                    throw;
//                }
//            }
//            return false;
//        }

//        public Task<bool> EditTemplateConfigurations(TemplateConfiguration templateConfiguration)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<List<Account>> GetAccounts()
//        {
//            return await _context.Accounts.ToListAsync();
//        }

//        public async Task<AppUser> GetAppUserByAxicianIdAsync(string AxcianId)
//        {
//            return await _context.Users.FirstOrDefaultAsync(x => x.UserCode == AxcianId);
//        }

//        public async Task<AppUser> GetAppUserByIdAsync(int id)
//        {
//            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
//        }

//        public async Task<List<EngagementModel>> GetEngagementModels()
//        {
//            return await _context.EngagementModels.ToListAsync();
//        }

//        public async Task<List<TemplateConfiguration>> GetTemplateConfigurations()
//        {
//            return await _context.TemplateConfigurations.ToListAsync();
//        }
//    }
//}