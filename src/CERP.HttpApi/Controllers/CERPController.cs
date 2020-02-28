using CERP.Localization;
using Volo.Abp.AspNetCore.Mvc;

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
    }
}