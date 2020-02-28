﻿using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace CERP.Web
{
    [Dependency(ReplaceServices = true)]
    public class CERPBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "CERP";
    }
}
