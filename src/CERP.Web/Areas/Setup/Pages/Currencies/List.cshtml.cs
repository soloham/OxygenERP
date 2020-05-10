using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CERP.App;
using CERP.AppServices.HR.EmployeeService;
using CERP.AppServices.Setup.CurrencySetup;
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

namespace CERP.Web.Areas.Setup.Pages.Currencies
{
    public class ListModel : CERPPageModel
    {
        public IRepository<DictionaryValue> DictionaryValuesRepo { get; set; }
        public CurrencyAppService CurrencyAppService { get; set; }
        public ListModel(IJsonSerializer jsonSerializer, CurrencyAppService currencyAppService, IRepository<DictionaryValue> dictionaryValuesRepo)
        {
            JsonSerializer = jsonSerializer;
            CurrencyAppService = currencyAppService;
            DictionaryValuesRepo = dictionaryValuesRepo;
        }

        public IJsonSerializer JsonSerializer { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostCurrency()
        {
            if (ModelState.IsValid)
            {
                Currency_Dto currency = JsonSerializer.Deserialize<Currency_Dto>(Request.Form["info"]);

                bool IsEditing = currency.Id != -1;
                if (IsEditing)
                {
                    Currency curCurrency = await CurrencyAppService.Repository.GetAsync(currency.Id);
                    curCurrency.CurrencyName = currency.CurrencyName;
                    curCurrency.CurrencyNameLocal = currency.CurrencyNameLocal;
                    curCurrency.CurrencyCode = currency.CurrencyCode;
                    curCurrency.Status = currency.Status;

                    Currency_Dto updated = ObjectMapper.Map<Currency, Currency_Dto>(await CurrencyAppService.Repository.UpdateAsync(curCurrency));

                    return StatusCode(200, updated);
                }
                else
                {
                    currency.Id = 0;
                    Currency_Dto added = await CurrencyAppService.CreateAsync(currency);

                    return StatusCode(200, added);
                }
            }

            return StatusCode(500);
        }

        public async Task<IActionResult> OnDeleteCurrency()
        {
            List<Currency_Dto> currencies = JsonSerializer.Deserialize<List<Currency_Dto>>(Request.Form["currencies"]);
            try
            {
                for (int i = 0; i < currencies.Count; i++)
                {
                    Currency_Dto currency = currencies[i];
                    await CurrencyAppService.DeleteAsync(currency.Id);
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
