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
    public class OS_FunctionTemplateAppService : CrudAppService<OS_FunctionTemplate, OS_FunctionTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_FunctionTemplate_Dto, OS_FunctionTemplate_Dto>
    {
        public OS_FunctionTemplateAppService(IRepository<OS_FunctionTemplate, int> repository, IRepository<OS_FunctionSkillTemplate, int> skillsRepository, IRepository<OS_FunctionAcademiaTemplate, int> academiaRepository, IRepository<OS_CompensationMatrixTemplate, int> compensationMatrixRepository) : base(repository)
        {
            Repository = repository;
            SkillsRepository = skillsRepository;
            AcademiaRepository = academiaRepository;
            CompensationMatrixRepository = compensationMatrixRepository;
        }

        public IRepository<OS_FunctionTemplate, int> Repository { get; }
        public IRepository<OS_FunctionSkillTemplate, int> SkillsRepository { get; }
        public IRepository<OS_FunctionAcademiaTemplate, int> AcademiaRepository { get; }
        public IRepository<OS_CompensationMatrixTemplate, int> CompensationMatrixRepository { get; }

        public async Task<List<OS_FunctionTemplate_Dto>> GetAllFunctionTemplatesAsync()
        {
            List<OS_FunctionTemplate_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
            return list;
        }
        public async Task<OS_FunctionTemplate_Dto> GetFunctionTemplateAsync(int id)
        {
            OS_FunctionTemplate_Dto obj = ObjectMapper.Map< OS_FunctionTemplate, OS_FunctionTemplate_Dto>(await Repository.GetAsync(id, true));
            return obj;
        }

        public async Task<OS_FunctionSkillTemplate_Dto> AddSkillTemplate(OS_FunctionSkillTemplate functionSkillTemplate)
        {
            return ObjectMapper.Map<OS_FunctionSkillTemplate, OS_FunctionSkillTemplate_Dto>(await SkillsRepository.InsertAsync(functionSkillTemplate));
        }
        public async Task<OS_FunctionSkillTemplate_Dto> AddSkillTemplate(OS_FunctionSkillTemplate_Dto functionSkillTemplate)
        {
            OS_FunctionSkillTemplate toAdd = ObjectMapper.Map<OS_FunctionSkillTemplate_Dto, OS_FunctionSkillTemplate>(functionSkillTemplate);
            return ObjectMapper.Map<OS_FunctionSkillTemplate, OS_FunctionSkillTemplate_Dto>(await SkillsRepository.InsertAsync(toAdd));
        }

        public async Task<OS_FunctionAcademiaTemplate_Dto> AddAcademiaTemplate(OS_FunctionAcademiaTemplate functionAcademiaTemplate)
        {
            return ObjectMapper.Map<OS_FunctionAcademiaTemplate, OS_FunctionAcademiaTemplate_Dto>(await AcademiaRepository.InsertAsync(functionAcademiaTemplate));
        }
        public async Task<OS_FunctionAcademiaTemplate_Dto> AddAcademia(OS_FunctionAcademiaTemplate_Dto functionAcademiaTemplate)
        {
            OS_FunctionAcademiaTemplate toAdd = ObjectMapper.Map<OS_FunctionAcademiaTemplate_Dto, OS_FunctionAcademiaTemplate>(functionAcademiaTemplate);
            return ObjectMapper.Map<OS_FunctionAcademiaTemplate, OS_FunctionAcademiaTemplate_Dto>(await AcademiaRepository.InsertAsync(toAdd));
        }

        public async Task<OS_CompensationMatrixTemplate_Dto> GetCompensationMatrixAsync(int compensationMatrixId)
        {
            OS_CompensationMatrixTemplate_Dto result = ObjectMapper.Map<OS_CompensationMatrixTemplate, OS_CompensationMatrixTemplate_Dto>(await CompensationMatrixRepository.GetAsync(compensationMatrixId, true));
            return result;
        }
    }
}
