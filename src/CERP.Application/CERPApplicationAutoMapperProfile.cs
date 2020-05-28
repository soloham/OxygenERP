using AutoMapper;
using CERP.App;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure;
using CERP.CERP.HR.Documents;
using CERP.FM;
using CERP.FM.COA;
using CERP.FM.COA.DTOs;
using CERP.FM.COA.UV_DTOs;
using CERP.FM.DTOs;
using CERP.FM.UV_DTOs;
using CERP.HR.Attendance;
using CERP.HR.Documents;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.Employees;
using CERP.HR.Employees.DTOs;
using CERP.HR.Employees.UV_DTOs;
using CERP.HR.Holidays;
using CERP.HR.Leaves;
using CERP.HR.Loans;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.OrganizationalManagement.PayrollStructure;
using CERP.HR.Timesheets;
using CERP.HR.Workshift.DTOs;
using CERP.HR.Workshifts;
using CERP.Payroll.DTOs;
using CERP.Payroll.Payrun;
using CERP.Setup;
using CERP.Setup.DTOs;
using CERP.Users;

namespace CERP
{
    public class CERPApplicationAutoMapperProfile : Profile
    {
        public CERPApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<ApprovalRouteTemplate, ApprovalRouteTemplate_Dto>();
            CreateMap<ApprovalRouteTemplate_Dto, ApprovalRouteTemplate>();

            CreateMap<ApprovalRouteTemplateItem, ApprovalRouteTemplateItem_Dto>().ForMember(d => d.ApprovalRouteTemplate, opt => opt.Ignore()).AfterMap((x, y) => y.Initialize());
            CreateMap<ApprovalRouteTemplateItem_Dto, ApprovalRouteTemplateItem>();

            CreateMap<ApprovalRouteTemplateItemEmployee, ApprovalRouteTemplateItemEmployee_Dto>().ForMember(d => d.ApprovalRouteTemplateItem, opt => opt.Ignore());
            CreateMap<ApprovalRouteTemplateItemEmployee_Dto, ApprovalRouteTemplateItemEmployee>();

            CreateMap<TaskTemplate, TaskTemplate_Dto>();
            CreateMap<TaskTemplate_Dto, TaskTemplate>();

            CreateMap<TaskTemplateItem, TaskTemplateItem_Dto>().ForMember(d => d.TaskTemplate, opt => opt.Ignore()).AfterMap((x, y) => y.Initialize());
            CreateMap<TaskTemplateItem_Dto, TaskTemplateItem>();

            CreateMap<TaskTemplateItemEmployee, TaskTemplateItemEmployee_Dto>().ForMember(d => d.TaskTemplateItem, opt => opt.Ignore());
            CreateMap<TaskTemplateItemEmployee_Dto, TaskTemplateItemEmployee>();

            CreateMap<COA_Account, COA_Account_Dto>();
            CreateMap<COA_Account_Dto, COA_Account>();
            CreateMap<COA_Account_Dto, COA_Account_UV_Dto>();
            CreateMap<COA_Account_UV_Dto, COA_Account>();

            CreateMap<COA_AccountSubCategory, COA_AccountSubCategory_Dto>();
            CreateMap<COA_AccountSubCategory_Dto, COA_AccountSubCategory>();
            CreateMap<COA_AccountSubCategory_UV_Dto, COA_AccountSubCategory>();

            CreateMap<COA_HeadAccount, COA_HeadAccount_Dto>();
            CreateMap<COA_HeadAccount_Dto, COA_HeadAccount>();
            CreateMap<COA_HeadAccount_UV_Dto, COA_HeadAccount>();

            CreateMap<Company, Company_Dto>();
            CreateMap<Company_Dto, Company>();
            CreateMap<Company_UV_Dto, Company>();

            CreateMap<CompanyCurrency, CompanyCurrency_Dto>();
            CreateMap<CompanyCurrency_Dto, CompanyCurrency>();

