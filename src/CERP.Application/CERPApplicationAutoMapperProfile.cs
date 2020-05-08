﻿using AutoMapper;
using CERP.App;
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
            
            CreateMap<LocationTemplate, LocationTemplate_Dto>().AfterMap((x, y) => y.Initialize());
            CreateMap<LocationTemplate_Dto, LocationTemplate>();

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

            CreateMap<WorkShift, WorkShift_Dto>().ForMember(d => d.Employees, opt => opt.Ignore());
            CreateMap<WorkShift_Dto, WorkShift>().ForMember(d => d.Employees, opt => opt.Ignore());

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
