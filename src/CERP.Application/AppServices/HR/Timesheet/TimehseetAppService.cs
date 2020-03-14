using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.Timesheets;
using CERP.HR.Workshifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.HR.WorkShiftService
{
    public class TimesheetAppService : CrudAppService<Timesheet, Timesheet_Dto, int, PagedAndSortedResultRequestDto, Timesheet_Dto, Timesheet_Dto>
    {
        public IRepository<TimesheetWeekSummary, int> TimesheetWeekSummaryRepo { get; set; }
        public TimesheetAppService(IRepository<Timesheet, int> repository, IRepository<TimesheetWeekSummary, int> timesheetWeekSummaryRepo) : base(repository)
        {
            Repository = repository;
            TimesheetWeekSummaryRepo = timesheetWeekSummaryRepo;
        }

        public IRepository<Timesheet, int> Repository { get; }

        public List<Timesheet_Dto> GetTimesheetsSummary()
        {
            List<Timesheet> timesheets = Repository.WithDetails().ToList();
            return timesheets.Select(MapToGetListOutputDto).ToList();
        }
        public Timesheet_Dto GetTimesheet(int year, int month, Guid employeeId)
        {
            return ObjectMapper.Map<Timesheet, Timesheet_Dto>(Repository.WithDetails(x => x.WeeklySummaries).SingleOrDefault(c => c.Year == year && c.Month == month && c.EmployeeId == employeeId));
        }
        public TimesheetWeekSummary_Dto GetWeekSummary(int year, int month, int week, Guid employeeId)
        {
            try
            {
                TimesheetWeekSummary weekSheet = TimesheetWeekSummaryRepo.WithDetails(x => x.WeeklyJobSummaries).Single(c => c.Year == year && c.Month == month && c.Week == week && c.EmployeeId == employeeId);
                return ObjectMapper.Map<TimesheetWeekSummary, TimesheetWeekSummary_Dto>(weekSheet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
