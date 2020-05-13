using System.Collections.Generic;
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
