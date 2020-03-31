using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace CERP.Base
{
    public class AuditedAggregateTenantRoot<TKey> : AuditedAggregateRoot<TKey>, IMultiTenant
    {
        //public ICurrentTenant CurrentTenant { get; set; }
        //public AuditedAggregateTenantRoot(ICurrentTenant currentTenant)
        //{
        //    CurrentTenant = currentTenant;
        //    TenantId = CurrentTenant.Id;
        //}
        public Guid? TenantId { get; set; }
        //public Guid? CompanyId { get; set; }
    }
}
