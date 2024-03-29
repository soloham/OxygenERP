﻿using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;
using CERP.HR.EmployeeCentral.Employee;
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
        public string Code { get; set; }

        [CustomAudited]
        public string Name { get; set; }
        [CustomAudited]
        public string NameLocalized { get; set; }

        [CustomAudited]
        public string Description { get; set; }

        [CustomAudited]
        public double Amount { get; set; }
        [CustomAudited]
        public double Percentage { get; set; }

        [CustomAudited]
        public PS_PayComponentTypeValueType ValueType { get; set; }

        public PS_PayComponentType? ValueComponentType { get; set; }
        [CustomAudited]
        public int? ValueComponentTypeId { get; set; }

    }
}
