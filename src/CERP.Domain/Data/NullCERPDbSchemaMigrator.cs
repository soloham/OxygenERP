using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CERP.Data
{
    /* This is used if database provider does't define
     * ICERPDbSchemaMigrator implementation.
     */
    public class NullCERPDbSchemaMigrator : ICERPDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}