using CERP.Base;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplateDepartment : AuditedAggregateTenantRoot<Guid>
    {
        public LeaveRequestTemplateDepartment()
        {

        }

        [ForeignKey("LeaveRequestTemplateId")]
        public virtual LeaveRequestTemplate LeaveRequestTemplate { get; set; }
        public int LeaveRequestTemplateId;

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public Guid DepartmentId;
    }
}
