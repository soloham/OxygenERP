using CERP.ApplicationContracts.HR.OrganizationalManagement;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.OrganizationalManagement;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.OrganizationalManagement.PayrollStructure;
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

namespace CERP.AppServices.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PayFrequencyAppService : CrudAppService<PS_PayFrequency, PS_PayFrequency_Dto, int, PagedAndSortedResultRequestDto, PS_PayFrequency_Dto, PS_PayFrequency_Dto>
    {
        public PS_PayFrequencyAppService(IRepository<PS_PayFrequency, int> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<PS_PayFrequency, int> Repository { get; }

        public async Task<List<PS_PayFrequency_Dto>> GetAllPayFrequenciesAsync()
        {
            List<PS_PayFrequency_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
            return list;
        }
        //public async Task<List<EntityReference>> GetAllReferences(int id)
        //{
        //    List<EntityReference> entityReferences = new List<EntityReference>();

        //    entityReferences.AddRange(PositionsReferenceRepo.WithDetails(x => x.PositionTemplate).Where(x => x.JobTemplateId == id)
        //        .ToList()
        //        .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.PositionTemplate.Name, Code = x.PositionTemplate.Code, Type = "Position" }));

        //    return entityReferences;
        //}
    }
}
