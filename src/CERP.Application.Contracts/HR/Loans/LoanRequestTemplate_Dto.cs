using CERP.App;
using CERP.Base;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;

namespace CERP.HR.Loans
{
    public class LoanRequestTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public LoanRequestTemplate_Dto()
        {

        }
        public LoanRequestTemplate_Dto(int id)
        {
            Id = id;
        }

        public string Title { get; set; }
        public string TitleLocalized { get; set; }
        public string Prefix { get; set; }
        public int StartingNo { get; set; }

        public DictionaryValue_Dto LoanType { get; set; }
        public Guid LoanTypeId { get; set; }

        public string GetAllDepartments { 
            get {
                string result = "";
                try
                {
                    if (Departments != null && Departments.Count > 0)
                    {
                        int i = 0;
                        foreach (LoanRequestTemplateDepartment_Dto department in Departments)
                        {
                            result += department.Department.Name + (i < Departments.Count - 1 ? ", " : "");
                            i++;
                        }
                    }
                }
                catch { }
                return result;
            } 
        }
        public List<LoanRequestTemplateDepartment_Dto> Departments { get; set; }
        public string GetAllPositions
        {
            get
            {
                string result = "";
                try
                {
                    if (Positions != null && Positions.Count > 0)
                    {
                        int i = 0;
                        foreach (LoanRequestTemplatePosition_Dto position in Positions)
                        {
                            result += position.Position.Title + (i < Positions.Count - 1 ? ", " : "");
                            i++;
                        }
                    }
                }
                catch { }
                return result;
            }
        }
        public List<LoanRequestTemplatePosition_Dto> Positions { get; set; }
        public string GetAllEmploymentTypes
        {
            get
            {
                string result = "";
                try
                {
                    if (EmploymentTypes != null && EmploymentTypes.Count > 0)
                    {
                        int i = 0;
                        foreach (LoanRequestTemplateEmploymentType_Dto employmentType in EmploymentTypes)
                        {
                            result += employmentType.EmploymentType.Value + (i < EmploymentTypes.Count - 1 ? ", " : "");
                            i++;
                        }
                    }
                }
                catch { }
                return result;
            }
        }
        public List<LoanRequestTemplateEmploymentType_Dto> EmploymentTypes { get; set; }
        public string GetAllEmployeeStatuses
        {
            get
            {
                string result = "";
                try
                {
                    if (EmployeeStatuses != null && EmployeeStatuses.Count > 0)
                    {
                        int i = 0;
                        foreach (LoanRequestTemplateEmployeeStatus_Dto employeeStatus in EmployeeStatuses)
                        {
                            result += employeeStatus.EmployeeStatus.Value + (i < EmployeeStatuses.Count - 1 ? ", " : "");
                            i++;
                        }
                    }
                }
                catch { }
                return result;
            }
        }
        public List<LoanRequestTemplateEmployeeStatus_Dto> EmployeeStatuses { get; set; }

        public int MinEmployeeDependants { get; set; }
        public double MaxIndemnityLimit { get; set; }

        public int MaxInstallmentsLimit { get; set; }
        public double MaxInstallmentAmount { get; set; }

        public virtual ApprovalRouteTemplate_Dto ApprovalRouteTemplate { get; set; }
        public int ApprovalRouteTemplateId { get; set; }
    }
}
