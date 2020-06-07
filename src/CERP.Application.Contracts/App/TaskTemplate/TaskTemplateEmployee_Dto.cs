using CERP.Base;
using CERP.HR.Employees.DTOs;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CERP.App
{
    public class TaskTemplateItemEmployee_Dto : AuditedEntityTenantDto<int>
    {
        public TaskTemplateItemEmployee_Dto()
        {

        }

        public virtual TaskTemplateItem_Dto TaskTemplateItem { get; set; }
        public int TaskTemplateItemId;

        public virtual Employee_Dto Employee { get; set; }
        public Guid EmployeeId;
    }
}
