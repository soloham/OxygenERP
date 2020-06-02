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
    public class OS_DivisionTemplateAppService : CrudAppService<OS_DivisionTemplate, OS_DivisionTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_DivisionTemplate_Dto, OS_DivisionTemplate_Dto>
    {
        public IRepository<OS_DivisionTemplate, int> Repository { get; }
        public IRepository<OS_OrganizationStructureTemplateBusinessUnit> OrganizationStructureBUsRepository { get; }

        public OS_DivisionTemplateAppService(IRepository<OS_DivisionTemplate, int> repository, IRepository<OS_OrganizationStructureTemplateBusinessUnit> organizationStructureRepository) : base(repository)
        {
            Repository = repository;
            OrganizationStructureBUsRepository = organizationStructureRepository;
        }

        public async Task<List<OS_DivisionTemplate_Dto>> GetAllDivisionTemplatesAsync()
        {
            List<OS_DivisionTemplate_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
            return list;
        }

        public async Task<List<EntityReference>> GetAllReferences(int id)
        {
            List<EntityReference> entityReferences = new List<EntityReference>();

            entityReferences.AddRange(OrganizationStructureBUsRepository.WithDetails().Where(x => x.OrganizationStructureTemplateDivisions.Any(y => y.DivisionTemplateId == id))
                .ToList()
                .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.BusinessUnitTemplate.Name, Code = x.BusinessUnitTemplate.Code, Type = "OS Business Unit" }));

            //entityReferences.AddRange(TasksReferenceRepo.WithDetails(x => x.TaskTemplate).Where(x => x.DivisionTemplateId == id)
            //    .ToList()
            //    .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.TaskTemplate.Name, Code = x.TaskTemplate.Code, Type = "Task" }));

            //entityReferences.AddRange(JobsReferenceRepo.WithDetails(x => x.JobTemplate).Where(x => x.DivisionTemplateId == id)
            //    .ToList()
            //    .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.JobTemplate.Name, Code = x.JobTemplate.Code, Type = "Job" }));

            return entityReferences;
        }
    }
}
