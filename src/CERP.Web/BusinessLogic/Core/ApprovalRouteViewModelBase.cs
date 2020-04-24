using CERP.HR.Employees.DTOs;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CERP.Web.BusinessLogic.Core
{
    public class ApprovalRouteViewModelBase
    {
        public List<ApprovalRouteVM> ApprovalRoute { get; set; }

        public void Initialize()
        {
            ApprovalRoute.ForEach(x => x.Initialize());
        }
    }


    public class ApprovalRouteVM
    {
        public void Initialize()
        {
            DepartmentIds = Departments.Select(x => (Guid?)x.Id).ToArray();
            PositionIds = Positions.Select(x => (Guid?)x.Id).ToArray();
            EmployeeIds = ApprovalRouteItemEmployees.Select(x => {
                Guid guid;
                Guid.TryParse(x.EmployeeId, out guid);
                return (Guid?)guid;
            }).ToArray();

            if (TaskTemplate != null)
                TaskTemplate.TaskTemplateItems.ForEach(x => x.Initialize());
        }

        public string Id { get; set; }

        public bool IsDepartmentHead { get; set; }
        public bool IsReportingTo { get; set; }

        public List<Department_Dto> Departments { get; set; } = new List<Department_Dto>();
        public Guid?[] DepartmentIds { get; set; }
        public List<Position_Dto> Positions { get; set; } = new List<Position_Dto>();
        public Guid?[] PositionIds { get; set; }
        public List<ApprovalRouteTemplateItemEmployeeVM> ApprovalRouteItemEmployees { get; set; } = new List<ApprovalRouteTemplateItemEmployeeVM>();
        public Guid?[] EmployeeIds { get; set; }

        public TaskTemplateVM TaskTemplate { get; set; } = new TaskTemplateVM();

        public Guid?[] TaskIds { get; set; }

        public bool Active { get; set; }
        public bool IsAny { get; set; }

        public bool NotifyEmployee { get; set; }
        public bool IsPoster { get; set; }
    }
    public class ApprovalRouteTemplateItemEmployeeVM
    {
        public string Id { get; set; }
        public Employee_Dto Employee { get; set; } = new Employee_Dto();
        public string EmployeeId { get; set; }
    }
    public class TaskTemplateVM
    {

        public List<LRTaskVM> TaskTemplateItems { get; set; } = new List<LRTaskVM>();
    }
    public class LRTaskVM
    {
        public void Initialize()
        {
            DepartmentIds = Departments.Select(x => (Guid?)x.Id).ToArray();
            PositionIds = Positions.Select(x => (Guid?)x.Id).ToArray();
            EmployeeIds = Employees.Select(x => (Guid?)x.Id).ToArray();
        }

        public string Id { get; set; }
        public bool Active { get; set; }
        public string TaskDescription { get; set; }

        public List<Department_Dto> Departments { get; set; } = new List<Department_Dto>();
        public Guid?[] DepartmentIds { get; set; }
        public List<Position_Dto> Positions { get; set; } = new List<Position_Dto>();
        public Guid?[] PositionIds { get; set; }
        public List<Employee_Dto> Employees { get; set; } = new List<Employee_Dto>();
        public Guid?[] EmployeeIds { get; set; }

        public bool IsAny { get; set; }
        public bool NotifyEmployee { get; internal set; }
    }
}
