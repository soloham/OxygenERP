using CERP.Base;
using CERP.HR.Employees.DTOs;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CERP.HR.EMPLOYEE.DTOs
{
    public class WorkShift_Dto : FullAuditedEntityTenantDto<int>
    {
        public WorkShift_Dto()
        {

        }

        public string Title { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        
        public Department_Dto Department { get; set; }
        public Guid DepartmentId { get; set; }

        public ICollection<Employee_Dto> Employees { get; set; }
    }
}
