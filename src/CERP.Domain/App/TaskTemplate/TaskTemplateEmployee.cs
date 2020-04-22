using CERP.Base;
using CERP.HR.Employees;
using CERP.HR.Employees.DTOs;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CERP.App
{
    public class TaskTemplateItemEmployee : AuditedAggregateTenantRoot<int>
    {
        public TaskTemplateItemEmployee()
        {

        }

        public virtual TaskTemplateItem TaskTemplateItem { get; set; }
        public int TaskTemplateItemId;

        public virtual Employee Employee { get; set; }
        public Guid EmployeeId;
    }
}
