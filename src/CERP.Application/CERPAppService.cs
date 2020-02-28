using System;
using System.Collections.Generic;
using System.Text;
using CERP.Localization;
using Volo.Abp.Application.Services;

namespace CERP
{
    /* Inherit your application services from this class.
     */
    public abstract class CERPAppService : ApplicationService
    {
        protected CERPAppService()
        {
            LocalizationResource = typeof(CERPResource);
        }
    }
}
