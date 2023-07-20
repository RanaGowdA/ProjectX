using CustomerRelationshipManagement.Data.Models;
using CustomerRelationshipManagement.Shared.Dto;
using CustomerRelationshipManagement.Shared.Models;
using CustomerRelationshipManagement.Shared.Models.AccountConfig;
using CustomerRelationshipManagement.Shared.Models.Implementation;
using CustomerRelationshipManagement.Shared.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerRelationshipManagement.Server.Repo.Interfaces
{
    public interface IAdminAppRepository
    {
        // All Data  
        public Task<List<ProjectAccount>> GetProjectAccounts();
        public Task<List<Division>> GetDivisions();
        public Task<List<Segment>> GetSegments();
        public Task<List<Location>> GetLocations();
        public Task<List<Function>> GetFunctions();


        // Add  
        public Task<bool> AddProjectAccount(ProjectAccount projectAccount);
        public Task<bool> AddDivision(Division division);
        public Task<bool> AddSegment(Segment segment);
        public Task<bool> AddLocation(Location location);


        // Edit   
        public Task<bool> EditProjectAccount(ProjectAccount projectAccount);
        public Task<bool> EditDivision(Division division);
        public Task<bool> EditSegment(Segment segment);
        public Task<bool> EditLocation(Location location);

        // Delete  
        public Task<bool> DeleteProjectAccount(int id);
        public Task<bool> DeleteDivision(int id);
        public Task<bool> DeleteSegment(int id);
        public Task<bool> DeleteLocation(int id);



    }
}
