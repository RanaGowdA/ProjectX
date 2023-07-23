
using CustomerRelationshipManagement.Client.Pages.UserConfig.AccountConfig;
using CustomerRelationshipManagement.Data;
using CustomerRelationshipManagement.Server.Repo.Interfaces;
using CustomerRelationshipManagement.Shared.Models.AccountConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CustomerRelationshipManagement.Server.Repo.RepoImplementation
{
    public class AdminAppRepo : IAdminAppRepository
    {
        private readonly AdminDbContext _context;

        public AdminAppRepo(AdminDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCompetency(Competency competency)
        {
            await _context.Competencies.AddAsync(competency);
            var projectAccount = await _context.ProjectAccounts.FirstOrDefaultAsync(pa => pa.Id == competency.ProjectAccountId);
            _ = _context.ProjectAccounts.Attach(projectAccount);

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> AddDivision(Division division)
        {
            await _context.Divisions.AddAsync(division);
            var segment = await _context.Segments.FirstOrDefaultAsync(s => s.Id == division.SegmentId);
            var projectAccount = await _context.ProjectAccounts.FirstOrDefaultAsync(pa => pa.Id == segment.ProjectAccountId);
            _ = _context.Segments.Attach(segment);
            _ = _context.ProjectAccounts.Attach(projectAccount);

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> AddEngagement(Engagement engagement)
        {
            await _context.EngagementModels.AddAsync(engagement);
            var projectAccount = await _context.ProjectAccounts.FirstOrDefaultAsync(pa => pa.Id == engagement.ProjectAccountId);
            _ = _context.ProjectAccounts.Attach(projectAccount);

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> AddFunction(AccountFunction function)
        {
            await _context.Functions.AddAsync(function);
            var projectAccount = await _context.ProjectAccounts.FirstOrDefaultAsync(pa => pa.Id == function.ProjectAccountId);
            _ = _context.ProjectAccounts.Attach(projectAccount);

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> AddLocation(Location location)
        {
            await _context.Locations.AddAsync(location);
            var projectAccount = await _context.ProjectAccounts.FirstOrDefaultAsync(pa => pa.Id == location.Segment.ProjectAccountId);
            _ = _context.ProjectAccounts.Attach(projectAccount);

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> AddProjectAccount(ProjectAccount projectAccount)
        {
            await _context.ProjectAccounts.AddAsync(projectAccount);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> AddSegment(Segment segment)
        {
            await _context.Segments.AddAsync(segment);
            var projectAccount = await _context.ProjectAccounts.FirstOrDefaultAsync(pa => pa.Id == segment.ProjectAccountId);
            _ = _context.ProjectAccounts.Attach(projectAccount);

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteCompetency(int id)
        {
            var savedCompetenciesAccount = await _context.Competencies.Where(s => s.Id == id).FirstOrDefaultAsync();
            if (savedCompetenciesAccount != null)
            {
                try
                {
                    _context.Competencies.Remove(savedCompetenciesAccount);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return false;
        }

        public async Task<bool> DeleteDivision(int id)
        {
            var savedProjectAccount = await _context.Divisions.Where(s => s.Id == id).FirstOrDefaultAsync();
            if (savedProjectAccount != null)
            {
                try
                {
                    _context.Divisions.Remove(savedProjectAccount);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return false;
        }

        public async Task<bool> DeleteEngagement(int id)
        {
            var savedEngagementAccount = await _context.EngagementModels.Where(s => s.Id == id).FirstOrDefaultAsync();
            if (savedEngagementAccount != null)
            {
                try
                {
                    _context.EngagementModels.Remove(savedEngagementAccount);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return false;
        }

        public async Task<bool> DeleteFunction(int id)
        {
            var savedFunctionAccount = await _context.Functions.Where(s => s.Id == id).FirstOrDefaultAsync();
            if (savedFunctionAccount != null)
            {
                try
                {
                    _context.Functions.Remove(savedFunctionAccount);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return false;
        }

        public async Task<bool> DeleteLocation(int id)
        {
            var savedProjectAccount = await _context.Locations.Where(s => s.Id == id).FirstOrDefaultAsync();
            if (savedProjectAccount != null)
            {
                try
                {
                    _context.Locations.Remove(savedProjectAccount);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return false;
        }

        public async Task<bool> DeleteProjectAccount(int ProjectAccountId)
        {
            var savedProjectAccount = await _context.ProjectAccounts.Where(s => s.Id == ProjectAccountId).FirstOrDefaultAsync();
            if (savedProjectAccount != null)
            {
                try
                {
                    _context.ProjectAccounts.Remove(savedProjectAccount);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return false;
        }

        public async Task<bool> DeleteSegment(int id)
        {
            var savedProjectAccount = await _context.Segments.Where(s => s.Id == id).FirstOrDefaultAsync();
            if (savedProjectAccount != null)
            {
                try
                {
                    _context.Segments.Remove(savedProjectAccount);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return false;
        }

        public async Task<bool> EditCompetency(Competency competency)
        {
            var savedCompetencyAccount = await _context.Competencies.Where(s => s.Id == competency.Id).FirstOrDefaultAsync();
            if (savedCompetencyAccount != null)
            {
                try
                {
                    _context.Entry(savedCompetencyAccount).CurrentValues.SetValues(competency);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return false;
        }

        public async Task<bool> EditDivision(Division division)
        {
            var savedProjectAccount = await _context.Divisions.Where(s => s.Id == division.Id).FirstOrDefaultAsync();
            if (savedProjectAccount != null)
            {
                try
                {
                    _context.Entry(savedProjectAccount).CurrentValues.SetValues(division);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return false;
        }

        public async Task<bool> EditEngagement(Engagement engagement)
        {
            var savedEngagementAccount = await _context.EngagementModels.Where(s => s.Id == engagement.Id).FirstOrDefaultAsync();
            if (savedEngagementAccount != null)
            {
                try
                {
                    _context.Entry(savedEngagementAccount).CurrentValues.SetValues(engagement);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return false;
        }

        public async Task<bool> EditFunction(AccountFunction function)
        {
            var savedFunctionAccount = await _context.Functions.Where(s => s.Id == function.Id).FirstOrDefaultAsync();
            if (savedFunctionAccount != null)
            {
                try
                {
                    _context.Entry(savedFunctionAccount).CurrentValues.SetValues(function);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return false;
        }

        public async Task<bool> EditLocation(Location location)
        {
            var savedProjectAccount = await _context.Locations.Where(s => s.Id == location.Id).FirstOrDefaultAsync();
            if (savedProjectAccount != null)
            {
                try
                {
                    _context.Entry(savedProjectAccount).CurrentValues.SetValues(location);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return false;
        }

        public async Task<bool> EditProjectAccount(ProjectAccount projectAccount)
        {
            var savedProjectAccount = await _context.ProjectAccounts.Where(s => s.Id == projectAccount.Id).FirstOrDefaultAsync();
            if (savedProjectAccount != null)
            {
                try
                {
                    _context.Entry(savedProjectAccount).CurrentValues.SetValues(projectAccount);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return false;
        }

        public async Task<bool> EditSegment(Segment segment)
        {

            var savedProjectAccount = await _context.Segments.Where(s => s.Id == segment.Id).FirstOrDefaultAsync();
            if (savedProjectAccount != null)
            {
                try
                {
                    _context.Entry(savedProjectAccount).CurrentValues.SetValues(segment);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return false;
        }

        public async Task<List<Competency>> GetCompetencies()
        {
            var result = await _context.Competencies.Include(x => x.ProjectAccount).ToListAsync();
            return result;
        }

        public async Task<List<Division>> GetDivisions()
        {
            var result = await _context.Divisions.Include(x => x.Segment).ThenInclude(x => x.ProjectAccount).ToListAsync();
            return result;
        }

        public async Task<List<Engagement>> GetEngagements()
        {
            var result = await _context.EngagementModels.Include(x => x.ProjectAccount).ToListAsync();
            return result;
        }

        public async Task<List<AccountFunction>> GetFunctions()
        {
            var result = await _context.Functions.Include(x => x.ProjectAccount).ToListAsync();
            return result;
        }

        public async Task<List<Location>> GetLocations()
        {
            var result = await _context.Locations.Include(x => x.Segment).ToListAsync();
            return result;
        }

        public async Task<List<ProjectAccount>> GetProjectAccounts()
        {
            var result = await _context.ProjectAccounts.ToListAsync();
            return result;
        }

        public async Task<List<Segment>> GetSegments()
        {
            var result = await _context.Segments.Include(x => x.ProjectAccount).ToListAsync();
            return result;
        }
    }
}