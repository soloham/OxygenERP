using CERP.App;
using CERP.App.Helpers;
using CERP.AppServices.Payroll.PayrunService;
using CERP.HR.EMPLOYEE.RougeDTOs;
using CERP.Payroll.DTOs;
using CERP.Payroll.Payrun;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Grids;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Json;
using CERP.Web.BusinessLogic.ViewModels.Payroll.PaymentSheet;

namespace CERP.Web.Areas.Payroll.Pages.PayrunPage
{
    public class PaymentSheetModel : CERPPageModel
    {
        [BindProperty(SupportsGet = true)]
        public int? payrunId { get; set; }

        public IJsonSerializer JsonSerializer { get; set; }
        public PayrunAppService PayrunAppService { get; set; }

        public IRepository<DictionaryValue, Guid> DicValuesRepo { get; set; }


        public PaymentSheetModel(IJsonSerializer jsonSerializer, PayrunAppService payrunAppService, IRepository<DictionaryValue, Guid> dicValuesRepo)
        {
            JsonSerializer = jsonSerializer;
            PayrunAppService = payrunAppService;
            DicValuesRepo = dicValuesRepo;
        }

        public async Task<IActionResult> OnPostPaymentSheet(int id)
        {
            try
            {
                Payrun payrun = PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Id == id);
                if (payrun != null && payrun.IsPosted)
                {
                    payrun.IsPSPosted = true;
                    await PayrunAppService.Repository.UpdateAsync(payrun);
                }
                else
                    return StatusCode(500);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        public Payrun_Dto payrun { get; set; }
        public List<dynamic> dynamicDS = new List<dynamic>();
        public string dynamicDSS;
        public async Task<IActionResult> OnGet()
        {
            payrun = await PayrunAppService.GetAsync(payrunId.Value);
            if (payrun != null)
            {
                List<PayrunDetail_Dto> payrunDetails = payrun.PayrunDetails.ToList();

                for (int i = 0; i < payrunDetails.Count; i++)
                {
                    PayrunDetail_Dto curDetail = payrunDetails[i];
                    dynamic paymentSlipDSRow = PayrollService.GetPaymentSheet(curDetail, JsonSerializer);
                    paymentSlipDSRow.isPosted = payrun.IsPSPosted;

                    dynamicDS.Add(paymentSlipDSRow);
                    dynamicDSS = JsonSerializer.Serialize(dynamicDS);
                }
            }
            return Page();
        }
    }
}
