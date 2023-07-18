﻿
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
            //Account account = new Account();
            //account.Address = ProjectAccount.Address1;
            //account.State = ProjectAccount.State;
            //account.WebSite = ProjectAccount.WebSite;
            //account.Organization = ProjectAccount.Organization;
            //account.Title = ProjectAccount.Title;
            //account.Phone = ProjectAccount.Phone;
            //account.MobilePhone = ProjectAccount.MobilePhone;
            //account.Fax = ProjectAccount.Fax;
            //account.NumberOfEmployees = ProjectAccount.NumberOfEmployees;
            //account.PostalCode = ProjectAccount.PostalCode;
            //account.City = ProjectAccount.City;
            //account.Country = ProjectAccount.Country;
            //account.Geo = Geo.EUROPE;
            //account.EmailAddress = ProjectAccount.EmailAddress;
            //account.Name = ProjectAccount.Name;
            //account.LastName = ProjectAccount.LastName;
            //account.CreatedById = ProjectAccount.CreatedById;
            //account.Industry = ProjectAccount.Industry;
            //account.ModifiedById = ProjectAccount.ModifiedById;
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