using CERP.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
