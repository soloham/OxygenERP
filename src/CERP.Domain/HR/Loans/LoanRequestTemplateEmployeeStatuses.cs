using CERP.App;
using CERP.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CERP.HR.Loans
{
    public class LoanRequestTemplateEmployeeStatus : AuditedAggregateTenantRoot<int>
    {
        public LoanRequestTemplateEmployeeStatus()
        {

        }


        [ForeignKey("LoanRequestTemplateId")]
        public virtual LoanRequestTemplate LoanRequestTemplate { get; set; }
        public int LoanRequestTemplateId;

        [ForeignKey("EmployeeStatusId")]
        public virtual DictionaryValue EmployeeStatus { get; set; }
        public Guid EmployeeStatusId;
    }
}
