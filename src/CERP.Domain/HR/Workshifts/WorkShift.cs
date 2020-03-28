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
    public class WorkShift : FullAuditedAggregateTenantRoot<int>
    {
        public WorkShift()
        {

        }

        public string Title { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public Guid DepartmentId { get; set; }

        public ICollection<Employees.Employee> Employees { get; set; }
    }
}
