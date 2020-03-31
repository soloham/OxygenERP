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
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace CERP.Payroll.Payrun
{
    public class SISetup : AuditedAggregateTenantRoot<int>
    {
        public double SI_UpperLimit { get; set; }

        public virtual ICollection<SIContributionCategory> ContributionCategories { get; set; }
    }
    public class SIContributionCategory : AuditedAggregateTenantRoot<int>
    {
        [ForeignKey("SetupId")]
        public SISetup Setup { get; set; }
        public int SetupId { get; set; }

        public string Title { get; set; }

        public bool IsExpense { get; set; }

        public virtual ICollection<SIContribution> SIContributions { get; set; }

        public SIContributionCategory()
        {

        }
    }

    public class SIContribution : AuditedAggregateTenantRoot<int>
    {
        [ForeignKey("SICategoryId")]
        public SIContributionCategory SICategory { get; set; }
        public int SICategoryId { get; set; }

        public string Title { get; set; }
        public double Value { get; set; }
        public bool IsPercentage { get; set; }
    }

    public class SocialInsuranceReport
    {
        [ForeignKey("EmployeeId")]
        public Payrun Payrun { get; set; }
        public int PayrunId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }

        public string EmpID { get; set; }
        public string EmpSIId { get; set; }

        public double BasicSalary { get; set; }
        public virtual ICollection<PayrunAllowanceSummary> PayrunSIAllowancesSummaries { get; set; }

        public double TotalSISalary { get; set; }
    }
}
