using CERP.Base;
using CERP.Setup;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CERP.HR.Loans
{
    public class LoanRequestTemplatePosition : AuditedAggregateTenantRoot<int>
    {
        public LoanRequestTemplatePosition()
        {

        }

        [ForeignKey("LoanRequestTemplateId")]
        public virtual LoanRequestTemplate LoanRequestTemplate { get; set; }
        public int LoanRequestTemplateId;

        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }
        public Guid PositionId;
    }
}
