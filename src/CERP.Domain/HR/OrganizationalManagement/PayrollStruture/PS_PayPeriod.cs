using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;
using CERP.HR.EmployeeCentral.Employee;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.PayrollStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PayPeriod : AuditedAggregateTenantRoot<int>
    {
        public PS_PayPeriod()
        {
        }

        [CustomAudited]
        public string Code { get; set; }

        [CustomAudited]
        public string Name { get; set; }
        [CustomAudited]
        public string NameLocalized { get; set; }

        [CustomAudited]
        public string AttendanceCutOffDate { get; set; }
        [CustomAudited]
        public string EmployeeTransactionCutOffDate { get; set; }

        [CustomAudited]
        public string PayrollProcessingDate { get; set; }

        [CustomAudited]
        public int PayrollReminderIssuanceDays { get; set; }


        [CustomAudited]
        public string ApprovalDate { get; set; }
        [CustomAudited]
        public int ApprovalReminderIssuanceDays { get; set; }
        [CustomAudited]
        public string PaymentDate { get; set; }

        [CustomAudited]
        public int PostPaymentSelfServiceAvailabilityDays { get; set; }

        [CustomAudited]
        public string GLExpensePostingDate { get; set; }



        [CustomAudited]
        public bool OffCyclePayroll { get; set; }


        [CustomAudited]
        public int PayrollPeriodId { get; set; }

    }
}
