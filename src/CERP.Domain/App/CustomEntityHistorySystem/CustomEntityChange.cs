using System;
using System.Collections.Generic;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;

namespace CERP.App.CustomEntityHistorySystem
{
    [DisableAuditing]
    public class CustomEntityChange : Entity<Guid>, IHasExtraProperties
    {   
        public CustomEntityChange()
        {

        }
        public CustomEntityChange(Guid guid)
        {
            this.Id = guid;
        }

        public virtual AuditLog AuditLog { get; set; }
        public Guid? AuditLogId { get; set; }

        public string TenantId { get; set; }

        public DateTime ChanegeTime { get; set; }
        public EntityChangeType ChangeType { get; set; }
        public string EntityTenantId { get; set; }
        public string EntityTypeFullName { get; set; }
        public string EntityId { get; set; }

        public virtual ICollection<CustomEntityPropertyChange> PropertyChanges { get; set; }

        public Dictionary<string, object> ExtraProperties { get; set; }
    }
}
