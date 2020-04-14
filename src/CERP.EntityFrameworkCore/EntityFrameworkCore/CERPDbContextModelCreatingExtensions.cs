using CERP.App;
using CERP.App.CustomEntityHistorySystem;
using CERP.FM;
using CERP.FM.COA;
using CERP.HR.Documents;
using CERP.HR.Employees;
using CERP.HR.Timesheets;
using CERP.HR.Workshifts;
using CERP.Payroll.Payrun;
using CERP.Setup;
using CERP.Users;
using Microsoft.EntityFrameworkCore;
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
                b.ToTable(CERPConsts.DbTablePrefix + "Companies", CERPConsts.DbSchema);

                b.ConfigureAudited();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(p => p.CompanyCode)
                 .UseIdentityColumn();

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

                b.HasMany(p => p.Departments).WithOne(c => c.Company).OnDelete(DeleteBehavior.ClientCascade);
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

            builder.Entity<Employee>(b =>
            {
                b.ToTable(CERPConsts.HRDbTablePrefix + "Employees", CERPConsts.HRDbSchema);

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
                b.ToTable(CERPConsts.HRDbTablePrefix + "WorkShifts", CERPConsts.HRDbSchema);

                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureSoftDelete();
                b.ConfigureMultiTenant(); b.ConfigureExtraProperties();
                b.ConfigureConcurrencyStamp();

                b.Property(x => x.Title)
                    .IsRequired();

                b.HasOne(x => x.Department).WithMany().OnDelete(DeleteBehavior.Restrict);
                b.HasMany(p => p.Employees).WithOne().OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Document>(b =>
            {
                b.ToTable(CERPConsts.HRDbTablePrefix + "Documents", CERPConsts.HRDbSchema);

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
                b.HasOne(x => x.Owner).WithMany().OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Timesheet>(b =>
            {
                b.ToTable(CERPConsts.HRDbTablePrefix + "Timesheets", CERPConsts.HRDbSchema);

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
                b.ToTable(CERPConsts.HRDbTablePrefix + "WeeklyTimesheets", CERPConsts.HRDbSchema);

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
                b.ToTable(CERPConsts.HRDbTablePrefix + "WeeklyTimesheetsJobs", CERPConsts.HRDbSchema);

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