using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace CERP.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(CERPHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class CERPConsoleApiClientModule : AbpModule
    {
        
    }
}
