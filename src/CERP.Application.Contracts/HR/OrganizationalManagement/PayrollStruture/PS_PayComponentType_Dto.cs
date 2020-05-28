using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;
using CERP.HR.Employees;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.PayrollStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PayComponentType_Dto : AuditedEntityTenantDto<int>
    {
        public PS_PayComponentType_Dto()
        {
        }
        public double Amount { get; set; }
        public double PercentageValue { get; set; }

        public PS_PayComponentType_Dto PercentagePayComponentType { get; set; }
        public int PercentagePayComponentTypeId { get; set; }

    }
}
