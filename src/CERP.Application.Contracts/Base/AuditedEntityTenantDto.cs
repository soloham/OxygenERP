using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace CERP.Base
{
    public class AuditedEntityTenantDto<TKey> : AuditedEntityDto<TKey>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
    }
}
