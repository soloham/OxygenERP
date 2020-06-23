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
    public class PS_PaymentCashFileAppService : CrudAppService<PS_PaymentCashFile, PS_PaymentCashFile_Dto, int, PagedAndSortedResultRequestDto, PS_PaymentCashFile_Dto, PS_PaymentCashFile_Dto>
    {
        public PS_PaymentCashFileAppService(IRepository<PS_PaymentCashFile, int> repository, IRepository<PS_PaymentCashFileColumn, int> columnsRepository) : base(repository)
        {
            Repository = repository;
            ColumnsRepository = columnsRepository;
        }

        public IRepository<PS_PaymentCashFile, int> Repository { get; }
        public IRepository<PS_PaymentCashFileColumn, int> ColumnsRepository { get; }

        public async Task<List<PS_PaymentCashFile_Dto>> GetAllPaymentCashsAsync()
        {
            try {
                List<PS_PaymentCashFile_Dto> list = (await Task.Run(() => Repository.Include(x => x.PaymentCashFileColumns).Select(MapToGetListOutputDto))).ToList();
                return list;
            }
            catch(Exception ex)
            {
                return new List<PS_PaymentCashFile_Dto>();
            }
        }
        public async Task<PS_PaymentCashFile_Dto> GetPaymentCashAsync(int id)
        {
            try {
                PS_PaymentCashFile_Dto result = await Task.Run(() =>  MapToGetOutputDto(Repository.Include(x => x.PaymentCashFileColumns).First(x => x.Id == id)));
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<PS_PaymentCashFile> GetPaymentCashRawAsync(int id)
        {
            try {
                PS_PaymentCashFile result = await Task.Run(() => Repository.Include(x => x.PaymentCashFileColumns).First(x => x.Id == id));
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
