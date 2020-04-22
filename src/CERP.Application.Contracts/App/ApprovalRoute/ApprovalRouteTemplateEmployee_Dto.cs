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
    public class ApprovalRouteTemplateItemEmployee_Dto : AuditedEntityTenantDto<int>
    {
        public ApprovalRouteTemplateItemEmployee_Dto()
        {

        }

        public virtual ApprovalRouteTemplateItem_Dto ApprovalRouteTemplate { get; set; }
        public int ApprovalRouteTemplateItemId;

        public virtual Employee_Dto Employee { get; set; }
        public Guid EmployeeId;
    }
}
