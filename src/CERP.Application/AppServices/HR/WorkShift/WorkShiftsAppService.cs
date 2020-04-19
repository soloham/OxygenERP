using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.Workshift.DTOs;
using CERP.HR.Workshifts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.HR.WorkShiftService
{
    public class WorkshiftAppService : CrudAppService<WorkShift, WorkShift_Dto, int, PagedAndSortedResultRequestDto, WorkShift_Dto, WorkShift_Dto>
    {
        public WorkshiftAppService(IRepository<WorkShift, int> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<WorkShift, int> Repository { get; }

        [Route("/getAllWorkshifts")]
        public List<WorkShift_Dto> GetAll()
        {
            List<WorkShift> _workshifts = Repository.WithDetails(x => x.Department, x => x.DeductionMethod).ToList();
            List<WorkShift_Dto> workshifts = ObjectMapper.Map<List<WorkShift>, List<WorkShift_Dto>>(_workshifts);
            return workshifts;
        }
    }
}
