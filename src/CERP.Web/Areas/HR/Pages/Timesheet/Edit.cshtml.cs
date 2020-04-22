using CERP.App;
using CERP.AppServices.HR.EmployeeService;
using CERP.AppServices.HR.WorkShiftService;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.Employees.DTOs;
using CERP.HR.Timesheets;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Json;

namespace CERP.Web.Areas.HR.Pages.TimeSheets
{
    public class EditModel : CERPPageModel
    {
        public IGuidGenerator guidGenerator { get; set; }
        public IJsonSerializer JsonSerializer { get; set; }

        public EmployeeAppService EmployeeAppService { get; set; }
        public TimesheetAppService TimesheetAppService { get; set; }
        public IRepository<DictionaryValue, Guid> DicValuesRepo { get; set; }
        public IRepository<TimesheetWeekSummary, int> TimesheetWeekSummaryRepo { get; set; }
        public IRepository<TimesheetWeekJobSummary, int> TimesheetWeekJobSummaryRepo { get; set; }

        public TimesheetWeekSummary_Dto CurrentWeeksheet { get; set; }

        public EditModel(IGuidGenerator guidGenerator, IJsonSerializer jsonSerializer, TimesheetAppService timesheetAppService, EmployeeAppService employeeAppService, IRepository<DictionaryValue, Guid> dicValuesRepo, IRepository<TimesheetWeekSummary, int> timesheetWeekSummaryRepo, IRepository<TimesheetWeekJobSummary, int> timesheetWeekJobSummaryRepo)
        {
            this.guidGenerator = guidGenerator;
            JsonSerializer = jsonSerializer;
            TimesheetAppService = timesheetAppService;
            EmployeeAppService = employeeAppService;
            DicValuesRepo = dicValuesRepo;
            TimesheetWeekSummaryRepo = timesheetWeekSummaryRepo;
            TimesheetWeekJobSummaryRepo = timesheetWeekJobSummaryRepo;
        }

        public void OnGet(int year, int month, int week, Guid employeeId)
        {
            ViewData["defYear"] = year;
            ViewData["defMonth"] = month;
            ViewData["defWeek"] = week;
            ViewData["defEdmpId"] = employeeId;

            //if(employeeId != Guid.Empty && month <= 12 && month >= 0)
            //{
            //    CurrentWeeksheet = TimesheetAppService.GetWeekSummary(year, month, week == 0? 1 : week, employeeId);
            //}
        }

        public List<Employee_Dto> GetEmployees()
        {
            return EmployeeAppService.GetAllEmployees();
        }

        public IActionResult OnGetWeeksheet(SearchVM searchVM)
        {
            CurrentWeeksheet = TimesheetAppService.GetWeekSummary(searchVM.Year, searchVM.Month, searchVM.Week, searchVM.EmployeeId);
            if (CurrentWeeksheet == null)
            {
                CurrentWeeksheet = new TimesheetWeekSummary_Dto()
                {
                    Id = -1,
                    Year = searchVM.Year,
                    Month = searchVM.Month,
                    Week = searchVM.Week,
                    EmployeeId = searchVM.EmployeeId,
                    WeeklyJobSummaries = new List<TimesheetWeekJobSummary_Dto>()
                };
            }
            return PartialView("_Weeksheet", this);
        }

