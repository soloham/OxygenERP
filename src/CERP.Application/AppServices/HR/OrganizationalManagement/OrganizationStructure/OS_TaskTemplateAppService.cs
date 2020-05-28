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
    public class OS_TaskTemplateAppService : CrudAppService<OS_TaskTemplate, OS_TaskTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_TaskTemplate_Dto, OS_TaskTemplate_Dto>
    {
        public OS_TaskTemplateAppService(IRepository<OS_TaskTemplate, int> repository, IRepository<OS_TaskSkillTemplate, int> skillsRepository, IRepository<OS_TaskAcademiaTemplate, int> academiaRepository, IRepository<OS_CompensationMatrixTemplate, int> compensationmatrixRepository, IRepository<OS_CompensationMatrixTemplate, int> compensationMatrixRepository, IRepository<OS_JobTaskTemplate, int> jobsReferenceRepo, IRepository<OS_PositionTaskTemplate, int> positionsReferenceRepo) : base(repository)
        {
            Repository = repository;
            SkillsRepository = skillsRepository;
            AcademiaRepository = academiaRepository;
            CompensationMatrixRepository = compensationmatrixRepository;
            CompensationMatrixRepository = compensationMatrixRepository;
            JobsReferenceRepo = jobsReferenceRepo;
            PositionsReferenceRepo = positionsReferenceRepo;
        }

        public IRepository<OS_TaskTemplate, int> Repository { get; }
        public IRepository<OS_TaskSkillTemplate, int> SkillsRepository { get; }
        public IRepository<OS_TaskAcademiaTemplate, int> AcademiaRepository { get; }
        public IRepository<OS_CompensationMatrixTemplate, int> CompensationMatrixRepository { get; }

        public IRepository<OS_JobTaskTemplate, int> JobsReferenceRepo { get; }
        public IRepository<OS_PositionTaskTemplate, int> PositionsReferenceRepo { get; }

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

        //public async Task<OS_TaskQualificationTemplate_Dto> AddQualificationTemplate(OS_TaskQualificationTemplate taskQualificationTemplate)
        //{
        //    return ObjectMapper.Map<OS_TaskQualificationTemplate, OS_TaskQualificationTemplate_Dto>(await QualificationsRepository.InsertAsync(taskQualificationTemplate));
        //}
        //public async Task<OS_TaskQualificationTemplate_Dto> AddQualificationTemplate(OS_TaskQualificationTemplate_Dto taskQualificationTemplate)
        //{
        //    OS_TaskQualificationTemplate toAdd = ObjectMapper.Map<OS_TaskQualificationTemplate_Dto, OS_TaskQualificationTemplate>(taskQualificationTemplate);
        //    return ObjectMapper.Map<OS_TaskQualificationTemplate, OS_TaskQualificationTemplate_Dto>(await QualificationsRepository.InsertAsync(toAdd));
        //}

        public async Task<OS_TaskSkillTemplate_Dto> AddSkillTemplate(OS_TaskSkillTemplate functionSkillTemplate)
        {
            return ObjectMapper.Map<OS_TaskSkillTemplate, OS_TaskSkillTemplate_Dto>(await SkillsRepository.InsertAsync(functionSkillTemplate));
        }
        public async Task<OS_TaskSkillTemplate_Dto> AddSkillTemplate(OS_TaskSkillTemplate_Dto functionSkillTemplate)
        {
            OS_TaskSkillTemplate toAdd = ObjectMapper.Map<OS_TaskSkillTemplate_Dto, OS_TaskSkillTemplate>(functionSkillTemplate);
            return ObjectMapper.Map<OS_TaskSkillTemplate, OS_TaskSkillTemplate_Dto>(await SkillsRepository.InsertAsync(toAdd));
        }

        public async Task<OS_TaskAcademiaTemplate_Dto> AddAcademiaTemplate(OS_TaskAcademiaTemplate functionAcademiaTemplate)
        {
            return ObjectMapper.Map<OS_TaskAcademiaTemplate, OS_TaskAcademiaTemplate_Dto>(await AcademiaRepository.InsertAsync(functionAcademiaTemplate));
        }
        public async Task<OS_TaskAcademiaTemplate_Dto> AddAcademia(OS_TaskAcademiaTemplate_Dto functionAcademiaTemplate)
        {
            OS_TaskAcademiaTemplate toAdd = ObjectMapper.Map<OS_TaskAcademiaTemplate_Dto, OS_TaskAcademiaTemplate>(functionAcademiaTemplate);
            return ObjectMapper.Map<OS_TaskAcademiaTemplate, OS_TaskAcademiaTemplate_Dto>(await AcademiaRepository.InsertAsync(toAdd));
        }

        public async Task<OS_CompensationMatrixTemplate_Dto> GetCompensationMatrixAsync(int compensationMatrixId)
        {
            OS_CompensationMatrixTemplate_Dto result = ObjectMapper.Map<OS_CompensationMatrixTemplate, OS_CompensationMatrixTemplate_Dto>(await CompensationMatrixRepository.GetAsync(compensationMatrixId, true));
            return result;
        }
        public async Task<List<EntityReference>> GetAllReferences(int id)
        {
            List<EntityReference> entityReferences = new List<EntityReference>();

            entityReferences.AddRange(JobsReferenceRepo.WithDetails(x => x.JobTemplate).Where(x => x.TaskTemplateId == id)
                .ToList()
                .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.JobTemplate.Name, Code = x.JobTemplate.Code, Type = "Job" }));
            
            entityReferences.AddRange(PositionsReferenceRepo.WithDetails(x => x.PositionTemplate).Where(x => x.TaskTemplateId == id)
                .ToList()
                .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.PositionTemplate.Name, Code = x.PositionTemplate.Code, Type = "Position" }));

            return entityReferences;
        }
    }
}
