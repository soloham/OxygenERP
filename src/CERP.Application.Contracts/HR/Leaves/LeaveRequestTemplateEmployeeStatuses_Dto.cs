using CERP.App;
using CERP.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplateEmployeeStatus_Dto : AuditedEntityTenantDto<int>
    {
        public LeaveRequestTemplateEmployeeStatus_Dto()
        {

        }


        public virtual LeaveRequestTemplate_Dto LeaveRequestTemplate { get; set; }
        public int LeaveRequestTemplateId;

        public virtual DictionaryValue_Dto EmployeeStatus { get; set; }
        public Guid EmployeeStatusId;
    }
}
