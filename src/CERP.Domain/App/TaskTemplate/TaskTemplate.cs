using CERP.Base;
using System.Collections.Generic;

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

        public virtual ApprovalRouteTemplateItem? ApprovalRouteTemplateItem { get; set; }
        public int? ApprovalRouteTemplateItemId { get; set; }
    }
}