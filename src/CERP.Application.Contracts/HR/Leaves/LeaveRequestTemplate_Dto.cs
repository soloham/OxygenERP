using CERP.App;
using CERP.Base;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public LeaveRequestTemplate_Dto()
        {

        }
        public LeaveRequestTemplate_Dto(int id)
        {
            Id = id;
        }

        public string Title { get; set; }
        public string TitleLocalized { get; set; }
        public string Prefix { get; set; }
        public int StartingNo { get; set; }
        public int EntitlementDays { get; set; }

        public string GetAllDepartments { get {
                string result = "";
                try
                {
                    if (Departments != null && Departments.Count > 0)
                    {
                        int i = 0;
                        foreach (LeaveRequestTemplateDepartment_Dto department in Departments)
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
        public virtual ICollection<LeaveRequestTemplateDepartment_Dto> Departments { get; set; }
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
                        foreach (LeaveRequestTemplatePosition_Dto position in Positions)
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
        public virtual ICollection<LeaveRequestTemplatePosition_Dto> Positions { get; set; }
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
                        foreach (LeaveRequestTemplateEmploymentType_Dto employmentType in EmploymentTypes)
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
        public virtual ICollection<LeaveRequestTemplateEmploymentType_Dto> EmploymentTypes { get; set; }
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
                        foreach (LeaveRequestTemplateEmployeeStatus_Dto employeeStatus in EmployeeStatuses)
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
        public virtual ICollection<LeaveRequestTemplateEmployeeStatus_Dto> EmployeeStatuses { get; set; }

        public ApprovalRouteTemplate_Dto ApprovalRouteTemplate { get; set; }

        public bool HasAdvanceSalaryRequest { get; set; }
        public bool HasExitReentryRequest { get; set; }
        public bool HasAirTicketRequest { get; set; }

        public bool HasNotesRequirement { get; set; }
        public bool HasAttachmentRequirement { get; set; }
    }
    
}
