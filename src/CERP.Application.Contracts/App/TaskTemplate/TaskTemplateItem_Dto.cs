using CERP.Base;
using CERP.HR.Employees.DTOs;
using CERP.Setup;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Initialize()
        {
            if (TaskEmployees != null && TaskEmployees.Count > 0) {
                try
                {
                    Departments = TaskEmployees.Select(x => x.Employee.Department).ToList();
                    Positions = TaskEmployees.Select(x => x.Employee.Position).ToList();
                }
                catch
                {

                }
            }
        }

        public virtual TaskTemplate_Dto TaskTemplate { get; set; }
        public int TaskTemplateId { get; set; }

        public bool Active { get; set; }

        public int RouteIndex { get; set; }

        public string GetAllDepartmentNames
        {
            get
            {
                string result = "";
                try
                {
                    if (Departments != null && Departments.Count > 0)
                    {
                        int i = 0;
                        foreach (Department_Dto department in Departments)
                        {
                            result += department.Name + (i < Departments.Count - 1 ? ", " : "");
                            i++;
                        }
                    }
                }
                catch { }
                return result;
            }
        }
        public virtual List<Department_Dto> Departments { get; set; }

        public string GetAllPositionTitles
        {
            get
            {
                string result = "";
                try
                {
                    if (Positions != null && Positions.Count > 0)
                    {
                        int i = 0;
                        foreach (Position_Dto position in Positions)
                        {
                            result += position.Title + (i < Positions.Count - 1 ? ", " : "");
                            i++;
                        }
                    }
                }
                catch { }
                return result;
            }
        }
        public virtual List<Position_Dto> Positions { get; set; }

        public string GetAllEmployeeNames
        {
            get
            {
                string result = "";
                try
                {
                    if (TaskEmployees != null && TaskEmployees.Count > 0)
                    {
                        int i = 0;
                        foreach (TaskTemplateItemEmployee_Dto TaskEmployee in TaskEmployees)
                        {
                            result += TaskEmployee.Employee.Name + (i < TaskEmployees.Count - 1 ? ", " : "");
                            i++;
                        }
                    }
                }
                catch { }
                return result;
            }
        }
        public virtual List<TaskTemplateItemEmployee_Dto> TaskEmployees { get; set; }

        public bool IsAny { get; set; }
        public bool NotifyEmployee { get; set; }

        public string TaskDescription { get; set; }
    }
}
