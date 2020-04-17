using CERP.App;
using CERP.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplateEmploymentType : AuditedAggregateTenantRoot<int>
    {
        public LeaveRequestTemplateEmploymentType()
        {

        }

        public virtual LeaveRequestTemplate LeaveRequestTemplate { get; set; }
        public int LeaveRequestTemplateId;

        public virtual DictionaryValue EmploymentType { get; set; }
        public Guid? EmploymentTypeId;
    }
}
