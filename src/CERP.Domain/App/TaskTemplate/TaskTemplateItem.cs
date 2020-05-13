using CERP.Base;
using System.Collections.Generic;

namespace CERP.App
{
    public class TaskTemplateItem : AuditedAggregateTenantRoot<int>
    {
        public TaskTemplateItem()
        {

        }
        public TaskTemplateItem(int id)
        {
            Id = id;
        }

        public virtual TaskTemplate TaskTemplate { get; set; }
        public int TaskTemplateId { get; set; }

        public bool Active { get; set; }

        public int RouteIndex { get; set; }

        public virtual ICollection<TaskTemplateItemEmployee> TaskEmployees { get; set; }

        public bool IsAny { get; set; }
        public bool NotifyEmployee { get; set; }

        public string TaskDescription { get; set; }
    }
}
