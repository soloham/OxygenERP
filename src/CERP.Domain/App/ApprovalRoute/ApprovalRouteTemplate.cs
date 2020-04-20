using CERP.Base;
using CERP.HR.Employees;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.Text;

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