using CERP.Base;
using CERP.HR.Employees.DTOs;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;

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
                Department = new List<Department_Dto>() { new Department_Dto() { Name = "Selected" } };
                Position = new List<Position_Dto>(){ new Position_Dto() { Title = "Head" } };
                ApprovalRouteEmployees = new List<ApprovalRouteTemplateItemEmployee_Dto> { new ApprovalRouteTemplateItemEmployee_Dto() { Employee = new Employee_Dto() { FirstName = "Auto" } } };
            }
            else if(IsReportingTo)
            {
                Department = new List<Department_Dto>() { new Department_Dto() { Name = "Selected" } };
                Position = new List<Position_Dto>() { new Position_Dto() { Title = "Auto" } };
                ApprovalRouteEmployees = new List<ApprovalRouteTemplateItemEmployee_Dto> { new ApprovalRouteTemplateItemEmployee_Dto() { Employee = new Employee_Dto() { FirstName = "Auto [Reporting To]" } } };
            }
        }

        public virtual ApprovalRouteTemplate_Dto ApprovalRouteTemplate { get; set; }
        public int ApprovalRouteTemplateId { get; set; }

        public bool Active { get; set; }

        public int RouteIndex { get; set; }

        public bool IsDepartmentHead { get; set; }
        public bool IsReportingTo { get; set; }

        public virtual List<Department_Dto> Department { get; set; }
        
        public virtual List<Position_Dto> Position { get; set; }

        public virtual List<ApprovalRouteTemplateItemEmployee_Dto> ApprovalRouteEmployees { get; set; }

        public bool IsAny { get; set; }

        public bool NotifyEmployee { get; set; }
        public bool IsPoster { get; set; }

        public virtual TaskTemplate_Dto? TaskTemplate { get; set; }
        public int? TaskTemplateId { get; set; }
    }
}
