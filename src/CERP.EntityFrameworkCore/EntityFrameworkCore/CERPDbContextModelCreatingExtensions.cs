using CERP.App;
using CERP.App.CustomEntityHistorySystem;
using CERP.FM;
using CERP.FM.COA;
using CERP.HR.Attendance;
using CERP.HR.Documents;
using CERP.HR.Employees;
using CERP.HR.Holidays;
using CERP.HR.Leaves;
using CERP.HR.Loans;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Timesheets;
using CERP.HR.Workshifts;
using CERP.Payroll.Payrun;
using CERP.Setup;
using CERP.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
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

            builder.Entity<ApprovalRouteTemplate>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "ApprovalRouteTemplates", CERPConsts.DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasMany(x => x.ApprovalRouteTemplateItems).WithOne(x => x.ApprovalRouteTemplate).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<ApprovalRouteTemplateItem>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "ApprovalRouteTemplateItems", CERPConsts.DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasOne(x => x.ApprovalRouteTemplate).WithMany(x => x.ApprovalRouteTemplateItems).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(x => x.TaskTemplate).WithOne(x => x.ApprovalRouteTemplateItem).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(x => x.ApprovalRouteItemEmployees).WithOne(x => x.ApprovalRouteTemplateItem).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<ApprovalRouteTemplateItemEmployee>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "ApprovalRouteTemplateItemEmployees", CERPConsts.DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasKey("ApprovalRouteTemplateItemId", "EmployeeId");
                b.HasOne(x => x.ApprovalRouteTemplateItem).WithMany(x => x.ApprovalRouteItemEmployees).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(x => x.Employee).WithMany().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<TaskTemplate>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "TaskTemplates", CERPConsts.DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasMany(x => x.TaskTemplateItems).WithOne(x => x.TaskTemplate).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TaskTemplateItem>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "TaskTemplateItems", CERPConsts.DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasOne(x => x.TaskTemplate).WithMany(x => x.TaskTemplateItems).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(x => x.TaskEmployees).WithOne(x => x.TaskTemplateItem).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TaskTemplateItemEmployee>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "TaskTemplateItemEmployees", CERPConsts.DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasKey("TaskTemplateItemId", "EmployeeId");
                b.HasOne(x => x.TaskTemplateItem).WithMany(x => x.TaskEmployees).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(x => x.Employee).WithMany().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<CustomEntityChange>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "CustomEntityChanges", CERPConsts.DbSchema);

                b.ConfigureExtraProperties();

                b.HasMany(x => x.PropertyChanges).WithOne(x => x.EntityChange).OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<CustomEntityPropertyChange>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "CustomEntityPropertyChanges", CERPConsts.DbSchema);

                b.ConfigureExtraProperties();

                b.HasOne(x => x.EntityChange).WithMany(x => x.PropertyChanges).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<COA_Account>(b =>
            {
                b.ToTable(CERPConsts.FMDbTablePrefix + "COAs", CERPConsts.FMDbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();
                b.ConfigureSoftDelete();

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

                b.Property(p => p.AccountGroupCatId);

                b.Property(p => p.AllowPosting)
                    .IsRequired();
                b.Property(p => p.AllowPayment)
                    .IsRequired();
                b.Property(p => p.AllowReceipt)
                    .IsRequired();
                b.Property(p => p.ActiveStatus)
                    .IsRequired(false);

                b.HasOne(p => p.CashFlowStatementType).WithMany().OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<COA_AccountSubCategory>(b =>
            {
                b.ToTable(CERPConsts.FMDbTablePrefix + "COASubCategories", CERPConsts.FMDbSchema);

                b.ConfigureAudited();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();
                b.ConfigureSoftDelete();
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
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();
                b.ConfigureSoftDelete();

                b.Property(p => p.HeadCode)
                    .IsRequired();
                b.Property(p => p.AccountName)
                    .IsRequired();
                b.Property(p => p.LocalizationKey)
                    .IsRequired(false);
            });

            builder.Entity<Company>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "Companies", CERPConsts.SetupDbSchema);

                b.ConfigureAudited();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(p => p.CompanyName)
                    .IsRequired();
                b.Property(p => p.CompanyNameLocalized)
                    .IsRequired(false);
                b.Property(p => p.Language)
                    .IsRequired();
                b.Property(p => p.Status)
                    .IsRequired();
                b.Property(p => p.RegistrationID)
                    .IsRequired();
                b.Property(p => p.TaxID)
                    .IsRequired();
                b.Property(p => p.SocialInsuranceID)
                    .IsRequired();
                b.Property(p => p.VATID)
                    .IsRequired();
                b.Property(p => p.ClientID)
                    .ValueGeneratedOnAdd()
                    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw); // <--

                b.HasMany(p => p.Departments).WithOne(c => c.Company).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(p => p.CompanyLocations).WithOne(c => c.Company).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(p => p.CompanyCurrencies).WithOne(c => c.Company).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(p => p.CompanyDocuments).WithOne(c => c.Company).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(p => p.CompanyPrintSizes).WithOne(c => c.Company).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<CompanyLocation>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "CompanyLocations", CERPConsts.SetupDbSchema);

                b.ConfigureAudited();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasKey("CompanyId", "LocationId");
                b.HasOne(p => p.Location).WithMany().OnDelete(DeleteBehavior.Cascade);
                b.HasOne(p => p.Company).WithMany(x => x.CompanyLocations).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<CompanyCurrency>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "CompanyCurrencies", CERPConsts.SetupDbSchema);

                b.HasKey("CompanyId", "CurrencyId");
                b.ConfigureAudited();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(p => p.Currency).WithMany().OnDelete(DeleteBehavior.Cascade);
                b.HasOne(p => p.Company).WithMany(x => x.CompanyCurrencies).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<CompanyDocument>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "CompanyDocuments", CERPConsts.SetupDbSchema);

                b.HasKey("CompanyId", "DocumentId");
                b.ConfigureAudited();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(p => p.Document).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.Company).WithMany(x => x.CompanyDocuments).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<CompanyPrintSize>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "CompanyPrintSizes", CERPConsts.SetupDbSchema);

                b.ConfigureAudited();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(p => p.Company)
                    .WithMany(x => x.CompanyPrintSizes).OnDelete(DeleteBehavior.Cascade); ;
            });

            builder.Entity<Branch>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "Branches", CERPConsts.DbSchema);

                b.ConfigureAudited();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
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
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
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
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();
                b.ConfigureSoftDelete();

                b.Property(p => p.Title)
                    .IsRequired();

            });

            builder.Entity<DictionaryValueType>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "DictionaryValueTypes", CERPConsts.DbSchema);

                b.ConfigureAudited();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.ValueTypeCode)
                    .IsRequired();
                b.Property(x => x.ValueTypeName)
                    .IsRequired();
                b.Property(x => x.ActiveStatus)
                    .IsRequired();
                b.Property(x => x.Locked)
                    .IsRequired();

                b.HasOne(p => p.Company).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.Branch).WithMany().OnDelete(DeleteBehavior.Restrict);

                //b.HasMany(p => p.Values).WithOne(p => p.ValueType);
            });

            builder.Entity<DictionaryValue>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "DictionaryValues", CERPConsts.DbSchema);

                b.ConfigureAudited();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.Key)
                    .IsRequired();

                b.HasOne(p => p.ValueType).WithMany(p => p.Values).OnDelete(DeleteBehavior.ClientCascade);
                b.HasOne(p => p.Company).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.Branch).WithMany().OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<COA_SubLedgerRequirement_Account>(b =>
            {
                b.ToTable(CERPConsts.FMDbTablePrefix + "SubLedgerRequirement_Account", CERPConsts.FMDbSchema);

                b.ConfigureAudited();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();
            });

            builder.Entity<COA_SubLedgerRequirement_Account>()
                .HasKey(bc => new { bc.AccountId, bc.SubLedgerRequirementId });
            builder.Entity<COA_SubLedgerRequirement_Account>()
                .HasOne(bc => bc.SubLedgerRequirement)
                .WithMany(b => b.SubLedgerRequirementAccounts)
                .HasForeignKey(bc => bc.SubLedgerRequirementId);
            builder.Entity<COA_SubLedgerRequirement_Account>()
                .HasOne(bc => bc.Account)
                .WithMany(c => c.SubLedgerRequirementAccounts)
                .HasForeignKey(bc => bc.AccountId);

            #region HR
            #region Organizational Management
            #region Organization Structure
            builder.Entity<OS_DepartmentTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}DepartmentTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(p => p.CostCenter).WithMany().OnDelete(DeleteBehavior.NoAction);
                b.HasMany(p => p.PositionTemplates).WithOne(p => p.DepartmentTemplate).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(p => p.SubDepartmentTemplates).WithOne(p => p.DepartmentTemplate).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<OS_DepartmentSubDepartmentTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}DepartmentSubDepartmentTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.HasKey("DepartmentTemplateId", "SubDepartmentTemplateId");
                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(x => x.DepartmentTemplate).WithMany(x => x.SubDepartmentTemplates).OnDelete(DeleteBehavior.NoAction);
                b.HasOne(x => x.SubDepartmentTemplate).WithOne().OnDelete(DeleteBehavior.NoAction);
            });
            //builder.Entity<OS_DepartmentPositionTemplate>(b =>
            //{
            //    b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}DepartmentPositionTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

            //    b.HasKey("DepartmentTemplateId", "PositionTemplateId");
            //    b.ConfigureFullAuditedAggregateRoot();
            //    b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
            //    b.ConfigureConcurrencyStamp();

            //    b.HasOne(x => x.DepartmentTemplate).WithMany(x => x.PositionTemplates).OnDelete(DeleteBehavior.NoAction);
            //    b.HasOne(x => x.PositionTemplate).WithMany().OnDelete(DeleteBehavior.NoAction);
            //});
            builder.Entity<OS_PositionTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}PositionTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(p => p.CostCenter).WithMany().OnDelete(DeleteBehavior.NoAction);
                b.HasMany(p => p.PositionJobTemplates).WithOne(p => p.PositionTemplate).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(p => p.PositionTaskTemplates).WithOne(p => p.PositionTemplate).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<OS_PositionJobTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}PositionJobTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.HasKey("PositionTemplateId", "JobTemplateId");
                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(x => x.PositionTemplate).WithMany(x => x.PositionJobTemplates).OnDelete(DeleteBehavior.NoAction);
                b.HasOne(x => x.JobTemplate).WithMany().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<OS_PositionTaskTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}PositionTaskTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.HasKey("PositionTemplateId", "TaskTemplateId");
                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(x => x.PositionTemplate).WithMany(x => x.PositionTaskTemplates).OnDelete(DeleteBehavior.NoAction);
                b.HasOne(x => x.TaskTemplate).WithMany().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<OS_JobTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}JobTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp(); 

                b.HasMany(x => x.JobTaskTemplates).WithOne(x => x.JobTemplate).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(x => x.JobFunctionTemplates).WithOne(x => x.JobTemplate).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(x => x.JobSkillTemplates).WithOne(x => x.JobTemplate).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(x => x.JobAcademiaTemplates).WithOne(x => x.JobTemplate).OnDelete(DeleteBehavior.Cascade);

                b.HasOne(x => x.CompensationMatrix).WithMany().OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<OS_JobTaskTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}JobTaskTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.HasKey("JobTemplateId", "TaskTemplateId");
                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(x => x.JobTemplate).WithMany(x => x.JobTaskTemplates).OnDelete(DeleteBehavior.NoAction);
                b.HasOne(x => x.TaskTemplate).WithMany().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<OS_JobFunctionTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}JobFunctionTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.HasKey("JobTemplateId", "FunctionTemplateId");
                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(x => x.JobTemplate).WithMany(x => x.JobFunctionTemplates).OnDelete(DeleteBehavior.NoAction);
                b.HasOne(x => x.FunctionTemplate).WithMany().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<OS_JobSkillTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}JobSkillTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.HasKey("JobTemplateId", "SkillTemplateId");
                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(x => x.JobTemplate).WithMany(x => x.JobSkillTemplates).OnDelete(DeleteBehavior.NoAction);
                b.HasOne(x => x.SkillTemplate).WithMany().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<OS_JobAcademiaTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}JobAcademiaTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.HasKey("JobTemplateId", "AcademiaTemplateId");
                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(x => x.JobTemplate).WithMany(x => x.JobAcademiaTemplates).OnDelete(DeleteBehavior.NoAction);
                b.HasOne(x => x.AcademiaTemplate).WithMany().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<OS_TaskTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}TaskTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasMany(x => x.TaskSkillTemplates).WithOne(x => x.TaskTemplate).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(x => x.TaskAcademiaTemplates).WithOne(x => x.TaskTemplate).OnDelete(DeleteBehavior.Cascade);

                b.HasOne(x => x.CompensationMatrix).WithMany().OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<OS_TaskSkillTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}TaskSkillTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.HasKey("TaskTemplateId", "SkillTemplateId");
                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(x => x.TaskTemplate).WithMany(x => x.TaskSkillTemplates).OnDelete(DeleteBehavior.NoAction);
                b.HasOne(x => x.SkillTemplate).WithMany().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<OS_TaskAcademiaTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}TaskAcademiaTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.HasKey("TaskTemplateId", "AcademiaTemplateId");
                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(x => x.TaskTemplate).WithMany(x => x.TaskAcademiaTemplates).OnDelete(DeleteBehavior.NoAction);
                b.HasOne(x => x.AcademiaTemplate).WithMany().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<OS_FunctionTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}FunctionTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasMany(x => x.FunctionSkillTemplates).WithOne(x => x.FunctionTemplate).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(x => x.FunctionAcademiaTemplates).WithOne(x => x.FunctionTemplate).OnDelete(DeleteBehavior.Cascade);

                b.HasOne(x => x.CompensationMatrix).WithMany().OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<OS_FunctionSkillTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}FunctionSkillTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.HasKey("FunctionTemplateId", "SkillTemplateId");
                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(x => x.FunctionTemplate).WithMany(x => x.FunctionSkillTemplates).OnDelete(DeleteBehavior.NoAction);
                b.HasOne(x => x.SkillTemplate).WithMany().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<OS_FunctionAcademiaTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}FunctionAcademiaTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.HasKey("FunctionTemplateId", "AcademiaTemplateId");
                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(x => x.FunctionTemplate).WithMany(x => x.FunctionAcademiaTemplates).OnDelete(DeleteBehavior.NoAction);
                b.HasOne(x => x.AcademiaTemplate).WithMany().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<OS_SkillTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}SkillTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();
            });
            builder.Entity<OS_AcademiaTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}AcademiaTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(x => x.Institute).WithMany().OnDelete(DeleteBehavior.NoAction);
                b.HasOne(x => x.AcademiaCertificateSubType).WithMany().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<OS_CompensationMatrixTemplate>(b =>
            {
                b.ToTable($"{CERPConsts.HR_OM_OrganizationStructure_DbTablePrefix}CompensationMatrixTemplates", CERPConsts.HR_OM_OrganizationStructure_DbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();
            });
            #endregion
            #endregion
            #endregion

            builder.Entity<Employee>(b =>
            {
                b.ToTable(CERPConsts.HRDbTablePrefix + "Employees", CERPConsts.HR_DbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureSoftDelete();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.HasOne(p => p.EmployeeStatus).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.POB).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.Nationality).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.Gender).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.MaritalStatus).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.BloodGroup).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.Religion).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.EmployeeType).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.ContractStatus).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.ContractType).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.EmployeeStatus).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.Department).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.SIType).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.IndemnityType).WithMany().OnDelete(DeleteBehavior.Restrict);

                b.HasOne(p => p.Position).WithOne(pos => pos.Employee).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.WorkShift).WithMany(p => p.Employees).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(p => p.Portal).WithOne(p => p.Employee).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Department>(b =>
            {
                b.ToTable(CERPConsts.SetupDbTablePrefix + "Departments", CERPConsts.SetupDbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureSoftDelete();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(p => p.Name)
                    .IsRequired();

                b.HasMany(p => p.Positions).WithOne(d => d.Department).OnDelete(DeleteBehavior.ClientCascade);
            });
            
            builder.Entity<LocationTemplate>(b =>
            {
                b.ToTable(CERPConsts.SetupDbTablePrefix + "LocationTemplates", CERPConsts.SetupDbSchema);

                b.HasOne(x => x.LocationCountry).WithMany();

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();
            });
            
            builder.Entity<Currency>(b =>
            {
                b.ToTable(CERPConsts.SetupDbTablePrefix + "Currencies", CERPConsts.SetupDbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant(); 
                b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();
            });

            builder.Entity<Position>(b =>
            {
                b.ToTable(CERPConsts.SetupDbTablePrefix + "Positions", CERPConsts.SetupDbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureSoftDelete();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.Title)
                    .IsRequired();

                b.HasOne(p => p.Employee).WithOne(e => e.Position).OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<WorkShift>(b =>
            {
                b.ToTable(CERPConsts.HRDbTablePrefix + "WorkShifts", CERPConsts.HR_DbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureSoftDelete();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.Title)
                    .IsRequired();

                b.HasOne(x => x.Department).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.DeductionMethod).WithMany(x => x.WorkShifts).OnDelete(DeleteBehavior.Restrict);
                b.HasMany(p => p.Employees).WithOne(p => p.WorkShift).OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<DeductionMethod>(b =>
            {
                b.ToTable(CERPConsts.HRDbTablePrefix + "DeductionMethods", CERPConsts.HR_DbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureSoftDelete();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.Title)
                    .IsRequired();
                b.Property(x => x.HoursMultiplicationFactor)
                    .IsRequired();

                b.HasMany(p => p.WorkShifts).WithOne(x => x.DeductionMethod).OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Document>(b =>
            {
                b.ToTable(CERPConsts.HRDbTablePrefix + "Documents", CERPConsts.HR_DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureSoftDelete();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.ReferenceNo)
                    .IsRequired();
                b.Property(x => x.FileName)
                    .IsRequired();
                b.Property(x => x.Name)
                    .IsRequired();
                b.Property(x => x.NameLocalized)
                    .IsRequired();
                b.Property(x => x.Description)
                    .IsRequired();
                b.Property(x => x.IssueDate)
                    .IsRequired();
                b.Property(x => x.ExpiryDate)
                    .IsRequired();

                b.HasOne(x => x.DocumentType).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.OwnerType).WithMany().OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Timesheet>(b =>
            {
                b.ToTable(CERPConsts.HRDbTablePrefix + "Timesheets", CERPConsts.HR_DbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureSoftDelete();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.Year)
                    .IsRequired();
                b.Property(x => x.Month)
                    .IsRequired();

                b.Property(x => x.Week1Hours)
                    .IsRequired();
                b.Property(x => x.Week2Hours)
                    .IsRequired();     
                b.Property(x => x.Week3Hours)
                    .IsRequired();     
                b.Property(x => x.Week4Hours)
                    .IsRequired();     
                b.Property(x => x.Week5Hours)
                    .IsRequired();

                b.Property(x => x.TotalMonthHours)
                    .IsRequired();

                b.Property(x => x.IsPosted)
                    .IsRequired();
                b.Property(x => x.Dated)
                    .IsRequired();

                b.HasOne(x => x.Employee).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasMany(x => x.WeeklySummaries).WithOne(e => e.Timesheet).OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<TimesheetWeekSummary>(b =>
            {
                b.ToTable(CERPConsts.HRDbTablePrefix + "WeeklyTimesheets", CERPConsts.HR_DbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureSoftDelete();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.TimesheetId)
                    .IsRequired();
                b.Property(x => x.EmployeeId)
                    .IsRequired();

                b.Property(x => x.Week)
                    .IsRequired();

                b.Property(x => x.SumSun)
                    .IsRequired();
                b.Property(x => x.SumMon)
                    .IsRequired();
                b.Property(x => x.SumTue)
                    .IsRequired();
                b.Property(x => x.SumWed)
                    .IsRequired();
                b.Property(x => x.SumThu)
                    .IsRequired();
                b.Property(x => x.SumFri)
                    .IsRequired();
                b.Property(x => x.SumSat)
                    .IsRequired();

                b.Property(x => x.TotalWeekHours)
                    .IsRequired();

                b.Property(x => x.IsSubmitted)
                    .IsRequired();
                b.Property(x => x.Dated)
                    .IsRequired();

                b.HasOne(x => x.Timesheet).WithMany(t => t.WeeklySummaries).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Employee).WithMany().OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<TimesheetWeekJobSummary>(b =>
            {
                b.ToTable(CERPConsts.HRDbTablePrefix + "WeeklyTimesheetsJobs", CERPConsts.HR_DbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureSoftDelete();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.WeekSheetId)
                    .IsRequired();
                b.Property(x => x.EmployeeId)
                    .IsRequired();

                b.Property(x => x.ChargeabilityId)
                    .IsRequired();
                b.Property(x => x.ServiceLineId)
                    .IsRequired();
                b.Property(x => x.ClientId)
                    .IsRequired(false);
                
                b.Property(x => x.Week)
                    .IsRequired();

                b.Property(x => x.Sun)
                    .IsRequired();
                b.Property(x => x.Mon)
                    .IsRequired();
                b.Property(x => x.Tue)
                    .IsRequired();
                b.Property(x => x.Wed)
                    .IsRequired();
                b.Property(x => x.Thu)
                    .IsRequired();
                b.Property(x => x.Fri)
                    .IsRequired();
                b.Property(x => x.Sat)
                    .IsRequired();

                b.Property(x => x.TotalJobWeekHours)
                    .IsRequired();

                b.Property(x => x.IsSubmitted)
                    .IsRequired();

                b.HasOne(x => x.WeekSheet).WithMany(t => t.WeeklyJobSummaries).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Employee).WithMany().OnDelete(DeleteBehavior.Restrict);

                b.HasOne(x => x.Chargeability).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.ServiceLine).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Client).WithMany().OnDelete(DeleteBehavior.Restrict);
            });


            builder.Entity<Payrun>(b =>
            {
                b.ToTable(CERPConsts.PayrollDbTablePrefix + "Payruns", CERPConsts.PayrollDbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureSoftDelete();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.CompanyId)
                    .IsRequired();
                b.Property(x => x.PostedById)
                    .IsRequired(false);

                b.Property(x => x.Year)
                    .IsRequired();
                b.Property(x => x.Month)
                    .IsRequired();

                b.Property(x => x.TotalEarnings)
                    .IsRequired();
                b.Property(x => x.TotalDeductions)
                    .IsRequired();
                b.Property(x => x.NetTotal)
                    .IsRequired();

                b.Property(x => x.Note)
                    .IsRequired(false);

                b.Property(x => x.IsPosted)
                    .IsRequired();
                b.Property(x => x.PostedDate)
                    .IsRequired(false);

                b.HasOne(x => x.Company).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.PostedBy).WithMany().OnDelete(DeleteBehavior.Restrict);

                b.HasMany(x => x.PayrunDetails).WithOne(p => p.Payrun).OnDelete(DeleteBehavior.ClientCascade);
                b.HasMany(x => x.Payslips).WithOne().OnDelete(DeleteBehavior.ClientCascade);
            });
            builder.Entity<PayrunDetail>(b =>
            {
                b.ToTable(CERPConsts.PayrollDbTablePrefix + "PayrunsDetails", CERPConsts.PayrollDbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureSoftDelete();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.PayrunId)
                    .IsRequired();
                b.Property(x => x.EmployeeId)
                    .IsRequired();

                b.Property(x => x.Year)
                    .IsRequired();
                b.Property(x => x.Month)
                    .IsRequired();

                b.Property(x => x.GrossEarnings)
                    .IsRequired();
                b.Property(x => x.GrossDeductions)
                    .IsRequired();
                b.Property(x => x.NetAmount)
                    .IsRequired();

                b.Property(x => x.GOSIAmount)
                    .IsRequired();
                b.Property(x => x.Loan)
                    .IsRequired();
                b.Property(x => x.Leaves)
                    .IsRequired();
                b.Property(x => x.Disciplinary)
                    .IsRequired();

                b.Property(x => x.AmountPaid)
                    .IsRequired();
                b.Property(x => x.DifferAmount)
                    .IsRequired();

                b.HasOne(x => x.Payrun).WithMany(p => p.PayrunDetails).OnDelete(DeleteBehavior.Restrict);
                b.HasMany(x => x.PayrunAllowancesSummaries).WithOne().OnDelete(DeleteBehavior.ClientCascade);
                b.HasOne(x => x.Employee).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Indemnity).WithOne(x => x.PayrunDetail).OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Payslip>(b =>
            {
                b.ToTable(CERPConsts.PayrollDbTablePrefix + "PayrunsPayslips", CERPConsts.PayrollDbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureSoftDelete();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.PayrunDetailId)
                    .IsRequired();
                b.Property(x => x.EmployeeId)
                    .IsRequired();

                b.Property(x => x.Year)
                    .IsRequired();
                b.Property(x => x.Month)
                    .IsRequired();

                b.Property(x => x.Earning)
                    .IsRequired();
                b.Property(x => x.Deduction)
                    .IsRequired();

                b.Property(x => x.Description)
                    .IsRequired();
                b.Property(x => x.Remarks)
                    .IsRequired();

                b.Property(x => x.IsPosted)
                    .IsRequired();

                b.HasOne(x => x.PayrunDetail).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.Employee).WithMany().OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<PayrunAllowanceSummary>(b =>
            {
                b.ToTable(CERPConsts.PayrollDbTablePrefix + "PayrunsAllowancesSummaries", CERPConsts.PayrollDbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureSoftDelete();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.Value)
                    .IsRequired();
                b.Property(x => x.AllowanceTypeId)
                    .IsRequired();
                b.Property(x => x.EmployeeId)
                    .IsRequired();

                b.HasOne(x => x.Employee).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.AllowanceType).WithMany().OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<SISetup>(b =>
            {
                b.ToTable(CERPConsts.PayrollDbTablePrefix + "SISetup", CERPConsts.PayrollDbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.SI_UpperLimit)
                    .IsRequired();

                b.HasMany(x => x.ContributionCategories).WithOne(x => x.Setup).OnDelete(DeleteBehavior.ClientCascade);
            });
            builder.Entity<SIContributionCategory>(b =>
            {
                b.ToTable(CERPConsts.PayrollDbTablePrefix + "SICategories", CERPConsts.PayrollDbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.Title)
                    .IsRequired();
                b.Property(x => x.IsExpense)
                    .IsRequired();

                b.HasMany(x => x.SIContributions).WithOne(x => x.SICategory).OnDelete(DeleteBehavior.ClientCascade);
                b.HasOne(x => x.Setup).WithMany(x => x.ContributionCategories).OnDelete(DeleteBehavior.ClientCascade);
            });
            builder.Entity<SIContribution>(b =>
            {
                b.ToTable(CERPConsts.PayrollDbTablePrefix + "SIContributions", CERPConsts.PayrollDbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.Title)
                    .IsRequired();
                b.Property(x => x.Value)
                    .IsRequired();
                b.Property(x => x.IsPercentage)
                    .IsRequired();

                b.HasOne(x => x.SICategory).WithMany(x => x.SIContributions).OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<PayrunDetailIndemnity>(b =>
            {
                b.ToTable(CERPConsts.PayrollDbTablePrefix + "PayrunDetailIndemnities", CERPConsts.PayrollDbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.BasicSalary)
                    .IsRequired();
                b.Property(x => x.GrossSalary)
                    .IsRequired();
                b.Property(x => x.TotalEmploymentDays)
                    .IsRequired();
                b.Property(x => x.TotalEOSB)
                    .IsRequired();
                b.Property(x => x.ActuarialEvaluation)
                    .IsRequired();
                b.Property(x => x.LastMonthEOSB)
                    .IsRequired();
                b.Property(x => x.Difference)
                    .IsRequired();

                b.HasOne(x => x.Employee).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.PayrunDetail).WithOne(x => x.Indemnity).OnDelete(DeleteBehavior.Restrict);
                b.HasMany(x => x.PayrunEOSBAllowancesSummaries).WithOne().OnDelete(DeleteBehavior.Restrict);
            });


            builder.Entity<Holiday>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "Holidays", CERPConsts.HR_DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasOne(x => x.HolidayType).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.ReligiousDenomination).WithMany().OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<LeaveRequestTemplate>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "LeaveRequestTemplates", CERPConsts.HR_DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasOne(x => x.LeaveType).WithMany().OnDelete(DeleteBehavior.NoAction);
                b.HasOne(x => x.ApprovalRouteTemplate).WithOne().OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.Departments).WithOne(x => x.LeaveRequestTemplate).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(x => x.Positions).WithOne(x => x.LeaveRequestTemplate).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(x => x.EmployeeStatuses).WithOne(x => x.LeaveRequestTemplate).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(x => x.EmploymentTypes).WithOne(x => x.LeaveRequestTemplate).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(x => x.Holidays).WithOne(x => x.LeaveRequestTemplate).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<LeaveRequestTemplateDepartment>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "LeaveRequestTemplateDepartments", CERPConsts.HR_DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasKey("LeaveRequestTemplateId", "DepartmentId");
                b.HasOne(x => x.LeaveRequestTemplate).WithMany(x => x.Departments).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(x => x.Department).WithMany().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<LeaveRequestTemplatePosition>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "LeaveRequestTemplatePositions", CERPConsts.HR_DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasKey("LeaveRequestTemplateId", "PositionId");
                b.HasOne(x => x.LeaveRequestTemplate).WithMany(x => x.Positions).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(x => x.Position).WithMany().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<LeaveRequestTemplateEmployeeStatus>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "LeaveRequestTemplateEmployeeStatuses", CERPConsts.HR_DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasKey("LeaveRequestTemplateId", "EmployeeStatusId");
                b.HasOne(x => x.LeaveRequestTemplate).WithMany(x => x.EmployeeStatuses).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(x => x.EmployeeStatus).WithMany().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<LeaveRequestTemplateEmploymentType>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "LeaveRequestTemplateEmploymentTypes", CERPConsts.HR_DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasKey("LeaveRequestTemplateId", "EmploymentTypeId");
                b.HasOne(x => x.LeaveRequestTemplate).WithMany(x => x.EmploymentTypes).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(x => x.EmploymentType).WithMany().OnDelete(DeleteBehavior.NoAction);
            }); 
            builder.Entity<LeaveRequestTemplateHoliday>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "LeaveRequestTemplateHolidays", CERPConsts.HR_DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasKey("LeaveRequestTemplateId", "HolidayId");
                b.HasOne(x => x.LeaveRequestTemplate).WithMany(x => x.Holidays).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(x => x.Holiday).WithMany().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<LoanRequestTemplate>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "LoanRequestTemplates", CERPConsts.HR_DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasOne(x => x.LoanType).WithMany().OnDelete(DeleteBehavior.NoAction);
                b.HasOne(x => x.ApprovalRouteTemplate).WithOne().OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.Departments).WithOne(x => x.LoanRequestTemplate).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(x => x.Positions).WithOne(x => x.LoanRequestTemplate).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(x => x.EmployeeStatuses).WithOne(x => x.LoanRequestTemplate).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(x => x.EmploymentTypes).WithOne(x => x.LoanRequestTemplate).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<LoanRequestTemplateDepartment>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "LoanRequestTemplateDepartments", CERPConsts.HR_DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasKey("LoanRequestTemplateId", "DepartmentId");
                b.HasOne(x => x.LoanRequestTemplate).WithMany(x => x.Departments).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(x => x.Department).WithMany().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<LoanRequestTemplatePosition>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "LoanRequestTemplatePositions", CERPConsts.HR_DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasKey("LoanRequestTemplateId", "PositionId");
                b.HasOne(x => x.LoanRequestTemplate).WithMany(x => x.Positions).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(x => x.Position).WithMany().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<LoanRequestTemplateEmployeeStatus>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "LoanRequestTemplateEmployeeStatuses", CERPConsts.HR_DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasKey("LoanRequestTemplateId", "EmployeeStatusId");
                b.HasOne(x => x.LoanRequestTemplate).WithMany(x => x.EmployeeStatuses).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(x => x.EmployeeStatus).WithMany().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<LoanRequestTemplateEmploymentType>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "LoanRequestTemplateEmploymentTypes", CERPConsts.HR_DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();

                b.HasKey("LoanRequestTemplateId", "EmploymentTypeId");
                b.HasOne(x => x.LoanRequestTemplate).WithMany(x => x.EmploymentTypes).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(x => x.EmploymentType).WithMany().OnDelete(DeleteBehavior.NoAction);
            }); 

            builder.Entity<Attendance>(b =>
            {
                b.ToTable(CERPConsts.DbTablePrefix + "Attendance", CERPConsts.HR_DbSchema);

                b.ConfigureAuditedAggregateRoot();
                b.ConfigureMultiTenant();
            });
        }

        public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b, bool isMigrationDbContext)
            where TUser: class, IUser
        {
            //b.ConfigureByConvention();
            //b.TryConfigureExtraProperties();
            //b.Property<string>(nameof(AppUser.ExtraProperties));
            b.Property<Guid?>(nameof(AppUser.EmployeeId));

            if(false)
            {
                b.Ignore(nameof(AppUser.Employee));
            }
            else
            {
                b.HasOne(nameof(AppUser.Employee)).WithOne(nameof(Employee.Portal)).OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}