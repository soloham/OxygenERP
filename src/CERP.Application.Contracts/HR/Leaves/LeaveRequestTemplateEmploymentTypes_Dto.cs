using CERP.App;
using CERP.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplateEmploymentType_Dto : AuditedEntityTenantDto<int>
    {
        public LeaveRequestTemplateEmploymentType_Dto()
        {

        }

        public virtual LeaveRequestTemplate_Dto LeaveRequestTemplate { get; set; }
        public int LeaveRequestTemplateId;

        public virtual DictionaryValue_Dto EmploymentType { get; set; }
        public Guid EmploymentTypeId;
    }
}
