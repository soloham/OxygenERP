using CERP.App.Helpers;
using CERP.ApplicationContracts.HR.OrganizationalManagement;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.OrganizationalManagement;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.OrganizationalManagement.PayrollStructure;
using CERP.HR.OrganizationalManagement.PayrollStruture;
using CERP.HR.Setup.OrganizationalManagement.PayrollStructure;
using CERP.HR.Timesheets;
using CERP.HR.Workshifts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
    public class PS_PaymentBankFileAppService : CrudAppService<PS_PaymentBankFile, PS_PaymentBankFile_Dto, int, PagedAndSortedResultRequestDto, PS_PaymentBankFile_Dto, PS_PaymentBankFile_Dto>
    {
        public PS_PaymentBankFileAppService(IRepository<PS_PaymentBankFile, int> repository, IRepository<PS_PaymentBankFileBank, int> banksRepo) : base(repository)
        {
            Repository = repository;
            BanksRepo = banksRepo;
        }

        public IRepository<PS_PaymentBankFile, int> Repository { get; }
        public IRepository<PS_PaymentBankFileBank, int> BanksRepo { get; }

        public async Task<List<PS_PaymentBankFile_Dto>> GetAllBySearchAsync(PS_PaymentBankFile_Dto data)
        {
            try
            {
                List<PS_PaymentBankFile_Dto> result = await Task.Run(() => Repository
                .Include(x => x.PaymentBanks)
                .Select(MapToGetListOutputDto).ToList());

                for (int i = 0; i < result.Count; i++)
                {
                    if (!CustomHelpers.CheckIfMatches(result[i], data))
                    {
                        result.Remove(result[i]);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<PS_PaymentBankFile_Dto>> GetAllPaymentBankFilesAsync()
        {
            try {
                List<PS_PaymentBankFile_Dto> list = (await Task.Run(() => Repository.Include(x => x.PaymentBanks).Select(MapToGetListOutputDto))).ToList();
                return list;
            }
            catch(Exception ex)
            {
                return new List<PS_PaymentBankFile_Dto>();
            }
        }
        public async Task<PS_PaymentBankFile_Dto> GetPaymentBankFileAsync(int id)
        {
            try {
                PS_PaymentBankFile_Dto result = await Task.Run(() =>  MapToGetOutputDto(Repository.Include(x => x.PaymentBanks).First(x => x.Id == id)));
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<PS_PaymentBankFile> GetPaymentBankFileRawAsync(int id)
        {
            try {
                PS_PaymentBankFile result = await Task.Run(() => Repository.Include(x => x.PaymentBanks).First(x => x.Id == id));
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<FileColumns> GetAllFileColumns()
        {
            try {
                FileColumns fileColumns = new FileColumns();
                
                return fileColumns;
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
