using CERP.App;
using CERP.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CERP.HR.Timesheets
{
    public class Timesheet : FullAuditedAggregateTenantRoot<int>
    {
        [ForeignKey("EmployeeId")]
        public virtual Employees.Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }

        public virtual ICollection<TimesheetWeekSummary> WeeklySummaries { get; set; }

        public int Week1Hours { get; set; }
        public int Week2Hours { get; set; }
        public int Week3Hours { get; set; }
        public int Week4Hours { get; set; }
        public int Week5Hours { get; set; }

        public int TotalMonthHours { get; set; }

        public string Description { get; set; }

        public bool IsPosted { get; set; }
        public DateTime Dated { get; set; }
    }

    public class TimesheetWeekSummary : FullAuditedAggregateTenantRoot<int>
    {
        [ForeignKey("TimesheetId")]
        public virtual Timesheet Timesheet { get; set; }
        public int TimesheetId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employees.Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }

        public virtual ICollection<TimesheetWeekJobSummary> WeeklyJobSummaries { get; set; }

        public int SumSun { get; set; }
        public int SumMon { get; set; }
        public int SumTue { get; set; }
        public int SumWed { get; set; }
        public int SumThu { get; set; }
        public int SumFri { get; set; }
        public int SumSat { get; set; }

        public int TotalWeekHours { get; set; }
        public bool IsSubmitted { get; set; }

        public string Description { get; set; }
        public DateTime Dated { get; set; }
    }

    public class TimesheetWeekJobSummary : FullAuditedAggregateTenantRoot<int>
    {
        [ForeignKey("WeekSheetId")]
        public virtual TimesheetWeekSummary WeekSheet { get; set; }
        public int WeekSheetId { get; set; }


        [ForeignKey("EmployeeId")]
        public virtual Employees.Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }

        public int JobInWeekId { get; set; }

        public bool IsChargeable { get; set; }
        [ForeignKey("ChargeabilityId")]
        public DictionaryValue Chargeability { get; set; }
        public Guid ChargeabilityId { get; set; }
        [ForeignKey("ServiceLineId")]
        public DictionaryValue ServiceLine { get; set; }
        public Guid ServiceLineId { get; set; }
        [ForeignKey("ClientId")]
        public DictionaryValue? Client { get; set; }
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
