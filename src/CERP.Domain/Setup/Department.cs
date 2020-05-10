using CERP.Base;
using CERP.FM;
using CERP.HR.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.Setup
{
    public class Department : FullAuditedAggregateTenantRoot<Guid>
    {
        public Department()
        {
            IsDeleted = false;
        }
        public Department(Guid id)
        {
            Id = id;
            IsDeleted = false;
        }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }

        public string Name { get; set; }
        public ICollection<Position> Positions { get; set; }
    }

}
