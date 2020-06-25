using CERP.HR.EmployeeCentral.Employee;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace CERP.Web.Pages.Shared.Components
{
    public enum AuditTrailModule
    {
        Employee,
        Payroll
    }
    [Widget(
        RefreshUrl = "Widgets/AuditTrail"
        )]
    public class AuditTrailWidgetViewComponent : AbpViewComponent
    {
        private readonly IAuditLogRepository auditLogsRepo;

        public AuditTrailWidgetViewComponent(IAuditLogRepository auditLogsRepo)
        {
            this.auditLogsRepo = auditLogsRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync(string url, string entityId)
        {
                //    url = ViewContext.HttpContext.Request.Path.Value;
            //var auditData = url == null? new List<DataAuditRowObject>() : await GetAuditsAsync(url, entityId);
            return View(new List<DataAuditRowObject>());
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