            CreateMap<CompanyLocation, CompanyLocation_Dto>();
            CreateMap<CompanyLocation_Dto, CompanyLocation>();

            CreateMap<CompanyDocument, CompanyDocument_Dto>();
            CreateMap<CompanyDocument_Dto, CompanyDocument>();

            CreateMap<CompanyPrintSize, CompanyPrintSize_Dto>();
            CreateMap<CompanyPrintSize_Dto, CompanyPrintSize>();

            CreateMap<LocationTemplate, LocationTemplate_Dto>().AfterMap((x, y) => y.Initialize());
            CreateMap<LocationTemplate_Dto, LocationTemplate>();

            CreateMap<Currency, Currency_Dto>();
            CreateMap<Currency_Dto, Currency>();
            
            CreateMap<Document, Document_Dto>();
            CreateMap<Document_Dto, Document>();

            CreateMap<Department, Department_Dto>().MaxDepth(1)
                .ForMember(d => d.Positions, opt => opt.Ignore());
            CreateMap<Department_Dto, Department>().MaxDepth(1)
                .ForMember(d => d.Positions, opt => opt.Ignore());
            CreateMap<Department_UV_Dto, Department>()
                .ForMember(d => d.Positions, opt => opt.Ignore());

            CreateMap<Position, Position_Dto>().MaxDepth(1)
                .ForMember(d => d.Employee, opt => opt.Ignore());
                //.ForMember(d => d.Department, opt => opt.Ignore());
            CreateMap<Position_Dto, Position>().MaxDepth(1)
                .ForMember(d => d.Employee, opt => opt.Ignore())
                .ForMember(d => d.Department, opt => opt.Ignore());
            CreateMap<Position_UV_Dto, Position>().MaxDepth(1)
                .ForMember(d => d.Employee, opt => opt.Ignore())
                .ForMember(d => d.Department, opt => opt.Ignore());

            CreateMap<Branch, Branch_Dto>();
            CreateMap<Branch_Dto, Branch>();
            CreateMap<Branch_UV_Dto, Branch>();

            CreateMap<COA_SubLedgerRequirement, COA_SubLedgerRequirement_Dto>().ForMember(d => d.SubLedgerRequirementAccounts, opt => opt.Ignore());
            CreateMap<COA_SubLedgerRequirement_Dto, COA_SubLedgerRequirement>().ForMember(d => d.SubLedgerRequirementAccounts, opt => opt.Ignore());
            CreateMap<COA_SubLedgerRequirement_UV_Dto, COA_SubLedgerRequirement>().ForMember(d => d.SubLedgerRequirementAccounts, opt => opt.Ignore());

            CreateMap<COA_SubLedgerRequirement_Account, COA_SubLedgerRequirement_Account_Dto>().ForMember(d => d.Account, opt => opt.Ignore());
            CreateMap<COA_SubLedgerRequirement_Account_Dto, COA_SubLedgerRequirement_Account>().ForMember(d => d.Account, opt => opt.Ignore());
            CreateMap<COA_SubLedgerRequirement_Account_UV_Dto, COA_SubLedgerRequirement_Account>().ForMember(d => d.Account, opt => opt.Ignore());

            CreateMap<AccountStatementType, AccountStatementType_Dto>();
            CreateMap<AccountStatementType_Dto, AccountStatementType>();
            CreateMap<AccountStatementType_UV_Dto, AccountStatementType>();

            CreateMap<DictionaryValue, DictionaryValue_Dto>();
            CreateMap<DictionaryValue_Dto, DictionaryValue>();

            CreateMap<DictionaryValueType, DictionaryValueType_Dto>().ForMember(d => d.Values, opt => opt.Ignore());
            CreateMap<DictionaryValueType_Dto, DictionaryValueType>().ForMember(d => d.Values, opt => opt.Ignore());

            CreateMap<Employee, Employee_Dto>();
            CreateMap<Employee_Dto, Employee>();
            CreateMap<Employee_UV_Dto, Employee_Dto>();
            CreateMap<Employee_Dto, Employee_UV_Dto>();
            CreateMap<Employee_UV_Dto, Employee>();

