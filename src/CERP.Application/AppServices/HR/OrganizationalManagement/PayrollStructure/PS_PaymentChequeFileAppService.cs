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
    public class PS_PaymentChequeFileAppService : CrudAppService<PS_PaymentChequeFile, PS_PaymentChequeFile_Dto, int, PagedAndSortedResultRequestDto, PS_PaymentChequeFile_Dto, PS_PaymentChequeFile_Dto>
    {
        public PS_PaymentChequeFileAppService(IRepository<PS_PaymentChequeFile, int> repository, IRepository<PS_PaymentChequeFileColumn, int> columnsRepository) : base(repository)
        {
            Repository = repository;
            ColumnsRepository = columnsRepository;
        }

        public IRepository<PS_PaymentChequeFile, int> Repository { get; }
        public IRepository<PS_PaymentChequeFileColumn, int> ColumnsRepository { get; }

        public async Task<List<PS_PaymentChequeFile_Dto>> GetAllPaymentChequesAsync()
        {
            try {
                List<PS_PaymentChequeFile_Dto> list = (await Task.Run(() => Repository.Include(x => x.PaymentChequeFileColumns).Select(MapToGetListOutputDto))).ToList();
                return list;
            }
            catch(Exception ex)
            {
                return new List<PS_PaymentChequeFile_Dto>();
            }
        }
        public async Task<PS_PaymentChequeFile_Dto> GetPaymentChequeAsync(int id)
        {
            try {
                PS_PaymentChequeFile_Dto result = await Task.Run(() =>  MapToGetOutputDto(Repository.Include(x => x.PaymentChequeFileColumns).First(x => x.Id == id)));
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<PS_PaymentChequeFile> GetPaymentChequeRawAsync(int id)
        {
            try {
                PS_PaymentChequeFile result = await Task.Run(() => Repository.Include(x => x.PaymentChequeFileColumns).First(x => x.Id == id));
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
