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