            CreateMap<AppUser, AppUser_Dto>();
            CreateMap<AppUser_Dto, AppUser>();

            CreateMap<PhysicalID, PhysicalID_Dto>().ForMember(d => d.Employee, opt => opt.Ignore());
            CreateMap<PhysicalID_Dto, PhysicalID>().ForMember(d => d.Employee, opt => opt.Ignore());
            CreateMap<PhysicalID_UV_Dto, PhysicalID_Dto>().ForMember(d => d.Employee, opt => opt.Ignore());
            CreateMap<PhysicalID_Dto, PhysicalID_UV_Dto>().ForMember(d => d.Employee, opt => opt.Ignore());
            CreateMap<PhysicalID_UV_Dto, PhysicalID>().ForMember(d => d.Employee, opt => opt.Ignore());
            //CreateMap<DictionaryValue_UV_Dto, DictionaryValue>();

            #region HR
            #region Organizational Management
            #region Organization Structure
            CreateMap<OS_OrganizationStructureTemplate, OS_OrganizationStructureTemplate_Dto>();
            CreateMap<OS_OrganizationStructureTemplate_Dto, OS_OrganizationStructureTemplate>();
            CreateMap<OS_OrganizationStructureTemplateBusinessUnits, OS_OrganizationStructureTemplateBusinessUnits_Dto>();
            CreateMap<OS_OrganizationStructureTemplateBusinessUnits_Dto, OS_OrganizationStructureTemplateBusinessUnits>();
            CreateMap<OS_OrganizationStructureTemplateBusinessUnitPosition, OS_OrganizationStructureTemplateBusinessUnitPosition_Dto>();
            CreateMap<OS_OrganizationStructureTemplateBusinessUnitPosition_Dto, OS_OrganizationStructureTemplateBusinessUnitPosition>();
            CreateMap<OS_OrganizationStructureTemplateDivisions, OS_OrganizationStructureTemplateDivisions_Dto>();
            CreateMap<OS_OrganizationStructureTemplateDivisions_Dto, OS_OrganizationStructureTemplateDivisions>();
            CreateMap<OS_OrganizationStructureTemplateDivisionPosition, OS_OrganizationStructureTemplateDivisionPosition_Dto>();
            CreateMap<OS_OrganizationStructureTemplateDivisionPosition_Dto, OS_OrganizationStructureTemplateDivisionPosition>();
            CreateMap<OS_OrganizationStructureTemplateDepartments, OS_OrganizationStructureTemplateDepartments_Dto>();
            CreateMap<OS_OrganizationStructureTemplateDepartments_Dto, OS_OrganizationStructureTemplateDepartments>();
            CreateMap<OS_OrganizationStructureTemplateDepartmentPosition, OS_OrganizationStructureTemplateDepartmentPosition_Dto>();
            CreateMap<OS_OrganizationStructureTemplateDepartmentPosition_Dto, OS_OrganizationStructureTemplateDepartmentPosition>();

            CreateMap<OS_DivisionTemplate, OS_DivisionTemplate_Dto>();
            CreateMap<OS_DivisionTemplate_Dto, OS_DivisionTemplate>();

            CreateMap<OS_BusinessUnitTemplate, OS_BusinessUnitTemplate_Dto>();
            CreateMap<OS_BusinessUnitTemplate_Dto, OS_BusinessUnitTemplate>();
            
            CreateMap<OS_DepartmentTemplate, OS_DepartmentTemplate_Dto>();
            CreateMap<OS_DepartmentTemplate_Dto, OS_DepartmentTemplate>();
            CreateMap<OS_DepartmentSubDepartmentTemplate, OS_DepartmentSubDepartmentTemplate_Dto>();
            CreateMap<OS_DepartmentSubDepartmentTemplate_Dto, OS_DepartmentSubDepartmentTemplate>();
            CreateMap<OS_DepartmentPositionTemplate, OS_DepartmentPositionTemplate_Dto>();
            CreateMap<OS_DepartmentPositionTemplate_Dto, OS_DepartmentPositionTemplate>();
            CreateMap<OS_DepartmentCostCenterTemplate, OS_DepartmentCostCenterTemplate_Dto>();
            CreateMap<OS_DepartmentCostCenterTemplate_Dto, OS_DepartmentCostCenterTemplate>();

