using CERP.Base;
using CERP.HR.Employees;
using System;

namespace CERP.App
{
    public class TaskTemplateItemEmployee : AuditedAggregateTenantRoot<int>
    {
        public TaskTemplateItemEmployee()
        {

        }

        public virtual TaskTemplateItem TaskTemplateItem { get; set; }
        public int TaskTemplateItemId;

        public virtual Employee Employee { get; set; }
        public Guid EmployeeId;
    }
}
