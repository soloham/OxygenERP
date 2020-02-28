using CERP.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace CERP
{
    [DependsOn(
        typeof(CERPEntityFrameworkCoreTestModule)
        )]
    public class CERPDomainTestModule : AbpModule
    {

    }
}