            CreateMap<OS_PositionTemplate, OS_PositionTemplate_Dto>();
            CreateMap<OS_PositionTemplate_Dto, OS_PositionTemplate>();
            CreateMap<OS_PositionJobTemplate, OS_PositionJobTemplate_Dto>();
            CreateMap<OS_PositionJobTemplate_Dto, OS_PositionJobTemplate>();
            CreateMap<OS_PositionTaskTemplate, OS_PositionTaskTemplate_Dto>();
            CreateMap<OS_PositionTaskTemplate_Dto, OS_PositionTaskTemplate>();
            CreateMap<OS_PositionCostCenterTemplate, OS_PositionCostCenterTemplate_Dto>();
            CreateMap<OS_PositionCostCenterTemplate_Dto, OS_PositionCostCenterTemplate>();

            CreateMap<OS_JobTemplate, OS_JobTemplate_Dto>();
            CreateMap<OS_JobTemplate_Dto, OS_JobTemplate>();
            CreateMap<OS_JobTaskTemplate, OS_JobTaskTemplate_Dto>();
            CreateMap<OS_JobTaskTemplate_Dto, OS_JobTaskTemplate>();
            CreateMap<OS_JobFunctionTemplate, OS_JobFunctionTemplate_Dto>();
            CreateMap<OS_JobFunctionTemplate_Dto, OS_JobFunctionTemplate>();
            CreateMap<OS_JobSkillTemplate, OS_JobSkillTemplate_Dto>();
            CreateMap<OS_JobSkillTemplate_Dto, OS_JobSkillTemplate>();
            CreateMap<OS_JobAcademiaTemplate, OS_JobAcademiaTemplate_Dto>();
            CreateMap<OS_JobAcademiaTemplate_Dto, OS_JobAcademiaTemplate>();
            CreateMap<OS_JobWorkshiftTemplate, OS_JobWorkshiftTemplate_Dto>();
            CreateMap<OS_JobWorkshiftTemplate_Dto, OS_JobWorkshiftTemplate>();

            CreateMap<OS_TaskTemplate, OS_TaskTemplate_Dto>();
            CreateMap<OS_TaskTemplate_Dto, OS_TaskTemplate>();
            CreateMap<OS_TaskSkillTemplate, OS_TaskSkillTemplate_Dto>();
            CreateMap<OS_TaskSkillTemplate_Dto, OS_TaskSkillTemplate>();
            CreateMap<OS_TaskAcademiaTemplate, OS_TaskAcademiaTemplate_Dto>();
            CreateMap<OS_TaskAcademiaTemplate_Dto, OS_TaskAcademiaTemplate>();
            
            CreateMap<OS_FunctionTemplate, OS_FunctionTemplate_Dto>();
            CreateMap<OS_FunctionTemplate_Dto, OS_FunctionTemplate>();
            CreateMap<OS_FunctionSkillTemplate, OS_FunctionSkillTemplate_Dto>();
            CreateMap<OS_FunctionSkillTemplate_Dto, OS_FunctionSkillTemplate>();
            CreateMap<OS_FunctionAcademiaTemplate, OS_FunctionAcademiaTemplate_Dto>();
            CreateMap<OS_FunctionAcademiaTemplate_Dto, OS_FunctionAcademiaTemplate>();

            CreateMap<OS_SkillTemplate, OS_SkillTemplate_Dto>();
            CreateMap<OS_SkillTemplate_Dto, OS_SkillTemplate>();
            CreateMap<OS_AcademiaTemplate, OS_AcademiaTemplate_Dto>();
            CreateMap<OS_AcademiaTemplate_Dto, OS_AcademiaTemplate>();

