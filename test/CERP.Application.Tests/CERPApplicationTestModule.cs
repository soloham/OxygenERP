using Volo.Abp.Modularity;

namespace CERP
{
    [DependsOn(
        typeof(CERPApplicationModule),
        typeof(CERPDomainTestModule)
        )]
    public class CERPApplicationTestModule : AbpModule
    {

    }
}