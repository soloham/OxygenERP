using CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure;
using CERP.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using Volo.Abp.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CERP.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class CERPController : AbpController
    {
        protected CERPController()
        {
            LocalizationResource = typeof(CERPResource);
        }

        [Route("Widgets")]
        public class PayrollStructureWidgetsController : CERPController
        {
            [HttpGet]
            [Route("PayrollPeriodWidget")]
            public IActionResult PayrollPeriod(PS_PayrollPeriod_Dto payrollPeriod_Dto)
            {
                return ViewComponent("PayrollPeriodWidget", new { payrollPeriod_Dto });
            }
        }
    }
}