            CreateMap<OS_CompensationMatrixTemplate, OS_CompensationMatrixTemplate_Dto>();
            CreateMap<OS_CompensationMatrixTemplate_Dto, OS_CompensationMatrixTemplate>();
            #endregion
            #region PayrollStructure
            CreateMap<PS_PayGroup, PS_PayGroup_Dto>();
            CreateMap<PS_PayGroup_Dto, PS_PayGroup>();

            CreateMap<PS_PayRange, PS_PayRange_Dto>();
            CreateMap<PS_PayRange_Dto, PS_PayRange>();

            CreateMap<PS_PayGrade, PS_PayGrade_Dto>();
            CreateMap<PS_PayGrade_Dto, PS_PayGrade>();

            CreateMap<PS_PayComponent, PS_PayComponent_Dto>();
            CreateMap<PS_PayComponent_Dto, PS_PayComponent>();

            CreateMap<PS_PayComponentType, PS_PayComponentType_Dto>();
            CreateMap<PS_PayComponentType_Dto, PS_PayComponentType>();

            CreateMap<PS_PayFrequency, PS_PayFrequency_Dto>();
            CreateMap<PS_PayFrequency_Dto, PS_PayFrequency>();
            #endregion
            #endregion
            #endregion

            CreateMap<WorkShift, WorkShift_Dto>();
            CreateMap<WorkShift_Dto, WorkShift>();

            CreateMap<DeductionMethod, DeductionMethod_Dto>().ForMember(d => d.WorkShifts, opt => opt.Ignore());
            CreateMap<DeductionMethod_Dto, DeductionMethod>();

            CreateMap<Timesheet, Timesheet_Dto>().AfterMap((ts, tsDto) => tsDto.Initialize());
            CreateMap<Timesheet_Dto, Timesheet>();
            CreateMap<TimesheetWeekSummary, TimesheetWeekSummary_Dto>().ForMember(d => d.Timesheet, opt => opt.Ignore()).AfterMap((tws, twsDto) => twsDto.Initialize());
            CreateMap<TimesheetWeekSummary_Dto, TimesheetWeekSummary>().ForMember(d => d.Timesheet, opt => opt.Ignore());
            CreateMap<TimesheetWeekJobSummary, TimesheetWeekJobSummary_Dto>().ForMember(d => d.WeekSheet, opt => opt.Ignore());
            CreateMap<TimesheetWeekJobSummary_Dto, TimesheetWeekJobSummary>().ForMember(d => d.WeekSheet, opt => opt.Ignore());

            CreateMap<Payrun, Payrun_Dto>();
            CreateMap<Payrun_Dto, Payrun>();
            CreateMap<PayrunDetail, PayrunDetail_Dto>().ForMember(d => d.Payrun, opt => opt.Ignore());
            CreateMap<PayrunDetail_Dto, PayrunDetail>().ForMember(d => d.Payrun, opt => opt.Ignore());
            CreateMap<PayrunAllowanceSummary, PayrunAllowanceSummary_Dto>();
            CreateMap<PayrunAllowanceSummary_Dto, PayrunAllowanceSummary>();
            //CreateMap<Payslip, Payslip_Dto>().ForMember(d => d.Payrun, opt => opt.Ignore());
            //CreateMap<Payslip_Dto, Payslip>().ForMember(d => d.Payrun, opt => opt.Ignore());

            CreateMap<SISetup, SISetup_Dto>();
            CreateMap<SISetup_Dto, SISetup>();
            CreateMap<SIContributionCategory, SIContributionCategory_Dto>().ForMember(d => d.Setup, opt => opt.Ignore());
            CreateMap<SIContributionCategory_Dto, SIContributionCategory>().ForMember(d => d.Setup, opt => opt.Ignore());
            CreateMap<SIContribution, SIContribution_Dto>().ForMember(d => d.SICategory, opt => opt.Ignore());
            CreateMap<SIContribution_Dto, SIContribution>().ForMember(d => d.SICategory, opt => opt.Ignore());

