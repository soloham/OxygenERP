using CERP.App;
using CERP.FM.DTOs;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.Employees.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CERP.Payroll.DTOs
{

    public class Payrun_Dto : FullAuditedEntityDto<int>
    {
        public Payrun_Dto()
        {

        }

        public Company_Dto Company { get; set; }
        [Required]
        public Guid CompanyId { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }
        public string GetMonth { get => Convert.ToDateTime(Month.ToString() + "/1/1990").ToString("MMMM"); }

        public decimal TotalEarnings { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal NetTotal { get; set; }

        public virtual ICollection<PayrunDetail_Dto> PayrunDetails { get; set; }
        public virtual ICollection<Payslip_Dto> Payslips { get; set; }

        public string Note { get; set; }
        public string AttachmentFile { get; set; }
        public bool IsPosted { get; set; }
        public DateTime? PostedDate { get; set; }

        public string PostedByTemp { get; set; }

        public Employee_Dto? PostedBy { get; set; }
        public Guid? PostedById { get; set; }
    }

    public class PayrunDetail_Dto : FullAuditedEntityDto<int>
    {
        public Payrun_Dto Payrun { get; set; }
        [Required]
        public int PayrunId { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }
        public string GetMonth { get => Convert.ToDateTime(Month.ToString() + "/1/1990").ToString("MMMM"); }

        public Employee_Dto Employee { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }

        public virtual ICollection<PayrunAllowanceSummary_Dto> PayrunAllowancesSummaries { get; set; }

        public Timesheet_Dto EmployeeTimesheet { get; set; }
        [Required]
        public int EmployeeTimesheetId { get; set; }

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

    public class PayrunAllowanceSummary_Dto : FullAuditedEntityDto<int>
    {
        public decimal Value { get; set; }

        public DictionaryValue_Dto AllowanceType { get; set; }
        [Required]
        public Guid AllowanceTypeId { get; set; }

        public Employee_Dto Empoloyee { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }
    }

    public class Payslip_Dto : FullAuditedEntityDto<int>
    {
        public PayrunDetail_Dto PayrunDetail { get; set; }
        [Required]
        public Guid PayrunDetailId { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }

        public Employee_Dto Employee { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }

        public decimal Earning { get; set; }
        public decimal Deduction { get; set; }

        public string Description { get; set; }
        public string Remarks { get; set; }

        public bool IsPosted { get; set; }
    }
}
