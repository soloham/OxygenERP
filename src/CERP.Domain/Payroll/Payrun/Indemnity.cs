using CERP.App;
using CERP.Base;
using CERP.FM;
using CERP.HR.Employees;
using CERP.HR.Timesheets;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CERP.Payroll.Payrun
{
    public class PayrunDetailIndemnity : AuditedAggregateTenantRoot<int>
    {
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }
        public Guid? EmployeeId { get; set; }

        public double BasicSalary { get; set; }
        public virtual ICollection<PayrunAllowanceSummary> PayrunEOSBAllowancesSummaries { get; set; }

        public double GrossSalary { get; set; }

        public int TotalEmploymentDays { get; set; }
        public int TotalPre5EmploymentDays { get => Math.Min(TotalEmploymentDays, 1825); }
        public int TotalPost5EmploymentDays { get => Math.Max(0, TotalEmploymentDays - 1825); }

        public double TotalEOSB { get; set; }
        public double ActuarialEvaluation { get; set; }
        public double LastMonthEOSB { get; set; }
        public double Difference { get; set; }

        [ForeignKey("PayrunDetailId")]
        public PayrunDetail PayrunDetail { get; set; }
        public int PayrunDetailId { get; set; }
    }
}