            CreateMap<PayrunDetailIndemnity, PayrunDetailIndemnity_Dto>().ForMember(d => d.PayrunDetail, opt => opt.Ignore());
            CreateMap<PayrunDetailIndemnity_Dto, PayrunDetailIndemnity>().ForMember(d => d.PayrunDetail, opt => opt.Ignore());

            CreateMap<LeaveRequestTemplate, LeaveRequestTemplate_Dto>();
            CreateMap<LeaveRequestTemplate_Dto, LeaveRequestTemplate>();

            CreateMap<LeaveRequestTemplateDepartment, LeaveRequestTemplateDepartment_Dto>().ForMember(d => d.LeaveRequestTemplate, opt => opt.Ignore());
            CreateMap<LeaveRequestTemplateDepartment_Dto, LeaveRequestTemplateDepartment>();

            CreateMap<LeaveRequestTemplatePosition, LeaveRequestTemplatePosition_Dto>().ForMember(d => d.LeaveRequestTemplate, opt => opt.Ignore());
            CreateMap<LeaveRequestTemplatePosition_Dto, LeaveRequestTemplatePosition>();

            CreateMap<LeaveRequestTemplateEmploymentType, LeaveRequestTemplateEmploymentType_Dto>().ForMember(d => d.LeaveRequestTemplate, opt => opt.Ignore());
            CreateMap<LeaveRequestTemplateEmploymentType_Dto, LeaveRequestTemplateEmploymentType>();

            CreateMap<LeaveRequestTemplateEmployeeStatus, LeaveRequestTemplateEmployeeStatus_Dto>().ForMember(d => d.LeaveRequestTemplate, opt => opt.Ignore());
            CreateMap<LeaveRequestTemplateEmployeeStatus_Dto, LeaveRequestTemplateEmployeeStatus>();

            CreateMap<LeaveRequestTemplateHoliday, LeaveRequestTemplateHoliday_Dto>().ForMember(d => d.LeaveRequestTemplate, opt => opt.Ignore());
            CreateMap<LeaveRequestTemplateHoliday_Dto, LeaveRequestTemplateHoliday>();

            CreateMap<LoanRequestTemplate, LoanRequestTemplate_Dto>();
            CreateMap<LoanRequestTemplate_Dto, LoanRequestTemplate>();

            CreateMap<LoanRequestTemplateDepartment, LoanRequestTemplateDepartment_Dto>().ForMember(d => d.LoanRequestTemplate, opt => opt.Ignore());
            CreateMap<LoanRequestTemplateDepartment_Dto, LoanRequestTemplateDepartment>();

            CreateMap<LoanRequestTemplatePosition, LoanRequestTemplatePosition_Dto>().ForMember(d => d.LoanRequestTemplate, opt => opt.Ignore());
            CreateMap<LoanRequestTemplatePosition_Dto, LoanRequestTemplatePosition>();

            CreateMap<LoanRequestTemplateEmploymentType, LoanRequestTemplateEmploymentType_Dto>().ForMember(d => d.LoanRequestTemplate, opt => opt.Ignore());
            CreateMap<LoanRequestTemplateEmploymentType_Dto, LoanRequestTemplateEmploymentType>();

            CreateMap<LoanRequestTemplateEmployeeStatus, LoanRequestTemplateEmployeeStatus_Dto>().ForMember(d => d.LoanRequestTemplate, opt => opt.Ignore());
            CreateMap<LoanRequestTemplateEmployeeStatus_Dto, LoanRequestTemplateEmployeeStatus>();

            CreateMap<Holiday, Holiday_Dto>();
            CreateMap<Holiday_Dto, Holiday>();

            CreateMap<Attendance, Attendance_Dto>();
            CreateMap<Attendance_Dto, Attendance>();
        }
    }
}
