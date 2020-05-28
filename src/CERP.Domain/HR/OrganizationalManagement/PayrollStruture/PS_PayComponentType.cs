using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;
using CERP.HR.Employees;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.PayrollStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PayComponentType : AuditedAggregateTenantRoot<int>
    {
        public PS_PayComponentType()
        {
        }

        [CustomAudited]
        public double Amount { get; set; }
        [CustomAudited]
        public double PercentageValue { get; set; }

        public PS_PayComponentType PercentagePayComponentType { get; set; }
        [CustomAudited]
        public int PercentagePayComponentTypeId { get; set; }

    }
}
