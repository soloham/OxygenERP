using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;
using CERP.HR.EmployeeCentral.Employee;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PaymentCashFile_Dto : AuditedEntityTenantDto<int>
    {
        public PS_PaymentCashFile_Dto()
        {
        }

        [CustomAudited]
        public string Name { get; set; }
        [CustomAudited]
        public string NameLocalized { get; set; }

        public virtual ICollection<PS_PaymentCashFileColumn_Dto> PaymentCashFileColumns { get; set; }
    }
    public class PS_PaymentCashFileColumn_Dto : AuditedEntity<int>, IMultiTenant
    {
        public int PaymentCashFileId { get; set; }
        public int Column { get; set; }

        public bool IsEmployee { get; set; }
        public bool IsPayroll { get; set; }

        public Guid? TenantId { get; set; }
    }

}
