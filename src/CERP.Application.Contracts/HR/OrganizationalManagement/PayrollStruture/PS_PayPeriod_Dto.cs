using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;

using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.PayrollStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PayPeriod_Dto : AuditedEntityTenantDto<int>
    {
        public PS_PayPeriod_Dto()
        {
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameLocalized { get; set; }
        public string AttendanceCutOffDate { get; set; }
        public string EmployeeTransactionCutOffDate { get; set; }
        public string PayrollProcessingDate { get; set; }
        public int PayrollReminderIssuanceDays { get; set; }
        public string ApprovalDate { get; set; }
        public int ApprovalReminderIssuanceDays { get; set; }
        public string PaymentDate { get; set; }
        public int PostPaymentSelfServiceAvailabilityDays { get; set; }
        public string GLExpensePostingDate { get; set; }
        public bool OffCyclePayroll { get; set; }

        public int PayrollPeriodId { get; set; }
    }
}
