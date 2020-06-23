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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PayrollPeriodAppService : CrudAppService<PS_PayrollPeriod, PS_PayrollPeriod_Dto, int, PagedAndSortedResultRequestDto, PS_PayrollPeriod_Dto, PS_PayrollPeriod_Dto>
    {
        public PS_PayrollPeriodAppService(IRepository<PS_PayrollPeriod, int> repository, IRepository<PS_PayPeriod, int> payPeriodsRepo, IAuditLogRepository auditLogsRepo, IAuditingHelper auditingHelper, IAuditingStore auditingStore) : base(repository)
        {
            Repository = repository;
            PayPeriodsRepo = payPeriodsRepo;
            AuditLogsRepo = auditLogsRepo;
            AuditingHelper = auditingHelper;
            AuditingStore = auditingStore;
        }

        public IRepository<PS_PayrollPeriod, int> Repository { get; }
        public IAuditLogRepository AuditLogsRepo { get; set; }
        public IAuditingHelper AuditingHelper { get; set; }
        public IAuditingStore AuditingStore { get; set; }
        public IRepository<PS_PayPeriod, int> PayPeriodsRepo { get; }

        public async Task<List<PS_PayrollPeriod_Dto>> GetAllBySearchAsync(PS_PayrollPeriod_Search_Dto data)
        {
            try
            {
                List<PS_PayrollPeriod_Dto> result = await Task.Run(() => Repository
                .Include(x => x.PayPeriods)
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

        public async Task<PS_PayrollPeriod_Dto> GetPayrollPeriodAsync(int id, string asOf = null)
        {
            return MapToGetOutputDto(await GetPayrollPeriodRawAsync(id, asOf));
        }
        public async Task<PS_PayrollPeriod> GetPayrollPeriodRawAsync(int id, string asOf = null)
        {
            try
            {
                PS_PayrollPeriod result = ObjectMapper.Map<PS_PayrollPeriod, PS_PayrollPeriod>(await Task.Run(() => Repository
               .Include(x => x.PayPeriods)
               .First(x => x.Id == id)));

                if (asOf != null)
                {
                    DateTime asOfDateTime = DateTime.Parse(asOf);
                    List<EntityChange> logs = AuditLogsRepo.WithDetails().Where(x => x.EntityChanges != null && x.EntityChanges.Any(x => x.EntityId == id.ToString() && x.EntityTenantId == CurrentTenant.Id && x.ChangeTime >= asOfDateTime))
                        .SelectMany(x => x.EntityChanges.Where(y => y.EntityId == id.ToString() && y.EntityTenantId == CurrentTenant.Id)).ToList();

                    logs.Reverse();
                    for (int i = 0; i < logs.Count; i++)
                    {
                        EntityChange log = logs[i];
                        //log.ChangeType
                        for (int y = 0; y < log.PropertyChanges.Count; y++)
                        {
                            EntityPropertyChange propertyChange = log.PropertyChanges.ElementAt(y);
                            PropertyInfo prop = typeof(PS_PaySubGroup).GetProperty(propertyChange.PropertyName);
                            if (prop != null)
                            {
                                try
                                {
                                    prop.SetValue(result, propertyChange.OriginalValue);
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<PS_PayrollPeriod_Dto>> GetAllPayrollPeriodsAsync()
        {
            List<PS_PayrollPeriod_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
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
