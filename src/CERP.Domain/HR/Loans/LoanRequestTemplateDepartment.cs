using CERP.Base;
using CERP.Setup;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CERP.HR.Loans
{
    public class LoanRequestTemplateDepartment : AuditedAggregateTenantRoot<Guid>
    {
        public LoanRequestTemplateDepartment()

        {

        }

        [ForeignKey("LoanId")]
        public virtual LoanRequestTemplate LoanRequestTemplate { get; set; }
        public int LoanRequestTemplateId;

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public Guid DepartmentId;
    }
}
