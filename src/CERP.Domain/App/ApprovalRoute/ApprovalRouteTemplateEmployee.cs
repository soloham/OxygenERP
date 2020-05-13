using CERP.Base;
using CERP.HR.Employees;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CERP.App
{
    public class ApprovalRouteTemplateItemEmployee : AuditedAggregateTenantRoot<int>
    {
        public ApprovalRouteTemplateItemEmployee()
        {

        }

        [ForeignKey("ApprovalRouteTemplateItemId")]
        public virtual ApprovalRouteTemplateItem ApprovalRouteTemplateItem { get; set; }
        public int ApprovalRouteTemplateItemId;

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        public Guid EmployeeId;
    }
}
