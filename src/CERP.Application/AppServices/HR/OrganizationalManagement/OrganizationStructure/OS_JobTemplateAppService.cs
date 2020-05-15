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
    public class OS_JobTemplateAppService : CrudAppService<OS_JobTemplate, OS_JobTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_JobTemplate_Dto, OS_JobTemplate_Dto>
    {
        public OS_JobTemplateAppService(IRepository<OS_JobTemplate, int> repository, IRepository<OS_JobQualificationTemplate, int> qualificationsRepository) : base(repository)
        {
            Repository = repository;
            QualificationsRepository = qualificationsRepository;
        }

        public IRepository<OS_JobTemplate, int> Repository { get; }
        public IRepository<OS_JobQualificationTemplate, int> QualificationsRepository { get; }

        public async Task<List<OS_JobTemplate_Dto>> GetAllJobTemplatesAsync()
        {
            List<OS_JobTemplate_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
            return list;
        }
        public async Task<OS_JobTemplate_Dto> GetJobTemplateAsync(int id)
        {
            OS_JobTemplate_Dto obj = ObjectMapper.Map<OS_JobTemplate, OS_JobTemplate_Dto>(await Repository.GetAsync(id, true));
            return obj;
        }

        public async Task<OS_JobQualificationTemplate_Dto> AddQualificationTemplate(OS_JobQualificationTemplate taskQualificationTemplate)
        {
            return ObjectMapper.Map<OS_JobQualificationTemplate, OS_JobQualificationTemplate_Dto>(await QualificationsRepository.InsertAsync(taskQualificationTemplate));
        }
        public async Task<OS_JobQualificationTemplate_Dto> AddQualificationTemplate(OS_JobQualificationTemplate_Dto taskQualificationTemplate)
        {
            OS_JobQualificationTemplate toAdd = ObjectMapper.Map<OS_JobQualificationTemplate_Dto, OS_JobQualificationTemplate>(taskQualificationTemplate);
            return ObjectMapper.Map<OS_JobQualificationTemplate, OS_JobQualificationTemplate_Dto>(await QualificationsRepository.InsertAsync(toAdd));
        }

    }
}
