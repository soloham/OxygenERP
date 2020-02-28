using CERP.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace CERP.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class CERPPageModel : AbpPageModel
    {
        protected CERPPageModel()
        {
            LocalizationResourceType = typeof(CERPResource);
        }
    }
}