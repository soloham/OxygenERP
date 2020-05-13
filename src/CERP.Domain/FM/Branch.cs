using CERP.Base;
using CERP.Setup;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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
