using CERP.App;
using CERP.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplateEmploymentType : AuditedAggregateTenantRoot<int>
    {
        public LeaveRequestTemplateEmploymentType()
        {

        }

        [ForeignKey("LeaveRequestTemplateId")]
        public virtual LeaveRequestTemplate LeaveRequestTemplate { get; set; }
        public int LeaveRequestTemplateId;

        [ForeignKey("EmploymentTypeId")]
        public virtual DictionaryValue EmploymentType { get; set; }
        public Guid EmploymentTypeId;
    }
}
