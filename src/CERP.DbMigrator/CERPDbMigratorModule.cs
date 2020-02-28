using CERP.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace CERP.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(CERPEntityFrameworkCoreDbMigrationsModule),
        typeof(CERPApplicationContractsModule)
        )]
    public class CERPDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
