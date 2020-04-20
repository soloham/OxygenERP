using CERP.Base;
using CERP.HR.Employees;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERP.App
{
    public class TaskTemplate : AuditedAggregateTenantRoot<int>
    {
        public TaskTemplate()
        {

        }
        public TaskTemplate(int id)
        {
            Id = id;
        }

        public TaskModule TaskModule { get; set; }

        public virtual ICollection<TaskTemplateItem> TaskTemplateItems { get; set; }
    }
}