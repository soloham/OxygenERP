using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
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

namespace CERP.AppServices.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_TaskTemplateAppService : CrudAppService<OS_TaskTemplate, OS_TaskTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_TaskTemplate_Dto, OS_TaskTemplate_Dto>
    {
        public OS_TaskTemplateAppService(IRepository<OS_TaskTemplate, int> repository, IRepository<OS_TaskQualificationTemplate, int> tasksQualificationsRepository) : base(repository)
        {
            Repository = repository;
            QualificationsRepository = tasksQualificationsRepository;
        }

        public IRepository<OS_TaskTemplate, int> Repository { get; }
        public IRepository<OS_TaskQualificationTemplate, int> QualificationsRepository { get; }

        public async Task<List<OS_TaskTemplate_Dto>> GetAllTaskTemplatesAsync()
        {
            List<OS_TaskTemplate_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
            return list;
        }
        public async Task<OS_TaskTemplate_Dto> GetTaskTemplateAsync(int id)
        {
            OS_TaskTemplate_Dto obj = ObjectMapper.Map< OS_TaskTemplate, OS_TaskTemplate_Dto>(await Repository.GetAsync(id, true));
            return obj;
        }

        public async Task<OS_TaskQualificationTemplate_Dto> AddQualificationTemplate(OS_TaskQualificationTemplate taskQualificationTemplate)
        {
            return ObjectMapper.Map<OS_TaskQualificationTemplate, OS_TaskQualificationTemplate_Dto>(await QualificationsRepository.InsertAsync(taskQualificationTemplate));
        }
        public async Task<OS_TaskQualificationTemplate_Dto> AddQualificationTemplate(OS_TaskQualificationTemplate_Dto taskQualificationTemplate)
        {
            OS_TaskQualificationTemplate toAdd = ObjectMapper.Map<OS_TaskQualificationTemplate_Dto, OS_TaskQualificationTemplate>(taskQualificationTemplate);
            return ObjectMapper.Map<OS_TaskQualificationTemplate, OS_TaskQualificationTemplate_Dto>(await QualificationsRepository.InsertAsync(toAdd));
        }
    }
}
