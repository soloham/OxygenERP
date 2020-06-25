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
using CERP;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace CERP.AppServices.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PaySubGroupAppService : CrudAppService<PS_PaySubGroup, PS_PaySubGroup_Dto, int, PagedAndSortedResultRequestDto, PS_PaySubGroup_Dto, PS_PaySubGroup_Dto>
    {
        public PS_PaySubGroupAppService(IRepository<PS_PaySubGroup, int> repository, IRepository<PS_PaySubGroupBank> paySubGroupBanksRepo, IRepository<PS_PayPeriod> payPeriodsRepo, IAuditingManager auditingManager, IAuditLogRepository auditLogsRepo) : base(repository)
        {
            Repository = repository;
            PaySubGroupBanksRepo = paySubGroupBanksRepo;
            PayPeriodsRepo = payPeriodsRepo;
            AuditingManager = auditingManager;
            AuditLogsRepo = auditLogsRepo;
        }

        public IAuditingManager AuditingManager { get; set; }
        public IAuditLogRepository AuditLogsRepo { get; set; }
        public IAuditingHelper AuditingHelper { get; set; }
        public IAuditingStore AuditingStore { get; set; }

        public IRepository<PS_PaySubGroup, int> Repository { get; }
        public IRepository<PS_PaySubGroupBank> PaySubGroupBanksRepo { get; set; }
        public IRepository<PS_PayPeriod> PayPeriodsRepo { get; set; }

        public async Task<List<PS_PaySubGroup_Dto>> GetAllPaySubGroupsAsync()
        {
            try {
                List<PS_PaySubGroup_Dto> list = (await Task.Run(() => Repository
                .Include(x => x.PayGroup)
                .Include(x => x.LegalEntity)
                .Include(x => x.Frequency)
                .Include(x => x.PayrollPeriod)
                .Include(x => x.AllowedBanks)
                .Select(MapToGetListOutputDto))).ToList();
                return list;
            }
            catch(Exception ex)
            {
                return new List<PS_PaySubGroup_Dto>();
            }
        }

        public async Task<List<PS_PaySubGroup_Dto>> GetAllBySearchAsync(PS_PaySubGroup_Search_Dto data)
        {
            try
            {
                List<PS_PaySubGroup_Dto> result = await Task.Run(() => Repository
                .Include(x => x.PayGroup)
                .Include(x => x.LegalEntity)
                .Include(x => x.Frequency)
                .Include(x => x.PayrollPeriod)
                    .ThenInclude(x => x.PayPeriods)
                .Include(x => x.AllowedBanks)
                .Select(MapToGetListOutputDto).ToList());

                for (int i = 0; i < result.Count; i++)
                {
                    if(!CustomHelpers.CheckIfMatches(result[i], data))
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

        public async Task<PS_PaySubGroup_Dto> GetPaySubGroupAsync(int id, string asOf = null)
        {
            return MapToGetOutputDto(await GetPaySubGroupRawAsync(id, asOf));
        }
        public async Task<PS_PaySubGroup> GetPaySubGroupRawAsync(int id, string asOf = null)
        {
            try {
                PS_PaySubGroup result = ObjectMapper.Map< PS_PaySubGroup, PS_PaySubGroup>(await Task.Run(() => Repository
                .Include(x => x.PayGroup)
                .Include(x => x.LegalEntity)
                .Include(x => x.Frequency)
                .Include(x => x.PayrollPeriod)
                 .ThenInclude(x => x.PayPeriods)
                .Include(x => x.AllowedBanks)
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
