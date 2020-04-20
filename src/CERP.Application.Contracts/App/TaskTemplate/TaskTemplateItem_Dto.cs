using CERP.Base;
using CERP.HR.Employees;
using CERP.HR.Employees.DTOs;
using CERP.Setup;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERP.App
{
    public class TaskTemplateItem_Dto : AuditedEntityTenantDto<int>
    {
        public TaskTemplateItem_Dto()
        {

        }
        public TaskTemplateItem_Dto(int id)
        {
            Id = id;
        }

        public virtual TaskTemplate_Dto TaskTemplate { get; set; }
        public int TaskTemplateId { get; set; }

        public bool Active { get; set; }

        public int RouteIndex { get; set; }

        public virtual Department_Dto? Department { get; set; }
        public Guid? DepartmentId { get; set; }
        public virtual Position_Dto? Position { get; set; }
        public Guid? PositionId { get; set; }
        public virtual Employee_Dto? Employee { get; set; }
        public Guid? EmployeeId { get; set; }

        public string TaskDescription { get; set; }
    }
}
