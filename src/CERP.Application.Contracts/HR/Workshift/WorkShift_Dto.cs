using CERP.Base;
using CERP.HR.Employees.DTOs;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CERP.HR.Workshift.DTOs
{
    public class WorkShift_Dto : FullAuditedEntityTenantDto<int>
    {
        public WorkShift_Dto()
        {

        }

        public string Title { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }

        public bool isSUN { get; set; }
        public bool isMON { get; set; }
        public bool isTUE { get; set; }
        public bool isWED { get; set; }
        public bool isTHU { get; set; }
        public bool isFRI { get; set; }
        public bool isSAT { get; set; }

        public Department_Dto Department { get; set; }
        public Guid? DepartmentId { get; set; }

        public DeductionMethod_Dto DeductionMethod { get; set; }
        public int DeductionMethodId { get; set; }

        public ICollection<Employee_Dto> Employees { get; set; }
    }
}
