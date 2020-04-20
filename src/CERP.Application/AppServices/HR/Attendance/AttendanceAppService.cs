using CERP.HR.Attendance;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.Holidays;
using CERP.HR.Leaves;
using CERP.HR.Workshift.DTOs;
using CERP.HR.Workshifts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.HR.AttendanceService
{
    public class AttendanceAppService : CrudAppService<Attendance, Attendance_Dto, int, PagedAndSortedResultRequestDto, Attendance_Dto, Attendance_Dto>
    {
        public AttendanceAppService(IRepository<Attendance, int> repository) : base(repository)
        {
            Repository = repository;
            
        }

        public IRepository<Attendance, int> Repository { get; }
       

        [Route("/api/app/attendance/getAllAsync")]
        public async Task<List<Attendance_Dto>> GetAllAsync()
        {
            List<Attendance> all = await Repository.GetListAsync(true);
            List<Attendance_Dto> mapped = ObjectMapper.Map<List<Attendance>, List<Attendance_Dto>>(all);
            return mapped;
        }
        public async Task<Attendance_Dto> GetCustomAsync(int id)
        {
            return ObjectMapper.Map<Attendance, Attendance_Dto>(await Repository.GetAsync(id, true));
        }

        public async Task<Attendance_Dto> CreateCustomAsync(Attendance_Dto attendance)
        {
            var created = await CreateAsync(attendance);
            return await GetCustomAsync(created.Id);
        }
    }
}
