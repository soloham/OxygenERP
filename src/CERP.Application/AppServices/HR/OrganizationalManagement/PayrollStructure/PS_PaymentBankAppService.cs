using CERP.ApplicationContracts.HR.OrganizationalManagement;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.OrganizationalManagement;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.OrganizationalManagement.PayrollStructure;
using CERP.HR.Timesheets;
using CERP.HR.Workshifts;
using Microsoft.EntityFrameworkCore;
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
    public class PS_PaymentBankAppService : CrudAppService<PS_PaymentBank, PS_PaymentBank_Dto, int, PagedAndSortedResultRequestDto, PS_PaymentBank_Dto, PS_PaymentBank_Dto>
    {
        public PS_PaymentBankAppService(IRepository<PS_PaymentBank, int> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<PS_PaymentBank, int> Repository { get; }

        public async Task<List<PS_PaymentBank_Dto>> GetAllPaymentBanksAsync()
        {
            try {
                List<PS_PaymentBank_Dto> list = (await Task.Run(() => Repository.Include(x => x.Country).Select(MapToGetListOutputDto))).ToList();
                return list;
            }
            catch(Exception ex)
            {
                return new List<PS_PaymentBank_Dto>();
            }
        }
        public async Task<PS_PaymentBank_Dto> GetPaymentBankAsync(int id)
        {
            try {
                PS_PaymentBank_Dto result = await Task.Run(() =>  MapToGetOutputDto(Repository.Include(x => x.Country).First(x => x.Id == id)));
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<PS_PaymentBank> GetPaymentBankRawAsync(int id)
        {
            try {
                PS_PaymentBank result = await Task.Run(() => Repository.Include(x => x.Country).First(x => x.Id == id));
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<EntityReference>> GetAllReferences(int id)
        {
            List<EntityReference> entityReferences = new List<EntityReference>();

            //entityReferences.AddRange(PositionsReferenceRepo.WithDetails(x => x.PositionTemplate).Where(x => x.JobTemplateId == id)
            //    .ToList()
            //    .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.PositionTemplate.Name, Code = x.PositionTemplate.Code, Type = "Position" }));

            return entityReferences;
        }
    }
}
