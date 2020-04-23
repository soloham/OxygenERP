using CERP.Base;
using CERP.HR.Employees.DTOs;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CERP.App
{
    public class ApprovalRouteTemplateItem_Dto : AuditedEntityTenantDto<int>
    {
        public ApprovalRouteTemplateItem_Dto()
        {

        }
        public ApprovalRouteTemplateItem_Dto(int id)
        {
            Id = id;
        }

        public void Initialize()
        {
            if(IsDepartmentHead)
            {
                Departments = new List<Department_Dto>() { new Department_Dto() { Name = "Selected" } };
                Positions = new List<Position_Dto>(){ new Position_Dto() { Title = "Head" } };
                ApprovalRouteItemEmployees = new List<ApprovalRouteTemplateItemEmployee_Dto> { new ApprovalRouteTemplateItemEmployee_Dto() { Employee = new Employee_Dto() { FirstName = "Auto" } } };
            }
            else if(IsReportingTo)
            {
                Departments = new List<Department_Dto>() { new Department_Dto() { Name = "Selected" } };
                Positions = new List<Position_Dto>() { new Position_Dto() { Title = "Auto" } };
                ApprovalRouteItemEmployees = new List<ApprovalRouteTemplateItemEmployee_Dto> { new ApprovalRouteTemplateItemEmployee_Dto() { Employee = new Employee_Dto() { FirstName = "Auto [Reporting To]" } } };
            }
            else
            {
                if (ApprovalRouteItemEmployees != null && ApprovalRouteItemEmployees.Count > 0)
                {
                    Departments = ApprovalRouteItemEmployees.Select(x => x.Employee.Department).ToList();
                    Positions = ApprovalRouteItemEmployees.Select(x => x.Employee.Position).ToList();
                }
            }
        }

        public virtual ApprovalRouteTemplate_Dto ApprovalRouteTemplate { get; set; }
        public int ApprovalRouteTemplateId { get; set; }

        public bool Active { get; set; }

        public int RouteIndex { get; set; }

        public bool IsDepartmentHead { get; set; }
        public bool IsReportingTo { get; set; }

        public string GetAllDepartmentNames
        {
            get
            {
                string result = "";
                try
                {
                    if (Departments != null && Departments.Count > 0)
                    {
                        int i = 0;
                        foreach (Department_Dto department in Departments)
                        {
                            result += department.Name + (i < Departments.Count - 1 ? ", " : "");
                            i++;
                        }
                    }
                }
                catch { }
                return result;
            }
        }
        public virtual List<Department_Dto> Departments { get; set; }

        public string GetAllPositionTitles
        {
            get
            {
                string result = "";
                try
                {
                    if (Positions != null && Positions.Count > 0)
                    {
                        int i = 0;
                        foreach (Position_Dto position in Positions)
                        {
                            result += position.Title + (i < Positions.Count - 1 ? ", " : "");
                            i++;
                        }
                    }
                }
                catch { }
                return result;
            }
        }
        public virtual List<Position_Dto> Positions { get; set; }

        public string GetAllEmployeeNames
        {
            get
            {
                string result = "";
                try
                {
                    if (ApprovalRouteItemEmployees != null && ApprovalRouteItemEmployees.Count > 0)
                    {
                        int i = 0;
                        foreach (ApprovalRouteTemplateItemEmployee_Dto ApprovalRouteEmployee in ApprovalRouteItemEmployees)
                        {
                            result += ApprovalRouteEmployee.Employee.Name + (i < ApprovalRouteItemEmployees.Count - 1 ? ", " : "");
                            i++;
                        }
                    }
                }
                catch { }
                return result;
            }
        }
        public virtual List<ApprovalRouteTemplateItemEmployee_Dto> ApprovalRouteItemEmployees { get; set; }

        public bool IsAny { get; set; }

        public bool NotifyEmployee { get; set; }
        public bool IsPoster { get; set; }

        public virtual TaskTemplate_Dto? TaskTemplate { get; set; }
        public int? TaskTemplateId { get; set; }
    }
}
