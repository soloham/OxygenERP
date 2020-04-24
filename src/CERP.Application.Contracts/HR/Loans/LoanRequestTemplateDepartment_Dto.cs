using CERP.Base;
using CERP.Setup;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CERP.HR.Loans
{
    public class LoanRequestTemplateDepartment_Dto : AuditedEntityTenantDto<Guid>
    {
        public LoanRequestTemplateDepartment_Dto()
        {

        }

        public virtual LoanRequestTemplate_Dto LoanRequestTemplate { get; set; }
        public int LoanRequestTemplateId;

        public virtual Department_Dto Department { get; set; }
        public Guid DepartmentId;
    }
}
