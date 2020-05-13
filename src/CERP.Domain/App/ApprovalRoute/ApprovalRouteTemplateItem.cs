using CERP.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CERP.App
{
    public class ApprovalRouteTemplateItem : AuditedAggregateTenantRoot<int>
    {
        public ApprovalRouteTemplateItem()
        {

        }
        public ApprovalRouteTemplateItem(int id)
        {
            Id = id;
        }

        public virtual ApprovalRouteTemplate ApprovalRouteTemplate { get; set; }
        public int ApprovalRouteTemplateId { get; set; }

        public bool Active { get; set; }

        public int RouteIndex { get; set; }

        public bool IsDepartmentHead { get; set; }
        public bool IsReportingTo { get; set; }

        public virtual ICollection<ApprovalRouteTemplateItemEmployee> ApprovalRouteItemEmployees { get; set; }

        public bool IsAny { get; set; }

        public bool NotifyEmployee { get; set; }
        public bool IsPoster { get; set; }

        [ForeignKey("TaskTemplateId")]
        public virtual TaskTemplate? TaskTemplate { get; set; }
        public int? TaskTemplateId { get; set; }
    }
}
