using CERP.Base;
using CERP.HR.Employees.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CERP.Payroll.DTOs
{
    public class SISetup_Dto : AuditedEntityTenantDto<int>
    {
        public double SI_UpperLimit { get; set; }

        public List<SIContributionCategory_Dto> ContributionCategories { get; set; }
    }

    public class SIContributionCategory_Dto : AuditedEntityTenantDto<int>
    {
        public SISetup_Dto Setup { get; set; }
        public int SetupId { get; set; }
        public string Title { get; set; }
        public bool IsExpense { get; set; }

        public List<SIContribution_Dto> SIContributions { get; set; }

        public SIContributionCategory_Dto()
        {

        }
    }

    public class SIContribution_Dto : AuditedEntityTenantDto<int>
    {
        public SIContributionCategory_Dto SICategory { get; set; }
        [Required]
        public int SICategoryId { get; set; }

        public string Title { get; set; }
        public double Value { get; set; }
        public bool IsPercentage { get; set; }
    }

    public class SocialInsuranceReport_Dto
    {
        public Payrun_Dto Payrun { get; set; }
        [Required]
        public int PayrunId { get; set; }
        
        public Employee_Dto Employee { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }

        public string EmpID { get; set; }
        public string EmpSIId { get; set; }

        public double BasicSalary { get; set; }
        public List<PayrunAllowanceSummary_Dto> PayrunSIAllowancesSummaries { get; set; }

        public double TotalSISalary { get; set; }
        public DateTime PayrunDate { get; set; }
    }
}
