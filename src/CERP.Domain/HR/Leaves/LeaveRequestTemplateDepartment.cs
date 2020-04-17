using CERP.Base;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplateDepartment : AuditedAggregateTenantRoot<int>
    {
        public LeaveRequestTemplateDepartment()
        {

        }

        public virtual LeaveRequestTemplate LeaveRequestTemplate { get; set; }
        public int LeaveRequestTemplateId;

        public virtual Department Department { get; set; }
        public Guid DepartmentId;
    }
}
