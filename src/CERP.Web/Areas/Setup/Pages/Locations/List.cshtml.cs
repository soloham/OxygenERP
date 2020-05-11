using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CERP.App;
using CERP.AppServices.HR.EmployeeService;
using CERP.AppServices.Setup.LocationSetup;
using CERP.HR.EMPLOYEE.RougeDTOs;
using CERP.HR.Employees.DTOs;
using CERP.Setup;
using CERP.Setup.DTOs;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.OpenApi.Extensions;
using Syncfusion.EJ2.Grids;
using Volo.Abp.AuditLogging;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Json;

namespace CERP.Web.Areas.Setup.Pages.Locations
{
    public class ListModel : CERPPageModel
    {
        public IRepository<DictionaryValue> DictionaryValuesRepo { get; set; }
        public LocationTemplateAppService LocationTemplateAppService { get; set; }
        public ListModel(IJsonSerializer jsonSerializer, LocationTemplateAppService locationAppService, IRepository<DictionaryValue> dictionaryValuesRepo)
        {
            JsonSerializer = jsonSerializer;
            LocationTemplateAppService = locationAppService;
            DictionaryValuesRepo = dictionaryValuesRepo;
        }

        public IJsonSerializer JsonSerializer { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostLocationTemplate()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LocationTemplate_Dto location = JsonSerializer.Deserialize<LocationTemplate_Dto>(Request.Form["info"]);
                    LocationAddress address = JsonSerializer.Deserialize<LocationAddress>(Request.Form["address"]);
                    location.SetProperty("address", address);

                    bool IsEditing = location.Id != Guid.Empty;
                    if (IsEditing)
                    {
                        LocationTemplate curLocation = await LocationTemplateAppService.Repository.GetAsync(location.Id);
                        curLocation.LocationName = location.LocationName;
                        curLocation.LocationNameLocalized = location.LocationNameLocalized;
                        curLocation.LocationCode = location.LocationCode;
                        curLocation.Status = location.Status;
                        curLocation.LocationCountryId = location.LocationCountryId;
                        curLocation.LocationEmail = location.LocationEmail;
                        curLocation.LocationFax = location.LocationFax;
                        curLocation.LocationMobile = location.LocationMobile;
                        curLocation.LocationPhone = location.LocationPhone;

                        curLocation.LocationCountry = null;
                        curLocation.UpdateExtraProperties(location.ExtraProperties);

                        LocationTemplate_Dto updated = ObjectMapper.Map<LocationTemplate, LocationTemplate_Dto>(await LocationTemplateAppService.Repository.UpdateAsync(curLocation));
                        updated.LocationCountry = ObjectMapper.Map<DictionaryValue, DictionaryValue_Dto>(await DictionaryValuesRepo.GetAsync(x => x.Id == updated.LocationCountryId));

                        return StatusCode(200, updated);
                    }
                    else
                    {
                        location.Id = Guid.Empty;

                        LocationTemplate_Dto added = await LocationTemplateAppService.CreateAsync(location);
                        added.LocationCountry = ObjectMapper.Map<DictionaryValue, DictionaryValue_Dto>(await DictionaryValuesRepo.GetAsync(x => x.Id == added.LocationCountryId));
                        return StatusCode(200, added);
                    }
                }
            }
            catch(Exception ex)
            { 

            }
            return StatusCode(500);
        }

        public async Task<IActionResult> OnDeleteLocation()
        {
            List<LocationTemplate_Dto> locations = JsonSerializer.Deserialize<List<LocationTemplate_Dto>>(Request.Form["locations"]);
            try
            {
                for (int i = 0; i < locations.Count; i++)
                {
                    LocationTemplate_Dto location = locations[i];
                    await LocationTemplateAppService.DeleteAsync(location.Id);
                }
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
