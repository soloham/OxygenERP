using Microsoft.EntityFrameworkCore;
using CERP.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users.EntityFrameworkCore;
using CERP.FM.COA;
using CERP.FM;
using CERP.App;
using CERP.HR.EmployeeCentral.Employee;
using CERP.Setup;
using CERP.HR.Workshifts;
using CERP.HR.Documents;
using CERP.HR.Timesheets;
using CERP.Payroll.Payrun;
using CERP.App.CustomEntityHistorySystem;
using CERP.HR.Leaves;
using CERP.HR.Holidays;
using CERP.HR.Attendance;
using CERP.HR.Loans;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.OrganizationalManagement.PayrollStructure;

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

        public DbSet<ApprovalRouteTemplate> ApprovalRouteTemplates { get; set; }
        public DbSet<ApprovalRouteTemplateItem> ApprovalRouteTemplateItems { get; set; }
        public DbSet<ApprovalRouteTemplateItemEmployee> ApprovalRouteTemplateItemEmployees { get; set; }

        public DbSet<TaskTemplate> TaskTemplates { get; set; }
        public DbSet<TaskTemplateItem> TaskTemplateItems { get; set; }
        public DbSet<TaskTemplateItemEmployee> TaskTemplateItemEmployees { get; set; }

        public DbSet<CustomEntityChange> CustomEntityChanges { get; set; }
        public DbSet<CustomEntityPropertyChange> CustomEntityPropertyChanges { get; set; }

        public DbSet<COA_Account> COAs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyLocation> CompanyLocations { get; set; }
        public DbSet<CompanyCurrency> CompanyCurrencies { get; set; }
        public DbSet<CompanyPrintSize> CompanyPrintSizes { get; set; }
        public DbSet<CompanyDocument> CompanyDocuments { get; set; }
        public DbSet<LocationTemplate> LocationTemplates { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<COA_HeadAccount> COAHeadAccounts { get; set; }
        public DbSet<COA_AccountSubCategory> COASubCategories { get; set; }
        public DbSet<COA_SubLedgerRequirement> SubLedgerRequirements { get; set; }

        public DbSet<AccountStatementType> AccountStatementTypes { get; set; }

        public DbSet<DictionaryValue> ValuesDictionary { get; set; }
        public DbSet<DictionaryValueType> ValueTypesDictionary { get; set; }

        #region HR
        #region Organizational Management
        #region Organization Structure
        public DbSet<OS_OrganizationStructureTemplate> OS_OrganizationStructureTemplates { get; set; }
        public DbSet<OS_OrganizationStructureTemplateBusinessUnit> OS_OrganizationStructureTemplateBusinessUnits { get; set; }
        public DbSet<OS_OrganizationStructureTemplateBusinessUnitPosition> OS_OrganizationStructureTemplateBusinessUnitPositions { get; set; }
        public DbSet<OS_OrganizationStructureTemplateBusinessUnitCostCenter> OS_OrganizationStructureTemplateBusinessUnitCostCenters { get; set; }
        public DbSet<OS_OrganizationStructureTemplateDivision> OS_OrganizationStructureTemplateDivisions { get; set; }
        public DbSet<OS_OrganizationStructureTemplateDivisionPosition> OS_OrganizationStructureTemplateDivisionPositions { get; set; }
        public DbSet<OS_OrganizationStructureTemplateDivisionCostCenter> OS_OrganizationStructureTemplateDivisionCostCenters { get; set; }
        public DbSet<OS_OrganizationStructureTemplateDepartment> OS_OrganizationStructureTemplateDepartments { get; set; }
        public DbSet<OS_OrganizationStructureTemplateDepartmentPosition> OS_OrganizationStructureTemplateDepartmentPositions { get; set; }
        public DbSet<OS_OrganizationStructureTemplateDepartmentCostCenter> OS_OrganizationStructureTemplateDepartmentCostCenters { get; set; }
         public DbSet<OS_OrganizationStructureTemplatePosition> OS_OrganizationStructureTemplatePositions { get; set; }
        public DbSet<OS_OrganizationStructureTemplatePositionJob> OS_OrganizationStructureTemplatePositionJobs { get; set; }

        public DbSet<OS_BusinessUnitTemplate> OS_BusinessUnitTemplates { get; set; }
        public DbSet<OS_DivisionTemplate> OS_DivisionTemplates { get; set; }

        public DbSet<OS_DepartmentTemplate> OS_DepartmentTemplates { get; set; }
        //public DbSet<OS_DepartmentPositionTemplate> OS_DepartmentPositionTemplates { get; set; }
        public DbSet<OS_DepartmentSubDepartmentTemplate> OS_DepartmentSubDepartmentTemplates { get; set; }
        public DbSet<OS_DepartmentCostCenterTemplate> OS_DepartmentCostCenterTemplates { get; set; }

        public DbSet<OS_PositionTemplate> OS_PositionTemplates { get; set; }
        public DbSet<OS_PositionJobTemplate> OS_PositionJobTemplates { get; set; }
        //public DbSet<OS_PositionTaskTemplate> OS_PositionTaskTemplates { get; set; }
        public DbSet<OS_PositionCostCenterTemplate> OS_PositionCostCenterTemplates { get; set; }

        public DbSet<OS_JobTemplate> OS_JobTemplates { get; set; }
        //public DbSet<OS_JobQualificationTemplate> OS_JobQualificationTemplates { get; set; }
        public DbSet<OS_JobTaskTemplate> OS_JobTaskTemplate { get; set; }
        public DbSet<OS_JobFunctionTemplate> OS_JobFunctionTemplates { get; set; }
        public DbSet<OS_JobSkillTemplate> OS_JobSkillTemplates { get; set; }
        public DbSet<OS_JobAcademiaTemplate> OS_JobAcademiaTemplates { get; set; }
        public DbSet<OS_JobWorkshiftTemplate> OS_JobWorkshiftTemplates { get; set; }

        public DbSet<OS_TaskTemplate> OS_TaskTemplates { get; set; }
        //public DbSet<OS_TaskQualificationTemplate> OS_TaskQualificationTemplates { get; set; }
        public DbSet<OS_TaskSkillTemplate> OS_TaskSkillTemplates { get; set; }
        public DbSet<OS_TaskAcademiaTemplate> OS_TaskAcademiaTemplates { get; set; }

        public DbSet<OS_FunctionTemplate> OS_FunctionTemplates { get; set; }
        public DbSet<OS_FunctionSkillTemplate> OS_FunctionSkillTemplates { get; set; }
        public DbSet<OS_FunctionAcademiaTemplate> OS_FunctionAcademiaTemplates { get; set; }

        public DbSet<OS_SkillTemplate> OS_SkillTemplates { get; set; }
        public DbSet<OS_AcademiaTemplate> OS_AcademiaTemplates { get; set; }

        public DbSet<OS_CompensationMatrixTemplate> OS_CompensationMatrixTemplates { get; set; }
        #endregion
        #region Payroll Structure
        public DbSet<PS_PayGroup> PayGroups { get; set; }
        public DbSet<PS_PaySubGroup> PaySubGroups { get; set; }
        public DbSet<PS_PaySubGroupBank> PaySubGroupBanks { get; set; }
        public DbSet<PS_PaymentBank> PaymentBanks { get; set; }

        public DbSet<PS_PaymentBankFile> PaymentBankFiles { get; set; }
        public DbSet<PS_PaymentCashFile> PaymentCashFiles { get; set; }
        public DbSet<PS_PaymentChequeFile> PaymentChequeFiles { get; set; }
        public DbSet<PS_PaymentBankFileBank> PaymentBankFileBanks { get; set; }

        public DbSet<PS_PayrollPeriod> PayrollPeriods { get; set; }
        public DbSet<PS_PayPeriod> PayPeriods { get; set; }
        public DbSet<PS_PaySubGroupBusinessUnit> PaySubGroupBusinessUnits { get; set; }
        public DbSet<PS_PaySubGroupBusinessUnitDivision> PaySubGroupBusinessUnitDivisions { get; set; }
        public DbSet<PS_PaySubGroupBusinessUnitDivisionDepartment> PaySubGroupBusinessUnitDivisionDepartments { get; set; }

        public DbSet<PS_PayRange> PayRanges { get; set; }
        public DbSet<PS_PayGrade> PayGrades { get; set; }

        public DbSet<PS_PayGradeComponent> PayGradeComponents { get; set; }
        public DbSet<PS_PayComponent> PayComponents { get; set; }
        public DbSet<PS_PayComponentType> PayComponentTypes { get; set; }
        public DbSet<PS_PayFrequency> PayFrequencies { get; set; }
        #endregion
        #endregion
        #region Employee Central
        #region Objects
        public DbSet<Disability> Disabilities { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<HomeAddress> HomeAddresses { get; set; }
        public DbSet<PhoneAddress> PhoneAddresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<NationalIdentity> NationalIdentities { get; set; }
        public DbSet<PassportTravelDocument> PassportTravelDocuments { get; set; }

        public DbSet<PrimaryValidityAttachment> PrimaryValidityAttachments { get; set; }
        #endregion
        #region Employee
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeLoan> EmployeeLoans { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Dependant> Dependants { get; set; }
        #endregion
        #region Bio
        public DbSet<EmployeeDisability> EmployeeDisabilities { get; set; }
        #endregion
        #region Addresses
        public DbSet<EmployeeEmailAddress> EmployeeEmailAddresses { get; set; }
        public DbSet<EmployeeHomeAddress> EmployeeHomeAddresses { get; set; }
        public DbSet<EmployeePhoneAddress> EmployeePhoneAddresses { get; set; }
        #endregion
        #region Contact
        public DbSet<EmployeeContact> EmployeeContacts { get; set; }
        #endregion
        #region Identities
        public DbSet<EmployeePrimaryValidityAttachment> EmployeePrimaryValidityAttachments { get; set; }
        public DbSet<DependantNationalIdentity> DependantNationalIdentities { get; set; }
        public DbSet<EmployeePassportTravelDocument> EmployeePassportTravelDocuments { get; set; }
        public DbSet<EmployeeSponsorLegalEntity> EmployeeSponsorLegalEntities { get; set; }
        public DbSet<DependantPassportTravelDocument> DependantPassportTravelDocuments { get; set; }
        #endregion
        #region Payment Types
        public DbSet<BankPaymentType> BankPaymentTypes { get; set; }
        public DbSet<CashPaymentType> CashPaymentTypes { get; set; }
        public DbSet<ChequePaymentType> ChequePaymentTypes { get; set; }
        #region Academia Skills Profile
        public DbSet<EC_AcademiaTemplate> AcademiaTemplates { get; set; }
        public DbSet<EC_SkillTemplate> SkillsTemplates { get; set; }
        #endregion
        #endregion
        #endregion
        #endregion

        public DbSet<Document> Documents { get; set; }
        public DbSet<WorkShift> WorkShifts { get; set; }
        public DbSet<DeductionMethod> DeductionMethods { get; set; }

        public DbSet<Timesheet> TimeSheets { get; set; }
        public DbSet<TimesheetWeekSummary> WeeklySheets { get; set; }
        public DbSet<TimesheetWeekJobSummary> WeeklySheetsJobs { get; set; }

        public DbSet<Payrun> Payruns { get; set; }
        public DbSet<PayrunAllowanceSummary> PayrunAllowancesSummaries { get; set; }
        public DbSet<PayrunDetail> PayrunDetails { get; set; }
        public DbSet<Payslip> Payslips { get; set; }

        public DbSet<SISetup> SISetup { get; set; }
        public DbSet<SIContributionCategory> SIContributionCategories { get; set; }
        public DbSet<SIContribution> SIContributions { get; set; }

        public DbSet<PayrunDetailIndemnity> PayrunDetailIndemnities { get; set; }

        public DbSet<LeaveRequestTemplate> LeaveRequestTemplates { get; set; }
        public DbSet<LeaveRequestTemplateDepartment> LeaveRequestTemplateDepartment { get; set; }
        public DbSet<LeaveRequestTemplatePosition> LeaveRequestTemplatePosition { get; set; }
        public DbSet<LeaveRequestTemplateEmployeeStatus> LeaveRequestTemplateEmployeeStatus { get; set; }
        public DbSet<LeaveRequestTemplateEmploymentType> LeaveRequestTemplateEmploymentType { get; set; }
        public DbSet<LeaveRequestTemplateHoliday> LeaveRequestTemplateHoliday { get; set; }

        public DbSet<LoanRequestTemplate> LoanRequestTemplates { get; set; }
        public DbSet<LoanRequestTemplateDepartment> LoanRequestTemplateDepartment { get; set; }
        public DbSet<LoanRequestTemplatePosition> LoanRequestTemplatePosition { get; set; }
        public DbSet<LoanRequestTemplateEmployeeStatus> LoanRequestTemplateEmployeeStatus { get; set; }
        public DbSet<LoanRequestTemplateEmploymentType> LoanRequestTemplateEmploymentType { get; set; }

        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Attendance> Attendance { get; set; }

        public CERPDbContext(DbContextOptions<CERPDbContext> options)
            : 
            base(options)
        {
            //options.UseLazyLoadingProxies();
        
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

                //b.ConfigureFullAuditedAggregateRoot();
                //b.ConfigureSoftDelete();
                //b.ConfigureExtraProperties();
                //b.ConfigureConcurrencyStamp();

                //Moved customization to a method so we can share it with the CERPMigrationsDbContext class
                b.ConfigureCustomUserProperties(false);
            });

            /* Configure your own tables/entities inside the ConfigureCERP method */

            builder.ConfigureCERP();
        }
    }
}
