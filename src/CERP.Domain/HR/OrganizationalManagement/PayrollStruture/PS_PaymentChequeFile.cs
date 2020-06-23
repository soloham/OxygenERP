using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;
using CERP.HR.EmployeeCentral.Employee;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace CERP.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PaymentChequeFile : AuditedAggregateTenantRoot<int>
    {
        public PS_PaymentChequeFile()
        {
        }

        [CustomAudited]
        public string Name { get; set; }
        [CustomAudited]
        public string NameLocalized { get; set; }

        public virtual ICollection<PS_PaymentChequeFileColumn> PaymentChequeFileColumns { get; set; }
    }
    public class PS_PaymentChequeFileColumn : AuditedEntity<int>, IMultiTenant
    {
        public int PaymentChequeFileId { get; set; }
        public int Column { get; set; }

        public bool IsEmployee { get; set; }
        public bool IsPayroll { get; set; }

        public Guid? TenantId { get; set; }
    }

}
