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
    public class PS_PaymentBankFile : AuditedAggregateTenantRoot<int>
    {
        public PS_PaymentBankFile()
        {
        }

        public virtual ICollection<PS_PaymentBankFileBank> PaymentBanks { get; set; }

        [CustomAudited]
        public string Name { get; set; }
        [CustomAudited]
        public string NameLocalized { get; set; }
    }
    public class PS_PaymentBankFileBank : AuditedEntity<int>, IMultiTenant
    {
        public int PaymentBankFileId { get; set; }
        public PS_PaymentBank Bank { get; set; }
        public int BankId { get; set; }


        public Guid? TenantId { get; set; }
    }

}
