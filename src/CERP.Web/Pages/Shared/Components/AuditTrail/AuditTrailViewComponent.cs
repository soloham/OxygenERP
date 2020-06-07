using CERP.HR.EmployeeCentral.Employee;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Entities;

namespace CERP.Web.Pages.Shared.Components
{
    public enum AuditTrailModule
    {
        Employee,
        Payroll
    }
    public class AuditTrailViewComponent : AbpViewComponent
    {
        private readonly IAuditLogRepository auditLogsRepo;

        public AuditTrailViewComponent(IAuditLogRepository auditLogsRepo)
        {
            this.auditLogsRepo = auditLogsRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync(AuditTrailModule auditTrailModule)
        {
            var auditData = await GetAuditsAsync(auditTrailModule);
            return View(auditData);
        }
        private async Task<List<DataAuditRowObject>> GetAuditsAsync(AuditTrailModule dataAuditModule)
        {
            List<DataAuditRowObject> result = new List<DataAuditRowObject>();
            
            switch (dataAuditModule)
            {
                case AuditTrailModule.Employee:
                    var employeeLogs = await auditLogsRepo.GetListAsync(url: "/HR/Employee");
                    for (int i = 0; i < employeeLogs.Count; i++)
                    {
                        AuditLog auditLog = employeeLogs[i];
                        var entityChanges = auditLog.EntityChanges.ToList();
                        for (int j = 0; j < entityChanges.Count; j++)
                        {
                            EntityChange entityChange = entityChanges[j];
                            result.Add(new DataAuditRowObject() { AuditLogId = auditLog.Id, EntityId = entityChange.EntityId, Id = GetReferenceId(entityChange.Id), ModificationDateTime = auditLog.ExecutionTime.ToShortDateString() + " " + auditLog.ExecutionTime.ToShortTimeString(), ModifiedBy = auditLog.UserName });
                        }
                    }
                    break;
                case AuditTrailModule.Payroll:
                    break;
            }

            return result;
        }

        public string GetReferenceId(Guid id) { return id.ToString().Substring(0, 4); }

    }

    public class DataAuditRowObject
    {
        public Guid? AuditLogId { get; set; }
        public string EntityId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string ModificationDateTime { get; set; }
        public string ModifiedBy { get; set; }
    }
}
