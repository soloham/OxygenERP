using CERP.App;
using CERP.Attributes;
using CERP.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class EmployeeLoan_Dto : AuditedEntityTenantDto<int>
    {
        public EmployeeLoan_Dto()
        {

        }

        public DictionaryValue_Dto LoanType { get; set; }
        [CustomAudited]
        public Guid LoanTypeId { get; set; }
        public DictionaryValue_Dto LoanStatus { get; set; }
        [CustomAudited]
        public Guid LoanStatusId { get; set; }

        [CustomAudited]
        public double LoanAmount { get; set; }

        [CustomAudited]
        public string ValidityFromDate { get; set; }
        [CustomAudited]
        public string ValidityToDate { get; set; }
    }
}
