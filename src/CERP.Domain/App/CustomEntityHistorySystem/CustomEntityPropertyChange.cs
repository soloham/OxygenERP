using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.App.CustomEntityHistorySystem
{
    [DisableAuditing]
    public class CustomEntityPropertyChange : Entity<Guid>, IHasExtraProperties
    {
        public CustomEntityPropertyChange()
        {

        }
        public CustomEntityPropertyChange(Guid guid)
        {
            this.Id = guid;
        }
        public Guid? TenantId { get; set; }

        public virtual CustomEntityChange EntityChange { get; set; }
        public Guid EntityChangeId { get; set; }

        public string PropertyTypeFullName { get; set; }

        public string NewValue { get; set; }
        public string OriginalValue { get; set; }
        public string PropertyName { get; set; }

        public Dictionary<string, object> ExtraProperties { get; set; }
    }
}