        public async Task<IActionResult> OnPostSaveTimesheet(TimesheetWeekSummary_Dto weeksheetDto)
        {
            try
            {
                if (TimesheetAppService.Repository.Any(x => x.EmployeeId == weeksheetDto.EmployeeId && x.Year == weeksheetDto.Year && x.Month == weeksheetDto.Month))
                {
                    Timesheet timesheetToUpdate;
                    if (weeksheetDto.Id == -1)
                    {
                        timesheetToUpdate = TimesheetAppService.Repository.WithDetails().First(x => x.EmployeeId == weeksheetDto.EmployeeId && x.Year == weeksheetDto.Year && x.Month == weeksheetDto.Month);

                        weeksheetDto.Id = 0;
                        TimesheetWeekSummary weeksheetToAdd = ObjectMapper.Map<TimesheetWeekSummary_Dto, TimesheetWeekSummary>(weeksheetDto);
                        timesheetToUpdate.WeeklySummaries.Add(weeksheetToAdd);

                        var updated = await TimesheetAppService.Repository.UpdateAsync(timesheetToUpdate);
                    }
                    else
                    {
                        TimesheetWeekSummary weeksheetToUpdate = TimesheetWeekSummaryRepo.WithDetails(x => x.WeeklyJobSummaries).First(x => x.Id == weeksheetDto.Id);
                        weeksheetToUpdate.SumSun = weeksheetDto.SumSun;
                        weeksheetToUpdate.SumMon = weeksheetDto.SumMon;
                        weeksheetToUpdate.SumTue = weeksheetDto.SumTue;
                        weeksheetToUpdate.SumWed = weeksheetDto.SumWed;
                        weeksheetToUpdate.SumThu = weeksheetDto.SumThu;
                        weeksheetToUpdate.SumFri = weeksheetDto.SumFri;
                        weeksheetToUpdate.SumSat = weeksheetDto.SumSat;
                        weeksheetToUpdate.TotalWeekHours = weeksheetDto.TotalWeekHours;

                        List<TimesheetWeekJobSummary> newJobSumaries = ObjectMapper.Map<ICollection<TimesheetWeekJobSummary_Dto>, List<TimesheetWeekJobSummary>>(weeksheetDto.WeeklyJobSummaries);
                        for (int i = 0; i < newJobSumaries.Count; i++)
                        {
                            if (!weeksheetToUpdate.WeeklyJobSummaries.Any(x => x.Id == newJobSumaries[i].Id))
                            {
                                weeksheetToUpdate.WeeklyJobSummaries.Add(newJobSumaries[i]);
                            }
                            else
                            {
                                TimesheetWeekJobSummary timesheetWeekJobSummary = newJobSumaries[i];
                                var jobSummary = weeksheetToUpdate.WeeklyJobSummaries.First(x => x.Id == timesheetWeekJobSummary.Id);
                                jobSummary.ChargeabilityId = timesheetWeekJobSummary.ChargeabilityId;
                                jobSummary.ServiceLineId = timesheetWeekJobSummary.ServiceLineId;
                                jobSummary.ClientId = timesheetWeekJobSummary.ClientId;
                                jobSummary.Sun = timesheetWeekJobSummary.Sun;
                                jobSummary.Mon = timesheetWeekJobSummary.Mon;
                                jobSummary.Tue = timesheetWeekJobSummary.Tue;
                                jobSummary.Wed = timesheetWeekJobSummary.Wed;
                                jobSummary.Thu = timesheetWeekJobSummary.Thu;
                                jobSummary.Fri = timesheetWeekJobSummary.Fri;
                                jobSummary.Sat = timesheetWeekJobSummary.Sat;
                                jobSummary.TotalJobWeekHours = timesheetWeekJobSummary.TotalJobWeekHours;
                                jobSummary.IsSubmitted = timesheetWeekJobSummary.IsSubmitted;
                                weeksheetToUpdate.IsSubmitted = timesheetWeekJobSummary.IsSubmitted;
                                weeksheetToUpdate.Description = weeksheetDto.Description;
                                jobSummary.IsDeleted = timesheetWeekJobSummary.IsDeleted;
                                var updated = await TimesheetWeekJobSummaryRepo.UpdateAsync(jobSummary);
                            }
                            await TimesheetWeekSummaryRepo.UpdateAsync(weeksheetToUpdate);
                        }
                    }

                    timesheetToUpdate = TimesheetAppService.Repository.WithDetails().First(x => x.EmployeeId == weeksheetDto.EmployeeId && x.Year == weeksheetDto.Year && x.Month == weeksheetDto.Month);
                    timesheetToUpdate.Week1Hours = timesheetToUpdate.WeeklySummaries.Where(x => x.Week == 1 && x.IsSubmitted).Sum(x => x.TotalWeekHours);
                    timesheetToUpdate.Week2Hours = timesheetToUpdate.WeeklySummaries.Where(x => x.Week == 2 && x.IsSubmitted).Sum(x => x.TotalWeekHours);
                    timesheetToUpdate.Week3Hours = timesheetToUpdate.WeeklySummaries.Where(x => x.Week == 3 && x.IsSubmitted).Sum(x => x.TotalWeekHours);
                    timesheetToUpdate.Week4Hours = timesheetToUpdate.WeeklySummaries.Where(x => x.Week == 4 && x.IsSubmitted).Sum(x => x.TotalWeekHours);
                    timesheetToUpdate.Week5Hours = timesheetToUpdate.WeeklySummaries.Where(x => x.Week == 5 && x.IsSubmitted).Sum(x => x.TotalWeekHours);

                    timesheetToUpdate.TotalMonthHours = timesheetToUpdate.Week1Hours + timesheetToUpdate.Week2Hours + timesheetToUpdate.Week3Hours + timesheetToUpdate.Week4Hours + timesheetToUpdate.Week5Hours;
                    await TimesheetAppService.Repository.UpdateAsync(timesheetToUpdate);
                }
                else
                {
                    Timesheet_Dto timesheetToCreateDto = new Timesheet_Dto();
                    timesheetToCreateDto.Year = weeksheetDto.Year;
                    timesheetToCreateDto.Month = weeksheetDto.Month;
                    timesheetToCreateDto.EmployeeId = weeksheetDto.EmployeeId;
                    weeksheetDto.Id = 0;
                    weeksheetDto.Dated = DateTime.Now;
                    timesheetToCreateDto.WeeklySummaries = new List<TimesheetWeekSummary_Dto>() { weeksheetDto };
                    timesheetToCreateDto.Dated = DateTime.Now;

                    switch (weeksheetDto.Week)
                    {
                        case 1:
                            timesheetToCreateDto.Week1Hours = weeksheetDto.TotalWeekHours;
                            break;
                        case 2:
                            timesheetToCreateDto.Week2Hours = weeksheetDto.TotalWeekHours;
                            break;
                        case 3:
                            timesheetToCreateDto.Week3Hours = weeksheetDto.TotalWeekHours;
                            break;
                        case 4:
                            timesheetToCreateDto.Week4Hours = weeksheetDto.TotalWeekHours;
                            break;
                        case 5:
                            timesheetToCreateDto.Week5Hours = weeksheetDto.TotalWeekHours;
                            break;
                    }
                    timesheetToCreateDto.TotalMonthHours = timesheetToCreateDto.Week1Hours + timesheetToCreateDto.Week2Hours + timesheetToCreateDto.Week3Hours + timesheetToCreateDto.Week4Hours + timesheetToCreateDto.Week5Hours;

                    Timesheet_Dto timesheetCreatedDto = await TimesheetAppService.CreateAsync(timesheetToCreateDto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            return new OkResult();
        }

        public List<GridColumn> GetCommandsColumns()
        {
            List<object> commands = new List<object>();
            commands.Add(new { type = "Edit", buttonOption = new { iconCss = "e-icons e-edit", cssClass = "e-flat" } });

            return new List<GridColumn>()
            {
                new GridColumn { Width = "65", HeaderText = "Actions", TextAlign=TextAlign.Center, MinWidth="10", Commands = commands }
            };
        }
        public List<GridColumn> GetPrimaryGridColumns()
        {
            List<GridColumn> gridColumns = new List<GridColumn>() {
                new GridColumn { Field = "id", Width = "80", HeaderText = "Emp Id", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "chargeability", Width = "110", HeaderText = "Employee", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "type", Width = "110", HeaderText = "Department", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "client.name", Width = "110", HeaderText = "Month", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "year", Width = "110", HeaderText = "Year", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "dated", Width = "110", HeaderText = "Dated", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "", Width = "110", HeaderText = "Weekly Hours", TextAlign=TextAlign.Center,  MinWidth="10",
                    Columns = new List<GridColumn>(){
                        new GridColumn { Field = "week1", Width = "95", HeaderText = "1st Week", TextAlign=TextAlign.Center,  MinWidth="10"  },
                        new GridColumn { Field = "week2", Width = "95", HeaderText = "2nd Week", TextAlign=TextAlign.Center,  MinWidth="10"  },
                        new GridColumn { Field = "week3", Width = "95", HeaderText = "3rd Week", TextAlign=TextAlign.Center,  MinWidth="10"  },
                        new GridColumn { Field = "week4", Width = "95", HeaderText = "4th Week", TextAlign=TextAlign.Center,  MinWidth="10"  },
                        new GridColumn { Field = "week5", Width = "95", HeaderText = "5th Week", TextAlign=TextAlign.Center,  MinWidth="10"  },
                    }
                },
                new GridColumn { Field = "totalMonthHours", Width = "110", HeaderText = "Total Hours", TextAlign=TextAlign.Center,  MinWidth="10" }
            };

            gridColumns.AddRange(GetCommandsColumns());

            return gridColumns;
        }

        public class SearchVM
        {
            public int Year { get; set; }
            public int Month { get; set; }
            public int Week { get; set; }
            public Guid EmployeeId { get; set; }
        }
    }
}
