using CERP.Base;
using CERP.HR.Employees;
using CERP.HR.Employees.DTOs;
using CERP.Setup;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERP.App
{
    public class TaskTemplateItem_Dto : AuditedEntityTenantDto<int>
    {
        public TaskTemplateItem_Dto()
        {

        }
        public TaskTemplateItem_Dto(int id)
        {
            Id = id;
        }

        public virtual TaskTemplate_Dto TaskTemplate { get; set; }
        public int TaskTemplateId { get; set; }

        public bool Active { get; set; }

        public int RouteIndex { get; set; }

        public virtual List<Department_Dto> Departments { get; set; }

        public virtual List<Position_Dto> Positions { get; set; }

        public virtual List<TaskTemplateItemEmployee_Dto> TaskEmployees { get; set; }

        public bool IsAny { get; set; }
        public bool NotifyEmployee { get; set; }

        public string TaskDescription { get; set; }
    }
}
