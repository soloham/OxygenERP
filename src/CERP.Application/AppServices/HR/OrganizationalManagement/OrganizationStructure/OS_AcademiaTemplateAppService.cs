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
    public class OS_AcademiaTemplateAppService : CrudAppService<OS_AcademiaTemplate, OS_AcademiaTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_AcademiaTemplate_Dto, OS_AcademiaTemplate_Dto>
    {
        public OS_AcademiaTemplateAppService(IRepository<OS_AcademiaTemplate, int> repository /*IRepository<OS_DepartmentAcademiaTemplate, int> departmentAcademiaTemplateRepo,*/, IRepository<OS_CompensationMatrixTemplate, int> compensationMatrixRepository, IRepository<OS_FunctionAcademiaTemplate, int> functionsReferenceRepo, IRepository<OS_TaskAcademiaTemplate, int> tasksReferenceRepo, IRepository<OS_JobAcademiaTemplate, int> jobsReferenceRepo) : base(repository)
        {
            Repository = repository;
            CompensationMatrixRepository = compensationMatrixRepository;
            FunctionsReferenceRepo = functionsReferenceRepo;
            TasksReferenceRepo = tasksReferenceRepo;
            JobsReferenceRepo = jobsReferenceRepo;
        }

        public IRepository<OS_AcademiaTemplate, int> Repository { get; }
        public IRepository<OS_CompensationMatrixTemplate, int> CompensationMatrixRepository { get; }
        public IRepository<OS_FunctionAcademiaTemplate, int> FunctionsReferenceRepo { get; }
        public IRepository<OS_TaskAcademiaTemplate, int> TasksReferenceRepo { get; }
        public IRepository<OS_JobAcademiaTemplate, int> JobsReferenceRepo { get; }

        public async Task<List<OS_AcademiaTemplate_Dto>> GetAllAcademiaTemplatesAsync()
        {
            List<OS_AcademiaTemplate_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
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

            entityReferences.AddRange(FunctionsReferenceRepo.WithDetails(x => x.FunctionTemplate).Where(x => x.AcademiaTemplateId == id)
                .ToList()
                .Select(x => new EntityReference() { Id = entityReferences.Count+1, Name = x.FunctionTemplate.Name, Code = x.FunctionTemplate.Code, Type = "Function" }));
            
            entityReferences.AddRange(TasksReferenceRepo.WithDetails(x => x.TaskTemplate).Where(x => x.AcademiaTemplateId == id)
                .ToList()
                .Select(x => new EntityReference() { Id = entityReferences.Count+1, Name = x.TaskTemplate.Name, Code = x.TaskTemplate.Code, Type = "Task" }));
            
            entityReferences.AddRange(JobsReferenceRepo.WithDetails(x => x.JobTemplate).Where(x => x.AcademiaTemplateId == id)
                .ToList()
                .Select(x => new EntityReference() { Id = entityReferences.Count+1, Name = x.JobTemplate.Name, Code = x.JobTemplate.Code, Type = "Job" }));

            return entityReferences;
        }
    }
}
