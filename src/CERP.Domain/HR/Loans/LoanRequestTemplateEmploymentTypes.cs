using CERP.App;
using CERP.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CERP.HR.Loans
{
    public class LoanRequestTemplateEmploymentType : AuditedAggregateTenantRoot<int>
    {
        public LoanRequestTemplateEmploymentType()
        {

        }

        [ForeignKey("LoanRequestTemplateId")]
        public virtual LoanRequestTemplate LoanRequestTemplate { get; set; }
        public int LoanRequestTemplateId;

        [ForeignKey("EmploymentTypeId")]
        public virtual DictionaryValue EmploymentType { get; set; }
        public Guid EmploymentTypeId;
    }
}
