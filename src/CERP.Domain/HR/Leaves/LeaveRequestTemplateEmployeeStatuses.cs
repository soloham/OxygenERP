using CERP.App;
using CERP.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplateEmployeeStatus : AuditedAggregateTenantRoot<int>
    {
        public LeaveRequestTemplateEmployeeStatus()
        {

        }

        public virtual LeaveRequestTemplate LeaveRequestTemplate { get; set; }
        public int LeaveRequestTemplateId;

        public virtual DictionaryValue EmployeeStatus { get; set; }
        public Guid? EmployeeStatusId;
    }
}
