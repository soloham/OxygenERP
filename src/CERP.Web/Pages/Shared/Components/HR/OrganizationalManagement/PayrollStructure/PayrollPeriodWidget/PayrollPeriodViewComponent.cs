using CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace CERP.Web.Pages.Shared.Components.HR.OrganizationalManagement.PayrollStructure.PayrollPeriodWidget
{
    [Widget(
        StyleFiles = new[] { "/Pages/Shared/Components/Default.css" },
        ScriptFiles = new[] { "/Pages/Shared/Components/Default.js" }
        )]
    public class PayrollPeriodWidgetViewComponent : AbpViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PS_PayrollPeriod_Dto payrollPeriod_Dto = null)
        {
            payrollPeriod_Dto = payrollPeriod_Dto == null ? new PS_PayrollPeriod_Dto() : payrollPeriod_Dto;
            return View("/Views/Shared/Components/HR/OrganizationalManagement/PayrollStructure/PayrollPeriod/Default.cshtml", payrollPeriod_Dto);
        }
    }
    public class PayrollPeriodWidgetStyleBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files
              .AddIfNotContains("/Pages/Shared/Components/HR/OrganizationalManagement/PayrollStructure/PayrollPeriodWidget/Default.css");
        }
    }

    public class PayrollPeriodWidgetScriptBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files
              .AddIfNotContains("/Pages/Shared/Components/HR/OrganizationalManagement/PayrollStructure/PayrollPeriodWidget/Default.js");
        }
    }
}
