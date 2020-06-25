using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.AuditLogging;

namespace CERP.AppServices.App.AuditTrailService
{
    public enum AuditTrailModule
    {
        Employee,
        Payroll
    }
    public class AuditTrailAppService : ApplicationService
    {
        public AuditTrailAppService(IAuditLogRepository auditLogsRepository)
        {
            AuditLogsRepository = auditLogsRepository;
        }

        public IAuditLogRepository AuditLogsRepository { get; set; }

        public async Task<List<DataAuditRowObject>> GetEntityAuditsAsync(string url, string entityId)
        {
            List<DataAuditRowObject> result = new List<DataAuditRowObject>();

            var logs = await Task.Run(() => AuditLogsRepository.Include(x => x.EntityChanges).ThenInclude(x => x.PropertyChanges).Where(x => x.Url == url && x.EntityChanges != null && x.EntityChanges.Any(x => x.EntityId == entityId)).ToList());
            for (int i = 0; i < logs.Count; i++)
            {
                AuditLog auditLog = logs[i];
                var entityChanges = auditLog.EntityChanges.Where(x => x.EntityId == entityId).ToList();
                for (int j = 0; j < entityChanges.Count; j++)
                {
                    EntityChange entityChange = entityChanges[j];
                    result.Add(new DataAuditRowObject()
                    {
                        AuditLogId = auditLog.Id,
                        EntityId = entityChange.EntityId,
                        Id = entityChange.Id.ToString(),
                        ModificationDateTime = auditLog.ExecutionTime.ToShortDateString() + " " + auditLog.ExecutionTime.ToShortTimeString(),
                        ModifiedBy = auditLog.UserName,
                        PropertyChanges = entityChange.PropertyChanges.ToList(),
                        Type = entityChange.ChangeType.ToString()
                    });
                }
            }

            return result;
        }
        public async Task<List<DataAuditRowObject>> GetModuleAuditsAsync(AuditTrailModule dataAuditModule)
        {
            List<DataAuditRowObject> result = new List<DataAuditRowObject>();

            switch (dataAuditModule)
            {
                case AuditTrailModule.Employee:
                    var employeeLogs = await AuditLogsRepository.GetListAsync(url: "/HR/Employee");
                    for (int i = 0; i < employeeLogs.Count; i++)
                    {
                        AuditLog auditLog = employeeLogs[i];
                        var entityChanges = auditLog.EntityChanges.ToList();
                        for (int j = 0; j < entityChanges.Count; j++)
                        {
                            EntityChange entityChange = entityChanges[j];
                            result.Add(new DataAuditRowObject() { 
                                AuditLogId = auditLog.Id, 
                                EntityId = entityChange.EntityId, 
                                Id = entityChange.Id.ToString(), 
                                ModificationDateTime = auditLog.ExecutionTime.ToShortDateString() + " " + auditLog.ExecutionTime.ToShortTimeString(), 
                                ModifiedBy = auditLog.UserName,
                                PropertyChanges = entityChange.PropertyChanges.ToList(),
                                Type = entityChange.ChangeType.ToString()
                            });
                        }
                    }
                    break;
                case AuditTrailModule.Payroll:
                    break;
            }

            return result;
        }
    }

    public class DataAuditRowObject
    {
        public Guid? AuditLogId { get; set; }
        public string EntityId { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string ModificationDateTime { get; set; }
        public string ModifiedBy { get; set; }
        public List<EntityPropertyChange> PropertyChanges { get; set; }
    }
}
