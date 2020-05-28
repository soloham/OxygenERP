using CERP.ApplicationContracts.HR.OrganizationalManagement;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.OrganizationalManagement;
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
    public class OS_SkillTemplateAppService : CrudAppService<OS_SkillTemplate, OS_SkillTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_SkillTemplate_Dto, OS_SkillTemplate_Dto>
    {
        public OS_SkillTemplateAppService(IRepository<OS_SkillTemplate, int> repository /*IRepository<OS_DepartmentSkillTemplate, int> departmentSkillTemplateRepo,*/, IRepository<OS_CompensationMatrixTemplate, int> compensationMatrixRepository, IRepository<OS_FunctionSkillTemplate, int> functionsReferenceRepo, IRepository<OS_TaskSkillTemplate, int> tasksReferenceRepo, IRepository<OS_JobSkillTemplate, int> jobsReferenceRepo) : base(repository)
        {
            Repository = repository;
            CompensationMatrixRepository = compensationMatrixRepository;
            FunctionsReferenceRepo = functionsReferenceRepo;
            TasksReferenceRepo = tasksReferenceRepo;
            JobsReferenceRepo = jobsReferenceRepo;
        }

        public IRepository<OS_SkillTemplate, int> Repository { get; }
        public IRepository<OS_CompensationMatrixTemplate, int> CompensationMatrixRepository { get; }
        public IRepository<OS_FunctionSkillTemplate, int> FunctionsReferenceRepo { get; }
        public IRepository<OS_TaskSkillTemplate, int> TasksReferenceRepo { get; }
        public IRepository<OS_JobSkillTemplate, int> JobsReferenceRepo { get; }

        public async Task<List<OS_SkillTemplate_Dto>> GetAllSkillTemplatesAsync()
        {
            List<OS_SkillTemplate_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
            return list;
        }

        public async Task<OS_CompensationMatrixTemplate_Dto> GetCompensationMatrixAsync(int compensationMatrixId)
        {
            OS_CompensationMatrixTemplate_Dto result = ObjectMapper.Map<OS_CompensationMatrixTemplate, OS_CompensationMatrixTemplate_Dto>(await CompensationMatrixRepository.GetAsync(compensationMatrixId, true));
            return result;
        }
        public async Task<List<EntityReference>> GetAllReferences(int id)
        {
            List<EntityReference> entityReferences = new List<EntityReference>();

            entityReferences.AddRange(FunctionsReferenceRepo.WithDetails(x => x.FunctionTemplate).Where(x => x.SkillTemplateId == id)
                .ToList()
                .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.FunctionTemplate.Name, Code = x.FunctionTemplate.Code, Type = "Function" }));

            entityReferences.AddRange(TasksReferenceRepo.WithDetails(x => x.TaskTemplate).Where(x => x.SkillTemplateId == id)
                .ToList()
                .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.TaskTemplate.Name, Code = x.TaskTemplate.Code, Type = "Task" }));

            entityReferences.AddRange(JobsReferenceRepo.WithDetails(x => x.JobTemplate).Where(x => x.SkillTemplateId == id)
                .ToList()
                .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.JobTemplate.Name, Code = x.JobTemplate.Code, Type = "Job" }));

            return entityReferences;
        }
    }
}
