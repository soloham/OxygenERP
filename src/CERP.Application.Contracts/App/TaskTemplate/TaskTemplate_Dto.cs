using CERP.Base;
using CERP.HR.Employees;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERP.App
{
    public class TaskTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public TaskTemplate_Dto()
        {

        }
        public TaskTemplate_Dto(int id)
        {
            Id = id;
        }

        public TaskModule TaskModule { get; set; }

        public virtual ICollection<TaskTemplateItem_Dto> TaskTemplateItems { get; set; }

        public virtual ApprovalRouteTemplateItem_Dto? ApprovalRouteTemplateItem { get; set; }
        public int? ApprovalRouteTemplateItemId { get; set; }
    }
}