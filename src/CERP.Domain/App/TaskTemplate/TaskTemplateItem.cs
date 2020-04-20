using CERP.Base;
using CERP.HR.Employees;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERP.App
{
    public class TaskTemplateItem : AuditedAggregateTenantRoot<int>
    {
        public TaskTemplateItem()
        {

        }
        public TaskTemplateItem(int id)
        {
            Id = id;
        }

        public virtual TaskTemplate TaskTemplate { get; set; }
        public int TaskTemplateId { get; set; }

        public bool Active { get; set; }

        public int RouteIndex { get; set; }

        public virtual Department? Department { get; set; }
        public Guid? DepartmentId { get; set; }
        public virtual Position? Position { get; set; }
        public Guid? PositionId { get; set; }
        public virtual Employee? Employee { get; set; }
        public Guid? EmployeeId { get; set; }

        public string TaskDescription { get; set; }
    }
}
