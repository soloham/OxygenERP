using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace CERP.EntityFrameworkCore
{
    [DependsOn(
        typeof(CERPEntityFrameworkCoreModule)
        )]
    public class CERPEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CERPMigrationsDbContext>();
        }
    }
}
