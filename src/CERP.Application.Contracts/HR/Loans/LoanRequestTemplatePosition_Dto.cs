using CERP.Base;
using CERP.Setup;
using CERP.Setup.DTOs;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CERP.HR.Loans
{
    public class LoanRequestTemplatePosition_Dto : AuditedEntityTenantDto<int>
    {
        public LoanRequestTemplatePosition_Dto()
        {

        }

        public virtual LoanRequestTemplate_Dto LoanRequestTemplate { get; set; }
        public int LoanRequestTemplateId;

        public virtual Position_Dto Position { get; set; }
        public Guid PositionId;
    }
}
