using CERP.Localization;
using CERP.Web.BusinessLogic.Core.Services.ApprovalRouteService;
using System;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace CERP.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class CERPSetupPageModel : CERPPageModel
    {
        public IApprovalRoutesManager ApprovalRoutesManager => LazyGetRequiredService(ref _approvalRoutesManager);
        private IApprovalRoutesManager _approvalRoutesManager;

        protected CERPSetupPageModel()
        {
            LocalizationResourceType = typeof(CERPResource);
        }
    }
}