using CERP.Base;
using CERP.Setup;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplateDepartment_Dto : AuditedEntityTenantDto<Guid>
    {
        public LeaveRequestTemplateDepartment_Dto()
        {

        }

        public virtual LeaveRequestTemplate_Dto LeaveRequestTemplate { get; set; }
        public int LeaveRequestTemplateId;

        public virtual Department_Dto Department { get; set; }
        public Guid DepartmentId;
    }
}
