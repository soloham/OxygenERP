using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CERP.App;
using CERP.AppServices.HR.EmployeeService;
using CERP.AppServices.Setup.CompanySetup;
using CERP.FM.DTOs;
using CERP.Setup;
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
        public CompanyAppService CompanyAppService { get; set; }
        public ListModel(IJsonSerializer jsonSerializer, IRepository<DictionaryValue> dictionaryValuesRepo, CompanyAppService companyAppService)
        {
            JsonSerializer = jsonSerializer;
            DictionaryValuesRepo = dictionaryValuesRepo;
            CompanyAppService = companyAppService;
        }

        public IJsonSerializer JsonSerializer { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostCompany()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Company_Dto company = JsonSerializer.Deserialize<Company_Dto>(Request.Form["info"]);
                    //List<CompanyLocation_Dto> addresses = JsonSerializer.Deserialize<List<CompanyLocation_Dto>>(Request.Form["locations"]);
                    //company.SetProperty("addresses", addresses);

                    bool IsEditing = company.Id != Guid.Empty;
                    if (IsEditing)
                    {
                        Company curCompany = await CompanyAppService.Repository.GetAsync(company.Id);
                        curCompany.CompanyName = company.CompanyName;
                        curCompany.CompanyNameLocalized = company.CompanyNameLocalized;
                        curCompany.CompanyCode = company.CompanyCode;
                        curCompany.Status = company.Status;
                        curCompany.TaxID = company.TaxID;
                        curCompany.SocialInsuranceID = company.SocialInsuranceID;
                        curCompany.VATID = company.VATID;
                        curCompany.RegistrationID = company.RegistrationID;
                        curCompany.LabourOfficeId = company.LabourOfficeId;
                        curCompany.Language = company.Language;

                        CompanyLocation_Dto[] compLocs = company.CompanyLocations.ToArray();
                        Guid[] curCompLocsIds = curCompany.CompanyLocations.Select(x => x.Location.Id).ToArray();
                        for (int i = 0; i < compLocs.Length; i++)
                        {
                            if (!curCompLocsIds.Contains(compLocs[i].Location.Id))
                            {
                                curCompany.CompanyLocations.Add(new CompanyLocation() { Name = compLocs[i].Name, LocationValidityStart = compLocs[i].LocationValidityStart, LocationValidityEnd = compLocs[i].LocationValidityEnd, LocationId = compLocs[i].Location.Id });
                            }
                        }
                        List<Guid> toDeleteLocs = new List<Guid>();
                        for (int i = 0; i < curCompLocsIds.Length; i++)
                        {
                            if (!compLocs.Any(x => x.LocationId == curCompLocsIds[i]))
                            {
                                curCompany.CompanyLocations.Remove(curCompany.CompanyLocations.First(x => x.Location.Id == curCompLocsIds[i]));
                                toDeleteLocs.Add(curCompLocsIds[i]);
                            }
                        }
                        
                        CompanyCurrency_Dto[] compCurrencies = company.CompanyCurrencies.ToArray();
                        int[] curCompCurrenciesIds = curCompany.CompanyCurrencies.Select(x => x.Currency.Id).ToArray();
                        for (int i = 0; i < compCurrencies.Length; i++)
                        {
                            if (!curCompCurrenciesIds.Contains(compCurrencies[i].Currency.Id))
                            {
                                curCompany.CompanyCurrencies.Add(new CompanyCurrency() { ExchangeRate = compCurrencies[i].ExchangeRate,  CurrencyId = compCurrencies[i].Currency.Id });
                            }
                        }
                        List<int> toDeleteCurrencies = new List<int>();
                        for (int i = 0; i < curCompCurrenciesIds.Length; i++)
                        {
                            if (!compCurrencies.Any(x => x.Currency.Id == curCompCurrenciesIds[i]))
                            {
                                curCompany.CompanyCurrencies.Remove(curCompany.CompanyCurrencies.First(x => x.CurrencyId == curCompCurrenciesIds[i]));
                                toDeleteCurrencies.Add(curCompCurrenciesIds[i]);
                            }
                        }

                        CompanyPrintSize_Dto[] compPrintSizes = company.CompanyPrintSizes.ToArray();
                        int[] curCompPrintSizesIds = curCompany.CompanyPrintSizes.Select(x => x.Id).ToArray();
                        for (int i = 0; i < compPrintSizes.Length; i++)
                        {
                            if (!curCompPrintSizesIds.Contains(compPrintSizes[i].Id))
                            {
                                curCompany.CompanyPrintSizes.Add(new CompanyPrintSize() { PrintSize = compPrintSizes[i].PrintSize });
                            }
                        }
                        List<int> toDeletePrintSizes = new List<int>();
                        for (int i = 0; i < curCompPrintSizesIds.Length; i++)
                        {
                            if (!compPrintSizes.Any(x => x.Id == curCompPrintSizesIds[i]))
                            {
                                curCompany.CompanyPrintSizes.Remove(curCompany.CompanyPrintSizes.First(x => x.Id == curCompPrintSizesIds[i]));
                                toDeletePrintSizes.Add(curCompPrintSizesIds[i]);
                            }
                        }


                        for (int i = 0; i < toDeletePrintSizes.Count; i++)
                        {
                            await CompanyAppService.PrintSizesRepository.DeleteAsync(x => x.Id == toDeletePrintSizes[i]);
                        }
                        for (int i = 0; i < toDeleteLocs.Count; i++)
                        {
                            await CompanyAppService.LocationsRepository.DeleteAsync(x => x.LocationId == toDeleteLocs[i]);
                        }
                        for (int i = 0; i < toDeleteCurrencies.Count; i++)
                        {
                            await CompanyAppService.CurrenciesRepository.DeleteAsync(x => x.CurrencyId == toDeleteCurrencies[i]);
                        }

                        Company_Dto updated = ObjectMapper.Map<Company, Company_Dto>(await CompanyAppService.Repository.UpdateAsync(curCompany));

                        return StatusCode(200, updated);
                    }
                    else
                    {
                        company.Id = Guid.Empty;
                        company.CompanyCurrencies.ForEach(x => { x.Id = 0; x.CurrencyId = x.Currency.Id; x.Currency = null; });
                        company.CompanyLocations.ForEach(x => { x.Id = 0; x.LocationId = x.Location.Id; x.Location = null; });
                        company.CompanyPrintSizes.ForEach(x => { x.Id = 0; });

                        Company_Dto added = await CompanyAppService.CreateAsync(company);

                        return StatusCode(200, added);
                    }
                }
                catch(Exception ex)
                {
                    
                }
            }

            return StatusCode(500);
        }

        public async Task<IActionResult> OnDeleteCompany()
        {
            List<Company_Dto> companies = JsonSerializer.Deserialize<List<Company_Dto>>(Request.Form["companies"]);
            try
            {
                for (int i = 0; i < companies.Count; i++)
                {
                    Company_Dto company = companies[i];
                    //await TaskTemplatesAppService.Repository.DeleteAsync(leaveRequest.);
                    await CompanyAppService.Repository.DeleteAsync(company.Id);
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
