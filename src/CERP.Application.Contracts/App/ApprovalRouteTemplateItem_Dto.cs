using CERP.Base;
using CERP.HR.Employees.DTOs;
using CERP.Setup.DTOs;
using System;

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
                Department = new Department_Dto() { Name = "Selected" };
                Position = new Position_Dto() { Title = "Head" };
                Employee = new Employee_Dto() { FirstName = "Auto" };
            }
            else if(IsReportingTo)
            {
                Department = new Department_Dto() { Name = "Selected" };
                Position = new Position_Dto() { Title = "Auto" };
                Employee = new Employee_Dto() { FirstName = "Auto [Reporting To]" };
            }
        }

        public virtual ApprovalRouteTemplate_Dto ApprovalRouteTemplate { get; set; }
        public int ApprovalRouteTemplateId { get; set; }

        public bool Active { get; set; }

        public int RouteIndex { get; set; }

        public bool IsDepartmentHead { get; set; }
        public bool IsReportingTo { get; set; }

        public virtual Department_Dto Department { get; set; }
        public Guid? DepartmentId { get; set; }
        
        public virtual Position_Dto Position { get; set; }
        public Guid? PositionId { get; set; }

        public virtual Employee_Dto Employee { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}
