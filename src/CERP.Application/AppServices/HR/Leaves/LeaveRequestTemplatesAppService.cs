using CERP.HR.EMPLOYEE.DTOs;
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

namespace CERP.AppServices.HR.LeaveRequestService
{
    public class LeaveRequestTemplatesAppService : CrudAppService<LeaveRequestTemplate, LeaveRequestTemplate_Dto, int, PagedAndSortedResultRequestDto, LeaveRequestTemplate_Dto, LeaveRequestTemplate_Dto>
    {
        public LeaveRequestTemplatesAppService(IRepository<LeaveRequestTemplate, int> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<LeaveRequestTemplate, int> Repository { get; }

        [Route("/getAllAsync")]
        public async Task<List<LeaveRequestTemplate_Dto>> GetAllAsync()
        {
            List<LeaveRequestTemplate> all = await Repository.GetListAsync(true);
            List<LeaveRequestTemplate_Dto> mapped = ObjectMapper.Map<List<LeaveRequestTemplate>, List<LeaveRequestTemplate_Dto>>(all);
            return mapped;
        }
        public async Task<LeaveRequestTemplate_Dto> GetCustomAsync(int id)
        {
            return ObjectMapper.Map<LeaveRequestTemplate, LeaveRequestTemplate_Dto>(await Repository.GetAsync(id, true));
        }

        public async Task<LeaveRequestTemplate_Dto> CreateCustomAsync(LeaveRequestTemplate_Dto leaveRequestTemplate)
        {
            var created = await CreateAsync(leaveRequestTemplate);
            return await GetCustomAsync(created.Id);
        }
    }
}
