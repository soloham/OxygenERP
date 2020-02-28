using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CERP.Data;
using Volo.Abp.DependencyInjection;

namespace CERP.EntityFrameworkCore
{
    [Dependency(ReplaceServices = true)]
    public class EntityFrameworkCoreCERPDbSchemaMigrator
        : ICERPDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreCERPDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the CERPMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<CERPMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}