using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.EmployeeCentral.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class EmployeeLoan : AuditedAggregateTenantRoot<int>
    {
        public EmployeeLoan()
        {

        }

        public DictionaryValue LoanType { get; set; }
        [CustomAudited]
        public Guid LoanTypeId { get; set; }
        public EC_LoanStatus LoanStatus { get; set; }

        [CustomAudited]
        public string Name { get; set; }
        [CustomAudited]
        public double Amount { get; set; }

        [CustomAudited]
        public string ValidityFromDate { get; set; }
        [CustomAudited]
        public string ValidityToDate { get; set; }
    }
}
