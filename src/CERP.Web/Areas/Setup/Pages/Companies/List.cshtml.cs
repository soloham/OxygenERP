using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CERP.App;
using CERP.AppServices.HR.EmployeeService;
using CERP.HR.EMPLOYEE.RougeDTOs;
using CERP.HR.Employees.DTOs;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.OpenApi.Extensions;
using Syncfusion.EJ2.Grids;
using Volo.Abp.AuditLogging;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Json;

namespace CERP.Web.Areas.Setup.Pages.Companies
{
    public class ListModel : CERPPageModel
    {
        public IRepository<DictionaryValue> DictionaryValuesRepo { get; set; }
        public ListModel(IJsonSerializer jsonSerializer, IRepository<DictionaryValue> dictionaryValuesRepo)
        {
            JsonSerializer = jsonSerializer;
            DictionaryValuesRepo = dictionaryValuesRepo;
        }

        public IJsonSerializer JsonSerializer { get; set; }

        public void OnGet()
        {

        }
    }
}
