using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CERP.App;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Syncfusion.EJ2.Grids;
using Volo.Abp.AuditLogging;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Volo.Abp.Auditing;
using CERP.CERP.HR.Documents;
using CERP.App.CustomEntityHistorySystem;
using CERP.Attributes;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.AppServices.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using CERP.App.Helpers;
using Volo.Abp.Users;
using Volo.Abp.Identity;

namespace CERP.Web.Areas.HR.Setup.UsersManagement.Pages.Users
{
    public class ListModel : CERPPageModel
    {
        public IWebHostEnvironment webHostEnvironment { get; set; }
        public IRepository<DictionaryValue, Guid> DictionaryValuesRepo { get; set; }
        public IAuditLogRepository AuditLogsRepo { get; set; }

        public IIdentityUserAppService IdentityUserAppService { get; set; }

        public IAuditingManager AuditingManager { get; set; }
        public IRepository<CustomEntityChange> CustomEntityChangesRepo { get; set; }

        public ListModel(IJsonSerializer jsonSerializer, IRepository<DictionaryValue, Guid> dictionaryValuesRepo, IWebHostEnvironment webHostEnvironment, IAuditLogRepository auditLogsRepo, IIdentityUserAppService identityUserAppService)
        {
            JsonSerializer = jsonSerializer;
            DictionaryValuesRepo = dictionaryValuesRepo;
            this.webHostEnvironment = webHostEnvironment;
            AuditLogsRepo = auditLogsRepo;
            IdentityUserAppService = identityUserAppService;
        }

        public IJsonSerializer JsonSerializer { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostPositionTemplate()
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    return StatusCode(200);
                }
                catch(Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }

            return StatusCode(500);
        }
        public async Task<IActionResult> OnDeletePositionTemplate()
        {
           return StatusCode(200);
        }
    }
}
