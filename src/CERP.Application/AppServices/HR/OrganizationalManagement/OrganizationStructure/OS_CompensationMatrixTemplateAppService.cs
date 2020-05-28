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
    public class OS_CompensationMatrixTemplateAppService : CrudAppService<OS_CompensationMatrixTemplate, OS_CompensationMatrixTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_CompensationMatrixTemplate_Dto, OS_CompensationMatrixTemplate_Dto>
    {
        public OS_CompensationMatrixTemplateAppService(IRepository<OS_CompensationMatrixTemplate, int> repository /*IRepository<OS_DepartmentCompensationMatrixTemplate, int> departmentCompensationMatrixTemplateRepo,*/, IRepository<OS_AcademiaTemplate, int> academiaRepository, IRepository<OS_SkillTemplate, int> skillsRepository, IRepository<OS_FunctionTemplate, int> functionsRepository, IRepository<OS_TaskTemplate, int> tasksRepository, IRepository<OS_JobTemplate, int> jobsRepository) : base(repository)
        {
            Repository = repository;
            AcademiaRepository = academiaRepository;
            SkillsRepository = skillsRepository;
            FunctionsRepository = functionsRepository;
            TasksRepository = tasksRepository;
            JobsRepository = jobsRepository;
        }

        public IRepository<OS_CompensationMatrixTemplate, int> Repository { get; }
        public IRepository<OS_AcademiaTemplate, int> AcademiaRepository { get; }
        public IRepository<OS_SkillTemplate, int> SkillsRepository { get; }
        public IRepository<OS_FunctionTemplate, int> FunctionsRepository { get; }
        public IRepository<OS_TaskTemplate, int> TasksRepository { get; }
        public IRepository<OS_JobTemplate, int> JobsRepository { get; }

        public async Task<List<OS_CompensationMatrixTemplate_Dto>> GetAllCompensationMatrixTemplatesAsync()
        {
            List<OS_CompensationMatrixTemplate_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
            return list;
        }

        public async Task<List<EntityReference>> GetAllReferences(int id)
        {
            List<EntityReference> entityReferences = new List<EntityReference>();

            entityReferences.AddRange(AcademiaRepository.Where(x => x.CompensationMatrixId == id)
                .ToList()
                .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.Name, Code = x.Code, Type = "Academia" }));

            entityReferences.AddRange(SkillsRepository.Where(x => x.CompensationMatrixId == id)
                .ToList()
                .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.Name, Code = x.Code, Type = "Skill" }));

            entityReferences.AddRange(FunctionsRepository.Where(x => x.CompensationMatrixId == id)
                .ToList()
                .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.Name, Code = x.Code, Type = "Function" }));
            
            entityReferences.AddRange(TasksRepository.Where(x => x.CompensationMatrixId == id)
                .ToList()
                .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.Name, Code = x.Code, Type = "Task" }));
            
            entityReferences.AddRange(JobsRepository.Where(x => x.CompensationMatrixId == id)
                .ToList()
                .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.Name, Code = x.Code, Type = "Job" }));

            return entityReferences;
        }
    }
}
