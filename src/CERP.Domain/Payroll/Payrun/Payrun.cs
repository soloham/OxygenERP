using CERP.App;
using CERP.FM;
using CERP.HR.Employees;
using CERP.HR.Timesheets;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.Payroll.Payrun
{
    public class Payrun : FullAuditedAggregateRoot<int>
    {
        public Payrun()
        {

        }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }

        public decimal TotalEarnings { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal NetTotal { get; set; }

        public virtual ICollection<PayrunDetail> PayrunDetails { get; set; }
        public virtual ICollection<Payslip> Payslips { get; set; }

        public string Note { get; set; }
        public string AttachmentFile { get; set; }
        public bool IsPosted { get; set; }
        public DateTime? PostedDate { get; set; }

        public string PostedByTemp { get; set; }

        [ForeignKey("PostedById")]
        public Employee? PostedBy { get; set; }
        public Guid? PostedById { get; set; }
    }

    public class PayrunDetail : FullAuditedAggregateRoot<int>
    {
        [ForeignKey("PayrunId")]
        public Payrun Payrun { get; set; }
        public int PayrunId { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }

        [ForeignKey("EmployeeTimesheetId")]
        public Timesheet EmployeeTimesheet { get; set; }
        public int EmployeeTimesheetId { get; set; }

        public virtual ICollection<PayrunAllowanceSummary> PayrunAllowancesSummaries { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal GOSIAmount { get; set; }
        public decimal Loan { get; set; }
        public decimal Leaves { get; set; }
        public decimal Disciplinary { get; set; }

        public decimal GrossEarnings { get; set; }
        public decimal GrossDeductions { get; set; }
        public decimal NetAmount { get; set; }

        public decimal AmountPaid { get; set; }
        public decimal DifferAmount { get; set; }
    }

    public class PayrunAllowanceSummary : FullAuditedAggregateRoot<int> 
    {
        public decimal Value { get; set; }

        [ForeignKey("AllowanceTypeId")]
        public DictionaryValue AllowanceType { get; set; }
        public Guid AllowanceTypeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }

    }

    public class Payslip : FullAuditedAggregateRoot<int>
    {
        [ForeignKey("PayrunDetailId")]
        public PayrunDetail PayrunDetail { get; set; }
        public int PayrunDetailId { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }

        public decimal Earning { get; set; }
        public decimal Deduction { get; set; }

        public string Description { get; set; }
        public string Remarks { get; set; }

        public bool IsPosted { get; set; }
    }
}
