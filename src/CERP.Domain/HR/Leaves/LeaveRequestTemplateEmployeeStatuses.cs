using CERP.App;
using CERP.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplateEmployeeStatus : AuditedAggregateTenantRoot<int>
    {
        public LeaveRequestTemplateEmployeeStatus()
        {

        }


        [ForeignKey("LeaveRequestTemplateId")]
        public virtual LeaveRequestTemplate LeaveRequestTemplate { get; set; }
        public int LeaveRequestTemplateId;

        [ForeignKey("EmployeeStatusId")]
        public virtual DictionaryValue EmployeeStatus { get; set; }
        public Guid EmployeeStatusId;
    }
}
