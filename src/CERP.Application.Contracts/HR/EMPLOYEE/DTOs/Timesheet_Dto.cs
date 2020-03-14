using CERP.App;
using CERP.HR.Employees.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CERP.HR.EMPLOYEE.DTOs
{
    
    public class Timesheet_Dto : FullAuditedEntityDto<int>
    {
        public virtual Employee_Dto Employee { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }

        public int Year { get; set; }
        public string GetMonth { get => Convert.ToDateTime(Month.ToString() + "/1/1990").ToString("MMMM"); }
        public int Month { get; set; }

        public virtual ICollection<TimesheetWeekSummary_Dto> WeeklySummaries { get; set; }

        public int Week1Hours { get; set; }
        public int Week2Hours { get; set; }
        public int Week3Hours { get; set; }
        public int Week4Hours { get; set; }
        public int Week5Hours { get; set; }

        public int TotalMonthHours { get; set; }

        public string GetProgress { get => ((float)TotalMonthHours / (5 * 45) * 100).ToString("N2"); }

        public string Description { get; set; }

        public bool IsPosted { get; set; }
        [Required]
        public DateTime Dated { get; set; }
    }

    public class TimesheetWeekSummary_Dto : FullAuditedEntityDto<int>
    {
        public virtual Timesheet_Dto Timesheet { get; set; }
        [Required]
        public int TimesheetId { get; set; }
        public virtual Employee_Dto Employee { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }

        public virtual ICollection<TimesheetWeekJobSummary_Dto> WeeklyJobSummaries { get; set; }

        public int SumSun { get; set; }
        public int SumMon { get; set; }
        public int SumTue { get; set; }
        public int SumWed { get; set; }
        public int SumThu { get; set; }
        public int SumFri { get; set; }
        public int SumSat { get; set; }

        public int TotalWeekHours { get; set; }
        public string GetProgress { get => ((float)TotalWeekHours / 45 * 100).ToString("N2"); }

        public bool IsSubmitted { get; set; }

        public string Description { get; set; }
        [Required]
        public DateTime Dated { get; set; }
    }

    public class TimesheetWeekJobSummary_Dto : FullAuditedEntityDto<int>
    {
        public virtual TimesheetWeekSummary_Dto WeekSheet { get; set; }
        [Required]
        public int WeekSheetId { get; set; }

        public virtual Employee_Dto Employee { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }

        public int JobInWeekId { get; set; }

        public bool IsChargeable { get; set; }
        public DictionaryValue_Dto Chargeability { get; set; }
        [Required]
        public Guid ChargeabilityId { get; set; }
        public DictionaryValue_Dto ServiceLine { get; set; }
        [Required]
        public Guid ServiceLineId { get; set; }
        public DictionaryValue_Dto? Client { get; set; }
        public Guid? ClientId { get; set; }

        public int Sun { get; set; }
        public int Mon { get; set; }
        public int Tue { get; set; }
        public int Wed { get; set; }
        public int Thu { get; set; }
        public int Fri { get; set; }
        public int Sat { get; set; }

        public int TotalJobWeekHours { get; set; }
        public bool IsSubmitted { get; set; }
    }
}
