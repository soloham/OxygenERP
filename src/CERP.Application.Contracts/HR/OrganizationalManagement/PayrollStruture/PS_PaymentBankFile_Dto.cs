using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;
using CERP.HR.EmployeeCentral.Employee;
using CERP.HR.OrganizationalManagement.PayrollStruture;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PaymentBankFile_Dto : AuditedEntityTenantDto<int>
    {
        
        public PS_PaymentBankFile_Dto()
        {
        }

        public List<PS_PaymentBankFileBank_Dto> PaymentBanks { get; set; }
        public string Name { get; set; }
        public string NameLocalized { get; set; }

        public FileColumns BankFileColumns { get; set; }
    }
        public class PS_PaymentBankFileBank_Dto : AuditedEntity<int>, IMultiTenant
    {
        public int PaymentBankFileId { get; set; }
        public PS_PaymentBank_Dto Bank { get; set; }
        public int BankId { get; set; }


        public Guid? TenantId { get; set; }
    }

}
