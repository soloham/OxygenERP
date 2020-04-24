using CERP.App;
using CERP.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CERP.HR.Loans
{
    public class LoanRequestTemplateEmploymentType_Dto : AuditedEntityTenantDto<int>
    {
        public LoanRequestTemplateEmploymentType_Dto()
        {

        }

        public virtual LoanRequestTemplate_Dto LoanRequestTemplate { get; set; }
        public int LoanRequestTemplateId;

        public virtual DictionaryValue_Dto EmploymentType { get; set; }
        public Guid EmploymentTypeId;
    }
}
