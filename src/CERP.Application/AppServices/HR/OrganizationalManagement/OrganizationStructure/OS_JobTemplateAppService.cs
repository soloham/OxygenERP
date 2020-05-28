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
    public class OS_JobTemplateAppService : CrudAppService<OS_JobTemplate, OS_JobTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_JobTemplate_Dto, OS_JobTemplate_Dto>
    {
        public OS_JobTemplateAppService(IRepository<OS_JobTemplate, int> repository, IRepository<OS_JobTaskTemplate, int> tasksRepository, IRepository<OS_JobFunctionTemplate, int> functionsRepository, IRepository<OS_JobSkillTemplate, int> skillsRepository, IRepository<OS_JobAcademiaTemplate, int> academiaRepository, IRepository<OS_CompensationMatrixTemplate, int> compensationMatrixRepository, IRepository<OS_JobWorkshiftTemplate, int> workshiftsRepository, IRepository<OS_PositionJobTemplate, int> positionsReferenceRepo) : base(repository)
        {
            Repository = repository;
            TasksRepository = tasksRepository;
            FunctionsRepository = functionsRepository;
            SkillsRepository = skillsRepository;
            AcademiaRepository = academiaRepository;
            CompensationMatrixRepository = compensationMatrixRepository;
            WorkshiftsRepository = workshiftsRepository;
            PositionsReferenceRepo = positionsReferenceRepo;
        }

        public IRepository<OS_JobTemplate, int> Repository { get; }
        public IRepository<OS_JobTaskTemplate, int> TasksRepository { get; }
        public IRepository<OS_JobFunctionTemplate, int> FunctionsRepository { get; }
        public IRepository<OS_JobSkillTemplate, int> SkillsRepository { get; }
        public IRepository<OS_JobAcademiaTemplate, int> AcademiaRepository { get; }
        public IRepository<OS_CompensationMatrixTemplate, int> CompensationMatrixRepository { get; }
        public IRepository<OS_JobWorkshiftTemplate, int> WorkshiftsRepository { get; set; }

        public IRepository<OS_PositionJobTemplate, int> PositionsReferenceRepo { get; set; }

        public async Task<List<OS_JobTemplate_Dto>> GetAllJobTemplatesAsync(bool withDetails = false)
        {
            List<OS_JobTemplate_Dto> list = (await Repository.GetListAsync(withDetails)).Select(MapToGetListOutputDto).ToList();
            return list;
        }
        public async Task<OS_JobTemplate_Dto> GetJobTemplateAsync(int id)
        {
            OS_JobTemplate_Dto obj = ObjectMapper.Map<OS_JobTemplate, OS_JobTemplate_Dto>(await Repository.GetAsync(id, true));
            return obj;
        }

        public async Task<OS_CompensationMatrixTemplate_Dto> GetCompensationMatrixAsync(int compensationMatrixId)
        {
            OS_CompensationMatrixTemplate_Dto result = ObjectMapper.Map<OS_CompensationMatrixTemplate, OS_CompensationMatrixTemplate_Dto>(await CompensationMatrixRepository.GetAsync(compensationMatrixId, true));
            return result;
        }

        public async Task<List<EntityReference>> GetAllReferences(int id)
        {
            List<EntityReference> entityReferences = new List<EntityReference>();

            entityReferences.AddRange(PositionsReferenceRepo.WithDetails(x => x.PositionTemplate).Where(x => x.JobTemplateId == id)
                .ToList()
                .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.PositionTemplate.Name, Code = x.PositionTemplate.Code, Type = "Position" }));

            return entityReferences;
        }
    }
}
