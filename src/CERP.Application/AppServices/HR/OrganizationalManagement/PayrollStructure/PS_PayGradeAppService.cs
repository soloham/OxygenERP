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
    public class PS_PayGradeAppService : CrudAppService<PS_PayGrade, PS_PayGrade_Dto, int, PagedAndSortedResultRequestDto, PS_PayGrade_Dto, PS_PayGrade_Dto>
    {
        public PS_PayGradeAppService(IRepository<PS_PayGrade, int> repository, IRepository<PS_PayGradeComponent> payComponentsRepository) : base(repository)
        {
            Repository = repository;
            PayComponentsRepository = payComponentsRepository;
        }

        public IRepository<PS_PayGrade, int> Repository { get; }
        public IRepository<PS_PayGradeComponent> PayComponentsRepository { get; }


        public async Task<List<PS_PayGrade_Dto>> GetAllPayGradesAsync()
        {
            try
            {
                List<PS_PayGrade_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
                return list;
            }
            catch (Exception ex)
            {
                return new List<PS_PayGrade_Dto>();
            }
        }
        public async Task<PS_PayGrade_Dto> GetPayGradeAsync(int id)
        {
            try
            {
                PS_PayGrade_Dto grade1 = MapToGetOutputDto(Repository.WithDetails(x => x.PayRange, x => x.PayGradeComponents).First(x => x.Id == id));
                PS_PayGrade_Dto grade = MapToGetOutputDto(await Repository.GetAsync(id, true));
                return grade;
            }
            catch (Exception ex)
            {
                return new PS_PayGrade_Dto();
            }
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
