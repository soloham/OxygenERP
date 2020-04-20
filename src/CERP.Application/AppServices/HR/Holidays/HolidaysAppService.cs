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

namespace CERP.AppServices.HR.HolidayService
{
    public class HolidaysAppService : CrudAppService<Holiday, Holiday_Dto, int, PagedAndSortedResultRequestDto, Holiday_Dto, Holiday_Dto>
    {
        public HolidaysAppService(IRepository<Holiday, int> repository) : base(repository)
        {
            Repository = repository;
            
        }

        public IRepository<Holiday, int> Repository { get; }
       

        [Route("/api/app/holidays/getAllAsync")]
        public async Task<List<Holiday_Dto>> GetAllAsync()
        {
            List<Holiday> all = await Repository.GetListAsync(true);
            List<Holiday_Dto> mapped = ObjectMapper.Map<List<Holiday>, List<Holiday_Dto>>(all);
            return mapped;
        }
        public async Task<Holiday_Dto> GetCustomAsync(int id)
        {
            return ObjectMapper.Map<Holiday, Holiday_Dto>(await Repository.GetAsync(id, true));
        }

        public async Task<Holiday_Dto> CreateCustomAsync(Holiday_Dto holiday)
        {
            var created = await CreateAsync(holiday);
            return await GetCustomAsync(created.Id);
        }
    }
}
