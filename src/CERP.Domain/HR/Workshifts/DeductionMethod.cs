using CERP.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using CERP.HR.Employees;
using CERP.Base;

namespace CERP.HR.Workshifts
{
    public class DeductionMethod : FullAuditedAggregateTenantRoot<int>
    {
        public DeductionMethod()
        {

        }

        public string Title { get; set; }
        public int HoursMultiplicationFactor { get; set; }

        public ICollection<WorkShift> WorkShifts { get; set; }
    }
}
