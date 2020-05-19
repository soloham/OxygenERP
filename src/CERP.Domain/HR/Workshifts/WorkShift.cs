using CERP.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CERP.Base;

namespace CERP.HR.Workshifts
{
    public class WorkShift : FullAuditedAggregateTenantRoot<int>
    {
        public WorkShift()
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

        //[ForeignKey("DepartmentId")]
        //public Department Department { get; set; }
        //public Guid? DepartmentId { get; set; }
        
        [ForeignKey("DeductionMethodId")]
        public DeductionMethod DeductionMethod { get; set; }
        public int? DeductionMethodId { get; set; }

        //public ICollection<Employees.Employee> Employees { get; set; }
    }
}
