using CERP.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.Users.EntityFrameworkCore;

namespace CERP.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See CERPDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class CERPMigrationsDbContext : AbpDbContext<CERPMigrationsDbContext>
    {
        public CERPMigrationsDbContext(DbContextOptions<CERPMigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            /* Configure customizations for entities from the modules included  */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable("AbpUsers");
                b.ConfigureAbpUser();
                b.ConfigureFullAuditedAggregateRoot();
                b.HasOne<IdentityUser>().WithOne().HasForeignKey<AppUser>(e => e.Id);

                b.ConfigureCustomUserProperties(true);
            });

            /* Configure your own tables/entities inside the ConfigureCERP method */

            builder.ConfigureCERP();
        }
    }
}