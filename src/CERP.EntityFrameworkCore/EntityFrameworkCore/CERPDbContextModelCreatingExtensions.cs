using CERP.App;
using CERP.FM;
using CERP.FM.COA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users;

namespace CERP.EntityFrameworkCore
{
    public static class CERPDbContextModelCreatingExtensions
    {
        public static void ConfigureCERP(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(CERPConsts.DbTablePrefix + "YourEntities", CERPConsts.DbSchema);

            //    //...
            //});

            builder.Entity<COA_Account>(b =>
            {
                b.ToTable(CERPConsts.FMDbTablePrefix + "COAs", CERPConsts.FMDbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(p => p.AccountId)
                    .IsRequired();
                b.Property(p => p.AccountCode)
                    .IsRequired();
                b.Property(p => p.AccountName)
                    .IsRequired();
                b.Property(p => p.AccountNameLocalizationKey)
                    .IsRequired(false);
                b.Property(p => p.AccountName)
                    .IsRequired();
                b.Property(p => p.AllowPosting)
                    .IsRequired();
                b.Property(p => p.AllowPayment)
                    .IsRequired();
                b.Property(p => p.AllowReceipt)
                    .IsRequired();
                b.Property(p => p.ActiveStatus)
                    .IsRequired(false);

                b.HasMany(p => p.SubLedgerRequirements)
                    .WithOne();
            });

            builder.Entity<COA_AccountSubCategory>(b =>
            {
                b.ToTable(CERPConsts.FMDbTablePrefix + "COASubCategories", CERPConsts.FMDbSchema);

                b.ConfigureAudited();
                b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();
                b.Property(p => p.SubCategoryCode)
                    .IsRequired();
                b.Property(p => p.LocalizationKey)
                    .IsRequired(false);
                b.Property(p => p.Title)
                    .IsRequired();

                b.Property(p => p.ParentId)
                    .IsRequired(false);

                b.HasOne(p => p.HeadAccount)
                    .WithMany();
                b.HasOne(p => p.Branch)
                    .WithMany();
                b.HasOne(p => p.Company);
            });

            builder.Entity<COA_HeadAccount>(b =>
            {
                b.ToTable(CERPConsts.FMDbTablePrefix + "COAHeadAccounts", CERPConsts.FMDbSchema);

                b.ConfigureFullAudited();
                b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(p => p.HeadCode)
                    .IsRequired();
                b.Property(p => p.AccountName)
                    .IsRequired();
                b.Property(p => p.LocalizationKey)
                    .IsRequired(false);
            });

            builder.Entity<Company>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "Companies", CERPConsts.DbSchema);

                b.ConfigureAudited();
                b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(p => p.Name)
                    .IsRequired();
                b.Property(p => p.NameLocalizationKey)
                    .IsRequired(false);
                b.Property(p => p.Address)
                    .IsRequired();
                b.Property(p => p.AddressLocalizationKey)
                    .IsRequired(false);
                b.Property(p => p.BankDetail)
                    .IsRequired();
                b.Property(p => p.BankDetailLocalizationKey)
                    .IsRequired(false);
                b.Property(p => p.Email)
                    .IsRequired(false);
                b.Property(p => p.Phone)
                    .IsRequired(false);
                b.Property(p => p.Website)
                    .IsRequired(false);
                b.Property(p => p.FiscalYearStartMonth)
                    .IsRequired();
                b.Property(p => p.FiscalYearBasis)
                    .IsRequired();
                b.Property(p => p.IsEnabled)
                    .IsRequired(false);
                b.Property(p => p.Language)
                    .IsRequired();
                b.Property(p => p.VATNumber)
                    .IsRequired();
            });

            builder.Entity<Branch>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "Branches", CERPConsts.DbSchema);

                b.ConfigureAudited();
                b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(p => p.Name)
                    .IsRequired();

                b.HasOne(p => p.Company)
                    .WithMany();
            });

            builder.Entity<AccountStatementType>(b =>
            {
                b.ToTable(CERPConsts.FMDbTablePrefix + "AccountStatementTypes", CERPConsts.FMDbSchema);

                b.ConfigureAudited();
                b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(p => p.Title)
                    .IsRequired();
                b.Property(p => p.TitleLocalizationKey)
                    .IsRequired(false);
                b.Property(p => p.ParentId)
                    .IsRequired(false);
            });

            builder.Entity<COA_SubLedgerRequirement>(b =>
            {
                b.ToTable(CERPConsts.FMDbTablePrefix + "SubLedgerRequirements", CERPConsts.FMDbSchema);

                b.ConfigureFullAudited();
                b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(p => p.Title)
                    .IsRequired();
            });

            builder.Entity<DictionaryValueType>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "DictionaryValueTypes", CERPConsts.DbSchema);

                b.ConfigureAudited();
                b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.ValueTypeName)
                    .IsRequired();
                b.Property(x => x.ActiveStatus)
                    .IsRequired();
                b.Property(x => x.Locked)
                    .IsRequired();

                b.HasOne(p => p.Company).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.Branch).WithMany().OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<DictionaryValue>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "DictionaryValues", CERPConsts.DbSchema);

                b.ConfigureAudited();
                b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.Key)
                    .IsRequired();

                b.HasOne(p => p.ValueType).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.Company).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.Branch).WithMany().OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b)
            where TUser: class, IUser
        {
            //b.Property<string>(nameof(AppUser.MyProperty))...
        }
    }
}