using CERP.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using CERP.HR.Employees;
using CERP.Base;

namespace CERP.HR.Workshift.DTOs
{
    public class DeductionMethod_Dto : FullAuditedEntityTenantDto<int>
    {
        public DeductionMethod_Dto()
        {

        }

        public string Title { get; set; }
        public int HoursMultiplicationFactor { get; set; }

        public ICollection<WorkShift_Dto> WorkShifts { get; set; }
    }
}
