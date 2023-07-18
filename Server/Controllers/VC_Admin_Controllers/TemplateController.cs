
using CustomerRelationshipManagement.Server.Repo.Interfaces;
using CustomerRelationshipManagement.Shared;
using CustomerRelationshipManagement.Shared.Dto;
using CustomerRelationshipManagement.Shared.Models;
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

        // POST: Template/addEM
        [HttpPost("addEM")]
        public async Task<bool> CreateNewEngagementModel(EngagementModel engagementModel)
        {
            return await _adminContext.AddEngagementModelEng(engagementModel);
        }


        // POST: Template/addTC
        [HttpPost("addTC")]
        public async Task<bool> CreateNewTemplateConfig(TemplateConfiguration Tc)
        {
            return await _adminContext.AddTemplateConfiguration(Tc);
        }

        // GET: Template/allEM
        [HttpGet("allEM")]
        public async Task<List<EngagementModel>> GetAllEngagementModelEng()
        {
            return await _adminContext.GetEngagementModels();
        }

        // GET: Template/allTmpConfig
        [HttpGet("allTmpConfig")]
        public async Task<List<TemplateConfiguration>> GetAllTemplateConfiguration()
        {
            return await _adminContext.GetTemplateConfigurations();
        }


        // POST: Template/AddPAccount
        [HttpPost("AddPAccount")]
        public async Task<bool> CreateNewAddAccount(Account ProjectAccount)
        {
            return await _adminContext.AddProjectAccount(ProjectAccount);
        }




        // POST: Template/AddPAccount
        [HttpPost("EditPAccount")]
        public async Task<bool> CreateEditAccount(Account ProjectAccount)
        {
            return await _adminContext.EditProjectAccount(ProjectAccount);
        }


        // POST: Template/AddPAccount
        [HttpPost("deletePAccount")]
        public async Task<bool> CreateDeleteAccount(DataIdDTO ProjectAccountIdDto)
        {
            return await _adminContext.DeleteProjectAccount(ProjectAccountIdDto.Id);
        }


        // GET: Template/allTmpConfig
        [HttpGet("allAccounts")]
        public async Task<List<Account>> GetAllAccounts()
        {
            return await _adminContext.GetAccounts();
        }

    }
}