using Microsoft.EntityFrameworkCore;
using CERP.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users.EntityFrameworkCore;
using CERP.FM.COA;
using CERP.FM;
using CERP.App;
using CERP.HR.Employees;
using CERP.Setup;
using CERP.HR.Workshifts;

namespace CERP.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See CERPMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class CERPDbContext : AbpDbContext<CERPDbContext>
    {
        public DbSet<AppUser> Users { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside CERPDbContextModelCreatingExtensions.ConfigureCERP
         */

        public DbSet<COA_Account> COAs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<COA_HeadAccount> COAHeadAccounts { get; set; }
        public DbSet<COA_AccountSubCategory> COASubCategories { get; set; }
        public DbSet<COA_SubLedgerRequirement> SubLedgerRequirements { get; set; }

        public DbSet<AccountStatementType> AccountStatementTypes { get; set; }

        public DbSet<DictionaryValue> ValuesDictionary { get; set; }
        public DbSet<DictionaryValueType> ValueTypesDictionary { get; set; }


        public DbSet<Employee> Employees { get; set; }

        public DbSet<WorkShift> WorkShifts { get; set; }

        public CERPDbContext(DbContextOptions<CERPDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable("AbpUsers"); //Sharing the same table "AbpUsers" with the IdentityUser
                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                //Moved customization to a method so we can share it with the CERPMigrationsDbContext class
                b.ConfigureCustomUserProperties();
            });

            /* Configure your own tables/entities inside the ConfigureCERP method */

            builder.ConfigureCERP();
        }
    }
}
