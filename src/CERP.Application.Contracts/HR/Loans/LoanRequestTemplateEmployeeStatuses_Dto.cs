using CERP.App;
using CERP.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CERP.HR.Loans
{
    public class LoanRequestTemplateEmployeeStatus_Dto : AuditedEntityTenantDto<int>
    {
        public LoanRequestTemplateEmployeeStatus_Dto()
        {

        }


        public virtual LoanRequestTemplate_Dto LoanRequestTemplate { get; set; }
        public int LoanRequestTemplateId;

        public virtual DictionaryValue_Dto EmployeeStatus { get; set; }
        public Guid EmployeeStatusId;
    }
}
