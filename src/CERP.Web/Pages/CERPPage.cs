using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using CERP.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace CERP.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits CERP.Web.Pages.CERPPage
     */
    public abstract class CERPPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<CERPResource> L { get; set; }
    }
}
