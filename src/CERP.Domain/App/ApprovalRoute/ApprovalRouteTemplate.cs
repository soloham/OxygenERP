using CERP.Base;
using System.Collections.Generic;

namespace CERP.App
{
    public class ApprovalRouteTemplate : AuditedAggregateTenantRoot<int>
    {
        public ApprovalRouteTemplate()
        {

        }
        public ApprovalRouteTemplate(int id)
        {
            Id = id;
        }

        public ApprovalRouteModule ApprovalRouteModule { get; set; }

        public virtual ICollection<ApprovalRouteTemplateItem> ApprovalRouteTemplateItems { get; set; }
    }
}