using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CERP.App;
using CERP.AppServices.HR.DepartmentService;
using CERP.AppServices.HR.WorkShiftService;
using CERP.AppServices.Setup.DepartmentSetup;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.Workshift.DTOs;
using CERP.HR.Workshifts;
using CERP.Setup.DTOs;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Grids;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Json;

namespace CERP.Web.Areas.HR.Pages.WorkShifts
{
    public class ListModel : CERPPageModel
    {
        public IGuidGenerator guidGenerator { get; set; }
        public IJsonSerializer JsonSerializer { get; set; }

        public DepartmentAppService DepartmentAppService { get; set; }
        public WorkShiftsAppService WorkShiftsAppService { get; set; }

        public ListModel(IGuidGenerator guidGenerator, DepartmentAppService departmentAppService, WorkShiftsAppService workShiftsAppService, IJsonSerializer jsonSerializer)
        {
            this.guidGenerator = guidGenerator;
            DepartmentAppService = departmentAppService;
            WorkShiftsAppService = workShiftsAppService;
            JsonSerializer = jsonSerializer;
        }

        public async Task OnDeleteWorkShift()
        {
            List<WorkShift_Dto> workshifts = JsonSerializer.Deserialize<List<WorkShift_Dto>>(Request.Form["workshifts"]);
            for (int i = 0; i < workshifts.Count; i++)
            {
                WorkShift_Dto workshift = workshifts[i];
                await WorkShiftsAppService.DeleteAsync(workshift.Id);
            }
        }

        public void OnGet()
        {
            List<WorkShift_Dto> workshifts = ObjectMapper.Map<List<WorkShift>, List<WorkShift_Dto>>(WorkShiftsAppService.Repository.WithDetails(x => x.Department).ToList());
            ViewData["Workshifts_DS"] = JsonSerializer.Serialize(workshifts);
        }
        

        public List<GridColumn> GetCommandsColumns()
        {
            List<object> commands = new List<object>();
            commands.Add(new { type = "Edit", buttonOption = new { iconCss = "e-icons e-edit", cssClass = "e-flat" } });
            commands.Add(new { type = "Delete", buttonOption = new { iconCss = "e-icons e-delete", cssClass = "e-flat" } });
            commands.Add(new { type = "Save", buttonOption = new { iconCss = "e-icons e-update", cssClass = "e-flat" } });
            commands.Add(new { type = "Cancel", buttonOption = new { iconCss = "e-icons e-cancel-icon", cssClass = "e-flat" } });

            return new List<GridColumn>()
            {
                new GridColumn { Width = "150", HeaderText = "Commands", TextAlign=TextAlign.Center, MinWidth="10", Commands = commands }
            };
        }
        public List<GridColumn> GetPrimaryGridColumns()
        {
            List<GridColumn> gridColumns = new List<GridColumn>() {
                new GridColumn { Field = "id", Width = "80", HeaderText = "#", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "title", Width = "110", HeaderText = "Title", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "department.name", Width = "110", HeaderText = "Department", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "startHour", Width = "110", HeaderText = "Start Hour", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "endHour", Width = "110", HeaderText = "End Hour", TextAlign=TextAlign.Center,  MinWidth="10"  },
            };

            gridColumns.AddRange(GetCommandsColumns());

            return gridColumns;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var formData = Request.Form;

                    WorkShiftViewModel generalInfo = new WorkShiftViewModel();
                    generalInfo = JsonSerializer.Deserialize<WorkShiftViewModel>(formData["info"].ToString());
                    generalInfo.initialize();

                    if(generalInfo.IsEditing)
                    {
                        WorkShift workShift = WorkShiftsAppService.Repository.First(x => x.Id == generalInfo.Id);
                        workShift.Title = generalInfo.Title;
                        workShift.DepartmentId = generalInfo.DepartmentId;
                        workShift.StartHour = generalInfo.StartHour;
                        workShift.EndHour = generalInfo.EndHour;

                        WorkShift workShiftAdded = await WorkShiftsAppService.Repository.UpdateAsync(workShift);
                        WorkShift_Dto workShiftDto = ObjectMapper.Map<WorkShift, WorkShift_Dto>(WorkShiftsAppService.Repository.WithDetails(x => x.Department).First(x => x.Id == workShiftAdded.Id));
                        return new JsonResult(workShiftDto);
                    }
                    else
                    {
                        WorkShift_Dto workShift = new WorkShift_Dto();
                        workShift.Title = generalInfo.Title;
                        workShift.DepartmentId = generalInfo.DepartmentId;
                        workShift.StartHour = generalInfo.StartHour;
                        workShift.EndHour = generalInfo.EndHour;

                        WorkShift_Dto workShiftAdded = await WorkShiftsAppService.CreateAsync(workShift);
                        WorkShift_Dto workShiftDto = ObjectMapper.Map<WorkShift, WorkShift_Dto>(WorkShiftsAppService.Repository.WithDetails(x => x.Department).First(x => x.Id == workShiftAdded.Id));
                        return new JsonResult(workShiftDto);
                    }
                }
                catch(Exception ex)
                {
                    return StatusCode(500);
                }
            }
            return NoContent();
        }

        public class WorkShiftViewModel
        {
            public WorkShiftViewModel()
            {
                IsEditing = false;
            }

            public void initialize()
            {
                DepartmentId = Department.Id;
            }

            public int Id { get; set; }

            public bool IsEditing { get; set; }
            public string Title { get; set; }
            public int StartHour { get; set; }
            public int EndHour { get; set; }

            public Department_Dto Department { get; set; }
            public Guid? DepartmentId { get; set; }
        }
    }
}
