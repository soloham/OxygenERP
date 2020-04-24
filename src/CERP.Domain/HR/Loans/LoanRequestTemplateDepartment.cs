using CERP.Base;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
