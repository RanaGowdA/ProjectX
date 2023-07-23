using CustomerRelationshipManagement.Shared.Models.AccountConfig;

namespace CustomerRelationshipManagement.Server.Repo.Interfaces
{
    public interface IAdminAppRepository
    {
        // All Data  
        public Task<List<ProjectAccount>> GetProjectAccounts();
        public Task<List<Division>> GetDivisions();
        public Task<List<Segment>> GetSegments();
        public Task<List<Location>> GetLocations();
        public Task<List<AccountFunction>> GetFunctions();
        public Task<List<Competency>> GetCompetencies();
        public Task<List<Engagement>> GetEngagements();


        // Add  
        public Task<bool> AddProjectAccount(ProjectAccount projectAccount);
        public Task<bool> AddDivision(Division division);
        public Task<bool> AddSegment(Segment segment);
        public Task<bool> AddLocation(Location location);
        public Task<bool> AddFunction(AccountFunction function);
        public Task<bool> AddCompetency(Competency competency);
        public Task<bool> AddEngagement(Engagement engagement);


        // Edit   
        public Task<bool> EditProjectAccount(ProjectAccount projectAccount);
        public Task<bool> EditDivision(Division division);
        public Task<bool> EditSegment(Segment segment);
        public Task<bool> EditLocation(Location location);
        public Task<bool> EditFunction(AccountFunction function);
        public Task<bool> EditCompetency(Competency competency);
        public Task<bool> EditEngagement(Engagement engagement);

        // Delete  
        public Task<bool> DeleteProjectAccount(int id);
        public Task<bool> DeleteDivision(int id);
        public Task<bool> DeleteSegment(int id);
        public Task<bool> DeleteLocation(int id);
        public Task<bool> DeleteFunction(int id);
        public Task<bool> DeleteCompetency(int id);
        public Task<bool> DeleteEngagement(int id);



    }
}
