using CERP.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.FM
{
    public class Branch : AuditedAggregateTenantRoot<Guid>
    {
        public Branch()
        {

        }
        public Branch(Guid id)
        {
            Id = id;
        }


        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        public Guid CompanyId { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public int BranchCode { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
