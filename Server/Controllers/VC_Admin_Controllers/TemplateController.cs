
using CustomerRelationshipManagement.Server.Repo.Interfaces;
using CustomerRelationshipManagement.Shared;
using CustomerRelationshipManagement.Shared.Dto;
using CustomerRelationshipManagement.Shared.Models;
using CustomerRelationshipManagement.Shared.Models.AccountConfig;
using CustomerRelationshipManagement.Shared.Models.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerRelationshipManagement.Server.Controllers.VC_Admin_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : Controller
    {
        public IAdminAppRepository _adminContext { get; set; }
        public TemplateController(IAdminAppRepository administrationContext)
        {
            _adminContext = administrationContext;
        }

        [HttpGet]
        public string Get()
        {
            return "TemplateControllerConnected";
        }



        // POST: Template/APA
        [HttpPost("APA")]
        public async Task<bool> AddProjectAccount(ProjectAccount ProjectAccount)
        {
            return await _adminContext.AddProjectAccount(ProjectAccount);
        }

        // POST: Template/EPA
        [HttpPost("EPA")]
        public async Task<bool> EditProjectAccount(ProjectAccount ProjectAccount)
        {
            return await _adminContext.EditProjectAccount(ProjectAccount);
        }


        // POST: Template/DPA
        [HttpPost("DPA")]
        public async Task<bool> DeleteProjectAccount(DataIdDTO dataIdDTO)
        {
            return await _adminContext.DeleteProjectAccount(dataIdDTO.Id);
        }

        // GET: Template/GPA
        [HttpGet("GPA")]
        public async Task<List<ProjectAccount>> GetProjectAccounts()
        {
            return await _adminContext.GetProjectAccounts();
        }

        // POST: Template/AS
        [HttpPost("AS")]
        public async Task<bool> AddSegment(Segment segment)
        {
            return await _adminContext.AddSegment(segment);
        }

        // POST: Template/ES
        [HttpPost("ES")]
        public async Task<bool> EditSegment(Segment segment)
        {
            return await _adminContext.EditSegment(segment);
        }


        // POST: Template/DS
        [HttpPost("DS")]
        public async Task<bool> DeleteSegment(DataIdDTO dataIdDTO)
        {
            return await _adminContext.DeleteSegment(dataIdDTO.Id);
        }

        // GET: Template/GS
        [HttpGet("GS")]
        public async Task<List<Segment>> GetSegments()
        {
            return await _adminContext.GetSegments();
        }

        // POST: Template/AS
        [HttpPost("AD")]
        public async Task<bool> AddDivision(Division division)
        {
            return await _adminContext.AddDivision(division);
        }

        // POST: Template/ED
        [HttpPost("ED")]
        public async Task<bool> EditDivision(Division division)
        {
            return await _adminContext.EditDivision(division);
        }

        // POST: Template/DD
        [HttpPost("DD")]
        public async Task<bool> DeleteDivision(DataIdDTO dataIdDTO)
        {
            return await _adminContext.DeleteDivision(dataIdDTO.Id);
        }

        // GET: Template/GD
        [HttpGet("GD")]
        public async Task<List<Division>> GetDivisions()
        {
            return await _adminContext.GetDivisions();
        }


        // POST: Template/AL
        [HttpPost("AL")]
        public async Task<bool> AddLocation(Location location)
        {
            return await _adminContext.AddLocation(location);
        }

        // POST: Template/EL
        [HttpPost("EL")]
        public async Task<bool> EditLocation(Location location)
        {
            return await _adminContext.EditLocation(location);
        }


        // POST: Template/DL
        [HttpPost("DL")]
        public async Task<bool> DeleteLocation(DataIdDTO dataIdDTO)
        {
            return await _adminContext.DeleteLocation(dataIdDTO.Id);
        }

        // GET: Template/GL
        [HttpGet("GL")]
        public async Task<List<Location>> GetLocations()
        {
            return await _adminContext.GetLocations();
        }






    }
}