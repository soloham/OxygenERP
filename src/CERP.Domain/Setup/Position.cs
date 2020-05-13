using CERP.Base;
using CERP.HR.Employees;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CERP.Setup
{
    public class Position : FullAuditedAggregateTenantRoot<Guid>
    {
        public Position()
        {
            IsDeleted = false;
        }
        public Position(Guid id)
        {
            Id = id;
            IsDeleted = false;
        }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public Guid DepartmentId { get; set; }

        public string Title { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }
        public Guid? EmployeeId { get; set; }
    }

}
