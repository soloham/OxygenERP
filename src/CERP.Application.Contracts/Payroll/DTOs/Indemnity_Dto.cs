using CERP.HR.Employees.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CERP.Payroll.DTOs
{
    public class PayrunDetailIndemnity_Dto
    {
        [Required]
        public DateTime PayrunDate { get; internal set; }
        public Payrun_Dto? Payrun { get; set; }
        [Required]
        public int PayrunId { get; set; }
        public Employee_Dto? Employee { get; set; }
        [Required]
        public Guid? EmployeeId { get; set; }

        [Required]
        public double BasicSalary { get; set; }
        [Required]
        public virtual ICollection<PayrunAllowanceSummary_Dto> PayrunEOSBAllowancesSummaries { get; set; }

        [Required]
        public double GrossSalary { get; set; }

        [Required]
        public int TotalEmploymentDays { get; set; }
        public int TotalPre5EmploymentDays { get => Math.Min(TotalEmploymentDays, 1825); }
        public int TotalPost5EmploymentDays { get => Math.Max(0, TotalEmploymentDays - 1825); }

        [Required]
        public double TotalEOSB { get; set; }
        public double ActuarialEvaluation { get; set; }
        [Required]
        public double LastMonthEOSB { get; set; }
        [Required]
        public double Difference { get; set; }
    }
}
