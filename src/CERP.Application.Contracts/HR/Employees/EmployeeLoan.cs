using CERP.App;
using CERP.App.Helpers;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.EmployeeCentral.Employee;
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
        public Guid LoanTypeId { get; set; }
        public string LoanStatusDescription { get => EnumExtensions.GetDescription(LoanStatus); set { try { LoanStatus = EnumExtensions.GetValueFromDescription<EC_LoanStatus>(value); } catch { } } }
        public EC_LoanStatus LoanStatus { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string ValidityFromDate { get; set; }
        public string ValidityToDate { get; set; }
    }
}
